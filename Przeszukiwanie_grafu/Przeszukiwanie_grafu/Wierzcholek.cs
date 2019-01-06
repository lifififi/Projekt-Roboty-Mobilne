using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przeszukiwanie_grafu
{
  public class Wierzcholek
    {
        public int x;
        public int y;
        public bool odwiedzonyW = false;
        public bool odwiedzonyS = false;
        public int[,] dystans;//tablica odleglosci od punktu
        public int[] sasiad;
        public bool kontynent = false;
        public int f = 0;
    }
}
