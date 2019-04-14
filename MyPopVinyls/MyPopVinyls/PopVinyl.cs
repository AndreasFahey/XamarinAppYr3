using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPopVinyls
{
    public class PopVinyl
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }

        public string Brand { get; set; }

        public string Character { get; set; }

        public int Issue { get; set; }

    }
}
