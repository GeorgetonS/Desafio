// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    var $seuCampoCpf = $("#Cpf");
    $seuCampoCpf.mask('000.000.000-00', { reverse: true });
});

$(document).ready(function () {
    var $seuCampoTelefone = $("#Telefone");
    $seuCampoTelefone.mask('00 0-0000-0000', { reverse: true });
});
