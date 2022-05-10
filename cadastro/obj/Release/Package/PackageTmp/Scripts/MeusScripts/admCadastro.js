$(document).ready(function () {
    
    path = $(location).attr('pathname');

    if (path == '/Home/Cadastro') {

        cadastroUsuario();

    }
});

function cadastroUsuario() {

    $("#btnSalvar").click(function () {


        let nomeCadastro = $("#txtNomeCompleto").val();
        let emailCadastro = $("#txtEmail").val();
        let senhaCadastro = $("#txtSenha").val();
        let RepetirSenhaCadastro = $("#txtRepetirSenha").val();
        let enderecoCadastro = $("#txtEndereco").val();
        let idadeCadastro = $("#txtIdade").val();
         
        if (senhaCadastro == RepetirSenhaCadastro /*&& senhaCadastro !="" && RepetirSenhaCadastro ==""*/ ) {

            let usuario = {

                nome: nomeCadastro,
                email: emailCadastro,
                endereco: enderecoCadastro,
                senha: senhaCadastro,
                idade: idadeCadastro
            }

            requisicaoAssincrona("POST", "../Home/CadastroUsuario", usuario, sucessoCadastroUsuario, erroCadastroUsuario);
        } else {

            alert("As Senhas não são iguais!!!!");
        }

    })
}

function sucessoCadastroUsuario(Json) {

    let resposta = Json.retorno; // declarada mas nao usada     
    limparCampos();
    window.location.href = "/Home/Index";
    
}

function erroCadastroUsuario(Json) {

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