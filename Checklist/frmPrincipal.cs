using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Checklist.Classes.Propriedades;
using Checklist.Classes;
using MyInputBox;
using System.Text.RegularExpressions;
using System.IO;

namespace Checklist
{
    public partial class frmPrincipal : Form
    {
        private bool Moving { get; set; }
        private Point mouseLocation;
        private Classes.Checklist CheckAtiva = null;
        public frmPrincipal()
        {
            InitializeComponent();
            ActionsWatcher.Path = PastaChecklists;
            WritingStateChanged += ChecklistExtensions.WritingChanged;
        }


        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.Icon;
            taskIcon.Icon = Properties.Resources.Icon;
            foreach (string file in Directory.GetFiles(PastaChecklists))
            {
                lbItems.Items.Add(lbDisplay.Create(file));
            }
            var regexItem = new Regex("^[a-zA-Z]*$");
            if (!System.Diagnostics.Debugger.IsAttached)
            {
                if (Properties.Settings.Default.Nome == "")
                {
                    string nome = "";
                    while (nome == "")
                    {
                        nome = InputBox.Show("", "Digite seu nome:");
                        if (!regexItem.IsMatch(nome))
                        {
                            nome = "";
                        }
                    }
                    Properties.Settings.Default.Nome = nome;
                    Properties.Settings.Default.Save();
                    ChecklistExtensions.GenerateCheckList(nome, false);
                }
            }
            MessageBox.Show("Bem vindo " + Properties.Settings.Default.Nome + "!");
            ActionsWatcher.Path = PastaChecklists;
        }
        #region Moving
        private void pbUpperbar_MouseDown(object sender, MouseEventArgs e)
        {
            Moving = true;
            mouseLocation = new Point(-e.X, -e.Y);
        }
        private void pbUpperbar_MouseUp(object sender, MouseEventArgs e)
        {
            Moving = false;
        }
        private void pbUpperbar_MouseMove(object sender, MouseEventArgs e)
        {
            if (Moving)
            {
                Point mousePos = MousePosition;
                mousePos.Offset(mouseLocation);
                Location = mousePos;
            }
        }
        #endregion
        #region Behavior
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            Visible = false;
            taskIcon.Visible = true;
            taskIcon.BalloonTipText = "Programa minimizado com sucesso.";
            taskIcon.ShowBalloonTip(50);
        }
        private void taskIcon_MouseClick(object sender, MouseEventArgs e)
        {
            taskIcon.Visible = false;
            Visible = true;
            WindowState = FormWindowState.Normal;
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == NativeMethods.WM_SHOWME)
            {
                this.ShowMe();
            }
            else if (m.Msg == NativeMethods.WM_CLOSEME)
            {
                Close();
            }
        }
        private void lbCheck_DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox lb = sender as ListBox;
            if (e.Index < 0) return;
            object addedItem = lb.Items[e.Index];
            Color c = ChecklistExtensions.GetColor(addedItem);
            Brush b = Brushes.Black;
            //if the item state is selected them change the back color
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e = new DrawItemEventArgs(e.Graphics,
                                          e.Font,
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                          e.ForeColor,
                                          Color.Black);//Choose the color
                b = new SolidBrush(c);
            }
            else if ((e.State & DrawItemState.NoFocusRect) == DrawItemState.NoFocusRect)
            {
                e = new DrawItemEventArgs(e.Graphics,
                                          e.Font,
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.NoFocusRect,
                                          e.ForeColor,
                                          c);//Choose the color
            }
            // Draw the background of the ListBox control for each item.
            e.DrawBackground();
            // Draw the current item text
            e.Graphics.DrawString(addedItem.ToString(), e.Font, b, e.Bounds, StringFormat.GenericDefault);
            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }
        private void lbItems_DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox lb = sender as ListBox;
            if (e.Index < 0) return;
            //if the item state is selected them change the back color 
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e = new DrawItemEventArgs(e.Graphics,
                                          e.Font,
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                          e.ForeColor,
                                          Color.LightSteelBlue);//Choose the color
            // Draw the background of the ListBox control for each item.
            e.DrawBackground();
            // Draw the current item text
            e.Graphics.DrawString(lb.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }
        #endregion
        #region Actions
        private void lbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lb = sender as ListBox;
            if (lb.SelectedIndex != -1)
            {
                string path = lbDisplay.GetPath(lb.SelectedItem);
                CheckAtiva = ChecklistExtensions.ReadChecklist(path);
                if (CheckAtiva.Accessible)
                {
                    lbCheck.ContextMenuStrip = stripChecklist;
                }
                else
                {
                    lbCheck.ContextMenuStrip = null;
                }
                lbCheck.DataSource = CheckAtiva.GetList();
            }
            lbCheck.Focus();
        }
        private void lbCheck_DoubleClick(object sender, EventArgs e)
        {
            CheckAtiva.Editar(lbCheck.SelectedItem);
        }
        private void lbCheck_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                CheckAtiva.Editar(lbCheck.SelectedItem);
            }
        }

        private void StateWatcher_Created(object sender, FileSystemEventArgs e)
        {
            Writing = Convert.ToBoolean(e.Name.Split('.')[0]);
        }
        private void ActionsWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (CheckAtiva?.Path == e.FullPath)
            {
                CheckAtiva = ChecklistExtensions.ReadChecklist(e.FullPath);
                lbCheck.DataSource = CheckAtiva.GetList();
            }
        }
        private void ActionsWatcher_Created(object sender, FileSystemEventArgs e)
        {
            lbItems.Items.Add(lbDisplay.Create(e.FullPath));
        }

        private void adicionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckAtiva?.AdicionarItem();
        }
        private void removerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckAtiva?.RemoverItem(lbCheck.SelectedItem);
        }
        private void stripAdicionarRemover_Opening(object sender, CancelEventArgs e)
        {
            ToolStripMenuItem moverParaStrip = (sender as ContextMenuStrip).Items.Find("moverParaToolStripMenuItem", false)[0] as ToolStripMenuItem;
            moverParaStrip.DropDownItems.Clear();
            List<ToolStripMenuItem> Acessibles = new List<ToolStripMenuItem>();
            foreach (object clRef in lbItems.Items)
            {
                Classes.Checklist cl = ChecklistExtensions.ReadChecklist(lbDisplay.GetPath(clRef));
                if (cl.Path != CheckAtiva.Path)
                {
                    ToolStripMenuItem moveStrip = new ToolStripMenuItem() { Name = "MoverPara" + cl.Name + "ToolStripMenu", Text = cl.Name };
                    moveStrip.Click += MoveStrip_Click;
                    moverParaStrip.DropDownItems.Add(moveStrip);
                }
            }
        }
        private void MoveStrip_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem _sender = sender as ToolStripMenuItem;
            Classes.Checklist clTarget = ChecklistExtensions.FindCheckList(_sender.Text);
            object item = lbCheck.SelectedItem;
            CheckAtiva.MoverItem(item, clTarget);
        }
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChecklistExtensions.RunHelper(lbCheck.SelectedItem);
        }

        private void frmPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                Properties.Settings.Default.Nome = "";
                Properties.Settings.Default.Save();
            }
            else if (e.KeyCode.ToString() == "F2")
            {
                if (Classes.Update_System.Updator.Update())
                {
                    MessageBox.Show("Programa atualizado com sucesso!");
                }
            }
            else if (e.KeyCode.ToString() == "F3")
            {
                NativeMethods.PostMessage(
               (IntPtr)NativeMethods.HWND_BROADCAST,
               NativeMethods.WM_CLOSEME,
               IntPtr.Zero,
               IntPtr.Zero);
            }
        }
        #endregion
    }
}