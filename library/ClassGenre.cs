using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ClassGenre
    {

        private int id;
        private string name;
        private string group;
        public int ID { set { id = value; } get { return id; } }
        public string Name { set { name = value; } get { return name; } }
        public string Group { set { group = value; } get { return group; } }
        public ClassGenre()
        {
            id = -1;name = "";group = "";
        }
        public ClassGenre(string info)
        {
            info = info.Trim();
            if (info.Length > 2)
            {
                string[] val = info.Split('!');
                id = Convert.ToInt32(val[0]);
                name = val[1];
                group = val[2];
            }
        }
    }
}
