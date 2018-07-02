<%@ Page Title="" Language="C#" MasterPageFile="~/Lid.master" AutoEventWireup="true" CodeBehind="Ontlening.aspx.cs" Inherits="Bibweb.Leden.Ontlening" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder4" runat="server">
   
    <asp:GridView ID="grvOntleningen" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="exemplaarId" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="grvOntleningen_SelectedIndexChanged" OnRowUpdating="grvOntleningen_RowUpdating" OnRowCancelingEdit="grvOntleningen_RowCancelingEdit" OnRowEditing="grvOntleningen_RowEditing" >
        <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:CommandField SelectText="Terugbrengen" ShowSelectButton="True" ShowEditButton="True" UpdateText="Verlengen" CausesValidation="False" >
        <ItemStyle CssClass="col-xs-2" />
        </asp:CommandField>
        <asp:BoundField DataField="exemplaarId" HeaderText="exemplaarId" ItemStyle-Width="30" ReadOnly="True" >
<ItemStyle Width="30px" CssClass="col-xs-1"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="titel" HeaderText="titel" ItemStyle-Width="250" ReadOnly="True" >
<ItemStyle Width="250px" CssClass="col-xs-4"></ItemStyle>
        </asp:BoundField>
        <asp:TemplateField HeaderText="Vanaf">
            <EditItemTemplate>
                <asp:Calendar ID="calVanaf" runat="server" SelectedDate='<%# Bind("Vanaf") %>' VisibleDate='<%# Bind("Vanaf") %>'></asp:Calendar>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lblVanaf" runat="server" Text='<%# Bind("Vanaf", "{0:d/M/yyyy}") %>'></asp:Label>
                <br />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
        <EmptyDataTemplate>
            Je hebt geen items ontleend.
        </EmptyDataTemplate>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />

<HeaderStyle BackColor="#990000" ForeColor="White" Font-Bold="True"></HeaderStyle>
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>
   
</asp:Content>
