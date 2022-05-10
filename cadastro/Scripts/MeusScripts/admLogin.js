$(document).ready(function () {
    
    path = $(location).attr('pathname');

    if (path == '/' || path == '/Home/Index') {

        login();

    }
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

        $("#aviso").html("<h5 class='content - group'>Erro ao fazer login.</h5>");
                
    }
    else 
    {
        window.location.href = "/Principal/Principal";
    }
    
}

function erroLogin(Json) {

    alert("Não foi possivel Realizar Login, verifique Usuário e Senha !!")
}