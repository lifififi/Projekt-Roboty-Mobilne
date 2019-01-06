using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Diagnostics;

namespace Przeszukiwanie_grafu
{
    public partial class Form1 : Form
    {
        Bitmap mapa = new Bitmap(@"..\..\mapa.png");
        Bitmap mapaOrginal = new Bitmap(@"..\..\mapa.png");
        Wierzcholek[] punkty = new Wierzcholek[3000];
        Wybor[] wyb = new Wybor[10000];
        Pen blackPen = new Pen(Color.Black, 3);
        Pen bluePen = new Pen(Color.Pink, 3);
        Pen greenPen = new Pen(Color.Green, 1);
        Pen blue2Pen = new Pen(Color.Blue, 3);
        int rozmiar = 0;
        public class point
        {
            public int x;
            public int y;
            public bool odwiedzonyW = false;
            public bool odwiedzonyS = false;
            public int[,] dystans;//tablica odleglosci od punktu
            public int[] sasiad;

        }
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = mapa;
            punkty[0] = new Wierzcholek();
            punkty[1] = new Wierzcholek();
            punkty[0].x = 3049;//tokio
            punkty[0].y = 793;//tokio poczatek
            punkty[1].x = 1802;//londyn koniec
            punkty[1].y = 561;//londyn
            kropka(3049, 793);
            kropka(1802, 561);
            blackPen.Width = 8;
            greenPen.Width = 8;
            bluePen.Width = 8;
        }
       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RysujGraf_Click(object sender, EventArgs e) //rysuj GRAF z wierzcholkow
        {

            grafButton.Enabled = false;
            // int rozmiar = 0;
            int i = 0;
            while (punkty[i] != null)
            {
                rozmiar = i;
                i++;
            }// to tylko daje realny rozmiar naszej tablicy punktów



            for (i = 0; i < rozmiar; i++)
            {
                punkty[i].dystans = new int[2, rozmiar];

                for (int j = 0; j < rozmiar - 1; j++)
                {
                    punkty[i].dystans[1, j] = 1;        //jedynkka znaczy ze nie połączony, zero - połączony
                    if (i == j)
                        punkty[j].dystans[0, j] = 10000;
                    else
                        punkty[i].dystans[0, j] = Odleglosc(punkty[i], punkty[j]);
                }
            }


            for (i = 0; i < rozmiar; i++)
            {

                int k = 0;

                while (k < 5)//5 sasiadow
                {
                    int minDystans = 10000;
                    int minIndex = 0;
                    punkty[i].sasiad = new int[rozmiar];
                    for (int j = 0; j < rozmiar - 1; j++)
                    {
                        /* Dystans to tablica dwuwymiarowa, w pierwszym wierszu jest odleglosc
                         a w drugim wierszu jest 0 lub 1, jak 0 to znaczy ze połączone dwa wierzcholki
                         */

                        if (punkty[i].dystans[0, j] < minDystans && punkty[i].dystans[1, j] == 1)
                        {
                            minDystans = punkty[i].dystans[0, j];
                            minIndex = j;
                            punkty[i].dystans[1, j] = 0;

                        }
                    }
                    if (lad(punkty[i], punkty[minIndex]) == false)
                    {

                        // punkty[i].sasiad[minIndex] = 10;

                        using (var graphics = Graphics.FromImage(mapa))
                        {
                            graphics.DrawLine(blue2Pen, punkty[i].x, punkty[i].y, punkty[minIndex].x, punkty[minIndex].y);
                        }
                    }
                    punkty[i].sasiad[k] = minIndex;
                    k++;

                }
                punkty[0].dystans[1, 1] = Odleglosc(punkty[0], punkty[1]);
                punkty[1].dystans[1, 0] = Odleglosc(punkty[0], punkty[1]);

            }
            // punkty[0].sasiad[1] = 0;
            // punkty[1].sasiad[0] = 0;

            pictureBox1.Image = mapa;
        }

        private void GenerujWierzcholki_Click(object sender, EventArgs e)
        {
            wierzcholkiButton.Enabled = false;
            Random rnd = new Random();
            int k = 2;
            // to tylko rysuje wierzcholek w londynie i tokio
            for (int i = 2; i < liczbaWierzcholkow.Value; i++)  // pętla od wierzcholków - ze sliderem
            {
                int krawedz = 25;
                int x = rnd.Next(krawedz + 1, mapa.Width - (krawedz + 1));
                int y = rnd.Next(krawedz + 1, mapa.Height - (krawedz + 1));

                if (mapa.GetPixel(x, y) == mapa.GetPixel(5, 10) && mapa.GetPixel(x - krawedz, y - krawedz) == mapa.GetPixel(5, 10) && mapa.GetPixel(x + krawedz, y - krawedz) == mapa.GetPixel(5, 10) && mapa.GetPixel(x - krawedz, y + krawedz) == mapa.GetPixel(5, 10) && mapa.GetPixel(x + krawedz, y + krawedz) == mapa.GetPixel(5, 10))
                {
                    punkty[k] = new Wierzcholek();
                    kropka(x, y);
                    punkty[k].x = x;
                    punkty[k].y = y;
                    k++;
                }

            }

            pictureBox1.Image = mapa;
        }

