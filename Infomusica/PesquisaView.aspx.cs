using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InfoArtista : System.Web.UI.Page
{

    DeezerController deezer = new DeezerController();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnBuscarArtista_Click(object sender, EventArgs e)
    {
        //ExibirArtistas();
        Login login = new Login();
        //login.ObterLogin(tbArtista.Text);
        login.IncluirLogin(new LoginEntity() { login = "erison.caires@hotmail.com", nome = "Erison", senha = "123456" });
    }

    private void ExibirArtistas()
    {
        gdArtistas.DataSource = ObterArtistas();
        gdArtistas.DataBind();
    }

    private List<Artistas> ObterArtistas()
    {
        List<Artistas> artistas = new List<Artistas>();

        String artista = tbArtista.Text;
        return deezer.BuscarArtistaPorNome(artista);
    }
}