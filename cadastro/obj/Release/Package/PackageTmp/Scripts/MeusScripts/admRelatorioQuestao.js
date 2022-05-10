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
    let objRetorno = Json.retorno;
    let lista = [];
    let contador = objRetorno.length;
    $("#contador").text("Existem "+contador+" questões disponiveis.");

    $.each(objRetorno, function (i, obj) {
        var conteudo = "<div class='panel panel-flat'>                                                        " +
            "<div class='panel-heading'>                                                       " +
            "<h5 class='panel-title'> Questão: </h5>                                       " +
            "<div class='heading-elements'>                                                " +
            "<ul class='icons-list'>                                                   " +
            "<li><a data-action='collapse'></a></li>                               " +
            "<li><a data-action='reload'></a></li>			                	  " +
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
            "    				</div>"

        lista.push(conteudo);
    });

    $("#divQuestoes").html(lista);

}
function erroRelatorioQuestao(Json) {

}