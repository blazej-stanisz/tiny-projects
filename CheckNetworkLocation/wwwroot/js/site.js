﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// variables
var $pathInput = $("#pathInput");
var $loadingSpinner = $("#loadingSpinner");
var $pasteButton = $("#pasteButton");
var $checkButton = $("#checkButton");

// onReady actions
$checkButton.hide();
$loadingSpinner.hide();

// bind events
$pasteButton.on("click", function () { pasteAndCheck() });
$checkButton.on("click", function () { checkPath() });
$pathInput.on('keyup', function (e) { if (e.keyCode === 13) { checkPath(); } });

// functions
function checkPath() {
    clearPathInput();

    $.ajax({
        url: 'Home/SomeAction',
        data: { inputText: $pathInput.val() },
        beforeSend: function () {
            showLoadingSpinner(true);
        },
        success: function (result) {
            if (result) {
                $pathInput.addClass("is-valid");
            } else {
                $pathInput.addClass("is-invalid");
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(ajaxOptions + ", " + thrownError);
        },
        complete: function () {
            showLoadingSpinner(false);
        }
    });
}

function clearPathInput() {
    $pathInput.removeClass("is-valid is-invalid");
}

function showLoadingSpinner(show) {
    $loadingSpinner.toggle(show);
}

async function pasteAndCheck() {
    const text = await navigator.clipboard.readText();
    $pathInput.val(text);
    checkPath();
}