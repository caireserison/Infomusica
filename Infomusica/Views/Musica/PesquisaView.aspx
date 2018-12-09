<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="PesquisaView.aspx.cs" Inherits="InfoArtista" %>

<asp:Content ID="Style" ContentPlaceHolderID="StyleSelection" runat="server">
</asp:Content>
<asp:Content ID="ConteudoArtista" ContentPlaceHolderID="ContentSection" runat="server">
    <div class="container">
        <div class="jumbotron">
            <h3>Pesquise um Artista</h3>
            <div class="form-inline">
                <div class="form-group">
                    <asp:textbox id="tbArtista" class="form-control col-sm-10" type="text" text="" runat="server" placeholder="ex.: Aerosmith"></asp:textbox>
                    <div class="col-sm-2">
                        <asp:button id="btBuscarArtista" class="btn btn-lg btn-primary" text="Pesquisar" runat="server" onclick="btnBuscarArtista_Click" />
                    </div>
                </div>
            </div>
            <br />
            <!--Repeater do Resultado de Pesquisa-->
            <div class="table-responsive">
            <asp:repeater id="rpPesquisa" runat="server">
            <HeaderTemplate>
            <table class="table table-hover table-light mx-auto">
                <thead>
                    <tr>
                        <th scope="col">#</th>
                        <th scope="col">Foto</th>
                        <th scope="col">Nome</th>
                        <th scope="col">Adicionar</th>
                    </tr>
                </thead>
            </HeaderTemplate>
                    <ItemTemplate>
                    <tbody>
                        <tr>
                            <th scope="row"><%# Container.ItemIndex + 1 %></th>
                            <td >
                                <img src=<%# DataBinder.Eval(Container.DataItem, "Picture_medium") %> alt="Alternate Text" style="width: 100px" />
                                </td>

                            <td class="align-middle">
                                <h3 ><%# DataBinder.Eval(Container.DataItem, "Name") %></h3>
                            </td>

                            <td class="w-25" >
                            <asp:Button runat="server" type="button" class="btn btn-outline-primary align-items-center float-right" text="+ Selecionar"></asp:Button>
                            </td>
                        </tr>
                    </tbody>
                    </ItemTemplate>
             <FooterTemplate>
             </table>
             </FooterTemplate>
            </asp:repeater>
           </div>


            <asp:gridview id="gdArtistas" runat="server" cssclass="table table-responsive">
                <HeaderStyle CssClass="thead-dark" />
            </asp:gridview>
        </div>
    </div>


</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
