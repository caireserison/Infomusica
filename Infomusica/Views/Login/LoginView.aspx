<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeFile="LoginView.aspx.cs" Inherits="LoginView" %>

<asp:Content ID="Style" ContentPlaceHolderID="StyleSelection" runat="server">
</asp:Content>
<asp:Content ID="ConteudoArtista" ContentPlaceHolderID="ContentSection" runat="server">
    <div class="container-fluid h-100 d-flex ">

        <div class="form-group mx-auto mt-5 mb-5 align-self-center text-center" style="background: #f4f6f9">
            <div class="col-12">
                <div class="form-group col-sm-12 text-center">
                    <img class="m-3" src="../../img/Login/mindica_login.png" />
                </div>
                <h3 class="m-3">Efetuar Login</h3>
                <label for="inputEmail" class="sr-only">Email</label>
                <asp:TextBox ID="tbUsuario" runat="server" type="email" class="form-control mt-3 mb-3" placeholder="Endereço de Email" required autofocus></asp:TextBox>
                <label for="inputPassword" class="sr-only">Senha</label>
                <asp:TextBox ID="tbSenha" runat="server" type="password" class="form-control mt-3 mb-3" placeholder="Senha" required></asp:TextBox>

                <asp:Button ID="btLogin" runat="server" class="btn btn-lg btn-primary btn-block  mt-3 mb-3" type="submit" Text="Entrar" OnClick="btLogin_Click" />
                <asp:HyperLink ID="hlCadastro" runat="server" class="" NavigateUrl="~/views/Login/CadastroView.aspx">Cadastre-se</asp:HyperLink>
            </div>
        </div>


    </div>

    <!-- The Modal -->
    <div class="modal fade" id="myModalLogin">
        <div class="modal-dialog">
            <div class="modal-content">

                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Erro ao Logar</h4>
                    <button type="button" class="close" data-dismiss="modal">×</button>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                    <p>- Verificar se o email digitado é valido</p>
                    <p>- Verificar se a senha foi digitada corretamente</p>
                </div>

                <!-- Modal footer -->
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                </div>

            </div>
        </div>
    </div>


</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ScriptSection" runat="server">
    <script type="text/javascript">
        function openModal() {
            $('#myModalLogin').modal('show');
        }
    </script>
</asp:Content>
