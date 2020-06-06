using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TESTEP
{
    public partial class PaginaInicial : Form
    {
        public PaginaInicial()
        {
            this.IsMdiContainer = true;
            InitializeComponent();
        }

        private void toolStripMenuIADM_Click(object sender, EventArgs e)
        {
            Area_Pessoal adm = new Area_Pessoal();
            adm.MdiParent = this;
            adm.Show();
            
        }

        private void toolStripMenuIReceitas_Click(object sender, EventArgs e)
        {
            Receitas rec = new Receitas();
            rec.MdiParent = this;
            rec.Show();

            
        }

        private void toolStripMenuUtilizador_Click(object sender, EventArgs e)
        {
            Utilizadores util = new Utilizadores();
            util.MdiParent = this;
            util.Show();
        }

        private void toolStripMenuIngredientes_Click(object sender, EventArgs e)
        {
            ingredientes ing = new ingredientes();
            ing.MdiParent = this;
            ing.Show();

        }

        private void toolStripMenuCat_Click(object sender, EventArgs e)
        {
            Categoria cat = new Categoria();
            cat.MdiParent = this;
            cat.Show();
        }

        private void toolStripMenuComen_Click(object sender, EventArgs e)
        {
            Comentarios com = new Comentarios();
            com.MdiParent = this;
            com.Show();
            
            

        }

        private void PaginaInicial_Load(object sender, EventArgs e)
        {
           
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Tem certeza que deseja sair do Sistema Receitas do Dia??", "A encerrar....", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) ;
            {
                this.Close();
                
            }

        }
    }
}
