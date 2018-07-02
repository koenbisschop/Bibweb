<%@ Page Title="" Language="C#" MasterPageFile="~/Medewerker.master" AutoEventWireup="true" CodeBehind="Betaling.aspx.cs" Inherits="Bibweb.Medewerkers.Betaling" %>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder4" runat="server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetLeden" TypeName="BibDomain.Business.Controller"></asp:ObjectDataSource>
    Kies een lid:
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataTextField="Achternaam" DataValueField="Id" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    <br />
            Betaling:
            <asp:TextBox ID="txtBetaald" runat="server">0</asp:TextBox>
    <br />
    <br />
            Saldo:
            <asp:Label ID="lblSaldo" runat="server" Text='<%# Eval("Saldo") %>'></asp:Label>
    <br />
    <br />
            Terug:
            <asp:Label ID="lblTerug" runat="server" BackColor="#FFFFCC"></asp:Label>
    <br />
    <br />
            <asp:Button ID="btnInnen" runat="server" OnClick="btnInnen_Click" Text="Betaling innen" />
    <br />
</asp:Content>
