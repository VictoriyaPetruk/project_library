using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ClassTopic
    {
        private int id;
        private string name;
        public int ID { set { id = value; } get { return id; } }
        public string Name { set { name = value; } get { return name; } }
        public ClassTopic()
        {
            id = -1;name = "";
        }
        public ClassTopic(string info)
        {
            info = info.Trim();
            if (info.Length > 2)
            {
                string[] val = info.Split('!');
                id = Convert.ToInt32(val[0]);
                name = val[1];
            }
        }
    }
}
