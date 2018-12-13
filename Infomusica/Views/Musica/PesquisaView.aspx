﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="PesquisaView.aspx.cs" Inherits="InfoArtista" %>

<asp:Content ID="Style" ContentPlaceHolderID="StyleSelection" runat="server">
</asp:Content>
<asp:Content ID="ConteudoArtista" ContentPlaceHolderID="ContentSection" runat="server">
    <div class="container">
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
            <!--Repeater do Resultado de Pesquisa-->
            <div class="table-responsive">
                <asp:Repeater ID="rpPesquisa" runat="server" OnItemCommand="rpPesquisa_ItemCommand">
                    <HeaderTemplate>
                        <table class="table table-hover table-light mx-auto">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr class="row">
                                <td class="ml-3 col-xs-2 text-center">
                                    <asp:Button runat="server"
                                        CommandName="Click"
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Tracklist") %>'
                                        type="button"
                                        class="mt-4 mb-4 btn btn-outline-success align-items-center"
                                        Text="Selecionar"></asp:Button>
                                </td>
                                <td class="">
                                    <img src='<%# DataBinder.Eval(Container.DataItem, "Picture_medium") %>' alt="Alternate Text" style="width: 100px" />
                                </td>

                                <td class="col-xs-3">
                                    <h3 class="m-4"><%# DataBinder.Eval(Container.DataItem, "Name") %></h3>
                                </td>
                            </tr>
                        </tbody>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>

            <div class="modal fade  bd-example-modal-lg" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-lg" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <span class="modal-title" id="exampleModalLabel"> 
                            <asp:Label ID="txEscolhido" class="col-form-label" runat="server" Text=""></asp:Label>
                            </span>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <form>
                                <div class="form-group">

                                    <h3>Escolha uma musica abaixo:</h3>
                                    <div class="table-responsive">


                                        <!--Repeater do Resultado de Pesquisa-->
                                        <asp:Repeater ID="rpPesquisaFaixa" runat="server" OnItemCommand="rpPesquisaFaixa_ItemCommand">
                                            <HeaderTemplate>
                                                <ul class="list-unstyled">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <li class="media">
                                                    <div class=" btn-group btn-group-sm mr-3">
                                                        <asp:Button runat="server"
                                                            CommandName="Click"
                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id") %>'
                                                            type="button"
                                                            class="btn btn-outline-success align-items-center float-left"
                                                            Text="Selecionar"></asp:Button>
                                                        <button id="btnOuvir"
                                                            data-toggle="collapse"
                                                            href="#multiCollapse<%# Container.ItemIndex + 1 %>"
                                                            type="button"
                                                            class="btn btn-outline-primary">
                                                            Ouvir Música</button>
                                                    </div>
                                                    <div class="media-body mb-2">
                                                        <h5 class="mt-0 mb-1"><%# DataBinder.Eval(Container.DataItem, "Title") %></h5>
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
                                                </li>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </ul>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                        <!--Fim Repeater-->
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>


</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ScriptSection" runat="server">
    <script type="text/javascript">
        $('#myModal').on('shown.bs.modal', function () {
            $('#myInput').trigger('focus')
        })

        function openModal() {
            $('#exampleModal').modal({ show: true });
        }

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
