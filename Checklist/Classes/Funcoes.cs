using System.Text;
using System.IO;

namespace Checklist.Classes
{
    public static class GenericExtensions
    {
        public static Encoding ReconhecerCodificacao(this string FullPath)
        {
            Encoding cod;
            string arqInteiro = File.ReadAllText(FullPath, Encoding.UTF8);
            if ((arqInteiro.Replace("�", null)).Length != arqInteiro.Length)
            {
                cod = Encoding.Default;
            }
            else
            {
                cod = Encoding.UTF8;
            }
            return cod;
        }
    }
}
