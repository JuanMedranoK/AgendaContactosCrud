using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Negocio;
using Entidad;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCRUD
{
    public partial class FrmHome : Form
    {
        LogicaContacto log = new LogicaContacto();
        private string cod;
        private bool Edit = false;
        Contactos contact = new Contactos();
        public FrmHome()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        public void showtable(string search)
        {
            DGV.DataSource = log.ListarClientes(search);
            DGV.ClearSelection();
        }
        
        private void Clear()
        {
            Edit = false;
            txtnombre.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtTrabajo.Clear();
            txtDireccion.Clear();

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Volveras al inicio!");
            Form1 inicio = new Form1();
            inicio.Show();
            this.Hide();
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {
            showtable("");
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            showtable(txtbuscar.Text);
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (Edit == false)
            {
                try
                {
                    contact.Name = txtnombre.Text.ToUpper();
                    contact.Phone = txtTelefono.Text.ToUpper();
                    contact.PhoneJob = txtTrabajo.Text.ToUpper();
                    contact.Email = txtCorreo.Text.ToUpper();
                    contact.Direction = txtDireccion.Text.ToUpper();

                    log.InsertarContactos(contact);
                    MessageBox.Show("Contacto ingresado correctamente");
                    showtable("");
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("NO SE PUEDO AGREGAR POR:" + ex);
                }
            }
           
            if (Edit == true)
            {
                try
                {
                    contact.Name = txtnombre.Text.ToUpper();
                    contact.Phone = txtTelefono.Text.ToUpper();
                    contact.PhoneJob = txtTrabajo.Text.ToUpper();
                    contact.Email = txtCorreo.Text.ToUpper();
                    contact.Direction = txtDireccion.Text.ToUpper();
                
                    log.InsertarContactos(contact);
                    MessageBox.Show("CONTACTO AGREGADO Y EDITADO");
                    showtable("");
                    Clear();
                    Edit = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("NO SE PUDO MODIFICAR AL CONTACTO POR:" + ex);
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (DGV.SelectedRows.Count > 0)
            {
                contact.CodigoContacto = Convert.ToInt32(DGV.CurrentRow.Cells[0].Value.ToString());
                log.EliminarContactos(contact);
                MessageBox.Show("CONTACTO ELIMINADO");
                showtable("");
            }
            else
            {
                MessageBox.Show("Favor elegir un contacto a eliminar");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (DGV.SelectedRows.Count > 0)
            {
                Edit = true;
                txtnombre.Text = DGV.CurrentRow.Cells["Name"].Value.ToString();
                txtTelefono.Text = DGV.CurrentRow.Cells["Phone"].Value.ToString();
                txtTrabajo.Text = DGV.CurrentRow.Cells["PhoneJob"].Value.ToString();
                txtCorreo.Text = DGV.CurrentRow.Cells["Email"].Value.ToString();
                txtDireccion.Text = DGV.CurrentRow.Cells["Direction"].Value.ToString();
                
            }
            else
            {
                MessageBox.Show("Seleccione un contacto para editar");
            }
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
