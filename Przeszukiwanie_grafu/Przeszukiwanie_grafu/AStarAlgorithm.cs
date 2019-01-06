using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Przeszukiwanie_grafu
{
    class AStarAlgorithm
    {
        private class Node : IComparable
        {
            public long id; //numer węzła
            public Point point;   //koordynacje x, y

            public long f;  //g+h
            public long g; //koszt od punktu startowego
            public long h; //szacowany koszt od punktu koncowego  

            public bool obstructionNode; // czy jest przeszkodą - lądem

            public Node parent;    //węzeł rodzic
            
            public Node(Point point)
            {
                this.point = point;
            }

            public int GetLengthTo(Node node)
            {
                float x = Math.Abs(point.X - node.point.X);
                float y = Math.Abs(point.Y - node.point.Y);

                return (int) Math.Sqrt(x*x + y*y)*crossCost;
            }

            public override bool Equals(object obj)
            {
                Node node = (Node)obj;

                if (node != null)
                {
                    if (node.point == point)
                        return true;
                }

                return false;
            }

            public override int GetHashCode()
            {
                return point.X * 41 + point.Y* point.Y* point.Y;
            }

            public int CompareTo(object obj)
            {
                Node other = (Node)obj;

                if (f < other.f)
                    return -1;
                else if (f == other.f)
                    return 0;
                else
                    return 1;

            }
        }

        enum Direction
        {
            NW,
            N,
            NE,
            E,
            SE,
            S,
            SW,
            W
        }

        Bitmap bitmap;

        Point source;
        Point destination;

        Node sourceNode;
        Node destinationNode;

        int MAP_HEIGHT;
        int MAP_WIDTH;

        const int crossCost = 10;       //koszt drogi N E S W 
        const int diagonalCost = 14;    //koszt drogi NE NW SE SW

        int hBoost;        //im wyższy hBoost tym blizej trzymamy się celu więc szybciej znajdziemy drogę, choć nie najbardziej optymalną
        int refreshTime;    //co ile odkrytych wezłów aktualizujemy mapę

        PictureBox pictureBox;

        public AStarAlgorithm(Bitmap bitmap, Point source, Point destination, ref PictureBox pictureBox, int hBoost, int refreshTime)
        {
            if (!CheckPointValidity(source, bitmap))
            {
                Console.WriteLine("Source point is Invalid");
                throw new FormatException();
            }

            if (!CheckPointValidity(destination, bitmap))
            {
                Console.WriteLine("Destination point is Invalid");
                throw new FormatException();
            }


            this.bitmap = bitmap;
            this.source = source;
            this.destination = destination;
            this.hBoost = hBoost;
            this.refreshTime = refreshTime;

            MAP_WIDTH = bitmap.Width;
            MAP_HEIGHT = bitmap.Height;

            this.pictureBox = pictureBox;

        }

        public static bool CheckPointValidity(Point p, Bitmap map) 
        {
            //Sprawdza, czy punkt może należeć do bitmapy
            if (p.X < 0 || p.X >= map.Width || p.Y < 0 || p.Y >= map.Height)
                return false;
            return true;
        }

        public void FindRouteList()
        {

            List<Node> openList = new List<Node>(); //lista w której trzymamy wezły do sprawdzenia
            List<Node> closedList = new List<Node>(); //lista w której trzymamy już sprawdzone węzły
            
            sourceNode = DiscoverSingleNode(source);
            destinationNode = DiscoverSingleNode(destination);
            openList.Add(sourceNode);

            UInt64 cnt = 0;
            Node currentNode=null;
            while (openList.Count > 0)
            {
           
                if(currentNode!=null) //aktualizuje kolor już obliczonego węzła na aqua
                    bitmap.SetPixel(currentNode.point.X, currentNode.point.Y, Color.Aqua); 

                currentNode = openList.OrderByDescending(x => x.f).Last(); //wybierz węzeł z najmniejszym f
                openList.Remove(currentNode); //i usuń z listy

                bitmap.SetPixel(currentNode.point.X, currentNode.point.Y, Color.Green); //w przybliżeniu, aktualnie obliczany węzeł jest koloru zielonego


                if (cnt++ % 450 == 0) //co ile iteracji aktualizujemy ekran
                    pictureBox.Refresh(); 

               
               if(DiscoverAdjecentNodesList(currentNode, ref openList, ref closedList)!=null)
                    break;

                closedList.Add(currentNode); // dodaj obliczony już węzeł do closedList     
            }

            List<Node> path = new List<Node>();

            RetrivePath(currentNode, ref path);

            foreach(var p in path)
            {
                bitmap.SetPixel(p.point.X, p.point.Y, Color.DarkCyan);
            }

            pictureBox.Refresh();
        }

        public void FindRouteDictionary()
        {

           

            Dictionary<int, Node> openDictionary = new Dictionary<int, Node>();
            Dictionary<int, Node> closedDictionary = new Dictionary<int, Node>();

            sourceNode = DiscoverSingleNode(source);
            destinationNode = DiscoverSingleNode(destination);

            openDictionary.Add(sourceNode.GetHashCode(), sourceNode);

            UInt64 cnt = 0;
            Node currentNode = null;

            while (openDictionary.Count > 0)
            {
  
                if (currentNode != null)
                    bitmap.SetPixel(currentNode.point.X, currentNode.point.Y, Color.Aqua);

                KeyValuePair<int, Node> pair = openDictionary.OrderByDescending(x => x.Value.f).Last();
                currentNode = pair.Value;

                bitmap.SetPixel(currentNode.point.X, currentNode.point.Y, Color.Green);
                openDictionary.Remove(currentNode.GetHashCode());

                if (cnt++ % 450 == 0)
                    pictureBox.Refresh();

               

                if (DiscoverAdjecentNodesDictionary(currentNode, ref openDictionary, ref closedDictionary) != null)
                    break;

                closedDictionary.Add(currentNode.GetHashCode(), currentNode);

            }
            List<Node> path = new List<Node>();
            RetrivePath(currentNode, ref path);

            foreach (var p in path)
            {
                bitmap.SetPixel(p.point.X, p.point.Y, Color.Red);
            }

            pictureBox.Refresh();
        }

        public static bool CheckIfObstruction(Point p, Bitmap map)
        {
            //Sprawdz czy dany punkt jest lądem - tylko czarny kolor to ląd #FF000000
            return map.GetPixel(p.X,p.Y).ToArgb() == Color.Black.ToArgb();
        }

        private Node DiscoverSingleNode(Point p)
        {

            if (!CheckPointValidity(p, bitmap))
                return null;

            int nodeId = (p.Y - 1) * MAP_WIDTH + p.X -1;

            //if (nullSet[nodeId] == true)
            //    return null;

            //nullSet[nodeId] = true;

            Node node = new Node(p) { f = 0, g = 0, h = 0, id = nodeId, obstructionNode = CheckIfObstruction(p, bitmap)};

            return node;
        }

        private Node DiscoverAdjecentNodesList(Node node, ref List<Node> openList, ref List<Node> closedList)
        { 
            //odkrywa węzły wokół parametrowego node'a
            foreach (var v in Enum.GetValues(typeof(Direction)))
            {
                //Dla każdego z dostępnych kierunków spróbuj go odkryć
                Point newPoint = GetOffsetPoint(node.point, (int)v);

                Node newNode = DiscoverSingleNode(newPoint);


                if (newNode != null) //jeżeli istnieje. Może nie istnieć, gdy ma współrzędne poza mapą, wtedy DiscoverSignleNode zwróci null
                {

                    newNode.parent = node; //ustaw rodzica na tego który szuka sąsiadów
                    UpdateCosts(node, ref newNode); //aktualizuj koszty

                    if (newNode.Equals(destinationNode)) //sprawdź czy jesteśmy u celu
                    {
                        Console.WriteLine("BAJLANDO ^^");
                        return newNode;
                    }
                    if (newNode.obstructionNode) //jeżeli węzeł jest lądem to go pomiń
                        continue;


                    Node foundNode;

                    if ((foundNode = FindInList(newNode, ref openList)) != null) //jeżeli node o tych współrzędnych już istnieje w openList
                    {
                        if (foundNode.f < newNode.f) //to jeżeli nowy ma większy f, to go pomiń
                            continue;
                        else //w innym wypadku wywal stary wstaw nowy z lepszym f
                        {
                            openList.Remove(foundNode);
                            openList.Add(newNode);
                        }
                    }
                    else if ((foundNode = FindInList(newNode, ref closedList)) != null) //jeżeli jest w closed, czyli był już obliczany, to go pomiń
                        continue;
              
                    else //każdy nowy dodaj do openList
                        openList.Add(newNode);

                    bitmap.SetPixel(newNode.point.X, newNode.point.Y, Color.Pink); //ustaw kolor nowego węzła na rózówy
                }
            }
            //pictureBox.Refresh();
            return null;
        }

        private Node DiscoverAdjecentNodesDictionary(Node node, ref Dictionary<int, Node> openDictionary, ref Dictionary<int, Node> closedDictionary)
        {
            //odkrywa węzły wokół parametrowego node'a


            foreach (var v in Enum.GetValues(typeof(Direction)))
            {
                //Dla każdego z dostępnych kierunków spróbuj go odkryć
                Point newPoint = GetOffsetPoint(node.point, (int)v);

                Node newNode = DiscoverSingleNode(newPoint);

                if (newNode != null)
                {

                    newNode.parent = node;

                    if (newNode.Equals(destinationNode))
                    {
                        Console.WriteLine("BAJLANDO");
                        return newNode;
                    }
                    if (newNode.obstructionNode)
                        continue;


                    UpdateCosts(node, ref newNode);

                    Node foundNode;

                    if ((foundNode = FindInDictionary(newNode, ref openDictionary)) != null)
                    {
                        if (foundNode.f < newNode.f) //<
                            continue;
                        else
                        {
                            openDictionary.Remove(foundNode.GetHashCode());
                            openDictionary.Add(newNode.GetHashCode(), newNode);
                        }
                    }
                    else if ((foundNode = FindInDictionary(newNode, ref closedDictionary)) != null)
                        continue;

                    else
                        openDictionary.Add(newNode.GetHashCode(), newNode);

                    bitmap.SetPixel(newNode.point.X, newNode.point.Y, Color.Pink);
                }
            }
            //pictureBox.Refresh();
            return null;
        }

        private Point GetOffsetPoint(Point point, int offset)
        {
            //przesuwa point o 1 w zależności od kierunku
            switch (offset)
            {
                case (int) Direction.N:
                    {
                        point.Y--;
                        break;
                    }
                case (int) Direction.NE:
                    {
                        point.Y--;
                        point.X++;
                        break;
                    }
                case (int) Direction.E:
                    {
                        point.X++;
                        break;
                    }
                case (int) Direction.SE:
                    {
                        point.Y++;
                        point.X++;
                        break;
                    }
                case (int) Direction.S:
                    {
                        point.Y++;
                        break;
                    }
                case (int) Direction.SW:
                    {
                        point.Y++;
                        point.X--;
                        break;
                    }
                case (int) Direction.W:
                    {
                        point.X--;
                        break;
                    }
                case (int) Direction.NW:
                    {
                        point.Y--;
                        point.X--;
                        break;
                    }
            }

            return point;
        }

        private void UpdateCosts(Node prevNode, ref Node nextNode)
        {
            //jeżeli współrzędne dwóch punktów różnią się o 2, to znaczy że stykają się rogiem
            //jeżeli o 1, to bokiem
            int dx = Math.Abs(prevNode.point.X - nextNode.point.X);
            int dy = Math.Abs(prevNode.point.Y - nextNode.point.Y);

            if (dx + dy == 2)
                nextNode.g = prevNode.g + diagonalCost;

            else if(dx+dy == 1)
                nextNode.g = prevNode.g + crossCost;

            nextNode.h = nextNode.GetLengthTo(destinationNode)*hBoost; //hBoost patrz deklarację
            
            nextNode.f = nextNode.g + nextNode.h;


        }

        private Node FindInList (Node node, ref List<Node> list)
        {
            //wyszukaj w liście, dwa węzły są takie same gdy mają te same współrzędne - Patrz Node.Equals();
            return list.Find(x => x.Equals(node));
        }

        private Node FindInDictionary(Node node, ref Dictionary<int,Node> dictionary)
        {
            Node retNode;
            dictionary.TryGetValue(node.GetHashCode(), out retNode);
            return retNode;

        }

        private bool CheckList(Node node, ref List<Node> openList)
        {
            Node foundNode = openList.Find(x => x.Equals(node));

            if (foundNode != null)
            {
                if (foundNode.f < node.f)
                {
                    return true;
                }
              
            }
            return false;
        }

        private bool CheckDictionary(Node node, ref Dictionary<int, Node> dictionary)
        {
            Node foundNode;
            dictionary.TryGetValue(node.GetHashCode(), out foundNode);

            if (foundNode != null)
            {
                if (foundNode.f < node.f)
                {
                    //skip node
                    return true;
                }
            }
            return false;
        }

        private List<Node> RetrivePath(Node destination, ref List<Node> path)
        {
            //rekurencyjnie tworzy listę węzłów od końca do początku
            if (destination == sourceNode)
                return path;

            path.Add(destination);

            destination = destination.parent;

            return RetrivePath(destination, ref path);
        }

        private void UpdateGUI()
        {
            pictureBox.Refresh();
        }

    }
}
