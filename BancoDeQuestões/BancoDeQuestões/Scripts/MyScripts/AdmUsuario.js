$(document).ready(function () {
  
    path = $(location).attr('pathname');

    if (path == '/Home/CadastrarUsuario') {

        cadastroUsuario();
       
    }
});



function cadastroUsuario() {
    debugger
    $("#btnSalvar").click(function () {


        let nomeCadastro = $("#txtNomeCompleto").val();
        let emailCadastro = $("#txtEmail").val();
        let senhaCadastro = $("#txtSenha").val();
        let RepetirSenhaCadastro = $("#txtRepetirSenha").val();
        let enderecoCadastro = $("#txtEndereco").val();
        let idadeCadastro = $("#txtIdade").val();

        if (senhaCadastro == RepetirSenhaCadastro) {

            let usuario = {

                nome: nomeCadastro,
                email: emailCadastro,
                endereco: enderecoCadastro,
                senha: senhaCadastro,
                idade: idadeCadastro
            }

            requisicaoAssincrona("POST", "../Home/CadastroUsuario", usuario, sucessoCadastro, erroCadastro);
        } else {

            erroNotificacao("As Senhas não são iguais!!!!");
        }

    })



}



function sucessoCadastro(Json) {

    let resposta = Json.retorno;
    //alert(resposta);
    sucessoNotificacao("Usuário cadastrado com sucesso!!");
    limparCampos();
    window.location.href = "/Home/Index";


}

function erroCadastro(Json) {

    alert("Não foi possivel realizar o cadastro!");
}

function limparCampos() {

    $("#txtNomeCompleto").val("");
    $("#txtEmail").val("");
    $("#txtSenha").val("");
    $("#txtRepetirSenha").val("");
    $("#txtEndereco").val("");
    $("#txtIdade").val("");
}
























