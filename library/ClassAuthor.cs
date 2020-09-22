using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ClassAuthor
    {
        private int id;
        private string name;
        private string lname;
        private string country;
        private string data_b;
        private string data_d;
        public int ID { set { id = value; } get { return id; } }
        public string Name { set { name = value; } get { return name; } }
        public string Lname { set { lname = value; } get { return lname; } }
        public string Country { set { country = value; } get { return country; } }
        public string Data_b { set { data_b = value; } get { return data_b; } }
        public string Data_d { set { data_d = value; } get { return data_d; } }
        public ClassAuthor()
        {
            id = -1; name="";
     lname="";
         country="";
      data_b="";
       data_d="";
    }
        public ClassAuthor(string info)
        {
            info = info.Trim();
            if (info.Length > 2)
            {
                string[] val = info.Split('!');
                id = Convert.ToInt32(val[0]);
                name = val[1];
                lname = val[2];
                country = val[3];
                data_b= val[4];
                data_d= val[5];
            }
        }
    }
}
