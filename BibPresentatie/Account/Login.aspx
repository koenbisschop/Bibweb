<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Bibweb.Account.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>aanmeldpagina</title>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentPlaceHolder3" runat="server">
    <asp:Login ID="wcAanmelden" runat="server" OnAuthenticate="wcAanmelden_Authenticate" DestinationPageUrl="~/default.aspx"></asp:Login>
</asp:Content>
