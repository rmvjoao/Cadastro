

function requisicaoAssincrona(tipoRequisicao, caminhoMetodo, parametroJson, funcaoJsSucesso, funcaoJsErro) {
    $.ajax({
        type: tipoRequisicao,
        url: caminhoMetodo,
        async: true,
        data: JSON.stringify(parametroJson),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (Json) {
            funcaoJsSucesso(Json);
        },
        error: function (Json) {
            funcaoJsErro(Json);
        }
    });
}

function erroNotificacao(texto) {
    new PNotify({
        title: 'Erro..',
        text: texto,
        addclass: 'alert alert-styled-left alert-arrow-left',
        type: 'error'
    });
}

function sucessoNotificacao(texto) {
    new PNotify({
        title: 'Sucesso..',
        text: texto,
        addclass: 'alert alert-styled-left alert-arrow-left',
        type: 'success'
    });
}