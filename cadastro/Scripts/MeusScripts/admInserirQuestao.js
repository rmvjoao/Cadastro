$(document).ready(function () {

    path = $(location).attr('pathname');

    if (path == '/Cadastro/CadastroQuestao') {
        
        inserirQuestao();
        VisualizarQuestoes();
                
    }
});
function inserirQuestao() {

    $("#btnSalvarQuestao").click(function () {

        $("#btnSalvarQuestao").attr("disabled", true);
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
                flag:0
            }

            requisicaoAssincrona("POST", "../Cadastro/InserirQuestao", questao, sucessoCadastro, erroCadastro);
        }
    })
}
function sucessoCadastro(Json) {

    let resposta = Json.retorno;
    sucessoNotificacao("Questão inserida com sucesso.");

    limparCampos();
    $("#btnSalvarQuestao").attr("disabled", false);
}
function erroCadastro(Json) {

    erroNotificacao("Não foi possivel criar esta questão.");
}
function limparCampos() {

    $("#txtQuestao").val("");
    $("#txtCorreta").val("");
    $("#txtB").val("");
    $("#txtC").val("");
    $("#txtD").val("");
    $("#txtE").val("");

}