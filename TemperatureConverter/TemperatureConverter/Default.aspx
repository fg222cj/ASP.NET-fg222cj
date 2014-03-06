<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TemperatureConverter.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Script.js"></script>
    <link href="~/Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" defaultbutton="Button1">
        <div class="Main">
            <div class="Column">
                <div>
                    <%-- Sammanfattning av valideringen --%>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                </div>
                
                <%-- Input-fält, label och validering för starttemperatur --%>
                <div>
                    <asp:Label ID="Label2" runat="server" Text="Starttemperatur:"></asp:Label><br />
                    <asp:TextBox ID="TextBoxStart" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Obligatoriskt fält!" ControlToValidate="TextBoxStart" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Måste vara en siffra och mindre än sluttemperatur!" ControlToValidate="TextBoxStart" ControlToCompare="TextBoxFinal" Type="Integer" Operator="LessThan" Text="*"></asp:CompareValidator>
                </div>
                <%-- Input-fält, label och validering för sluttemperatur --%>
                <div>
                    <asp:Label ID="Label3" runat="server" Text="Sluttemperatur:"></asp:Label><br />
                    <asp:TextBox ID="TextBoxFinal" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Obligatoriskt fält!" ControlToValidate="TextBoxFinal" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Måste vara en siffra och större än starttemperatur!" ControlToValidate="TextBoxFinal" ControlToCompare="TextBoxStart" Type="Integer" Operator="GreaterThan" Text="*"></asp:CompareValidator>
                </div>
                <%-- Input-fält, label och validering för temperaturintervallet --%>
                <div>
                    <asp:Label ID="Label4" runat="server" Text="Temperatursteg:"></asp:Label><br />
                    <asp:TextBox ID="TextBoxInterval" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Obligatoriskt fält!" ControlToValidate="TextBoxInterval" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Måste vara en siffra mellan 1-100!" ControlToValidate="TextBoxInterval" Type="Integer" MaximumValue="100" MinimumValue="1" Display="Dynamic" Text="*"></asp:RangeValidator>
                </div>
                <%-- Radioknappar ger användaren valet mellan C->F-konvertering eller vice versa --%>
                <div>
                    <asp:Label ID="Label1" runat="server" Text="Typ av konvertering:"></asp:Label>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Du måste välja ett alternativ!" ClientValidationFunction="CustomValidator1_ClientValidate" OnServerValidate="CustomValidator1_ServerValidate" Text="*"></asp:CustomValidator><br />
                    <asp:RadioButton ID="RadioButton1" runat="server" GroupName="ConversionFromTo" Checked="true" />
                    <asp:Label ID="Label5" runat="server" Text="Celsius till Fahrenheit"></asp:Label><br />
                    <asp:RadioButton ID="RadioButton2" runat="server" GroupName="ConversionFromTo" />
                    <asp:Label ID="Label6" runat="server" Text="Fahrenheit till Celsius"></asp:Label>
                </div>
                <div>
                    <asp:Button ID="Button1" runat="server" Text="Beräkna" OnClick="Button1_Click" />
                </div>
            </div>
            <div class="Column">
                <asp:Table ID="Table1" runat="server" Visible="False">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell>
                            <asp:Label ID="TableHeaderLeft" runat="server" Text="&deg;C"></asp:Label>
                        </asp:TableHeaderCell>
                        <asp:TableHeaderCell>
                            <asp:Label ID="TableHeaderRight" runat="server" Text="&deg;F"></asp:Label>
                        </asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
            </div>
        </div>
    </form>
</body>
</html>
