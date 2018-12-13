<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="IndicacoesView.aspx.cs" Inherits="Views_Musica_IndicacoesView" %>

<asp:Content ID="Style" ContentPlaceHolderID="StyleSelection" runat="server">
</asp:Content>
<asp:Content ID="ConteudoArtista" ContentPlaceHolderID="ContentSection" runat="server">
    <div class="container">
        <div class="jumbotron">
            <h3>Veja as recomendações musicais na data de hoje:</h3>
            <br />
            <div class="table">
                <!--Repeater do Resultado de Pesquisa-->
                <asp:Repeater ID="rpMusicas" runat="server" OnItemCreated="rpMusicas_ItemCreated" OnItemCommand="rpMusicas_ItemCommand">
                    <HeaderTemplate>
                        <div class="table bg-transparent">
                            <div class="row">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="col-sm-4 mb-4">
                            <div class="card p-2">
                                <h4 class="card-title"><%# DataBinder.Eval(Container.DataItem, "NomeUsuario") %></h4>
                                <img class="card-img-top img-fluid" src='<%# DataBinder.Eval(Container.DataItem, "URLFotoArtista") %>' alt="Card image cap">
                                <div class="card-block">
                                    <dl>
                                        <dt><%# DataBinder.Eval(Container.DataItem, "NomeMusica") %></dt>
                                        <dd>- <%# DataBinder.Eval(Container.DataItem, "NomeArtista") %> / <%# DataBinder.Eval(Container.DataItem, "NomeAlbum") %></dd>
                                    </dl>
                                </div>
                                <div class="container-fluid text-center">
                                    <div class=" btn-group btn-group-sm">
                                        <asp:Button runat="server"
                                            ID="btnRemover"
                                            CommandName="Remove"
                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IdUsuario") %>'
                                            type="button"
                                            class="m-3 btn btn-outline-danger"
                                            Text="Remover"></asp:Button>
                                        <button
                                            id="btnOuvir"
                                            data-toggle="collapse"
                                            href="#multiCollapse<%# Container.ItemIndex + 1 %>"
                                            type="button"
                                            class="m-3 btn btn-outline-primary">
                                            Ouvir Música</button>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <div class="collapse multi-collapse" id="multiCollapse<%# Container.ItemIndex + 1 %>">
                                            <div class="card card-body">
                                                <%# DataBinder.Eval(Container.DataItem, "Embed") %>
                                            </div>
                                        </div>
                                    </div>
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
    <script type="text/javascript">
        $("iframe").contents().find("#dzplayer").addClass("embed-responsive");
    </script>
    <style>
        iframe {
            position: relative;
            display: block;
            width: 100%;
            padding: 0;
            overflow: hidden;
        }
    </style>

</asp:Content>
