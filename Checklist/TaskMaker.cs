using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checklist
{
    public partial class TaskMaker : Form
    {
        public TaskMaker()
        {
            InitializeComponent();
        }
        string resposta = null;
        public static new string Show()
        {
            TaskMaker frmChoice = new TaskMaker();
            frmChoice.ShowDialog();
            return frmChoice.resposta;
        }
        private void btnCriar_Click(object sender, EventArgs e)
        {
            Control checkedRadio = gbAcao.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
            switch (checkedRadio.TabIndex)
            {
                case 0:
                    folderDialog.ShowDialog();
                    resposta = "openfolder£" + folderDialog.SelectedPath.ToUniversalPath();
                    break;
                case 1:
                    fileDialog.ShowDialog();
                    resposta = "openfile£" + fileDialog.FileName.ToUniversalPath();
                    break;
                case 2:
                    string dica = MyInputBox.InputBox.Show("", "Dica:");
                    resposta = "tell£" + dica;
                    break;
                case 3:
                    resposta = "null£null";
                    break;
            }
            DialogResult = DialogResult.OK;
        }
        public static Task GenerateTask(string arg)
        {
            string[] cut = arg.Split('£');
            switch (cut[0].ToLower())
            {
                case "openfolder":
                    return new Task(() =>
                    {
                        System.Diagnostics.Process.Start(cut[1]);
                    });
                case "openfile":
                    return new Task(() =>
                    {
                        System.Diagnostics.Process.Start("explorer.exe", string.Format("/select,\"{0}\"", cut[1]));
                    });
                case "tell":
                    return new Task(() =>
                    {
                        MessageBox.Show(cut[1]);
                    });

                default:
                    return new Task(() =>
                    {
                        MessageBox.Show("Não há dica para esta tarefa.");
                    }
                    );
            }
        }
        
    }
    public static class TaskMakerExtensions
    {
        public static string ToUniversalPath(this string LocalPath)
        {
            if (!LocalPath.StartsWith("\\\\"))
            {
                string Root = Path.GetPathRoot(LocalPath);
                return @"\\" + Environment.MachineName + "\\" + Root.Replace(":", null) + LocalPath.Substring(Root.Length);
            }
            else
            {
                return LocalPath;
            }
        }
    }
}
