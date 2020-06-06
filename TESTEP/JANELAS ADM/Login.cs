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

namespace TESTEP
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            passe.Visible = false;
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-SRU6BAD\SQLEXPRESS;Initial Catalog=Receitas;Integrated Security=True ");
        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            
            string query = "Select * FROM Administrador WHERE Email='"+txtemail.Text.Trim()+"'and [palavra-passe]='"+txtpasse.Text.Trim()+"'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable table = new DataTable();con.Open();
            adapter.Fill(table); 
            if(table.Rows.Count == 1)
            {
                
                PaginaInicial pg = new PaginaInicial();
                this.Hide();
                pg.Show();
                con.Close();
            
            }
            else
            {
                MessageBox.Show("Verifique seu email e senha", "Ups.. Dados Incorretos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            con.Open();
            SqlCommand cm = new SqlCommand("SELECT * FROM Administrador WHERE Email='" + txtemail.Text + "'", con);
            SqlDataReader reader = cm.ExecuteReader();
            if(reader.Read())
            {
                passe.Text = "Sua palavra-passe:" +" "+ reader.GetValue(2).ToString();
                passe.Visible = true;
                con.Close();
            }
            else
            {
                MessageBox.Show("Email incorreto", "CAMPO EMAIL VAZIO....",MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
            
        }
    }
}
