using ApplicationR;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GameUI
{
    /// <summary>
    /// Interaction logic for GameScreen.xaml
    /// </summary>
    public partial class GameScreen : Window
    {
        public GameScreen()
        {
            InitializeComponent();

            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var equationsInt = scope.Resolve<IEquationsInt>();
                equationsInt.PopulateArguments_Range100();
                TxbEquation.Text = equationsInt.ReturnArgumentA().ToString();
            }
        }
    }
}
