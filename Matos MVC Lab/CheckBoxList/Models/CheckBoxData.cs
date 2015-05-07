using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckBoxList.Models
{
    public class CheckBoxData
    {
        public bool Checked { get; set; }
        public String Name { get; set; }

        public CheckBoxData()
        {

        }
        public CheckBoxData(bool c, String name)
        {
            Checked = c;
            Name = name;
        }
    }
}