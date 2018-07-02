<%@ Page Title="" Language="C#" MasterPageFile="~/Medewerker.master" AutoEventWireup="true" CodeBehind="LidInfo.aspx.cs" Inherits="Bibweb.Medewerkers.LidInfo" %>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder4" runat="server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetLeden" TypeName="BibDomain.Business.Controller"></asp:ObjectDataSource>
    Kies een lid:
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1" DataTextField="Achternaam" DataValueField="Id" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1">
</asp:DropDownList>
    <br />
    <asp:DataList ID="DataList1" runat="server">
        <ItemTemplate>
            Achternaam:
            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Achternaam") %>'></asp:Label>
            <br />
            Voornaam:
            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Voornaam") %>'></asp:Label>
            <br />
            Rol:
            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Rol") %>'></asp:Label>
        </ItemTemplate>
    </asp:DataList>
    <br />
    <br />
    </asp:Content>
