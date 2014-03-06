<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HemligaTalet.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Script.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Ange ett tal mellan 1 och 100:"></asp:Label>
            <asp:TextBox ID="TextBoxGuess" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Obligatoriskt fält!"
                ControlToValidate="TextBoxGuess" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Du måste gissa på ett heltal mellan 1 och 100!" 
                Type="Integer" Display="Dynamic" MaximumValue="100" MinimumValue="1" ControlToValidate="TextBoxGuess" Text="*"></asp:RangeValidator>
            <asp:Button ID="ButtonSubmitGuess" runat="server" Text="Gissa!" OnClick="ButtonSubmitGuess_Click" />
        </div>
        <div>
            <asp:Label ID="LabelPreviousGuesses" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LabelResult" runat="server" Visible="False"></asp:Label>
        </div>
        <div>
            <asp:Button ID="ButtonNewGame" runat="server" Text="Ny omgång" OnClick="ButtonNewGame_Click" CausesValidation="false" Visible="False" />
        </div>
    </form>
</body>
</html>
