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
using System.IO;
using System.Drawing.Imaging;

namespace TESTEP
{
    public partial class Area_Pessoal : Form
    {
        public Area_Pessoal()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-SRU6BAD\SQLEXPRESS;Initial Catalog=Receitas;Integrated Security=True ");


        private void Area_Pessoal_Load(object sender, EventArgs e)
        {
            GetAdmRecord();
        }

        private bool IsValid()
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Selecione uma conta", "UPS...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void GetAdmRecord()
        {
            SqlCommand cmd = new SqlCommand("Select * from Administrador", con);
            DataTable dt = new DataTable();
            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("UPDATE Administrador SET Nome= @nome, Email=@email, [Palavra-passe] = @senha", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@nome", textBox1.Text);
                cmd.Parameters.AddWithValue("@email", textBox2.Text);
                cmd.Parameters.AddWithValue("@senha", textBox3.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


                MessageBox.Show("Dados atualizados com sucesso!!", "Atualizando....", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetAdmRecord();
                ClearALL();
            }
        }
        private void ClearALL()
        {
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem Certeza que deseja excluir este Adm?", "Deletar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Administrador WHERE Nome= @nome", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@nome", textBox1.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Conta deletada com sucesso!!", "Atualizando....", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetAdmRecord();
                ClearALL();
            }

            else
            {
                MessageBox.Show("Por favor selecione um Utilizador para deletar!!", "Selecione....", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Administrador (Nome, Email,[Palavra-passe] ) VALUES (@nome, @email, @senha)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@nome", textBox1.Text);
                cmd.Parameters.AddWithValue("@email", textBox2.Text);
                cmd.Parameters.AddWithValue("@senha", textBox3.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


                MessageBox.Show("Dados Inseridos com sucesso!!", "Atualizando....", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetAdmRecord();
                ClearALL();
            }
        }
    }
}
