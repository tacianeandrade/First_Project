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
    public partial class Comentarios : Form
    {
        public Comentarios()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-SRU6BAD\SQLEXPRESS;Initial Catalog=Receitas;Integrated Security=True ");
        public int IDUtil;

        private void Comentarios_Load(object sender, EventArgs e)
        {
            getComRecord();
        }

        //Buscar a table UTIL/RECEITA com os comentarios
        private void getComRecord()
        {        
                SqlCommand cmd = new SqlCommand("Select * from UtilizadorReceita", con);
                DataTable dt = new DataTable();
                con.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                con.Close();
                dataGridComentario.DataSource = dt;           
        }

        private void dataGridComentario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            IDUtil= Convert.ToInt32(dataGridComentario.SelectedRows[0].Cells[0].Value);
            txtNota.Text = dataGridComentario.SelectedRows[0].Cells[2].Value.ToString();
            richTextBox1.Text = dataGridComentario.SelectedRows[0].Cells[3].Value.ToString();
        }

        //DELETAR
        #region
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (IDUtil > 0)
            {

                if (MessageBox.Show("Tem Certeza que deseja excluir este Comentário?", "Deletar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    SqlCommand cmd = new SqlCommand("DELETE FROM UtilizadorReceita  WHERE IDUtilizador = @ID", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("ID", this.IDUtil);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Comentário deletado com sucesso da base de dados", "Excluindo....", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getComRecord();
                    
                }
            }
            else
            {
                MessageBox.Show("Selecione  um Comentário para deletar", "UPS....", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        //ATUALIZAR
        #region
        private void Atualizar_Click(object sender, EventArgs e)
        {

            if (IDUtil > 0)
            {
               

                SqlCommand cmd = new SqlCommand("UPDATE UtilizadorReceita SET Nota=@nota, Comentario=@com WHERE ID_Utilizador = @ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@nota", txtNota.Text);
                cmd.Parameters.AddWithValue("@com", richTextBox1.Text);
                cmd.Parameters.AddWithValue("ID", this.IDUtil);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


                MessageBox.Show("Comentário atualizadO com sucesso a base de dados", "Atualizando....", MessageBoxButtons.OK, MessageBoxIcon.Information);
               getComRecord();
                

            }
            else
            {
                MessageBox.Show("Selecione um Comentário para atualizar", "UPS....", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
