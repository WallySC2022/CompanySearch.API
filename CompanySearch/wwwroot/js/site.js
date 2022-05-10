// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

/*const { parseJSON } = require("jquery");*/

// Write your JavaScript code.

$("#btnPesquisar").click(function () {

    var CNPJFORVALIDATE = $("#inputConsulta").val();
    var CNPJCleaned = CNPJFORVALIDATE.replace(/[^0-9]/g, '');
    var IsCNPJValide = validarCNPJ(CNPJCleaned);

    if (IsCNPJValide) {
        jQuery.ajax({
            cache: false,
            Type: "POST",
            url: 'Home/ConsultarEmpresa/' + CNPJCleaned,
            success: function (data) {
                var company = JSON.parse(data);
                $("#inputName").val(company.Nome);
                $("#inputUf").val(company.Uf);
                $("#inputTelefone").val(company.Telefone);
                $("#inputEmail").val(company.Email);
                $("#inputSituacao").val(company.Situacao);
                
                company = JSON.stringify(company);
                localStorage.setItem("company", company)
            }
        });               
    }
    else {
        alert("O CNPJ digitado está invalido!")
    }
});

$("#btnSalvarEmpresa").click(function () {

    var company = localStorage.getItem("company");

    jQuery.ajax({
        cache: false,
        Type: "POST",
        url: 'Home/GravarEmpresa/' + company,
        success: function (data) {
            alert("Salvou!");
        }
    });

});




function validarCNPJ(cnpj) {

    cnpj = cnpj.replace(/[^\d]+/g, '');

    if (cnpj == '') return false;

    if (cnpj.length != 14)
        return false;

    // Elimina CNPJs invalidos conhecidos
    if (cnpj == "00000000000000" ||
        cnpj == "11111111111111" ||
        cnpj == "22222222222222" ||
        cnpj == "33333333333333" ||
        cnpj == "44444444444444" ||
        cnpj == "55555555555555" ||
        cnpj == "66666666666666" ||
        cnpj == "77777777777777" ||
        cnpj == "88888888888888" ||
        cnpj == "99999999999999")
        return false;

    // Valida DVs
    tamanho = cnpj.length - 2
    numeros = cnpj.substring(0, tamanho);
    digitos = cnpj.substring(tamanho);
    soma = 0;
    pos = tamanho - 7;
    for (i = tamanho; i >= 1; i--) {
        soma += numeros.charAt(tamanho - i) * pos--;
        if (pos < 2)
            pos = 9;
    }
    resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
    if (resultado != digitos.charAt(0))
        return false;

    tamanho = tamanho + 1;
    numeros = cnpj.substring(0, tamanho);
    soma = 0;
    pos = tamanho - 7;
    for (i = tamanho; i >= 1; i--) {
        soma += numeros.charAt(tamanho - i) * pos--;
        if (pos < 2)
            pos = 9;
    }
    resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
    if (resultado != digitos.charAt(1))
        return false;

    return true;
}

