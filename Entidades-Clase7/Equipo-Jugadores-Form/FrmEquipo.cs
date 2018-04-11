using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades_Clase7;
namespace Equipo_Jugadores_Form
{
    public partial class FrmEquipo : Form
    {
        public FrmEquipo()
        {
            InitializeComponent();
        }

        private Equipo _equipo;

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            short cantidad = short.Parse(this.txtCantJug.Text);
            this._equipo = new Equipo(cantidad, nombre);
            this.txtNombre.Enabled = false;
            this.txtCantJug.Enabled = false;
            this.btnAceptar.Visible = false;
            this.btnCancelar.Visible = false;
            this.btnMenos.Visible = true;
            this.btnModificar.Visible = true;
            this.btnMas.Visible = true;
            this.txtListBox.Visible = true;
        }

        private void MostrarEnListBox()
        {
            this.txtListBox.Items.Clear();
            foreach (Jugador jugador in this._equipo.GetJugadores())
            {
                this.txtListBox.Items.Add(jugador.MostrarDatos());
            }
                
        }

        private void btnMas_Click(object sender, EventArgs e)
        {
            FrmJuagdor pantalla = new FrmJuagdor();
            pantalla.ShowDialog();

            if(pantalla.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                Jugador jugador = pantalla.getJugador();
                bool flag= this._equipo + jugador;

                if (flag)
                {
                    MessageBox.Show("Se agrego correactamente!");
                    MostrarEnListBox();
                }
                else
                {
                    MessageBox.Show("No se pudo agregar");
                }
             } 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtCantJug_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnMenos_Click(object sender, EventArgs e)
        {
            int index=txtListBox.SelectedIndex;
            List<Jugador> jugador = this._equipo.GetJugadores();
            
            if (index >= 0)
            {
                DialogResult rta = MessageBox.Show(jugador[index].MostrarDatos() + "\n\n desea eliminar este jugador?", "ATENCION!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (rta == System.Windows.Forms.DialogResult.Yes)
                {
                    bool flag = _equipo - jugador[index];

                    if (flag)
                    {
                        MessageBox.Show("Se borro correactamente!");
                        MostrarEnListBox();
                    }
                    else
                        MessageBox.Show("No se pudo borrar");
                }
                else
                {
                    MessageBox.Show("Decidio no borrar");
                }
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        { }
        private void button1_Click_1(object sender, EventArgs e)
        {

        }


        private void btnModificar_Click(object sender, EventArgs e)
        {
            int index = txtListBox.SelectedIndex;
            List<Jugador> jugador = this._equipo.GetJugadores();
            Jugador jugadorAux;
            if (index >= 0)
            {
                FrmJuagdor pantalla = new FrmJuagdor(jugador[index]);
                pantalla.ShowDialog();

                if (pantalla.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    jugador[index]=pantalla.getJugador();
                    MostrarEnListBox();
                }
            }
        }
    }
}
