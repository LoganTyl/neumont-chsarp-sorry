using Sorry.Assets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Sorry
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PawnTest : Page
    {
        List<Pawn> pawnList = new List<Pawn>();

        public PawnTest()
        {
            this.InitializeComponent();
        }


        private void GeneratePawn()
        {

            Pawn p = new Pawn();
            pawnList.Add(p);

            MainCanvas.Children.Add(p.pawnRect);



        }

        private void MainCanvas_Tapped(object sender, TappedRoutedEventArgs e)
        {
            GeneratePawn();
        }

        private void MoveButton_Click(object sender, RoutedEventArgs e)
        {
            Random rng = new Random();
            foreach (var p in pawnList)
            {
                //p.SetPosition(rng.Next(400), rng.Next(400));
            }
        }
    }
}
