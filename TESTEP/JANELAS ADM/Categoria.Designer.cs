namespace TESTEP
{
    partial class Categoria
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
            this.dataGridCategoria = new System.Windows.Forms.DataGridView();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Atualizar = new System.Windows.Forms.Button();
            this.deletar = new System.Windows.Forms.Button();
            this.Inserir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCategoria)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridCategoria
            // 
            this.dataGridCategoria.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridCategoria.BackgroundColor = System.Drawing.Color.Silver;
            this.dataGridCategoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCategoria.Location = new System.Drawing.Point(329, 27);
            this.dataGridCategoria.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridCategoria.Name = "dataGridCategoria";
            this.dataGridCategoria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridCategoria.Size = new System.Drawing.Size(529, 408);
            this.dataGridCategoria.TabIndex = 0;
            this.dataGridCategoria.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridCategoria_CellClick);
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(164, 62);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(148, 25);
            this.txtNome.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nome da Categoria";
            // 
            // Atualizar
            // 
            this.Atualizar.BackColor = System.Drawing.Color.Silver;
            this.Atualizar.Location = new System.Drawing.Point(200, 174);
            this.Atualizar.Name = "Atualizar";
            this.Atualizar.Size = new System.Drawing.Size(80, 30);
            this.Atualizar.TabIndex = 3;
            this.Atualizar.Text = "Atualizar";
            this.Atualizar.UseVisualStyleBackColor = false;
            this.Atualizar.Click += new System.EventHandler(this.Atualizar_Click);
            // 
            // deletar
            // 
            this.deletar.BackColor = System.Drawing.Color.Silver;
            this.deletar.Location = new System.Drawing.Point(200, 214);
            this.deletar.Name = "deletar";
            this.deletar.Size = new System.Drawing.Size(80, 30);
            this.deletar.TabIndex = 5;
            this.deletar.Text = "Deletar";
            this.deletar.UseVisualStyleBackColor = false;
            this.deletar.Click += new System.EventHandler(this.deletar_Click);
            // 
            // Inserir
            // 
            this.Inserir.BackColor = System.Drawing.Color.Silver;
            this.Inserir.Location = new System.Drawing.Point(200, 134);
            this.Inserir.Name = "Inserir";
            this.Inserir.Size = new System.Drawing.Size(80, 30);
            this.Inserir.TabIndex = 6;
            this.Inserir.Text = "Inserir";
            this.Inserir.UseVisualStyleBackColor = false;
            this.Inserir.Click += new System.EventHandler(this.Inserir_Click);
            // 
            // Categoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(871, 661);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.dataGridCategoria);
            this.Controls.Add(this.Inserir);
            this.Controls.Add(this.deletar);
            this.Controls.Add(this.Atualizar);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Categoria";
            this.Text = "Categorias";
            this.Load += new System.EventHandler(this.Categoria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCategoria)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridCategoria;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Atualizar;

        private System.Windows.Forms.Button deletar;
        private System.Windows.Forms.Button Inserir;
    }
}