<%@ Page Title="" Language="C#" MasterPageFile="~/Medewerker.master" AutoEventWireup="true" CodeBehind="BeheerItem.aspx.cs" Inherits="Bibweb.Medewerkers.NieuwExemplaar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder4" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" DataKeyNames="Id" OnRowCommand="GridView1_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" ShowEditButton="True" >
            <ItemStyle CssClass="col-xs-1" />
            </asp:CommandField>
            <asp:BoundField DataField="Titel" HeaderText="Titel" SortExpression="Titel" >
            <ItemStyle CssClass="col-xs-2" />
            </asp:BoundField>
            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" >
            <ItemStyle CssClass="col-xs-1" />
            </asp:BoundField>
            <asp:BoundField DataField="OntleenTarief" HeaderText="OntleenTarief" ReadOnly="True" SortExpression="OntleenTarief" >
            <ItemStyle CssClass="col-xs-1" />
            </asp:BoundField>
            <asp:BoundField DataField="OntleenTermijn" HeaderText="OntleenTermijn" ReadOnly="True" SortExpression="OntleenTermijn" >
            <ItemStyle CssClass="col-xs-1" />
            </asp:BoundField>
            <asp:BoundField DataField="BoeteTarief" HeaderText="BoeteTarief" ReadOnly="True" SortExpression="BoeteTarief" >
            <ItemStyle CssClass="col-xs-1" />
            </asp:BoundField>
            <asp:ButtonField Text="Nieuw exemplaar" CommandName="nieuwExemplaar_click" >
            <ItemStyle CssClass="col-xs-1" />
            </asp:ButtonField>
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
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetItems" TypeName="BibDomain.Business.Controller" UpdateMethod="WijzigItem">
        <UpdateParameters>
            <asp:Parameter Name="Titel" Type="String" />
            <asp:Parameter Name="Id" Type="Int32" />
            <asp:Parameter Name="ontleenTarief" Type="Decimal" />
            <asp:Parameter Name="ontleenTermijn" Type="Int32" />
            <asp:Parameter Name="boeteTarief" Type="Decimal" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    <br />
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource2" DataKeyNames="Id" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="GridView2_RowDeleting">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" />
            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" >
            <ItemStyle CssClass="col-xs-2" />
            </asp:BoundField>
            <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True" SortExpression="Status" >
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
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetExemplarenForItem" TypeName="BibDomain.Business.Controller" DeleteMethod="VerwijderExemplaar">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="GridView1" Name="itemId" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
