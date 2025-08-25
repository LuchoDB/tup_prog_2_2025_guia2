using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        Servicio servicio = new Servicio();
        public Form1()
        {
            InitializeComponent();
        }
        private void Actualizar()
        {
            lbPersonas.Items.Clear();
            for (int i = 0; i < servicio.VerCantidadPersonas(); i++)
            {
                Persona persona = servicio.verPersona(i);
                lbPersonas.Items.Add(persona.Describir());
            }
        }
        private void btnListar_Click(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormDatos Datos = new FormDatos();
            if (Datos.ShowDialog() == DialogResult.OK)
            {
                string nombre = Datos.tbPedirNombre.Text;
                int dni = Convert.ToInt32(Datos.tbPedirDNI.Text);

                Persona p = new Persona(dni, nombre);
                if (servicio.AgregarPersona(p))
                {
                    MessageBox.Show("Persona agregada");
                }
                else
                {
                    MessageBox.Show("Error, ya existe una persona con ese DNI");
                }
                Actualizar();
            }
            Datos.Dispose();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            FormDatos Datos = new FormDatos();

            //Solo necesito mostrar ver los datos, asi que deshabilito los textbox
            Datos.tbPedirNombre.Enabled = false;
            Datos.tbPedirDNI.Enabled = false;
            //Tambien puedo ocultar un boton asi es mas entendible para el usuario
            Datos.btnCancelar.Visible = false;

            Persona persona = servicio.verPersona(lbPersonas.SelectedIndex); //De aca saco la persona seleccionada

            if(persona != null)
            {
                Datos.tbPedirNombre.Text = persona.nombre;
                Datos.tbPedirDNI.Text = persona.dni.ToString();
                Datos.ShowDialog();
            }
            else
            {
                MessageBox.Show("Error, no selecciono una persona");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            FormDatos Datos = new FormDatos();

            //Nota de color: en la vida real el dni no se modifica (legalmente), pero si el nombre.
            Datos.tbPedirDNI.Enabled = false; //No dejo modificar el dni

            Persona p = servicio.verPersona(lbPersonas.SelectedIndex);

            if (p != null)
            {
                Datos.tbPedirNombre.Text = p.nombre;
                Datos.tbPedirDNI.Text = p.dni.ToString();

                /*El sentido de tbPedirDNI en este caso es mostrar el DNI pero no permitir que se modifique*/

                if(Datos.ShowDialog() == DialogResult.OK)
                {
                    string nombre = Datos.tbPedirNombre.Text;
                    p.nombre = nombre;

                    MessageBox.Show("Nombre modificado");

                }
            }
            else
            {
                MessageBox.Show("Error, no selecciono una persona");
            }
            Actualizar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            FormDatos Datos = new FormDatos();

            Persona p = servicio.verPersona(lbPersonas.SelectedIndex);

            if (p != null)
            {
                servicio.EliminarPersona(p);
                lbPersonas.Items.RemoveAt(lbPersonas.SelectedIndex);
                MessageBox.Show("Persona eliminada");
            }
            else
            {
                MessageBox.Show("Error, no selecciono una persona");
            }
        }
    }
}
