using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        public Usuario UsuarioSeleccionado { get; set; }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if(TbxID.Text == TbxID.Text)
            {
                if(UsuarioDal.Crear(TbxID.Text, TbxNombre.Text) > 0)
                {
                    MessageBox.Show("Usuario Guardado!!");
                }
            }
        }
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            
            DGVBuscarUsuario.DataSource = UsuarioDal.BuscarUsuario(TbxID.Text,TbxNombre.Text);
        }
        private void BtnModificar_Click_1(object sender, EventArgs e)
        {
            if (DGVBuscarUsuario.SelectedRows.Count == 1)
            {
                string ID = Convert.ToString(DGVBuscarUsuario.CurrentRow.Cells[0].Value);
                string Nombre = Convert.ToString(DGVBuscarUsuario.CurrentRow.Cells[1].Value);
                if (!string.IsNullOrWhiteSpace(ID) && !string.IsNullOrWhiteSpace(Nombre))
                {
                    UsuarioSeleccionado = UsuarioDal.ModificarUsuario(ID, Nombre);
                    MessageBox.Show("Usuario seleccionado para edición.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo obtener la información del usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un usuario para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            if (DGVBuscarUsuario.SelectedRows.Count == 1)
            {
                string ID = Convert.ToString(DGVBuscarUsuario.CurrentRow.Cells[0].Value);
                DialogResult resultado = MessageBox.Show(
                    "¿Está seguro de que desea eliminar este usuario?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                if (resultado == DialogResult.Yes)
                {
                    if (UsuarioDal.EliminarUsuario(ID))
                    {
                        MessageBox.Show("Usuario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BtnBuscar_Click(sender, e); 
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un usuario para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
