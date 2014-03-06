"use strict";

var form = {
    init: function () {
        var textBoxTotal = document.getElementById("TextBoxTotal");
        textBoxTotal.focus();
        textBoxTotal.select();
    }
};

window.onload = form.init;