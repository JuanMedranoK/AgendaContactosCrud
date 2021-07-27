using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidad;
using Negocio;
using Dato;

namespace ProyectoCRUD
{
    public partial class Form1 : Form
    {
        public string name;
        public int codigousuario;

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            valid();
        }

        void valid()
        {
               
             if(txtname.Text != Name && txtname.TextLength>2)
            {
                Random codAlAzar = new Random();
                codigousuario = codAlAzar.Next(1, 92);
                Name = txtname.Text;
                MessageBox.Show("Bienvenido estimado " + Name +
                    " Su codigo de usuario es " + codigousuario);
                FrmHome lobby = new FrmHome();
                lobby.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Ingrese un nombre porfavor");
                
            }
            
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
