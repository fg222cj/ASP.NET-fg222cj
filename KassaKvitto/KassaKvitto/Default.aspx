<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="KassaKvitto.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Script.js"></script>
    <link href="~/Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" defaultbutton="ButtonSubmit">
        <div>
            <%-- Inputfält för användaren, indata förväntas vara siffror större än 0. --%>
            <asp:Label ID="LabelTotalInput" runat="server" Text="Total köpesumma:" AssociatedControlID="TextBoxTotal"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="TextBoxTotal" runat="server"></asp:TextBox>
            <asp:Label ID="LabelCurrency" runat="server" Text="Kr"></asp:Label>
            <%-- Validering av indata --%>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Du måste fylla i textfältet!" ControlToValidate="TextBoxTotal" Display="Dynamic" />
            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Endast tal (SIFFROR, INTE BOKSTÄVER) som är större än 0!" Type="Double" ControlToValidate="TextBoxTotal" Operator="GreaterThan" ValueToCompare="0" Display="Dynamic" />
        </div>
        <div>
            <asp:Button ID="ButtonSubmit" runat="server" Text="Beräkna rabatt" OnClick="ButtonSubmit_Click" />
        </div>
    </form>
    <%-- Placeholder för kvittot, syns inte när det inte finns data att presentera. --%>
    <asp:PlaceHolder ID="PlaceHolderReceipt" runat="server" Visible="False">
        <div class="Receipt">
            <h1>DeVe</h1>
            <h4>En del av EllenNu</h4>
            <p>Tel: 0772-28 80 00</p>
            <p>Öppettider 8-17</p>
            <p>EV. FEL GER UNDERKÄNT</p><%-- Lite nervös blir man --%>
            <p>--------------------------------</p>
            <p>
                <asp:Label ID="Subtotal" runat="server" Text="Totalt {0:c}"></asp:Label>
            </p>
            <p>
                <asp:Label ID="DiscountRate" runat="server" Text="Rabattsats {0:p0}"></asp:Label>
            </p>
            <p>
                <asp:Label ID="MoneyOff" runat="server" Text="Rabatt {0:c}"></asp:Label>
            </p>
            <p>
                <asp:Label ID="Total" runat="server" Text="Att betala {0:c}"></asp:Label>
            </p>
            <p>--------------------------------</p>
            <p>ORG. NR: 202100-6271</p>
            <p>VÄLKOMMEN ÅTER</p>
        </div>
    </asp:PlaceHolder>
</body>
</html>
