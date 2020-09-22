using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
   public class ClassPublish
    {
        private int id;
        private string name;
        private string country;
        public int ID { set { id = value; } get { return id; } }
        public string Name { set { name = value; } get { return name; } }
        public string Country { set { country = value; } get { return country; } }
        public ClassPublish()
        {
            id = -1;name = "";country = "";
        }
        public ClassPublish(string info)
        {
            info = info.Trim();
            if (info.Length > 2)
            {
                string[] val = info.Split('!');
                id = Convert.ToInt32(val[0]);
                name = val[1];
                country = val[2];
            }
        }
    }
}
