<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Registratie.aspx.cs" Inherits="Bibweb.Account.Registratie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentPlaceHolder3" runat="server">
    <div class="form-horizontal">
        <fieldset>
            <legend class="col-sm-offset-2">Nieuw lid</legend>
            <div class="form-group">
                <label for="gebruikersnaam" class="control-label col-sm-2">Gebruikersnaam:</label>
                <div class="col-sm-4">
                    <input class="form-control" type="text" required="required" placeholder="gebuikersnaam" id="gebruikersnaam" runat="server" />
                </div>
            </div>
            <div class="form-group">
                <label for="paswoord" class="control-label col-sm-2">paswoord: </label>
                <div class="col-sm-4">
                    <input required="required" type="password" id="paswoord" name="paswoord" runat="server" class="form-control" />
                </div>
            </div>
            <div class="form-group">
                <label for="ConfirmPassword" class="control-label col-sm-2">bevestig paswoord:</label>
                <div class="col-sm-4">

                    <input type="password" required="required" id="confirmPaswoord" class="form-control" runat="server" />
                </div>
            </div>
            <div class="form-group">
                <label for="achternaam" class="control-label col-sm-2">Achternaam:</label>
                <div class="col-sm-4">

                    <input type="text" required="required" placeholder="achternaam" id="achternaam" class="form-control" runat="server" />
                </div>
            </div>
            <div class="form-group">
                <label for="voornaam" class="control-label col-sm-2">Voornaam:</label>
                <div class="col-sm-4">
                    <input type="text" required="required" placeholder="voornaam" id="voornaam" runat="server" class="form-control" />
                </div>
            </div>
            <div class="form-group">
                <label runat="server" for="geboorteDatum" class="col-sm-2 control-label">Geboortedatum:</label>
                <div class="col-sm-4">
                        <div class="input-group date" id="gebdat">
                            <input type="text" placeholder="geboortedatum" id="geboorteDatum" runat="server" class="form-control" />
                            <span class="input-group-addon">
                                <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                </div>
            </div>
            <div class="form-group" style="margin-top: 25px">
                <asp:Label ID="foutboodschap" runat="server" class="alert alert-danger col-sm-offset-2"></asp:Label>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-4">
                    <asp:Button ID="btnNieuweGebruiker" runat="server" Text="Maak gebruiker" OnClick="btnNieuweGebruiker_Click" PostBackUrl="Registratie.aspx" class="btn btn-primary" />
                </div>
            </div>
        </fieldset>
    </div>
</asp:Content>
