<%@ Page Title="" Language="C#" MasterPageFile="~/Medewerker.master" AutoEventWireup="true" CodeBehind="promoveren.aspx.cs" Inherits="Bibweb.Medewerkers.promoveren" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder4" runat="server">
    <asp:GridView ID="grvGebruikers" runat="server" DataKeyNames="Id" AutoGenerateColumns="False" DataSourceID="dsGebruikers" >
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="Gebruikersnaam" HeaderText="Gebruikersnaam" ReadOnly="True" SortExpression="Gebruikersnaam" />
            <asp:TemplateField HeaderText="Rol" SortExpression="Rol">
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="dsRolbeschrijvingenEdit" DataTextField="Omschrijving" DataValueField="Id" SelectedValue='<%# Bind("Rol") %>'>
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="dsRolbeschrijvingenEdit" runat="server" SelectMethod="GetRolBeschrijvingen" TypeName="BibDomain.Business.Controller"></asp:ObjectDataSource>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="dsRolBeschrijvingen" DataTextField="Omschrijving" DataValueField="Id" SelectedValue='<%# Bind("Rol") %>' Enabled="False">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="dsRolBeschrijvingen" runat="server" SelectMethod="GetRolBeschrijvingen" TypeName="BibDomain.Business.Controller"></asp:ObjectDataSource>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="dsGebruikers" runat="server" SelectMethod="GetGebruikers" TypeName="BibDomain.Business.Controller" UpdateMethod="PromoveerGebruiker">
        <UpdateParameters>
            <asp:Parameter Name="id" Type="Int32" />
            <asp:Parameter Name="gebruikersnaam" Type="String" />
            <asp:Parameter Name="rol" Type="Object" />
        </UpdateParameters>
    </asp:ObjectDataSource>
</asp:Content>
