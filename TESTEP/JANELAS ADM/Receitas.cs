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
    public partial class Receitas : Form
    {

        public Receitas()
        {
            InitializeComponent();
            pendentes.Visible = false;

        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-SRU6BAD\SQLEXPRESS;Initial Catalog=Receitas;Integrated Security=True ");
        public int IDReceita;
        Bitmap bpm;

        private void Receitas_Load(object sender, EventArgs e)
        {
            GetReceitaRecord();

        }

         
        #region GetReceitas
        private void GetReceitaRecord()
        {
            SqlCommand cmd = new SqlCommand("Select * from Receitas", con);
            DataTable dt = new DataTable();
            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            dataGridReceitas.DataSource = dt;
        }
        private void todasAsReceitasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            GetReceitaRecord();
            pendentes.Visible = false;
        }
        #endregion


        #region GetReceitasPendentes


        private void GetReceitasPendentes()
        {
            SqlCommand pendentes = new SqlCommand("Select * from Receitas Where Status = '0' ", con);
            DataTable dt = new DataTable();
            con.Open();

            SqlDataReader sdr = pendentes.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            dataGridReceitas.DataSource = dt;
        }

        private void receitasPendentesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            GetReceitasPendentes();
            pendentes.Visible = true;
        }

        #endregion


        #region Inserir
        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                byte[] imagem = ImageToByte2(pictureBox1.Image);

                SqlCommand cmd = new SqlCommand("Insert INTO Receitas (NomeReceita,Descricao,ModoPreparo,Dificuldade,Duracao,Categoria, Foto, Status) VALUES (@nome, @descricao, @modopre,@dificuldade,@duracao, @categoria, @imagem, @status)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text);
                cmd.Parameters.AddWithValue("@modopre", richModoDePreparo.Text);
                cmd.Parameters.AddWithValue("@dificuldade", txtDificuldade.Text);
                cmd.Parameters.AddWithValue("@duracao", txtDuracao.Text);
                cmd.Parameters.AddWithValue("@categoria", txtCategoria.Text);
                cmd.Parameters.AddWithValue("@imagem", imagem);
                cmd.Parameters.AddWithValue("@status", txtStatus.Text); 
               


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


                MessageBox.Show("Receita adicionada com sucesso a base de dados", "Inserir....", MessageBoxButtons.OK, MessageBoxIcon.Information);
               GetReceitaRecord();
                ClearALL();
            }
        }
       
        private bool IsValid()
        {
            if (txtNome.Text == string.Empty)
            {
                MessageBox.Show("Preencher todos os campos para submeter uma nova Receita! " , "UPS...Falta algo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        #endregion
      
        #region Limpar
        private void ClearALL()
        {
            txtCategoria.Clear(); txtNome.Clear(); txtStatus.Clear(); txtDuracao.Clear(); txtDificuldade.Clear(); txtDescricao.Clear(); richModoDePreparo.Clear(); pictureBox1.Image = null;
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearALL();

        }
        #endregion

   
        #region GridView
        private void dataGridReceitas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pictureBox1.Image = null;
            int cell = e.ColumnIndex;

            txtNome.Text = dataGridReceitas.SelectedRows[0].Cells[0].Value.ToString();
            IDReceita = Convert.ToInt32(dataGridReceitas.SelectedRows[0].Cells[1].Value);
            txtDescricao.Text = dataGridReceitas.SelectedRows[0].Cells[2].Value.ToString();
            richModoDePreparo.Text = dataGridReceitas.SelectedRows[0].Cells[3].Value.ToString();
            txtDificuldade.Text = dataGridReceitas.SelectedRows[0].Cells[4].Value.ToString();
            txtDuracao.Text = dataGridReceitas.SelectedRows[0].Cells[5].Value.ToString();
            txtCategoria.Text = dataGridReceitas.SelectedRows[0].Cells[6].Value.ToString();
            txtStatus.Text = dataGridReceitas.SelectedRows[0].Cells[8].Value.ToString();

            if (dataGridReceitas.SelectedRows[0].Cells[7].Value != DBNull.Value)
            {
                MemoryStream nome = new MemoryStream((byte[])dataGridReceitas.SelectedRows[0].Cells[7].Value);
                pictureBox1.Image = Image.FromStream(nome);
            }
        }
        #endregion
        
        #region Atualizar
        private void button3_Click(object sender, EventArgs e)
        {
            if (IDReceita > 0 )        
            {
                byte[] imagem = ImageToByte2(pictureBox1.Image);

                SqlCommand cmd = new SqlCommand("UPDATE Receitas SET NomeReceita = @nome,Descricao= @descricao,ModoPreparo= @modopre,Dificuldade= @dificuldade ,Duracao= @duracao ,Categoria= @categoria,Foto =@imagem, Status= @status WHERE ID_Receita = @ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text);
                cmd.Parameters.AddWithValue("@modopre", richModoDePreparo.Text);
                cmd.Parameters.AddWithValue("@dificuldade", txtDificuldade.Text);
                cmd.Parameters.AddWithValue("@duracao", txtDuracao.Text);
                cmd.Parameters.AddWithValue("@categoria", txtCategoria.Text);
                cmd.Parameters.AddWithValue("@imagem", imagem);
                cmd.Parameters.AddWithValue("@status", txtStatus.Text);
                cmd.Parameters.AddWithValue("ID", this.IDReceita);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


                MessageBox.Show("Receita atualizada com sucesso a base de dados", "Atualizando....", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetReceitaRecord();
                ClearALL();

            }
            else
            {
                MessageBox.Show("Selecione uma receita para atualizar", "UPS....", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        
        #region Deletar
        private void button4_Click(object sender, EventArgs e)
        {
            if (IDReceita > 0)
            {

                if (MessageBox.Show("Tem Certeza que deseja excluir esta Receita?", "Deletar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    SqlCommand cmd = new SqlCommand("DELETE FROM Receitas  WHERE IDReceita = @ID", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("ID", this.IDReceita);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Receita Deletada com sucesso a base de dados", "Excluindo....", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetReceitaRecord();
                    ClearALL();
                }
            }
            else
            {
                MessageBox.Show("Selecione uma receita para deletar", "UPS....", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        
        #region Imagens
        private void button1_Click_1(object sender, EventArgs e)
        {//buscar foto
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string nome = openFileDialog1.FileName;
                bpm = new Bitmap(nome);
                pictureBox1.Image = bpm;
            }
        }


        private byte[] ImageToByte2(Image image)
        {//converter a imagem
            MemoryStream stream = new MemoryStream();

            image.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
            return stream.ToArray();

        }

        #endregion



    }

}
