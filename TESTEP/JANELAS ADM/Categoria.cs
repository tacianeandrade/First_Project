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
    public partial class Categoria : Form
    {
        public Categoria()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-SRU6BAD\SQLEXPRESS;Initial Catalog=Receitas;Integrated Security=True ");
        public int CategoriaID;
        private void Categoria_Load(object sender, EventArgs e)
        {
            GetCategoriaRecord();
        }

        private void GetCategoriaRecord()
        {
            SqlCommand cmd = new SqlCommand("Select * From Categorias", con);
            DataTable dt = new DataTable();
            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            dataGridCategoria.DataSource = dt;
        }

        private void Inserir_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("Insert INTO Categorias (Nome) VALUES (@nome)", con);
                cmd.CommandType = CommandType.Text;
                //  cmd.Parameters.AddWithValue("@id_ingrediente", txtID.Text);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


                MessageBox.Show("Categoria adicionada com sucesso a base de dados", "Inserir....", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetCategoriaRecord();
                Clear();
            }
        }

        private bool IsValid()
        {
            if (txtNome.Text == string.Empty)
            {
                MessageBox.Show("Adicione um nome para esta Categoria", "UPS...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void Clear()
        {
            txtNome.Clear();
        }

        private void dataGridCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CategoriaID = Convert.ToInt32(dataGridCategoria.SelectedRows[0].Cells[0].Value);
            txtNome.Text = dataGridCategoria.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void Atualizar_Click(object sender, EventArgs e)
        {
            if (CategoriaID > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE Categorias SET nome = @nome WHERE ID_Categoria = @ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@ID", this.CategoriaID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


                MessageBox.Show("Categoria atualizada com sucesso!!", "Atualizando....", MessageBoxButtons.OK, MessageBoxIcon.Information);
               GetCategoriaRecord();
                Clear();
            }
            else
            {
                MessageBox.Show("Por favor selecione uma categoria para atualizar!!", "Selecione....", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void deletar_Click(object sender, EventArgs e)
        {
            if (CategoriaID > 0)
            {
                if (MessageBox.Show("Tem Certeza que deseja excluir esta Categoria?", "Deletar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Categorias  WHERE ID_Categoria = @ID", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", this.CategoriaID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();


                    MessageBox.Show("Categoria deletada com sucesso!!", "Atualizando....", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetCategoriaRecord();
                    Clear();
                }

            }
            else
            {
                MessageBox.Show("Por favor selecione uma Categoria para deletar!!", "Selecione....", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
