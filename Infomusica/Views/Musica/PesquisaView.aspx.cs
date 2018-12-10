﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InfoArtista : System.Web.UI.Page
{
    Login usuario = new Login();
    DeezerController deezer = new DeezerController();

    protected void Page_Load(object sender, EventArgs e)
    {
        VerificarSession();
    }

    private void VerificarSession()
    {
        usuario = (Login)Session["usuario"];

        if (usuario == null)
            Response.Redirect("/Views/Login/LoginView.aspx");
    }

    protected void btnBuscarArtista_Click(object sender, EventArgs e)
    {
        ExibirArtistas();
    }

    private void ExibirArtistas()
    {
        rpPesquisa.DataSource = ObterArtistas();
        rpPesquisa.DataBind();
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
                //Recuperando o valor do Argumento.
                string trackList = e.CommandArgument.ToString();

                //txEscolhido.Text = nomeArtista.ToString();

                ExibirFaixas(trackList);


                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                break;
        }
    }
}