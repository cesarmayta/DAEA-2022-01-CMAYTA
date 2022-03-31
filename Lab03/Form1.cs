using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lab03
{
    public partial class Form1 : Form
    {
        //SqlConnection nos permite manejar el acceso al servidor
        SqlConnection conn;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            //declaramos variables para almacenar los valores de los texbox
            //y definimos una cadena de conexión
            String servidor = txtServidor.Text;
            String bd = txtBaseDatos.Text;
            String user = txtUsuario.Text;
            String pwd = txtPassword.Text;

            String str = "Server=" + servidor + ";Database=" + bd + ";";

            //La cadena de conexión cambia en función del estado del checkbox
            if (chkAutenticacion.Checked)
                str += "Integrated Security=true";
            else
                str += "User Id=" + user + ";Password=" + pwd + ";";

            //Abrir una conexión con el servidor usando la cadena de conexión
            try
            {
                conn = new SqlConnection(str);
                conn.Open();
                MessageBox.Show("Conectado Satisfactoriamente");
                btnDesconectar.Enabled = true;

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al conectar al servidor : \n" + ex.ToString());
            }
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            frmUsuarios usuario = new frmUsuarios(conn);
            usuario.Show();
        }
    }
}
