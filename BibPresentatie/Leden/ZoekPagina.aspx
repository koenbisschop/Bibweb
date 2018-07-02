<%@ Page Title="" Language="C#" MasterPageFile="~/Lid.master" AutoEventWireup="true" CodeBehind="ZoekPagina.aspx.cs" Inherits="Bibweb.Lid.ZoekPagina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder4" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="ObjectDataSource1" DataKeyNames="Id" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White"  />
        <Columns>
            <asp:CommandField ShowSelectButton="True" >
            <ItemStyle CssClass="col-xs-1" />
            </asp:CommandField>
            <asp:BoundField DataField="Titel" HeaderText="Titel" ReadOnly="True" SortExpression="Titel" >
            <ItemStyle CssClass="col-xs-4" />
            </asp:BoundField>
            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" >
            <ItemStyle CssClass="col-xs-1" />
            </asp:BoundField>
            <asp:BoundField DataField="OntleenTarief" HeaderText="OntleenTarief" ReadOnly="True" SortExpression="OntleenTarief" >
            <ItemStyle CssClass="col-xs-2" />
            </asp:BoundField>
            <asp:BoundField DataField="OntleenTermijn" HeaderText="OntleenTermijn" ReadOnly="True" SortExpression="OntleenTermijn" >
            <ItemStyle CssClass="col-xs-2" />
            </asp:BoundField>
            <asp:BoundField DataField="BoeteTarief" HeaderText="BoeteTarief" ReadOnly="True" SortExpression="BoeteTarief" >
            <ItemStyle CssClass="col-xs-2" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetItems" 
        DataObjectTypeName ="BibDomain.Business.Item"
        TypeName="BibDomain.Business.Controller">
    </asp:ObjectDataSource>
    <br />
    <br />
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource2" DataKeyNames="Id"  Width="606px" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Ontlenen" Visible='<%# (BibDomain.Business.OntleenStatus)Eval("Status")==BibDomain.Business.OntleenStatus.Beschikbaar %>'></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle CssClass="col-xs-2" />
            </asp:TemplateField>
            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" >
            <ItemStyle CssClass="col-xs-1" />
            </asp:BoundField>
            <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True" SortExpression="Status" >
            <ItemStyle CssClass="col-xs-2" />
            </asp:BoundField>
        </Columns>
        <EmptyDataTemplate>
            Geen exemplaren van dit item aanwezig
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetExemplarenForItem" TypeName="BibDomain.Business.Controller">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="0" Name="itemId" SessionField="itemId" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
