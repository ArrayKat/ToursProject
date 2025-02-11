using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Tours.Models
{
    public partial class Tour
    {
        string isActualStr;
        string colorIsActual;
        public string IsActualStr => IsActual==0 ? "Не актуален" : "Актуален";
        public string ColorIsActual => IsActual == 0 ? "Red" : "Green";

    }
}
