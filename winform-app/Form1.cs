﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace winform_app
{
    public partial class frmPokemon : Form
    {
        private List<Pokemon> listaPokemon;
        public frmPokemon()
        {
            InitializeComponent();
        }

        private void frmPokemon_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void cargar() 
        {
            PokemonNegocio negocio = new PokemonNegocio();
            try
            {
                listaPokemon = negocio.listar();
                dgvPokemon.DataSource = listaPokemon;
                dgvPokemon.Columns["UrlImagen"].Visible = false;
                dgvPokemon.Columns["Id"].Visible = false;
                cargarImagen(listaPokemon[0].UrlImagen);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }


        }
        private void dgvPokemon_SelectionChanged(object sender, EventArgs e)
        {
          Pokemon seleccionado =  (Pokemon)dgvPokemon.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.UrlImagen);
        }
        private void cargarImagen(string imagen) 
        {
            try
            {
                pictureBoxPokemon.Load(imagen);
            }
            catch (Exception ex)
            {

                pictureBoxPokemon.Load("https://www.came-educativa.com.ar/upsoazej/2022/03/placeholder-4.png");
            }



        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaPokemon alta = new frmAltaPokemon();
            alta.ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Pokemon seleccionado;
            seleccionado = (Pokemon) dgvPokemon.CurrentRow.DataBoundItem;
            frmAltaPokemon modificar = new frmAltaPokemon(seleccionado);
            modificar.ShowDialog();
            cargar();
        }
    }
}