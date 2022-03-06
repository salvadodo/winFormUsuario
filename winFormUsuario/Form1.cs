using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winFormUsuario
{
    public partial class frmUsuarios : Form
    {
        DataUsuario objUsuario=new DataUsuario();
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtIdUsuario.Enabled = false;
            //txtIdUsuario.Visible = false;
            listarUsuarios();
        }
        public void listarUsuarios()
        {
            dgvUsuario.DataSource = objUsuario.registrosUsuarios();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text!="" && txtEdad.Text!="" && cbobSexo.Text!="" && txtDireccion.Text!="")
            {
                Usuario newUsuario = new Usuario() { Nombre = txtNombre.Text, Edad = Convert.ToInt32(txtEdad.Text), Sexo = cbobSexo.Text, Direccion = txtDireccion.Text };
                objUsuario.insertarUsuario(newUsuario);
                listarUsuarios();
                limpiar();
            }
            else
            {
                MessageBox.Show("Ingrese todos los campos", "Información de campos de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtEdad.Text != "" && cbobSexo.Text != "" && txtDireccion.Text != "")
            {
                Usuario newUsuario = new Usuario() { idUsuario = Convert.ToInt32(txtIdUsuario.Text), Nombre = txtNombre.Text, Edad = Convert.ToInt32(txtEdad.Text), Sexo = cbobSexo.Text, Direccion = txtDireccion.Text };
                objUsuario.modificarUsuario(newUsuario);
                listarUsuarios();
                limpiar();
            }
            else
            {
                MessageBox.Show("Ingrese todos los campos", "Información de campos de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            objUsuario.eliminarUsuario(Convert.ToInt32(txtIdUsuario.Text));
            listarUsuarios();
            limpiar();
        }
        private void btnBuscarNombre_Click(object sender, EventArgs e)
        {
            dgvUsuario.DataSource = objUsuario.buscarPorNombre(txtBuscarNombre.Text);
            txtBuscarNombre.Text = "";
        }
        private void dgvUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdUsuario.Text = dgvUsuario.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dgvUsuario.CurrentRow.Cells[1].Value.ToString();
            txtEdad.Text = dgvUsuario.CurrentRow.Cells[2].Value.ToString();
            cbobSexo.Text = dgvUsuario.CurrentRow.Cells[3].Value.ToString();
            txtDireccion.Text = dgvUsuario.CurrentRow.Cells[4].Value.ToString();
        }
        private void limpiar()
        {
            txtIdUsuario.Text = "";
            txtNombre.Text = "";
            txtEdad.Text = "";
            cbobSexo.Text = "";
            txtDireccion.Text = "";
        }
    }
}
