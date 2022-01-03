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
        IEquationsInt _equations;

        public GameScreen()
        {
            InitializeComponent();

            InitiateEquations();

            InitiateProblem();
        }

        #region InitiateEquation
        /// <summary>
        /// Creates a container to initiate equations interface and populate it with random values.
        /// </summary>
        public void InitiateEquations()
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                _equations = scope.Resolve<IEquationsInt>();
                _equations.PopulateArguments_Range100();
            }
        }
        #endregion

        /// <summary>
        /// Initiates the problem that needs to be solved.
        /// </summary>
        public void InitiateProblem()
        {
            TxbEquation.Text = String.Format("{0} + {1} = ?", _equations.ArgumentA.ToString(), _equations.ArgumentB.ToString());
        }

        /// <summary>
        /// Tests whether the given answer in the <c>TxbAnswerBox.Text</c> is an int and then tests whether or not it is equall to the answer of the generated question.
        /// </summary>
        private void BtnAttack_Click(object sender, RoutedEventArgs e)
        {
            int x;
            if (Int32.TryParse(TxbAnswerBox.Text, out x))
            {
                _equations.ArgumentsAnswer = x;
            }
            else TxbAnswerBox.Text = "Failed";

            if (_equations.EquateAnswers())
            TxbAnswerBox.Text = _equations.EquateAnswers().ToString();
            else TxbAnswerBox.Text = "Failed";
        }
    }
}
