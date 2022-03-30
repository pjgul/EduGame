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
using System.Windows.Threading;
using System.Timers;

namespace GameUI
{
    //refreshing method for showing prompt messages
    public static class ExtensionMethods
    {
        private static Action EmptyDelegate = delegate () { };


        public static void Refresh(this UIElement uiElement)

        {
            uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }
    }

    /// <summary>
    /// Interaction logic for GameScreen.xaml
    /// </summary>
    public partial class GameScreen : Window
    {
        IEquationsInt _equations;

        IHealthMechanic _healthMechanic;

        public bool EnemySwitch { get; set; } = false;

        int Score;

        public GameScreen()
        {
            InitializeComponent();

            InitiateEquations();

            InitiateHealth();

            //function should only be used only after all other initiations
            InitiateProblem();
        }

        //waits a certain amount of miliseconds
        public void wait(int milliseconds)
        {
            var timer1 = new Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            // Console.WriteLine("start wait timer");
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();
        }


        #region InitiateEquation
        /// <summary>
        /// Creates a container to initiate equations interface and populate it with random values.
        /// This method should only be activated once on the GameScreen inicialization.
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

        #region InitiateHealth
        /// <summary>
        /// Creates a container to for health and initiates base health for the player and the enemy.
        /// This method should only be activated once on the GameScreen inicialization.
        /// </summary>
        public void InitiateHealth()
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                _healthMechanic = scope.Resolve<IHealthMechanic>();
                _healthMechanic.PlayerHealth = 3;
                _healthMechanic.EnemyHealth = 3;
            }
        }
        #endregion

        #region InitiateProblem
        /// <summary>
        /// Initiates the problem that needs to be solved.
        /// </summary>
        public void InitiateProblem()
        {
            TxbEquation.Text = String.Format("{0} + {1}", _equations.ArgumentA.ToString(), _equations.ArgumentB.ToString());
        }
        #endregion

        #region CheckPlayerHealth
        /// <summary>
        /// Checks the health of the enemy and shows their hp accordingly.
        /// At 0 hp the player dies.
        /// </summary>
        public bool CheckPlayerHealth()
        {
            switch(_healthMechanic.PlayerHealth)
            {
                case 3:
                    {
                        HeartPlayer1.Visibility = Visibility.Visible;
                        HeartPlayer2.Visibility = Visibility.Visible;
                        HeartPlayer3.Visibility = Visibility.Visible;
                        break;
                    }
                case 2:
                    {
                        HeartPlayer1.Visibility = Visibility.Visible;
                        HeartPlayer2.Visibility = Visibility.Visible;
                        HeartPlayer3.Visibility = Visibility.Hidden;
                        break;
                    }
                case 1:
                    {
                        HeartPlayer1.Visibility = Visibility.Visible;
                        HeartPlayer2.Visibility = Visibility.Hidden;
                        HeartPlayer3.Visibility = Visibility.Hidden;
                        break;
                    }
                default:
                    {
                        HeartPlayer1.Visibility = Visibility.Hidden;
                        HeartPlayer2.Visibility = Visibility.Hidden;
                        HeartPlayer3.Visibility = Visibility.Hidden;
                        return true;
                    }
            }
            return false;
        }
        #endregion

        #region CheckEnemyHealth
        /// <summary>
        /// Checks the health of the player and shows their hp accordingly.
        /// At 0 hp the player dies.
        /// </summary>
        public bool CheckEnemyHealth()
        {
            switch (_healthMechanic.EnemyHealth)
            {
                case 3:
                    {
                        HeartEnemyNOT1.Visibility = Visibility.Visible;
                        HeartEnemyNOT2.Visibility = Visibility.Visible;
                        HeartEnemyNOT3.Visibility = Visibility.Visible;
                        break;
                    }
                case 2:
                    {
                        HeartEnemyNOT1.Visibility = Visibility.Visible;
                        HeartEnemyNOT2.Visibility = Visibility.Visible;
                        HeartEnemyNOT3.Visibility = Visibility.Hidden;
                        break;
                    }
                case 1:
                    {
                        HeartEnemyNOT1.Visibility = Visibility.Visible;
                        HeartEnemyNOT2.Visibility = Visibility.Hidden;
                        HeartEnemyNOT3.Visibility = Visibility.Hidden;
                        break;
                    }
                default:
                    {
                        HeartEnemyNOT1.Visibility = Visibility.Hidden;
                        HeartEnemyNOT2.Visibility = Visibility.Hidden;
                        HeartEnemyNOT3.Visibility = Visibility.Hidden;
                        return true;
                    }
            }
            return false;
        }
        #endregion

        #region DealDamagePlayer
        /// <summary>
        /// The player is dealth damage and a massage replaces the equation.
        /// </summary>
        public void DealDamagePlayer()
        {
            LblFailure.Visibility = Visibility.Visible;
            LblFailure.Refresh();
            //System.Threading.Thread.Sleep(1000);
            wait(1000);
            LblFailure.Visibility = Visibility.Hidden;
            _healthMechanic.PlayerHealth--;
        }
        #endregion

        #region DealDamageEnemy
        /// <summary>
        /// Deals damage to the enenmy.
        /// </summary>
        public void DealDamageEnemy()
        {
            _healthMechanic.EnemyHealth--;
        }
        #endregion

        /// <summary>
        /// Sets up a new image for the enemy and resets their health.
        /// </summary>
        public void NewEnemy()
        {
            wait(1000);
            if (EnemySwitch)
            {
                EnemySwitch = false;
                _healthMechanic.EnemyHealth = 3;
                EnemyImage.Source = new BitmapImage(new Uri($"/Images/Enemies/slime.png", UriKind.RelativeOrAbsolute));
                EnemyImage.Refresh();
                HeartEnemyNOT1.Visibility = Visibility.Visible;
                HeartEnemyNOT2.Visibility = Visibility.Visible;
                HeartEnemyNOT3.Visibility = Visibility.Visible;
            }
            else
            {
                EnemySwitch = true;
                _healthMechanic.EnemyHealth = 3;
                EnemyImage.Source = new BitmapImage(new Uri($"/Images/Enemies/imps.png", UriKind.RelativeOrAbsolute));
                EnemyImage.Refresh();
                HeartEnemyNOT1.Visibility = Visibility.Visible;
                HeartEnemyNOT2.Visibility = Visibility.Visible;
                HeartEnemyNOT3.Visibility = Visibility.Visible;
            }
        }

        #region VerifyAnswer
        /// <summary>
        /// Method checks whether given argument is an int, the parsed vriable is then passed to the ArgumentAnswer property.
        /// If it isn't the player is dealt damage.
        /// </summary>
        public bool VerifyAnswer()
        {
            int parsed;
            if (Int32.TryParse(TxbAnswerBox.Text, out parsed))
            {
                _equations.ArgumentsAnswer = parsed;
                return true;
            }
            else
            {
                DealDamagePlayer();
                return false;
            }
        }
        #endregion


        #region Attack
        /// <summary>
        /// Tests whether the given answer in the <c>TxbAnswerBox.Text</c> is an int and then tests whether or not it is equall to the answer of the generated question.
        /// If the answer is incorrect the player looses health. At the end the total amount of health is verified.
        /// </summary>
        private void BtnAttack_Click(object sender, RoutedEventArgs e)
        {
            //the extra if statment is required to not deal double damage for not providing a valid answer and giving a wrong one
            if (VerifyAnswer())
            {
                //the method then checks whether the given answer is correct. if it is the enemy is dealt damage
                if (_equations.EquateAnswers())
                {
                    DealDamageEnemy();
                }
                //otherwise the player recives the damage
                else
                {
                    DealDamagePlayer();
                }
            }
            //afterwards the arguments are populated with new values and the player's and enemy's health is verified
            //_equations.PopulateArguments_Range100();
            _equations.PopulateArguments_Range20();
            //if the return condition is true the player dies
            if (CheckPlayerHealth())
            {
                LblYouDied.Visibility = Visibility.Visible;
                LblYouDied.Refresh();
                wait(4000);
                Close();
            }
            //if the return condition is true the enemy dies and is replaced with a new enemy with full health
            if (CheckEnemyHealth())
            {
                NewEnemy();
                Score++;
                LblScore.Content = "Wynik: " + Score;
            }
            InitiateProblem();
        }
        #endregion
    }
}
