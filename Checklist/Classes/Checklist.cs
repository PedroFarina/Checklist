using System;
using System.Text;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using static Checklist.Classes.ChecklistExtensions;
using Checklist.Classes.XML;
using System.Threading.Tasks;
using static Checklist.Classes.Propriedades;
using System.Linq;
namespace Checklist.Classes
{
    public class Checklist
    {
        public string Name { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public bool Accessible { get; set; }
        public string Path { get; set; }
        public void Editar(object selectedItem)
        {
            if (Accessible)
            {
                string resposta = MyInputBox.InputBox.ShowEnumerable(Enum.GetNames(typeof(State)));
                (selectedItem as Item).Value = (State)Enum.Parse(typeof(State), resposta);
                this.WriteConfigs();
            }
        }
        public bool AdicionarItem()
        {
            if (Accessible)
            {
                string nome = MyInputBox.InputBox.Show("", "Tarefa:");
                State estado = State.Doing;
                Items.Add(new Item(this) { Description = nome, Value = estado, Helper = TaskMaker.Show() });
                this.WriteConfigs();
                return true;
            }
            return false;
        }
        public bool AdicionarItem(Item item)
        {
            if (Accessible)
            {
                item.ID = new Item(this).ID;
                Items.Add(item);
                this.WriteConfigs();
                return true;
            }
            return false;
        }
        public bool RemoverItem(object item)
        {
            Item iRemove = Items.Find(x => x.ID == (item as Item).ID);
            Items.Remove(iRemove);
            this.WriteConfigs();
            return true;
        }
        public bool MoverItem(object item, Checklist clTarget)
        {
            bool success = true, cAcess = clTarget.Accessible;
            clTarget.Accessible = true;
            success &= clTarget.AdicionarItem(item as Item);
            clTarget.Accessible = false;
            success &= RemoverItem(item);
            return success;
        }
    }
    [Serializable]
    public class Item
    {
        public Item() { }
        public Item(Checklist Parent)
        {
            int i = 1;
            foreach (Item item in Parent.Items.OrderBy(x => x.ID))
            {
                if (item.ID == i)
                {
                    i += 1;
                }
            }
            ID = i;
        }
        public int ID { get; set; }
        public string Display { get { return Description + " - " + Value.ToString(); } }
        public State Value { get; set; }
        public string Description { get; set; }
        public string Helper { get; set; }
        public override string ToString()
        {
            return Display;
        }
    }
    public static class ChecklistExtensions
    {
        public enum State { Doing, Urgent, Done };
        public static Checklist ReadChecklist(string ChecklistPath)
        {
            Task checkWriting = Task.Run(() => { while (Writing) { } });
            checkWriting.Wait();
            Checklist cl = new Checklist();
            string[] cut = Path.GetFileName(ChecklistPath).Split('.')[0].Split('_');
            cl.Name = cut[1];
            cl.Accessible = cut[0] == "True" || cl.Name == Properties.Settings.Default.Nome;
            cl.Items = ChecklistPath.Deserializar(new Type[1] { typeof(Item) });
            cl.Path = ChecklistPath;
            return cl;
        }
        public static Checklist GenerateCheckList(string Name, bool Acessible)
        {
            string path = PastaChecklists + "\\" + Acessible.ToString() + "_" + Name + ".ini";
            Checklist cl = new Checklist();
            cl.Name = Name;
            cl.Accessible = Acessible;
            cl.Path = path;
            if (!File.Exists(path))
            {
                cl.Items.Serializar(cl.Path);
            }
            return cl;
        }
        public static Checklist FindCheckList(string Name)
        {
            foreach (string cl in Directory.GetFiles(PastaChecklists))
            {
                if (Path.GetFileNameWithoutExtension(cl).Split('_')[1] == Name)
                {
                    return ReadChecklist(cl);
                }
            }
            return null;
        }
        public static bool RunHelper(object Item)
        {
            try
            {
                TaskMaker.GenerateTask(((Item)Item).Helper).RunSynchronously();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static object GetList(this Checklist cl)
        {
            return cl.Items;
        }
        public static Color GetColor(object Item)
        {
            switch (((Item)Item).Value)
            {
                case State.Doing:
                    return Color.LightYellow;
                case State.Done:
                    return Color.LightGreen;
                case State.Urgent:
                    return Color.PaleVioletRed;
                default:
                    return Color.White;
            }
        }
        public static bool WriteConfigs(this Checklist cl)
        {
            Task taskw = Task.Run(() =>
            {
                while (Writing)
                {
                }
                Writing = true;
                cl.Items.Serializar(cl.Path);
                Writing = false;
            });
            return true;
        }
        public static void WritingChanged(bool value)
        {
            bool changed = true;
            foreach (string file in Directory.GetFiles(PastaEstado))
            {
                if (!(Path.GetFileName(file) == value.ToString() + ".ini"))
                {
                    File.Delete(file);
                }
                else
                {
                    changed = false;
                }
            }
            if (changed)
            {
                using (File.Create(PastaEstado + "\\" + value.ToString() + ".ini")) { }
            }
        }
    }
}
