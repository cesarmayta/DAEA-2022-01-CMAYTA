using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Lab02_01
{
    public partial class frmLogin : Form
    {
        SqlConnection conn;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if(conn.State == ConnectionState.Open)
            {
                String strUsuario = txtUsuario.Text;
                String strPassword = txtPassword.Text;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "LoginUsuario";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter paramUsuario = new SqlParameter();
                paramUsuario.ParameterName = "@usuario";
                paramUsuario.SqlDbType = SqlDbType.NVarChar;
                paramUsuario.Value = strUsuario;

                cmd.Parameters.Add(paramUsuario);

                SqlParameter paramPassword = new SqlParameter();
                paramPassword.ParameterName = "@password";
                paramPassword.SqlDbType = SqlDbType.NVarChar;
                paramPassword.Value = strPassword;

                cmd.Parameters.Add(paramPassword);

                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                
                if (dt.Rows.Count >  0) 
                {
                    PrincipalMDI principal = new PrincipalMDI();
                    principal.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("datos incorrectos");
                }

            }

            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            conn.Close();
            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            String strConn = "Server=LOCAL\\LOCAL;Database=School;Integrated Security=true";
            try
            {
                conn = new SqlConnection(strConn);
                conn.Open();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al conectarse : \n " + ex.ToString());
            }

        }
    }
}
