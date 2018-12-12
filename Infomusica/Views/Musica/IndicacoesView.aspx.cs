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
        if (!IsPostBack)
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

    private List<Indicacao> ObterIndicacoes()
    {
        return controle.ObterMusicaPorData(new Musica() { dtInclusao = DateTime.Now.Date });
    }

    private void RemoverMusica()
    {
        controle.RemoverMusica(new Musica() { idUsuario = usuario.id, dtInclusao = DateTime.Now.Date });
    }

    protected void rpMusicas_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.DataItem != null)
        {
            if ((e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) && ((Indicacao)e.Item.DataItem).IdUsuario != usuario.id)
            {
                e.Item.FindControl("btnRemover").Visible = false;
            }
        }
    }

    protected void rpMusicas_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Remove":
                RemoverMusica();
                Response.Redirect("/Views/Musica/PesquisaView.aspx");
                break;
            case "Click":
                Response.Redirect("/Views/Musica/PesquisaView.aspx");
                break;
        }
    }
}