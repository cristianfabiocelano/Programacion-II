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
    public partial class FrmJuagdor : Form
    {
        public FrmJuagdor()
        {
            InitializeComponent();
        }
        public FrmJuagdor(Jugador jugador):this()
        {
            _jugador = jugador;
            this.txtNombre.Text = _jugador.Nombre;
            this.txtDni.Text = ""+_jugador.Dni;
            this.txtGoles.Text =""+ _jugador.TotalGoles;
            this.txtPartidosJugados.Text = ""+_jugador.PartidosJugados;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private Jugador _jugador;

        public Jugador getJugador()
        {
            return this._jugador;
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            long dni = long.Parse(this.txtDni.Text);
            string nombre = this.txtNombre.Text;
            int goles = int.Parse(this.txtGoles.Text);
            int partidos = int.Parse(this.txtPartidosJugados.Text);
            this._jugador = new Jugador(nombre, goles, partidos, dni);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;

           
        }


        

    }
}
