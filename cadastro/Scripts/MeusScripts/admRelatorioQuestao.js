$(document).ready(function () {
    path = $(location).attr('pathname');

    if (path == '/Questao/RelatorioQuestoes') {
        relatorioQuestao();        
    }
});

function relatorioQuestao() {
    requisicaoAssincrona("POST", "../Questao/RelatorioQuestao", "", sucessoRelatorioQuestao, erroRelatorioQuestao);
}

function sucessoRelatorioQuestao(Json) {
    let objRetorno = JSON.parse(Json.retorno);
    
    let lista = [];
    let contador = objRetorno.length;
    $("#contador").text("Existem "+contador+" questões disponiveis.");

    $.each(objRetorno, function (i, obj) {
       // let objId = objRetorno[0].Id.toString(); 
       // let objId = id.getAttribute(Id);
        var conteudo = "<div class='panel panel-flat'>                                                        " +
            "<div class='panel-heading'>                                                       " +
            "<h5 class='panel-title'> Questão: </h5>                                       " +
            "<div class='heading-elements'>                                                " +
            "<ul class='icons-list'>                                                   " +
            //"<li><a data-action='collapse'></a></li>                               " +
            //"<li><a data-action=''></a></li>			                	  " +
            "</ul>                                                                     " +
            "</div>                                                                        " +
            "</div>                                                                            " +
            "<div class='panel-body'>                                                          " +
            "            				<p class='content-group'> <strong>" + objRetorno[0].pergunta + "</strong></p> " +
            "                                                                                                         " +
            "	                		<div class='row'>                                                             " +
            "		                    <div class='col-md-12'>		                                                  " +
            "        <p class='content-group'> <span style='color:green;'><strong>(A)" + objRetorno[0].alternativaCorreta + "</strong></p>       " +
            "        <p class='content-group'> (B)" + objRetorno[0].alternativaB + "</p>       " +
            "        <p class='content-group'> (C)" + objRetorno[0].alternativaC + "</p>       " +
            "        <p class='content-group'> (D)" + objRetorno[0].alternativaD + "</p>       " +
            "        <p class='content-group'> (E)" + objRetorno[0].alternativaE + "</p>       " +
            "								</div>		" +
            "							</div>" +
            "        				</div>" +
            "<div class='text-right'>                                                                                                                " +
            " <input type='button' class='btn btn-primary' value='Editar' id='btnEditarQuestao' indiceEditar= " + objRetorno[0].Id + " > " +
            " <input type='button' class='btn btn-danger' value='Deletar' id='btnDeletarQuestao' indice= " + objRetorno[0].Id + " > " +           
            "                </div>                                                                                                                  "+
            "    				</div>"

        lista.push(conteudo);

    });

    $("#divQuestoes").html(lista);
    deletarQuestao();
    editarQuestao();
}
function erroRelatorioQuestao(Json) {

}
function deletarQuestao() {
    $("#btnDeletarQuestao").click(function () {
        let idQuestao = $("#btnDeletarQuestao").attr("indice");
  
        {
            let id = {

                _id:idQuestao               

            }
           
            requisicaoAssincrona("POST", "../Cadastro/DeletarQuestao", id, sucessoDeletar, erroDeletar);
        }
    });

}
function sucessoDeletar(Json) {
    relatorioQuestao();
    sucessoNotificacao("Deletado com sucesso.");
}
function erroDeletar(Json) {
    erroNotificacao("Erro ao deletar.");
}
function editarQuestao() {

    $("#btnEditarQuestao").click(function () {

        $("#btnEditarQuestao").attr("disabled", true);
        let perguntaQuestao = $("#txtQuestao").val();
        let alternativaCorretaQuestao = $("#txtCorreta").val();
        let alternativaBQuestao = $("#txtB").val();
        let alternativaCQuestao = $("#txtC").val();
        let alternativaDQuestao = $("#txtD").val();
        let alternativaEQuestao = $("#txtE").val();

        {
            let questao = {

                pergunta: perguntaQuestao,
                alternativaCorreta: alternativaCorretaQuestao,
                alternativaB: alternativaBQuestao,
                alternativaC: alternativaCQuestao,
                alternativaD: alternativaDQuestao,
                alternativaE: alternativaEQuestao,
                flag: 0
            }

            requisicaoAssincrona("POST", "../Cadastro/InserirQuestao", questao, sucessoEditar, erroEditar);
        }
    })
}
function sucessoEditar(Json) {
    relatorioQuestao();
    sucessoNotificacao("Editado com sucesso.");
}
function erroEditar(Json) {
    erroNotificacao("Erro ao Editar.");
}