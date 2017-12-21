using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Checklist
{
    static class Program
    {
        static Mutex mutex = new Mutex(true, "Checklist");
        [STAThread]
        static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Classes.Update_System.Updator Aplicativo = new Classes.Update_System.Updator();
                object Retorno = Aplicativo.Run();
                if (Retorno.GetType() == typeof(frmPrincipal))
                {
                    Application.Run((frmPrincipal)Retorno);
                }
            }
            else
            {
                NativeMethods.PostMessage(
               (IntPtr)NativeMethods.HWND_BROADCAST,
               NativeMethods.WM_SHOWME,
               IntPtr.Zero,
               IntPtr.Zero);
            }
        }
    }
    internal class NativeMethods
    {
        public const int HWND_BROADCAST = 0xffff;
        public static readonly int WM_SHOWME = RegisterWindowMessage("WM_SHOWME");
        public static readonly int WM_CLOSEME = RegisterWindowMessage("WM_CLOSEME");
        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);
    }
    public static class FormMethods
    {
        public static void ShowMe(this Form frm)
        {
            if (frm.WindowState == FormWindowState.Minimized)
            {
                frm.WindowState = FormWindowState.Normal;
            }
            bool top = frm.TopMost;
            frm.TopMost = true;
            frm.TopMost = top;
        }
    }
}
