<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="IndicacoesView.aspx.cs" Inherits="Views_Musica_IndicacoesView" %>

<asp:Content ID="Style" ContentPlaceHolderID="StyleSelection" runat="server">
</asp:Content>
<asp:Content ID="ConteudoArtista" ContentPlaceHolderID="ContentSection" runat="server">
    <div class="container">
        <div class="jumbotron">
            <h3>Veja as recomendações musicais dos seus amigos na data de hoje:</h3>
            <br />
            <div class="table">
            <!--Repeater do Resultado de Pesquisa-->
                <asp:Repeater ID="rpMusicas" runat="server">
                    <HeaderTemplate>
                        <div class="table">
                            <div class="row">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="col-sm-4 mb-4">
                            <div class="card p-2">
                                <h4 class="card-title">'<%# DataBinder.Eval(Container.DataItem, "NomeUsuario") %>'</h4>
                                <img class="card-img-top img-fluid" src='<%# DataBinder.Eval(Container.DataItem, "URLFotoArtista") %>' alt="Card image cap">
                                <div class="card-block">
                                    <h4 class="card-title">'<%# DataBinder.Eval(Container.DataItem, "NomeArtista") %>'</h4>
                                    <p class="card-text">'<%# DataBinder.Eval(Container.DataItem, "NomeArtista") %>'</p>
                                    <p class="card-text"><small class="text-muted">'<%# DataBinder.Eval(Container.DataItem, "NomeAlbum") %>'</small></p>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                            </div>
			            </div>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>


</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ScriptSection" runat="server">
    </script>

</asp:Content>