        public int Odleglosc(Wierzcholek poczatek, Wierzcholek koniec) // int odl = Odleglosc(wierzcholki[z], wierzcholki[i]);
        {
            float dx = Math.Abs(koniec.x - poczatek.x);
            float dy = Math.Abs(koniec.y - poczatek.y);
            int r = (int)Math.Sqrt(dx * dx + dy * dy);
            return r;
        }

        void kropka(int x, int y)
        {
            mapa.SetPixel(x - 1, y - 1, Color.Red);
            mapa.SetPixel(x, y - 1, Color.Red);
            mapa.SetPixel(x + 1, y - 1, Color.Red);
            mapa.SetPixel(x - 1, y, Color.Red);
            mapa.SetPixel(x + 1, y, Color.Red);
            mapa.SetPixel(x - 1, y + 1, Color.Red);
            mapa.SetPixel(x, y + 1, Color.Red);
            mapa.SetPixel(x + 1, y + 1, Color.Red);
            mapa.SetPixel(x - 2, y - 2, Color.Red);
            mapa.SetPixel(x - 1, y - 2, Color.Red);
            mapa.SetPixel(x, y - 2, Color.Red);
            mapa.SetPixel(x + 1, y - 2, Color.Red);
            mapa.SetPixel(x + 2, y - 2, Color.Red);
            mapa.SetPixel(x - 2, y - 1, Color.Red);
            mapa.SetPixel(x + 2, y - 1, Color.Red);
            mapa.SetPixel(x - 2, y, Color.Red);
            mapa.SetPixel(x + 2, y, Color.Red);
            mapa.SetPixel(x - 2, y + 1, Color.Red);
            mapa.SetPixel(x + 2, y + 1, Color.Red);
            mapa.SetPixel(x - 2, y + 2, Color.Red);
            mapa.SetPixel(x - 1, y + 2, Color.Red);
            mapa.SetPixel(x, y + 2, Color.Red);
            mapa.SetPixel(x + 1, y + 2, Color.Red);
            mapa.SetPixel(x + 2, y + 2, Color.Red);
            mapa.SetPixel(x, y, Color.Red);
        }

