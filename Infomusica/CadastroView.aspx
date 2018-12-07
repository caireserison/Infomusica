<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="CadastroView.aspx.cs" Inherits="CadastroView" %>

<asp:Content ID="Style" ContentPlaceHolderID="StyleSelection" runat="server">
</asp:Content>
<asp:Content ID="ConteudoArtista" ContentPlaceHolderID="ContentSection" runat="server">
    <div class="container-fluid h-100 d-flex ">
        <div class="form-group mx-auto mt-5 mb-5 align-self-center text-center" style="background: #f4f6f9">
            <div class="col-12">
                <div class="form-group col-sm-12 text-center">
                    <img class="w-25 h-25 m-3" src="img/music.png" />
                </div>
                <h3 class="m-3">Bem Vindo, Faça seu cadastro</h3>

                <label class="sr-only">Nome</label>
                <asp:textbox id="tbNomeUsuario" runat="server" type="" class="form-control mt-3 mb-3" placeholder="Seu Nome" required autofocus></asp:textbox>

                <label for="inputEmail" class="sr-only">Email</label>
                <asp:textbox id="tbUsuario" runat="server" type="email" class="form-control mt-3 mb-3" placeholder="Endereço de Email" required autofocus></asp:textbox>

                <label for="inputPassword" class="sr-only">Senha</label>
                <asp:textbox id="tbSenha" runat="server" type="password" class="form-control mt-3 mb-3" placeholder="Senha" required></asp:textbox>

                <div class="btn-toolbar mt-3 mb-3 justify-content-center" role="toolbar" aria-label="Basic example">
                    <div class="btn-group mr-2" role="group" aria-label="First group">
                        <asp:button id="btCadastrar" runat="server" class="btn btn-lg btn-primary btn-block  " type="submit" text="Cadastrar" />
                    </div>
                    <div class="btn-group" role="group" aria-label="First group">
                        <a href="LoginView.aspx" class="btn btn-secondary btn-lg" role="button" aria-pressed="true">Voltar</a>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
