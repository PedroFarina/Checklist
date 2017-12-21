using System.Windows.Forms;
using System.IO;
using System;

namespace Checklist.Classes.Update_System
{
    public class Updator
    {
        private static frmPrincipal frmPrincipal;
        private static string CaminhoExecutavel = System.Reflection.Assembly.GetExecutingAssembly().Location;
        private static string LocalExecutavel = Path.GetDirectoryName(CaminhoExecutavel);
        private static string NomeExecutavel = Path.GetFileName(CaminhoExecutavel);
        private static FileSystemWatcher updateWatcher = new FileSystemWatcher();
        private bool Detected = false;
        public Updator()
        {
            if (!System.Diagnostics.Debugger.IsAttached)
            {
                updateWatcher.Path = Propriedades.PastaRelease;
                updateWatcher.EnableRaisingEvents = true;
                updateWatcher.Filter = "*.*";
                updateWatcher.Changed += UpdateWatcher_Changed;
            }
        }

        private void UpdateWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (!Detected)
            {
                Detected = true;
                MessageBox.Show("Há uma atualização disponível.\r\nFechando programa.", "Atualização Disponível");
                System.Threading.Thread.Sleep(500);
                foreach (string item in Directory.GetFiles(updateWatcher.Path))
                {
                    File.Copy(item, LocalExecutavel + "\\u" + Path.GetFileName(item), true);
                }
                System.Diagnostics.Process.Start(LocalExecutavel + "\\Updator.exe");
                NativeMethods.PostMessage(
               (IntPtr)NativeMethods.HWND_BROADCAST,
               NativeMethods.WM_CLOSEME,
               IntPtr.Zero,
               IntPtr.Zero);
            }
        }

        public object Run()
        {
            if (!TemAtualizacao())
            {
                frmPrincipal = new frmPrincipal();
                return frmPrincipal;
            }
            else
            {
                MessageBox.Show("Há uma atualização disponível.", "Atualização Disponível");
                foreach (string item in Directory.GetFiles(updateWatcher.Path))
                {
                    File.Copy(item, LocalExecutavel + "\\u" + Path.GetFileName(item), true);
                }
                System.Diagnostics.Process.Start(LocalExecutavel + "\\Updator.exe");
                return false;
            }
        }
        private bool TemAtualizacao()
        {
            bool retorno = false;

            bool Checklist = (File.GetLastWriteTime(LocalExecutavel + "\\" + NomeExecutavel)) < (File.GetLastWriteTime(updateWatcher.Path + "\\" + NomeExecutavel));
            bool InputBox = (File.GetLastWriteTime(LocalExecutavel + "\\MyInputBox.dll")) < (File.GetLastWriteTime(updateWatcher.Path + "\\MyInputBox.dll"));
            retorno = Checklist || InputBox;
            return retorno;
        }
        public static bool Update()
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                try
                {
                    File.Copy(CaminhoExecutavel, Propriedades.PastaRelease + "\\" + NomeExecutavel, true);
                    File.Copy(LocalExecutavel + "\\MyInputBox.dll", Propriedades.PastaRelease + "\\MyInputBox.dll", true);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }
    }
}