        public bool lad(Wierzcholek poczatek, Wierzcholek koniec)
        {
            bool wynik;
            int xSr;
            int ySr;
            xSr = (poczatek.x + koniec.x) / 2;
            ySr = (poczatek.y + koniec.y) / 2;
            if (mapa.GetPixel(xSr, ySr) != mapa.GetPixel(5, 10))
                wynik = true;
            else wynik = false;
            return wynik;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            grafButton.Enabled = true;
            sciezkaButton.Enabled = true;
            wierzcholkiButton.Enabled = true;
            pictureBox1.Image = mapaOrginal;
            mapa = new Bitmap(@"..\..\mapa.png");
            punkty[0] = new Wierzcholek();
            punkty[1] = new Wierzcholek();
            punkty[0].x = 3049;//tokio
            punkty[0].y = 793;//tokio poczatek
            punkty[1].x = 1802;//londyn koniec
            punkty[1].y = 561;//londyn
            kropka(3049, 793);
            kropka(1802, 561);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void buttonRRT_Click(object sender, EventArgs e)
        {

        }

        public bool londyn(int x, int y)
        {
            //bool wynik = false;
            return (x < 1950 && x > 1750) && (y > 450 && y < 650);// wynik = true;

            //return wynik;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AlgorytmAGwiazdka(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Reset();
            sw.Start();
            Button btn = (Button)sender;

            if (btn == null)
                return;

            int hBoost;
            int refreshTime;

            //sprawdź który guzik został nacisnięty
            if (btn.Name == "fastA")
            {
                hBoost = 100;
                refreshTime = 75;
            }
            else if (btn.Name == "mediumA")
            {
                hBoost = 5;
                refreshTime = 100;
            }
            else
            {
                hBoost = 1;
                refreshTime = 450;
            }

            Point tokyo = new Point(1584,347);
            Point london = new Point(926,255);


            Bitmap mapa = new Bitmap(@"..\..\mapaAlt.png");

            int brushThickness = 15;
            
            using (Graphics graphics = Graphics.FromImage(mapa))
            {
                Brush brush = new SolidBrush(Color.Crimson);
                
                graphics.FillEllipse(brush, tokyo.X-brushThickness/2, tokyo.Y - brushThickness / 2, brushThickness, brushThickness);
                graphics.FillEllipse(brush, london.X - brushThickness / 2, london.Y - brushThickness / 2, brushThickness, brushThickness);
                
            }

            pictureBox1.Image = mapa;
            pictureBox1.Refresh();

            

            AStarAlgorithm aStar = new AStarAlgorithm(mapa, tokyo, london, ref pictureBox1, hBoost, refreshTime);
            //aStar.FindRouteList();            //opcja na listach
            aStar.FindRouteDictionary();        //opcja na słownikach

            using (Graphics graphics = Graphics.FromImage(mapa))
            {
                Brush brush = new SolidBrush(Color.Crimson);

                graphics.FillEllipse(brush, tokyo.X - brushThickness / 2, tokyo.Y - brushThickness / 2, brushThickness, brushThickness);
                graphics.FillEllipse(brush, london.X - brushThickness / 2, london.Y - brushThickness / 2, brushThickness, brushThickness);
                pictureBox1.Refresh();

            }
            sw.Stop();
            czasLabel.Text = sw.Elapsed.Milliseconds.ToString() + " ms";
        }

        private void sciezkaButton_Click(object sender, EventArgs e)
        {

            Stopwatch sw = new Stopwatch();
            sw.Start();
            punkty[0].odwiedzonyW = true;

            int droga = 200;
            int[] nalezy = new int[rozmiar];
            nalezy[0] = 0;
            int p = 1;
            int minmin = 0;
            int fmin = 0;
            int ilosc1 = 0;
            int[] zlyW = new int[rozmiar];
            int liczbazle = 0;



            while (!punkty[1].odwiedzonyW)
            {
                for (int i = 0; i < rozmiar; i++)
                {
                    int odleglosc = 10000;
                    int odleglosc2 = 250;

                    droga = 0;
                    if (punkty[i].odwiedzonyW && !punkty[i].odwiedzonyS)
                    {
                        ilosc1 = 0;

                        for (int k = 0; k < rozmiar; k++)
                        {


                            {

                                punkty[k].f = Odleglosc(punkty[k], punkty[i]) + Odleglosc(punkty[k], punkty[1]);
                                for (int g = 0; g < liczbazle; g++)
                                {
                                    if (zlyW[g] == k && k != 0)
                                        punkty[k].f = 10000;
                                }


                                if (k != i && (punkty[k].f < odleglosc) && (Odleglosc(punkty[k], punkty[i]) < odleglosc2) && !punkty[k].odwiedzonyW)
                                {

                                    odleglosc2 = Odleglosc(punkty[k], punkty[i]);
                                    odleglosc = Odleglosc(punkty[k], punkty[i]) + Odleglosc(punkty[k], punkty[1]);
                                    fmin = punkty[k].f;
                                    minmin = k;
                                    nalezy[p] = minmin;
                                }

                            }

                        }

                        p++;
                        droga = droga + odleglosc;


                        {
                            punkty[minmin].odwiedzonyW = true;
                            punkty[i].odwiedzonyS = true;


                        }





                    }

                    else ilosc1++;

                    //if (punkty[1].odwiedzonyW == true && p < wierzcholki)
                    //{
                    //    for (int k = 0; k < rozmiar; k++)
                    //    {
                    //        for (int f = 0; f < p; f++)
                    //        {

                    //            if (k!=0 &&f!=0 && nalezy[f] != k && (Odleglosc(punkty[k], punkty[nalezy[f]]) < 250) && punkty[k].f < punkty[nalezy[f + 1]].f)
                    //            {
                    //                wierzcholki = p;
                    //                int rozmiar;
                    //                f++;
                    //                rozmiar = f;
                    //                nalezy[f] = k;
                    //                punkty[nalezy[f]].odwiedzonyW = true;
                    //                punkty[nalezy[f]].odwiedzonyS = false;
                    //                while (f - 1 < p)
                    //                {
                    //                    punkty[nalezy[f + 1]].odwiedzonyW = false;
                    //                    punkty[nalezy[f + 1]].odwiedzonyS = false;
                    //                    f++;
                    //                }

                    //                p = rozmiar;
                    //            }

                    //        }
                    //    }
                    //}
                    //punkty[1].odwiedzonyW = true ;

                    if (ilosc1 > rozmiar)
                    {

                        ilosc1 = 0;
                        for (int w = 0; w < rozmiar; w++)
                        {
                            punkty[w].odwiedzonyW = false;
                            punkty[w].odwiedzonyS = false;
                        }
                        zlyW[liczbazle] = minmin;

                        p = 1;
                        i = -1;
                        punkty[0].odwiedzonyW = true;
                        liczbazle++;
                    }


                }


            }



            if (liczbazle > rozmiar)
            {
                return;
            }



            for (int t = 0; t < p - 1; t++)
            {
                using (var graphics = Graphics.FromImage(mapa))
                {
                    graphics.DrawLine(greenPen, punkty[nalezy[t]].x, punkty[nalezy[t]].y, punkty[nalezy[t + 1]].x, punkty[nalezy[t + 1]].y);

                }
            }


            pictureBox1.Image = mapa;
            sw.Stop();
            czasLabel.Text = sw.Elapsed.Milliseconds.ToString() + " ms";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void buttonRRT_Click_1(object sender, EventArgs e)
        {
            point[] drzewo = new point[30000];
            buttonRRT.Enabled = false;
            Stopwatch stoper = new Stopwatch();
            stoper.Start();
            int k = trackBar1.Value;
            point start = new point
            {
                x = 3049,
                y = 793
            };

            point koniec = new point
            {
                x = 1802,
                y = 561
            };
            point obecny = new point
            {
                x = start.x,
                y = start.y
            };

            drzewo[0] = new point
            {
                x = start.x,
                y = start.y
            };
            Random rand = new Random();
            point losowy = new point();
            point najblizszy = new point();
            for (int i = 1; i < k; i++)
            {
                do
                {
                    losowy.x = rand.Next(3, mapa.Width - 3);
                    losowy.y = rand.Next(3, mapa.Height - 3);
                } while (mapa.GetPixel(losowy.x, losowy.y) != mapa.GetPixel(5, 10));
                int a = 0, b;

                long rozmiar = 1;
                long s = 1;
                while (drzewo[s] != null)
                {
                    rozmiar = s;
                    s++;
                }

                int minDystans = 1000;
                for (int j = 0; j < rozmiar; j++)
                {
                    if (Odleglosc(losowy, drzewo[j]) < minDystans)
                    {
                        minDystans = Odleglosc(losowy, drzewo[j]);
                        najblizszy.x = drzewo[j].x;
                        najblizszy.y = drzewo[j].y;
                    }
                }



                obecny.x = najblizszy.x;
                obecny.y = najblizszy.y;
                if (losowy.x - obecny.x != 0)
                    a = (losowy.y - obecny.y) / (losowy.x - obecny.x);
                b = obecny.y - a * obecny.x;

                if (Odleglosc(losowy, obecny) < 1000 && !lad(losowy, obecny))
                {
                    using (var graphics = Graphics.FromImage(mapa))
                    {
                        graphics.DrawLine(blue2Pen, losowy.x, losowy.y, obecny.x, obecny.y);
                    }

                    pictureBox1.Image = mapa;
                    if (animacja.Checked == true && i % 10 == 0)
                        pictureBox1.Update();

                }
                else
                {
                    // obecny.x = (int)Math.Pow(double.Parse((losowy.x * losowy.x + losowy.y * losowy.y).ToString()), 0.5);
                }
                drzewo[i] = new point
                {
                    x = losowy.x,
                    y = losowy.y
                };

            }

            stoper.Stop();
            czasLabel.Text = stoper.Elapsed.Milliseconds.ToString() + " ms";
            stoper.Reset();
        }
        public int Odleglosc(point poczatek, point koniec) // int odl = Odleglosc(wierzcholki[z], wierzcholki[i]);
        {
            float dx = Math.Abs(koniec.x - poczatek.x);
            float dy = Math.Abs(koniec.y - poczatek.y);
            int r = (int)Math.Sqrt(dx * dx + dy * dy);
            return r;
        }
        public bool lad(point poczatek, point koniec)
        {
            bool wynik;
            int xSr;
            int ySr;
            xSr = (poczatek.x + koniec.x) / 2;
            ySr = (poczatek.y + koniec.y) / 2;
            if (mapa.GetPixel(xSr, ySr) != mapa.GetPixel(5, 10)) wynik = true;
            else wynik = false;
            return wynik;
        }

        private void RRTsciezka_Click(object sender, EventArgs e)
        {
            //RRT1();
            //RRT2();
            //pictureBox1.Image = mapaOrginal;
            RRT3();
        }
        public void RRT1()
        {


            Random rnd = new Random();
            int k = 2;
            for (int i = 2; i < liczbaWierzcholkow.Value; i++)
            {
                int krawedz = 25;
                int x = rnd.Next(krawedz + 1, mapa.Width - (krawedz + 1));
                int y = rnd.Next(krawedz + 1, mapa.Height - (krawedz + 1));

                if (mapa.GetPixel(x, y) == mapa.GetPixel(5, 10) && mapa.GetPixel(x - krawedz, y - krawedz) == mapa.GetPixel(5, 10) && mapa.GetPixel(x + krawedz, y - krawedz) == mapa.GetPixel(5, 10) && mapa.GetPixel(x - krawedz, y + krawedz) == mapa.GetPixel(5, 10) && mapa.GetPixel(x + krawedz, y + krawedz) == mapa.GetPixel(5, 10))
                {
                    punkty[k] = new Wierzcholek();
                    punkty[k].x = x;
                    punkty[k].y = y;
                    k++;
                }

            }

            pictureBox1.Image = mapa;
        }
        public void RRT2()
        {

            int i = 0;
            while (punkty[i] != null)
            {
                rozmiar = i;
                i++;
            }



            for (i = 0; i < rozmiar; i++)
            {
                punkty[i].dystans = new int[2, rozmiar];

                for (int j = 0; j < rozmiar - 1; j++)
                {
                    punkty[i].dystans[1, j] = 1;
                    if (i == j)
                        punkty[j].dystans[0, j] = 10000;
                    else
                        punkty[i].dystans[0, j] = Odleglosc(punkty[i], punkty[j]);
                }
            }


            for (i = 0; i < rozmiar; i++)
            {

                int k = 0;

                while (k < 5)
                {
                    int minDystans = 10000;
                    int minIndex = 0;
                    punkty[i].sasiad = new int[rozmiar];
                    for (int j = 0; j < rozmiar - 1; j++)
                    {

                        if (punkty[i].dystans[0, j] < minDystans && punkty[i].dystans[1, j] == 1)
                        {
                            minDystans = punkty[i].dystans[0, j];
                            minIndex = j;
                            punkty[i].dystans[1, j] = 0;

                        }
                    }
                    if (lad(punkty[i], punkty[minIndex]) == false)
                    {

                    }
                    punkty[i].sasiad[k] = minIndex;
                    k++;

                }
                punkty[0].dystans[1, 1] = Odleglosc(punkty[0], punkty[1]);
                punkty[1].dystans[1, 0] = Odleglosc(punkty[0], punkty[1]);

            }

            pictureBox1.Image = mapa;
        }
        public void RRT3()
        {
            punkty[0].odwiedzonyW = true;

            int droga = 0;

            while (!punkty[1].odwiedzonyW)
            {
                for (int i = 0; i < rozmiar; i++)
                {
                    int odleglosc = 10000;
                    int odleglosc2 = 300;
                    int minmin = 0;
                    droga = 0;
                    if (punkty[i].odwiedzonyW && !punkty[i].odwiedzonyS)
                    {
                        for (int k = 0; k < rozmiar; k++)
                        {


                            {

                                if (k != i && (Odleglosc(punkty[i], punkty[1]) + Odleglosc(punkty[k], punkty[i]) < odleglosc + droga) && (Odleglosc(punkty[k], punkty[i]) < odleglosc2) && !punkty[k].odwiedzonyW && punkty[k].kontynent == false)
                                {
                                    odleglosc2 = Odleglosc(punkty[k], punkty[i]);
                                    odleglosc = Odleglosc(punkty[k], punkty[i]) + Odleglosc(punkty[k], punkty[1]);
                                    //  if (minmin != 0)
                                    {
                                        //if ((Odleglosc(punkty[minmin], punkty[0]) + Odleglosc(punkty[minmin], punkty[i]))< (Odleglosc(punkty[k], punkty[0]) + Odleglosc(punkty[k], punkty[i])))
                                        {


                                            {


                                                minmin = k;

                                            }
                                        }
                                    }
                                    // else minmin = k;

                                }
                            }

                        }
                        droga = droga + odleglosc;
                        {
                            punkty[minmin].odwiedzonyW = true;
                            punkty[i].odwiedzonyS = true;
                            using (var graphics = Graphics.FromImage(mapa))
                            {
                                graphics.DrawLine(greenPen, punkty[i].x, punkty[i].y, punkty[minmin].x, punkty[minmin].y);

                            }
                            pictureBox1.Update();

                        }





                    }
                }
            }

            pictureBox1.Image = mapa;
        }
    }
}
