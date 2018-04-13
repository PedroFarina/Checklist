namespace Checklist
{
    partial class frmPrincipal
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
            this.btnClose = new System.Windows.Forms.Button();
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            this.taskIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ActionsWatcher = new System.IO.FileSystemWatcher();
            this.gbChecklist = new System.Windows.Forms.GroupBox();
            this.lbCheck = new System.Windows.Forms.ListBox();
            this.pbUpperbar = new System.Windows.Forms.PictureBox();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.lbItems = new System.Windows.Forms.ListBox();
            this.StateWatcher = new System.IO.FileSystemWatcher();
            this.stripChecklist = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.adicionarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moverParaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ActionsWatcher)).BeginInit();
            this.gbChecklist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUpperbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StateWatcher)).BeginInit();
            this.stripChecklist.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(462, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(26, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // taskIcon
            // 
            this.taskIcon.Text = "Checklist";
            this.taskIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.taskIcon_MouseClick);
            // 
            // ActionsWatcher
            // 
            this.ActionsWatcher.EnableRaisingEvents = true;
            this.ActionsWatcher.SynchronizingObject = this;
            this.ActionsWatcher.Changed += new System.IO.FileSystemEventHandler(this.ActionsWatcher_Changed);
            this.ActionsWatcher.Created += new System.IO.FileSystemEventHandler(this.ActionsWatcher_Created);
            // 
            // gbChecklist
            // 
            this.gbChecklist.Controls.Add(this.lbCheck);
            this.gbChecklist.Location = new System.Drawing.Point(126, 53);
            this.gbChecklist.Name = "gbChecklist";
            this.gbChecklist.Size = new System.Drawing.Size(362, 198);
            this.gbChecklist.TabIndex = 2;
            this.gbChecklist.TabStop = false;
            this.gbChecklist.Text = "Checklist";
            // 
            // lbCheck
            // 
            this.lbCheck.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbCheck.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbCheck.Font = new System.Drawing.Font("Perpetua Titling MT", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCheck.FormattingEnabled = true;
            this.lbCheck.ItemHeight = 20;
            this.lbCheck.Location = new System.Drawing.Point(6, 19);
            this.lbCheck.Name = "lbCheck";
            this.lbCheck.Size = new System.Drawing.Size(350, 160);
            this.lbCheck.TabIndex = 0;
            this.lbCheck.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbCheck_DrawItem);
            this.lbCheck.DoubleClick += new System.EventHandler(this.lbCheck_DoubleClick);
            this.lbCheck.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lbCheck_KeyPress);
            // 
            // pbUpperbar
            // 
            this.pbUpperbar.Image = global::Checklist.Properties.Resources.upperbar;
            this.pbUpperbar.Location = new System.Drawing.Point(0, 0);
            this.pbUpperbar.Name = "pbUpperbar";
            this.pbUpperbar.Size = new System.Drawing.Size(500, 47);
            this.pbUpperbar.TabIndex = 3;
            this.pbUpperbar.TabStop = false;
            this.pbUpperbar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbUpperbar_MouseDown);
            this.pbUpperbar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbUpperbar_MouseMove);
            this.pbUpperbar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbUpperbar_MouseUp);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Location = new System.Drawing.Point(430, 12);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(26, 23);
            this.btnMinimize.TabIndex = 5;
            this.btnMinimize.Text = "-";
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // lbItems
            // 
            this.lbItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbItems.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbItems.FormattingEnabled = true;
            this.lbItems.Location = new System.Drawing.Point(12, 53);
            this.lbItems.Name = "lbItems";
            this.lbItems.Size = new System.Drawing.Size(108, 197);
            this.lbItems.Sorted = true;
            this.lbItems.TabIndex = 6;
            this.lbItems.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbItems_DrawItem);
            this.lbItems.SelectedIndexChanged += new System.EventHandler(this.lbItems_SelectedIndexChanged);
            // 
            // StateWatcher
            // 
            this.StateWatcher.EnableRaisingEvents = true;
            this.StateWatcher.SynchronizingObject = this;
            this.StateWatcher.Created += new System.IO.FileSystemEventHandler(this.StateWatcher_Created);
            // 
            // stripChecklist
            // 
            this.stripChecklist.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adicionarToolStripMenuItem,
            this.removerToolStripMenuItem,
            this.moverParaToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.stripChecklist.Name = "stripAdicionarRemover";
            this.stripChecklist.Size = new System.Drawing.Size(135, 92);
            this.stripChecklist.Opening += new System.ComponentModel.CancelEventHandler(this.stripAdicionarRemover_Opening);
            // 
            // adicionarToolStripMenuItem
            // 
            this.adicionarToolStripMenuItem.Name = "adicionarToolStripMenuItem";
            this.adicionarToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.adicionarToolStripMenuItem.Text = "Adicionar";
            this.adicionarToolStripMenuItem.Click += new System.EventHandler(this.adicionarToolStripMenuItem_Click);
            // 
            // removerToolStripMenuItem
            // 
            this.removerToolStripMenuItem.Name = "removerToolStripMenuItem";
            this.removerToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.removerToolStripMenuItem.Text = "Remover";
            this.removerToolStripMenuItem.Click += new System.EventHandler(this.removerToolStripMenuItem_Click);
            // 
            // moverParaToolStripMenuItem
            // 
            this.moverParaToolStripMenuItem.Name = "moverParaToolStripMenuItem";
            this.moverParaToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.moverParaToolStripMenuItem.Tag = "MoveTo";
            this.moverParaToolStripMenuItem.Text = "Mover Para";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(500, 263);
            this.Controls.Add(this.lbItems);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.gbChecklist);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pbUpperbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmPrincipal";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPrincipal_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ActionsWatcher)).EndInit();
            this.gbChecklist.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbUpperbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StateWatcher)).EndInit();
            this.stripChecklist.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolTip tip;
        private System.Windows.Forms.NotifyIcon taskIcon;
        private System.IO.FileSystemWatcher ActionsWatcher;
        private System.Windows.Forms.GroupBox gbChecklist;
        private System.Windows.Forms.PictureBox pbUpperbar;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.ListBox lbCheck;
        private System.Windows.Forms.ListBox lbItems;
        private System.IO.FileSystemWatcher StateWatcher;
        private System.Windows.Forms.ContextMenuStrip stripChecklist;
        private System.Windows.Forms.ToolStripMenuItem adicionarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moverParaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}

