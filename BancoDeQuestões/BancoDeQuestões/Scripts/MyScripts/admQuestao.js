$(document).ready(function () {

    path = $(location).attr('pathname');

    if (path == '/Questoes/InserirQuestao') {

        inserirQuestao();

    }

    if (path == '/Questoes/VisualizarQuestao') {

        selecionarQuestao();
       
    }


});



function inserirQuestao() {

    $("#btnSalvarQuestao").click(function () {

        let perguntaQuestao = $("#txtPergunta").val();
        let altCorreta = $("#txtCorreta").val();
        let alternativaBquestao = $("#txtAltB").val();
        let alternativaCquestao = $("#txtAltC").val();
        let alternativaDquestao = $("#txtAltD").val();
        let alternativaEquestao = $("#txtAltE").val();

        //validar campos vazios
       

            let questao = {

                pergunta: perguntaQuestao,
                alternativaCorreta: altCorreta,
                alternativaB: alternativaBquestao,
                alternativaC: alternativaCquestao,
                alternativaD: alternativaDquestao,
                alternativaE: alternativaEquestao,
                flag:0
            }
        requisicaoAssincrona("POST", "../Questoes/InserirQuestao", questao, sucessoQuestao, erroQuestao);

    })


}

function sucessoQuestao(Json) {

   // var objRetorno = Json.retorno;
    limparCampos();
    sucessoNotificacao("Tudo Certo, sua questão foi inserida.");
   


}

function erroQuestao(Json) {

    erroNotificacao("Não foi possivel cadastrar a questão!!")
}



function selecionarQuestao() {
   
    requisicaoAssincrona("POST", "../Questoes/SelecionarQuestao", "", sucessoVerQuestao, erroVerQuestao);

}

function sucessoVerQuestao(Json) {

    let objRetorno = JSON.parse(Json.retorno);
    let card = [];
    
    let contador = objRetorno.length;
    $("#qtdQuestoes").text(" " + contador);

    $("#divQuestao").html("");
    $.each(objRetorno, function (i, obj) {
        var _id = JSON.stringify(obj.Id);
        
        var conteudo =
            "<div class='card'>" +
            "	<div class='card-header header-elements-inline'>" +
            "        <h6 class='card-title'>QUESTÃO - 0"+([i+1])+"</h6>" +
            "		<div class='header-elements'>" +
            "			<div class='list-icons'>" +
            "        		<a class='list-icons-item' data-action='collapse'></a>" +
            "        		<a class='list-icons-item' data-action='reload'></a>" +
            "        		<a class='list-icons-item' data-action='remove'></a>" +
            "        	</div>" +
            "    	</div>" +
            "	</div>" +
            "    <div class='card-body'>" +
            "    	<form >" +
            "			<div class='form-group'>" +
            "				<label><strong>" + (obj.pergunta).toUpperCase() + "</strong></label>" +
            "                   <p class='mb - 2 font - size - base'></p > " +

            "                   <p class='mb - 2 font - size - base'> <span style='color: green;'><strong>(A)" + obj.alternativaCorreta + "</strong></span></p > " +
            "                   <p class='mb - 2 font - size - base'> (B) " + obj.alternativaB +".</p>" +
            "                   <p class='mb - 2 font - size - base'> (C) " + obj.alternativaC +".</p>" +
            "                   <p class='mb - 2 font - size - base'> (D) " + obj.alternativaD +".</p>" +
            "                   <p class='mb - 2 font - size - base'> (E) " + obj.alternativaE +".</p>" +
            "			</div>" +
            "<div class='text-right'>" +
            "	<input id='btnDeletar' indice=" + _id +" type='button' class='btn bg-teal-400' value = 'Deletar'/>" +
            "</div>" +
            "			</div>" +
            "		</form>" +
            "	</div>" +
            "</div>";


        card.push(conteudo)
    });
    
    $("#divQuestao").html(card);
    deletarQuestão();
}

function erroVerQuestao(Json) {

    alert("Não foi possivel obter a questão!!")
}

function limparCampos() {

    $("#txtPergunta").val("");
    $("#txtCorreta").val("");
    $("#txtAltB").val("");
    $("#txtAltC").val("");
    $("#txtAltD").val("");
    $("#txtAltE").val("");
    
}

function deletarQuestão() {

    $("#btnDeletar").click(function () {


        let _id = $("#btnDeletar").attr('indice');
        
           let dados = {

               indice: _id
              
            }
        
            requisicaoAssincrona("POST", "../Questoes/DeletarQuestao", dados, sucessoDelete, erroDelete);
       

    })

}
function sucessoDelete(Json) {
    var objRetorno = Json.retorno;
    debugger
    if (objRetorno == "ok") {
        selecionarQuestao();
        sucessoNotificacao("Questão removida com Sucesso");
    } else {
        erroNotificacao(objRetorno);
    }
}
function erroDelete(Json) {
    erroNotificacao("Erro na funçaoDeletar");
}
