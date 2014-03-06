﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BildGalleri.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="Image1" runat="server" />
        </div>
        <div>
            <asp:Repeater ID="Repeater1" runat="server" ItemType="System.String" SelectMethod="Repeater1_GetData">
                <HeaderTemplate>
                    <ul class="images">
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <asp:HyperLink ID="HyperLink1" runat="server" 
                            ImageUrl='<%# Item.ToString() %>'></asp:HyperLink>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
