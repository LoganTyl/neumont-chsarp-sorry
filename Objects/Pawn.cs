using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace Sorry.Assets
{
    [DataContract]
    public class Pawn
    {
        public Image pawnRect { get; set; }
        private Random rng = new Random();
        [DataMember]
        public int[] position { get; set; }
        [DataMember]
        public color pawnColor { get; set; }
        [DataMember]
        public string positionName { get; set; }

        public Pawn()
        {
            pawnRect = createPawn();
            position = new int[2];
            position[0] = 0;
            position[1] = 0;
        }
        public Pawn(ImageSource source, color color)
        {
            pawnColor = color;
            pawnRect = createPawn();
            position = new int[2];
            position[0] = 0;
            position[1] = 0;
            SetImage(source);
        }


        public Image createPawn()
        {
            Image im = new Image();
            im.Width = 30;
            im.Height = 30;
            //Color c = new Color();
            //c = Color.FromArgb(255, (byte)rng.Next(1, 255), (byte)rng.Next(1, 255), (byte)rng.Next(1, 255));
            //r.Fill = new SolidColorBrush(c);
            return im;
        }

        public void SetPosition(Object sender, int[] pos)
        {
            var o = (FrameworkElement)sender;
            Grid g = (Grid)o.Parent;

            var b = (FrameworkElement)sender;
            var X = Grid.GetColumn(b);
            var Y = Grid.GetRow(b);


            try
            {
                var GridParent = (Grid)pawnRect.Parent;
                GridParent.Children.Remove(pawnRect);

            }
            catch (Exception)
            { }

            g.Children.Add(pawnRect);
            if (pos != null)
            {
                Grid.SetColumn(pawnRect, pos[0]);
                Grid.SetRow(pawnRect, pos[1]);
                position[0] = pos[0];
                position[1] = pos[1];
            }
            else
            {
                Grid.SetColumn(pawnRect, X);
                Grid.SetRow(pawnRect, Y);
                position[0] = X;
                position[1] = Y;
            }

            setPositionName();


        }

        public void SetPosition(string positionName, Grid boardGrid)
        {
            //try
            //{
            if (!positionName.Contains("Start"))
            {

                var s = boardGrid.Children.First(p =>
            {
                var b = (FrameworkElement)p;
                return b.Name == positionName;
            });
                var space = (FrameworkElement)s;
                SetPosition(Grid.GetColumn(space), Grid.GetRow(space));
                Debug.WriteLine("Pawn placed-------------------------------------"); 
            }
            //}
            //catch (Exception)
            //{
            //    Debug.WriteLine("Pawn not placed");
            //}
        }

        public void SetPosition(int X, int Y)
        {


            try
            {
                var GridParent = (Grid)pawnRect.Parent;
                GridParent.Children.Remove(pawnRect);
                GridParent.Children.Add(pawnRect);

            }
            catch (Exception)
            { }


            Grid.SetColumn(pawnRect, X);
            Grid.SetRow(pawnRect, Y);
            position[0] = X;
            position[1] = Y;
            //setPositionName();

        }

        public void SetImage(ImageSource source)
        {
            pawnRect.Source = source;
        }

        public void SetSize(int width, int height)
        {
            pawnRect.Width = width;
            pawnRect.Height = height;
        }
        public bool checkClickPosition(Object sender, int[] pos)
        {
            var o = (FrameworkElement)sender;
            Grid g = (Grid)o.Parent;

            var b = (FrameworkElement)sender;
            var X = Grid.GetColumn(b);
            var Y = Grid.GetRow(b);
            if (X == pos[0] && Y == pos[1])
                return true;
            else
                return false;
        }

        public bool checkPawnPosition(Pawn sender, int[] pos)
        {
            int[] pp = sender.position;
            if (pp == pos)
                return true;
            else
                return false;
        }


        public void setPositionName()
        {
            var gP = (Grid)pawnRect.Parent;
            var pawnPosition = gP.Children.First(p =>
            {
                var fE = (FrameworkElement)p;
                return Grid.GetColumn(fE) == position[0] && Grid.GetRow(fE) == position[1];
            });
            var pawnFE = (FrameworkElement)pawnPosition;
            positionName = pawnFE.Name;
            Debug.WriteLine(positionName + "----------------------------");
        }

        public void SetPosition(int X, int Y, Grid grid)
        {


            try
            {
                var GridParent = (Grid)pawnRect.Parent;
                GridParent.Children.Remove(pawnRect);

            }
            catch (Exception)
            { }
           
                grid.Children.Add(pawnRect);
            Debug.WriteLine(grid.Children);

            Grid.SetColumn(pawnRect, X);
            Grid.SetRow(pawnRect, Y);
            position[0] = X;
            position[1] = Y;
            //setPositionName();
        }


    }
}