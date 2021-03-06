﻿namespace AFSport.WindowsForms.Formularios.Base
{
    partial class FrmCadastroBase
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
            this.components = new System.ComponentModel.Container();
            this.pnlmargin = new System.Windows.Forms.Panel();
            this.pnlNavBar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.BtnNovo = new System.Windows.Forms.Button();
            this.BtnAlterar = new System.Windows.Forms.Button();
            this.BtnDeletar = new System.Windows.Forms.Button();
            this.pnlmargin2 = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pnlNavBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlmargin
            // 
            this.pnlmargin.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlmargin.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlmargin.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlmargin.Location = new System.Drawing.Point(0, 0);
            this.pnlmargin.Margin = new System.Windows.Forms.Padding(4);
            this.pnlmargin.Name = "pnlmargin";
            this.pnlmargin.Size = new System.Drawing.Size(784, 14);
            this.pnlmargin.TabIndex = 0;
            // 
            // pnlNavBar
            // 
            this.pnlNavBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNavBar.Controls.Add(this.label1);
            this.pnlNavBar.Controls.Add(this.lblTitulo);
            this.pnlNavBar.Controls.Add(this.BtnNovo);
            this.pnlNavBar.Controls.Add(this.BtnAlterar);
            this.pnlNavBar.Controls.Add(this.BtnDeletar);
            this.pnlNavBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavBar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlNavBar.Location = new System.Drawing.Point(0, 14);
            this.pnlNavBar.Margin = new System.Windows.Forms.Padding(4);
            this.pnlNavBar.Name = "pnlNavBar";
            this.pnlNavBar.Padding = new System.Windows.Forms.Padding(6);
            this.pnlNavBar.Size = new System.Drawing.Size(784, 89);
            this.pnlNavBar.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(87, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 32);
            this.label1.TabIndex = 7;
            this.label1.Text = "Titulo";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Font Awesome 5 Free Solid", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitulo.Location = new System.Drawing.Point(24, 21);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(43, 36);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "";
            // 
            // BtnNovo
            // 
            this.BtnNovo.BackColor = System.Drawing.Color.White;
            this.BtnNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnNovo.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnNovo.FlatAppearance.BorderSize = 0;
            this.BtnNovo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BtnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNovo.Font = new System.Drawing.Font("Font Awesome 5 Free Solid", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNovo.ForeColor = System.Drawing.Color.Green;
            this.BtnNovo.Location = new System.Drawing.Point(440, 6);
            this.BtnNovo.Name = "BtnNovo";
            this.BtnNovo.Size = new System.Drawing.Size(112, 75);
            this.BtnNovo.TabIndex = 1;
            this.BtnNovo.Text = "";
            this.ToolTip.SetToolTip(this.BtnNovo, "Novo");
            this.BtnNovo.UseVisualStyleBackColor = false;
            this.BtnNovo.Click += new System.EventHandler(this.BtnNovo_Click);
            // 
            // BtnAlterar
            // 
            this.BtnAlterar.BackColor = System.Drawing.Color.White;
            this.BtnAlterar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAlterar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnAlterar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnAlterar.FlatAppearance.BorderSize = 0;
            this.BtnAlterar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.BtnAlterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAlterar.Font = new System.Drawing.Font("Font Awesome 5 Free Solid", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAlterar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BtnAlterar.Location = new System.Drawing.Point(552, 6);
            this.BtnAlterar.Name = "BtnAlterar";
            this.BtnAlterar.Size = new System.Drawing.Size(112, 75);
            this.BtnAlterar.TabIndex = 2;
            this.BtnAlterar.Text = "";
            this.ToolTip.SetToolTip(this.BtnAlterar, "Alterar");
            this.BtnAlterar.UseVisualStyleBackColor = false;
            this.BtnAlterar.Click += new System.EventHandler(this.BtnAlterar_Click);
            // 
            // BtnDeletar
            // 
            this.BtnDeletar.BackColor = System.Drawing.Color.White;
            this.BtnDeletar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDeletar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnDeletar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnDeletar.FlatAppearance.BorderSize = 0;
            this.BtnDeletar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BtnDeletar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDeletar.Font = new System.Drawing.Font("Font Awesome 5 Free Solid", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDeletar.ForeColor = System.Drawing.Color.Red;
            this.BtnDeletar.Location = new System.Drawing.Point(664, 6);
            this.BtnDeletar.Name = "BtnDeletar";
            this.BtnDeletar.Size = new System.Drawing.Size(112, 75);
            this.BtnDeletar.TabIndex = 3;
            this.BtnDeletar.Text = "";
            this.ToolTip.SetToolTip(this.BtnDeletar, "Apagar");
            this.BtnDeletar.UseVisualStyleBackColor = false;
            this.BtnDeletar.Click += new System.EventHandler(this.BtnDeletar_Click);
            // 
            // pnlmargin2
            // 
            this.pnlmargin2.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlmargin2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlmargin2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlmargin2.Location = new System.Drawing.Point(0, 103);
            this.pnlmargin2.Margin = new System.Windows.Forms.Padding(4);
            this.pnlmargin2.Name = "pnlmargin2";
            this.pnlmargin2.Size = new System.Drawing.Size(784, 14);
            this.pnlmargin2.TabIndex = 2;
            // 
            // pnlBody
            // 
            this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBody.Location = new System.Drawing.Point(0, 117);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(6);
            this.pnlBody.Size = new System.Drawing.Size(784, 444);
            this.pnlBody.TabIndex = 3;
            // 
            // FrmCadastroBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlmargin2);
            this.Controls.Add(this.pnlNavBar);
            this.Controls.Add(this.pnlmargin);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCadastroBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CadastroBase";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmCadastroBase_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCadastroBase_KeyDown);
            this.pnlNavBar.ResumeLayout(false);
            this.pnlNavBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        protected System.Windows.Forms.Button BtnNovo;
        protected System.Windows.Forms.Button BtnAlterar;
        protected System.Windows.Forms.Button BtnDeletar;
        protected System.Windows.Forms.Panel pnlmargin;
        protected System.Windows.Forms.Panel pnlNavBar;
        protected System.Windows.Forms.Panel pnlmargin2;
        protected System.Windows.Forms.Panel pnlBody;
        protected System.Windows.Forms.Label lblTitulo;
        protected System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip ToolTip;
    }
}