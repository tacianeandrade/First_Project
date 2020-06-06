using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Drawing.Imaging;

namespace TESTEP
{
    public partial class Utilizadores : Form
    {

        
        public Utilizadores()
        {
            InitializeComponent();
            pendentes.Visible = false;

        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-SRU6BAD\SQLEXPRESS;Initial Catalog=Receitas;Integrated Security=True ");
        Bitmap bpm;
        public int IDUtilizador;

        private void Utilizadores_Load(object sender, EventArgs e)
        {
           
            GetUtilizadorRecord();
        }

   
        #region GetUtil
        private void GetUtilizadorRecord()
        {


            SqlCommand cmd = new SqlCommand("Select * from Utilizadores", con);
            DataTable dt = new DataTable();
            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            dataGridUtil.DataSource = dt;


        }


        private void todosUtilizadoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GetUtilizadorRecord();
            pendentes.Visible = false;

        }
        #endregion


        #region UtilPendentes


        private void GetUtilizadoresPendentes()
        {
            SqlCommand pendentes = new SqlCommand("Select * from Utilizadores Where Status = '0' ", con);
            DataTable dt = new DataTable();
            con.Open();

            SqlDataReader sdr = pendentes.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            dataGridUtil.DataSource = dt;
        }


        private void utilizadoresPendentesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GetUtilizadoresPendentes();
            pendentes.Visible = true;
        }

        #endregion


        #region Inserir 
        private void btnInserir_Click(object sender, EventArgs e)
        {        
            
            if (IsValid())
            {
                byte[] imagem = ImageToByte2(pictureBox1.Image);

                SqlCommand cmd = new SqlCommand("Insert INTO Utilizadores (Nome, Email,Passe, Foto, Status) VALUES (@nome, @email, @passe,@imagem, @status)", con);
                 cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@nome", textBox1.Text);
                 cmd.Parameters.AddWithValue("@email", textBox6.Text);
                 cmd.Parameters.AddWithValue("@passe", textBox2.Text);
                cmd.Parameters.AddWithValue("@imagem", imagem);
                cmd.Parameters.AddWithValue("@status", textBox3.Text);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Utilizador adicionado com sucesso a base de dados", "Inserir....", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetUtilizadorRecord();
                ClearALL();
            }
        }


        private bool IsValid()
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Preencher todos os campos para submeter um novo utilizador", "UPS...Falta Algo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        #endregion

        
        #region LImpar
        private void ClearALL()
        {
            textBox1.Clear(); pictureBox1.Image = null;
            textBox2.Clear(); textBox3.Clear(); textBox6.Clear();
        }

    
     private void Limpar_Click(object sender, EventArgs e)
        {
            ClearALL();
        }

        #endregion

        
        #region Atualizar
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (IDUtilizador > 0)
            {
                byte[] imagem = ImageToByte2(pictureBox1.Image);

                SqlCommand cmd = new SqlCommand("UPDATE Utilizadores SET nome = @nome, email = @email, Passe = @passe, Foto= @foto, status = @status  WHERE ID_Utilizador = @ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@nome", textBox1.Text);
                cmd.Parameters.AddWithValue("@email", textBox6.Text);
                cmd.Parameters.AddWithValue("@passe", textBox2.Text);
                cmd.Parameters.AddWithValue("@status", textBox3.Text);
                cmd.Parameters.AddWithValue("@foto",imagem);
                cmd.Parameters.AddWithValue("@ID", this.IDUtilizador);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


                MessageBox.Show("Utilizador atualizado com sucesso!!", "Atualizando....", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetUtilizadorRecord();
                ClearALL();
            }
            else
            {
                MessageBox.Show("Por favor selecione um Utilizador para atualizar!!", "Selecione....", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        
        #region Deletar
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (IDUtilizador > 0)
            {


                if (MessageBox.Show("Tem Certeza que deseja excluir este Utilizador?", "Deletar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Utilizadores WHERE ID_Utilizador = @ID", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", this.IDUtilizador);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Utilizador deletado com sucesso!!", "Atualizando....", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetUtilizadorRecord();
                    ClearALL();
                }              
            }
            else
            {
                MessageBox.Show("Por favor selecione um Utilizador para deletar!!", "Selecione....", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        
        #region DataGridView
        private void dataGridUtil_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pictureBox1.Image = null;
            int cell = e.ColumnIndex;


            IDUtilizador = Convert.ToInt32(dataGridUtil.SelectedRows[0].Cells[0].Value);
            textBox1.Text = dataGridUtil.SelectedRows[0].Cells[1].Value.ToString();
            textBox6.Text = dataGridUtil.SelectedRows[0].Cells[2].Value.ToString();
            textBox2.Text = dataGridUtil.SelectedRows[0].Cells[3].Value.ToString();
            textBox3.Text = dataGridUtil.SelectedRows[0].Cells[5].Value.ToString();


            if(dataGridUtil.SelectedRows[0].Cells[4].Value !=DBNull.Value)
            {
                MemoryStream nome = new MemoryStream((byte[])dataGridUtil.SelectedRows[0].Cells[4].Value);
                pictureBox1.Image = Image.FromStream(nome);
            }
                      
        }
        #endregion

       
        #region Imagens
        private void BusarFoto_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string nome = openFileDialog1.FileName;
               bpm = new Bitmap(nome);
                pictureBox1.Image = bpm;
            }
        }


        private byte[] ImageToByte2(Image image)
        {
            MemoryStream stream = new MemoryStream();

            image.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
            return stream.ToArray();

        }



        #endregion



    }


}
