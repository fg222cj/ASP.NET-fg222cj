"use strict";

var form = {
    init: function () {
        var textBoxGuess = document.getElementById("TextBoxGuess");
        textBoxGuess.focus();
        textBoxGuess.select();
    }
};

window.onload = form.init;