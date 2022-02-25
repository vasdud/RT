using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTask
{
    internal class Entyti
    {
        static List<string> values;
        int Id;
        string Name;
        string Path;
        string Type;
        int Id_P;

        public static List<string> VALUE
        {
            get
            {
                return values;
            }
            set
            {
                values = value;
            }
        }

        public int ID
        {
            get
            {
                return Id;
            }
            set
            {
                Id = value + 1;
            }
        }

        public string NAME
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
            }
        }

        public string PATH
        {
            get
            {
                return Path;
            }
            set
            {
                Path = value;
            }
        }

        public string TYPE
        {
            get
            {
                return Type;
            }
            set
            {
                Type = value;
            }
        }

        public int IDP
        {
            get
            {
                return Id_P;
            }
            set
            {
                Id_P = value;
            }
        }

        public Entyti()
        {
            values = new List<string>();
            Name = string.Empty;
            Path = string.Empty;
            Type = string.Empty;
        }

        public int GetParentID(string thePath)
        {
            DataBase DB = new DataBase();
            if (!string.IsNullOrEmpty(thePath) && !thePath.Equals("\\"))
            {
                if(DB.GetValuesByPath(thePath))
                {
                    if (!string.IsNullOrEmpty(Entyti.VALUE[0]))
                    {
                        Id_P = Convert.ToInt32(Entyti.VALUE[0]);
                    }
                }
            }
            else
            {
                Id_P = 0;
            }
            return Id_P;
        }

        public bool IsEnqName(string theName)
        {
            bool result = true;
            DataBase DB = new DataBase();
            List<string> ExNames = DB.GetNamesItms();
            foreach (string Nm in ExNames)
            {
                if (!string.IsNullOrEmpty(Nm) && string.Equals(theName, Nm))
                {
                    result = false;
                    if (result)
                    {
                        break;
                    }
                }
            }

            return result;
        }

        public bool IsValidName(string theName)
        {
            bool result = true;
            bool IsCont = true;
            char[] SpSmbl = { '\'', '\"', '\\', '\0', '\a', '\b', '\f', '\n', '\r', '\t', '\v', '!', '@', '#', '№', '$', ';', '%', '^', ':', '?', '&', '*', '(', ')', '{', '}', '[', ']', '-', '_', '+', '=', ',', '.', '<', '>', '/' };
            foreach (char ch in SpSmbl)
            {
                IsCont = theName.Contains(ch);
                if (IsCont)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public bool SetValues()
        {
            bool result = true;
            values.Clear();
            if (!string.IsNullOrEmpty(Id.ToString()) && result)
            {
                values.Add(Id.ToString());
            }
            else
            {
                result = false;
            }
            if (!string.IsNullOrEmpty(Name) && result)
            {
                values.Add(Name);
            }
            else
            {
                result = false;
            }
            if (!string.IsNullOrEmpty(Path) && result)
            {
                values.Add(Path);
            }
            else
            {
                result = false;
            }
            if (!string.IsNullOrEmpty(Type) && result)
            {
                values.Add(Type);
            }
            else
            {
                result = false;
            }
            if (!string.IsNullOrEmpty(Id_P.ToString()) && result)
            {
                values.Add(Id_P.ToString());
            }
            else
            {
                result = false;
            }

            return result;
        }

    }
}
