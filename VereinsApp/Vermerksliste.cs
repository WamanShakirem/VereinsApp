using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VereinsApp
{
    internal class Vermerksliste
    {
        [DisplayName("Bezahldatum")]
        public DateOnly Bezahldatum { get; set; }

        public Vermerksliste(DateOnly Bezahldatum)
        {
            this.Bezahldatum = Bezahldatum;
        }

        public Vermerksliste(DataRow row)
        {
            this.Bezahldatum = (DateOnly)row["Bezahldatum"];
        }

    }
}
