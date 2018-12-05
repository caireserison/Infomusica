<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="PesquisaView.aspx.cs" Inherits="InfoArtista" %>

<asp:Content ID="Style" ContentPlaceHolderID="StyleSelection" runat="server">
</asp:Content>
<asp:Content ID="ConteudoArtista" ContentPlaceHolderID="ContentSection" runat="server">

    <div class="jumbotron">
        <h3>Pesquise um Artista</h3>
        <div class="form-inline">
            <div class="form-group">
                <asp:TextBox ID="tbArtista" class="form-control col-sm-10" type="text" Text="" runat="server" placeholder="ex.: Aerosmith"></asp:TextBox>
                <div class="col-sm-2">
                <asp:Button ID="btBuscarArtista" class="btn btn-lg btn-primary" Text="Pesquisar" runat="server" OnClick="btnBuscarArtista_Click" />
                </div>
            </div>
        </div>
        <br />
        <asp:GridView ID="gdArtistas" runat="server" CssClass="table table-responsive">
            <HeaderStyle CssClass="thead-dark" />
        </asp:GridView>
    </div>


</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
