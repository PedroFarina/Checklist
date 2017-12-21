using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checklist.Classes
{
    public class lbDisplay
    {
        string Path { get; set; }
        public override string ToString()
        {
            return System.IO.Path.GetFileName(Path).Split('.')[0].Split('_')[1];
        }

        public static lbDisplay Create(string path)
        {
            return new lbDisplay() { Path = path };
        }
        public static string GetPath(object selectedItem)
        {
            return ((lbDisplay)selectedItem).Path;
        }
    }
}
