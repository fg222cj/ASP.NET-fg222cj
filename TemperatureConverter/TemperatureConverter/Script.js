function CustomValidator1_ClientValidate(source, args) {
    if (document.getElementById("<%= RadioButton1.ClientID %>").checked || document.getElementById("<%= RadioButton2.ClientID %>").checked) {
        args.IsValid = true;
    }
    else {
        args.IsValid = false;
    }

}