namespace TESTEP
{
    partial class PaginaInicial
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaginaInicial));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuIADM = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuIReceitas = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuUtilizador = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuIngredientes = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuCat = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuComen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuIADM,
            this.toolStripMenuIReceitas,
            this.toolStripMenuUtilizador,
            this.toolStripMenuIngredientes,
            this.toolStripMenuCat,
            this.toolStripMenuComen});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuIADM
            // 
            this.toolStripMenuIADM.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairToolStripMenuItem});
            this.toolStripMenuIADM.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuIADM.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuIADM.Image")));
            this.toolStripMenuIADM.Name = "toolStripMenuIADM";
            this.toolStripMenuIADM.Size = new System.Drawing.Size(114, 20);
            this.toolStripMenuIADM.Text = "Área Pessoal";
            this.toolStripMenuIADM.Click += new System.EventHandler(this.toolStripMenuIADM_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // toolStripMenuIReceitas
            // 
            this.toolStripMenuIReceitas.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuIReceitas.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuIReceitas.Image")));
            this.toolStripMenuIReceitas.Name = "toolStripMenuIReceitas";
            this.toolStripMenuIReceitas.Size = new System.Drawing.Size(87, 20);
            this.toolStripMenuIReceitas.Text = "Receitas";
            this.toolStripMenuIReceitas.Click += new System.EventHandler(this.toolStripMenuIReceitas_Click);
            // 
            // toolStripMenuUtilizador
            // 
            this.toolStripMenuUtilizador.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuUtilizador.Image")));
            this.toolStripMenuUtilizador.Name = "toolStripMenuUtilizador";
            this.toolStripMenuUtilizador.Size = new System.Drawing.Size(85, 20);
            this.toolStripMenuUtilizador.Text = "Utilizador";
            this.toolStripMenuUtilizador.Click += new System.EventHandler(this.toolStripMenuUtilizador_Click);
            // 
            // toolStripMenuIngredientes
            // 
            this.toolStripMenuIngredientes.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuIngredientes.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuIngredientes.Image")));
            this.toolStripMenuIngredientes.Name = "toolStripMenuIngredientes";
            this.toolStripMenuIngredientes.Size = new System.Drawing.Size(106, 20);
            this.toolStripMenuIngredientes.Text = "Ingredientes";
            this.toolStripMenuIngredientes.Click += new System.EventHandler(this.toolStripMenuIngredientes_Click);
            // 
            // toolStripMenuCat
            // 
            this.toolStripMenuCat.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuCat.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuCat.Image")));
            this.toolStripMenuCat.Name = "toolStripMenuCat";
            this.toolStripMenuCat.Size = new System.Drawing.Size(98, 20);
            this.toolStripMenuCat.Text = "Categorias";
            this.toolStripMenuCat.Click += new System.EventHandler(this.toolStripMenuCat_Click);
            // 
            // toolStripMenuComen
            // 
            this.toolStripMenuComen.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuComen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuComen.Image")));
            this.toolStripMenuComen.Name = "toolStripMenuComen";
            this.toolStripMenuComen.Size = new System.Drawing.Size(113, 20);
            this.toolStripMenuComen.Text = "Comentários ";
            this.toolStripMenuComen.Click += new System.EventHandler(this.toolStripMenuComen_Click);
            // 
            // PaginaInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PaginaInicial";
            this.Text = "Pagina Inicial";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Load += new System.EventHandler(this.PaginaInicial_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuIADM;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuIReceitas;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuUtilizador;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuIngredientes;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuCat;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuComen;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
    }
}