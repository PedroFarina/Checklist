namespace Checklist
{
    partial class TaskMaker
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
            this.rbOpenFolder = new System.Windows.Forms.RadioButton();
            this.gbAcao = new System.Windows.Forms.GroupBox();
            this.btnCriar = new System.Windows.Forms.Button();
            this.rbNull = new System.Windows.Forms.RadioButton();
            this.rbDica = new System.Windows.Forms.RadioButton();
            this.rbOpenFile = new System.Windows.Forms.RadioButton();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.gbAcao.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbOpenFolder
            // 
            this.rbOpenFolder.AutoSize = true;
            this.rbOpenFolder.Location = new System.Drawing.Point(6, 19);
            this.rbOpenFolder.Name = "rbOpenFolder";
            this.rbOpenFolder.Size = new System.Drawing.Size(75, 17);
            this.rbOpenFolder.TabIndex = 0;
            this.rbOpenFolder.TabStop = true;
            this.rbOpenFolder.Text = "Abrir pasta";
            this.rbOpenFolder.UseVisualStyleBackColor = true;
            // 
            // gbAcao
            // 
            this.gbAcao.Controls.Add(this.btnCriar);
            this.gbAcao.Controls.Add(this.rbNull);
            this.gbAcao.Controls.Add(this.rbDica);
            this.gbAcao.Controls.Add(this.rbOpenFile);
            this.gbAcao.Controls.Add(this.rbOpenFolder);
            this.gbAcao.Location = new System.Drawing.Point(12, 12);
            this.gbAcao.Name = "gbAcao";
            this.gbAcao.Size = new System.Drawing.Size(187, 99);
            this.gbAcao.TabIndex = 1;
            this.gbAcao.TabStop = false;
            this.gbAcao.Text = "Ação";
            // 
            // btnCriar
            // 
            this.btnCriar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCriar.Location = new System.Drawing.Point(55, 65);
            this.btnCriar.Name = "btnCriar";
            this.btnCriar.Size = new System.Drawing.Size(75, 23);
            this.btnCriar.TabIndex = 2;
            this.btnCriar.Text = "Criar";
            this.btnCriar.UseVisualStyleBackColor = true;
            this.btnCriar.Click += new System.EventHandler(this.btnCriar_Click);
            // 
            // rbNull
            // 
            this.rbNull.AutoSize = true;
            this.rbNull.Location = new System.Drawing.Point(98, 42);
            this.rbNull.Name = "rbNull";
            this.rbNull.Size = new System.Drawing.Size(51, 17);
            this.rbNull.TabIndex = 3;
            this.rbNull.TabStop = true;
            this.rbNull.Text = "Vazio";
            this.rbNull.UseVisualStyleBackColor = true;
            // 
            // rbDica
            // 
            this.rbDica.AutoSize = true;
            this.rbDica.Location = new System.Drawing.Point(6, 42);
            this.rbDica.Name = "rbDica";
            this.rbDica.Size = new System.Drawing.Size(83, 17);
            this.rbDica.TabIndex = 2;
            this.rbDica.TabStop = true;
            this.rbDica.Text = "Mostrar dica";
            this.rbDica.UseVisualStyleBackColor = true;
            // 
            // rbOpenFile
            // 
            this.rbOpenFile.AutoSize = true;
            this.rbOpenFile.Location = new System.Drawing.Point(98, 19);
            this.rbOpenFile.Name = "rbOpenFile";
            this.rbOpenFile.Size = new System.Drawing.Size(84, 17);
            this.rbOpenFile.TabIndex = 1;
            this.rbOpenFile.TabStop = true;
            this.rbOpenFile.Text = "Abrir arquivo";
            this.rbOpenFile.UseVisualStyleBackColor = true;
            // 
            // fileDialog
            // 
            this.fileDialog.FileName = "openFileDialog1";
            // 
            // TaskMaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 119);
            this.Controls.Add(this.gbAcao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TaskMaker";
            this.Text = "TaskMaker";
            this.gbAcao.ResumeLayout(false);
            this.gbAcao.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbOpenFolder;
        private System.Windows.Forms.GroupBox gbAcao;
        private System.Windows.Forms.RadioButton rbOpenFile;
        private System.Windows.Forms.RadioButton rbDica;
        private System.Windows.Forms.RadioButton rbNull;
        private System.Windows.Forms.Button btnCriar;
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
        private System.Windows.Forms.OpenFileDialog fileDialog;
    }
}