using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przeszukiwanie_grafu
{
    class Wybor
    {
        public int x; // pozycje 
        public int y;
        public int kierunek; // w ktorym kierunku sie ostatnio poruszał
        public double droga; // łączna odległość w lini prostej i drogi wykonanej przez program
        public double koszt; // droga wykonana przez program
        public bool odw; // czy wierzchołek był odwiedzony
        public double minOdl; // odl. w lini prostej każdego wierzchołka
    }
}
