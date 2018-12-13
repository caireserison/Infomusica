using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InfoArtista : System.Web.UI.Page
{
    Login usuario = new Login();
    DeezerController deezer = new DeezerController();
    MusicaController musica = new MusicaController();

    protected void Page_Load(object sender, EventArgs e)
    {
        VerificarSession();
        if (!VerificarMusicaData())
            Response.Redirect("/Views/Musica/IndicacoesView.aspx");
    }

    protected void btnBuscarArtista_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(tbArtista.Text.Trim()))
            ExibirArtistas();
    }

    private void VerificarSession()
    {
        usuario = (Login)Session["usuario"];
        if (usuario == null)
            Response.Redirect("/Views/Login/LoginView.aspx");
    }

    private bool VerificarMusicaData()
    {
        Musica musicaUsuario = (Musica)musica.ObterMusicaPorUsuarioData(new Musica() { idUsuario = usuario.id, dtInclusao = DateTime.Now.Date });
        return (musicaUsuario.idFaixa == 0);
    }
    
    private void ExibirArtistas()
    {
        var artistas = ObterArtistas();
        if (artistas.Count != 0)
        {
            rpPesquisa.DataSource = artistas;
            rpPesquisa.DataBind();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "openModal()", true);
        }
    }

    private List<Artistas> ObterArtistas()
    {
        List<Artistas> artistas = new List<Artistas>();

        String artista = tbArtista.Text;
        return deezer.BuscarArtistaPorNome(artista);
    }

    private void ExibirFaixas(string trackList)
    {
        rpPesquisaFaixa.DataSource = ObterFaixas(trackList);
        rpPesquisaFaixa.DataBind();
    }

    private List<Faixas> ObterFaixas(string trackList)
    {
        List<Faixas> faixas = new List<Faixas>();

        return deezer.BuscarFaixaPorTracklist(trackList);
    }
    
    protected void rpPesquisa_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Click":
                ExibirFaixas(e.CommandArgument.ToString());
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalMusicas();", true);
                break;
        }
    }

    private bool IncluirMusica(int idMusica)
    {
        MusicaController controle = new MusicaController();
        if (VerificarMusicaData())
        {
            controle.IncluirMusica(new Musica() { idUsuario = usuario.id, idFaixa = idMusica, dtInclusao = DateTime.Now.Date });
            return true;
        }
        
        return false;
    }

    protected void rpPesquisaFaixa_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Click":
                IncluirMusica(int.Parse(e.CommandArgument.ToString()));
                Response.Redirect("/Views/Musica/IndicacoesView.aspx");
                break;
        }
    }
}