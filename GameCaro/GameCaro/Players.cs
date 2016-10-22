using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace GameCaro
{
    public class Players
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private Image mark;
        public Image Mark
        {
            get { return mark; }
            set { mark = value; }
        }
        public Players(string name,Image mark)
        {
            this.Name = name;
            this.Mark = mark;
        }

    }
}
