$(document).ready(function () {
    
    //path = $(location).attr('pathname');

    //if (path == '/') {

        login();
       
    //}
});



function login() {

    $("#btnLogin").click(function () {

        let emailLogin = $("#txtEmailLogin").val();
        let senhaLogin = $("#txtSenhaLogin").val();


        if (emailLogin != "" && senhaLogin != "") {

            let usuario = {

                email: emailLogin,
                senha: senhaLogin

            }

            requisicaoAssincrona("POST", "../Home/ValidarLogin", usuario, sucessoLogin, erroLogin);

        } else {

            alert("Campos Obrigatórios!");
        }

    })


}

function sucessoLogin(Json) {
    
    var objRetorno = Json.retorno;
    if (objRetorno == null) {


        $("#aviso").html("<h5 class='content - group'>Usuario não Cadastrado</h5>");


    } else {

        window.location.href = "/Home/Principal";
    }

}

function erroLogin(Json) {

    alert("Não foi possivel Realizar Login, verifique Usuário e Senha !!")
}