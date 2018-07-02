<%@ Page Title="" Language="C#" MasterPageFile="~/Medewerker.master" AutoEventWireup="true" CodeBehind="NieuwItem.aspx.cs" Inherits="Bibweb.Medewerkers.Nieuw_item" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder4" runat="server">
    <div class="form-horizontal">
        <fieldset>
            <legend class="col-sm-offset-2">Nieuw item</legend>
            <div class="form-group">
                <label for="titel" class="control-label col-sm-2">Titel:</label>
                <div class="col-sm-4">
                    <asp:TextBox ID="titel" CssClass="form-control" runat="server" AutoPostBack="true" 
                        placeholder="titel" required="required" OnTextChanged="titel_TextChanged" EnableViewState="False" />
                </div>
            </div>
            <div class="form-group">
                <label for="drager" class="control-label col-sm-2">Drager:</label>
                <div class="col-sm-6">
                    <asp:RadioButtonList ID="soortDrager" runat="server" RepeatDirection="Vertical">
                        <asp:ListItem Value="boek" Selected="True">boek</asp:ListItem>
                        <asp:ListItem Value="CD">CD/DVD</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>

            <div class="form-group" style="margin-top: 25px">
                <asp:Label ID="boodschap" runat="server" class="col-sm-offset-2"></asp:Label>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-4">
                    <asp:Button ID="btnNieuwItem" runat="server" Text="Nieuw item" PostBackUrl="NieuwItem.aspx" class="btn btn-primary" OnClick="btnNieuwItem_Click" />
                </div>
            </div>

        </fieldset>
    </div>
</asp:Content>
