using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPopVinyls
{
    public class PopVinyl
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set;}
        public string Franchise { get; set; }

        public override string ToString()
        {
            return this.Name + "(" + this.Franchise + ")";
        }

    }
}
