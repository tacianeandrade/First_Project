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
    public partial class ingredientes : Form
    {
        public ingredientes()
        {
            InitializeComponent();
        }
        
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-SRU6BAD\SQLEXPRESS;Initial Catalog=Receitas;Integrated Security=True ");
        public int IngredienteID;
        private void ingredientes_Load(object sender, EventArgs e)
        {
            GetIngredientesRecord();
        }

        private void GetIngredientesRecord()
        {
           
            SqlCommand cmd = new SqlCommand("Select * from Ingredientes", con);
            DataTable dt = new DataTable();
            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            dataGridIngredientes.DataSource = dt;
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
           
            if(IsValid())
            {
                SqlCommand cmd = new SqlCommand("Insert INTO Ingredientes (NomeIngrediente, Quantidade) VALUES (@nomeingrediente,@quantidade)", con);
                cmd.CommandType = CommandType.Text;
              //  cmd.Parameters.AddWithValue("@id_ingrediente", txtID.Text);
                cmd.Parameters.AddWithValue("@nomeingrediente", txtNome.Text);
                cmd.Parameters.AddWithValue("@quantidade", txtQuant.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


                MessageBox.Show("Ingrediente adicionado com sucesso a base de dados", "Inserir....", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetIngredientesRecord();
                Limpar();
            }
        }
        private bool IsValid()
        {
            if(txtNome.Text == string.Empty)
            {
                MessageBox.Show("Adicione um nome para o ingrediente", "UPS...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void Limpar()
        {
            IngredienteID = 0;  txtNome.Clear(); txtQuant.Clear(); txtNome.Focus();
        }

        private void dataGridIngredientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IngredienteID = Convert.ToInt32(dataGridIngredientes.SelectedRows[0].Cells[0].Value);
            txtNome.Text = dataGridIngredientes.SelectedRows[0].Cells[1].Value.ToString();
            txtQuant.Text = dataGridIngredientes.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (IngredienteID > 0)
             {
                SqlCommand cmd = new SqlCommand("UPDATE Ingredientes SET nomeIngrediente = @nomeingrediente, Quantidade = @quantidade WHERE ID_Ingrediente = @ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@nomeingrediente", txtNome.Text);
                cmd.Parameters.AddWithValue("@quantidade", txtQuant.Text);
                cmd.Parameters.AddWithValue("@ID", this.IngredienteID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


                MessageBox.Show("Ingrediente atualizado com sucesso!!", "Atualizando....", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetIngredientesRecord();
                Limpar();
            }
            else
            {
                MessageBox.Show("Por favor selecione um ingrediente para atualizar!!", "Selecione....", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (IngredienteID > 0)
            {
                if (MessageBox.Show("Tem Certeza que deseja excluir este Ingrediente?", "Deletar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Ingredientes  WHERE ID_Ingrediente = @ID", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", this.IngredienteID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();


                    MessageBox.Show("Ingrediente deletado com sucesso!!", "Atualizando....", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetIngredientesRecord();
                    Limpar();
                }
                
            }
            else
            {
                MessageBox.Show("Por favor selecione um ingrediente para deletar!!", "Selecione....", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
