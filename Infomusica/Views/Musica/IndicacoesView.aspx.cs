using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Musica_IndicacoesView : System.Web.UI.Page
{
    Login usuario = new Login();
    List<Musica> musicas = new List<Musica>();
    MusicaController controle = new MusicaController();

    protected void Page_Load(object sender, EventArgs e)
    {
        VerificarSession();
        CarregarIndicacoes();
    }

    private void VerificarSession()
    {
        usuario = (Login)Session["usuario"];

        if (usuario == null)
            Response.Redirect("/Views/Login/LoginView.aspx");
    }

    private void CarregarIndicacoes()
    {
        rpMusicas.DataSource = ObterIndicacoes();
        rpMusicas.DataBind();
    }

    //private void CarregarIndicacoesUsuario()
    //{
    //    //grid = ObterIndicacoesUsuario();
    //    //grid blind
    //}

    private List<Indicacao> ObterIndicacoes()
    {
        return controle.ObterMusicaPorData(new Musica() { dtInclusao = DateTime.Now.Date });
    }
    
    //private Musica ObterIndicacoesUsuario()
    //{
    //    return (Musica)controle.ObterMusicaPorUsuarioData(new Musica() { dtInclusao = DateTime.Now.Date, idUsuario = usuario.id });
    //}
}