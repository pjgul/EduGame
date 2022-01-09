using System;
using DomainR.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationR
{
    /// <summary>
    /// EquationsInt describes logic of equations within Integer range of numbers.
    /// </summary>
    public class EquationsInt : IEquationsInt
    {
        IArguments<int> _arguments;

        public EquationsInt(IArguments<int> arguments)
        {
            _arguments = arguments;
        }

        /// <summary>
        /// Populates arguments with integer values raging from 1 to 100.
        /// </summary>
        public void PopulateArguments_Range100()
        {
            _arguments.ArgumentA = new Random().Next(1, 101);
            System.Threading.Thread.Sleep(100);
            _arguments.ArgumentB = new Random().Next(1, 101);
            System.Threading.Thread.Sleep(100);
            _arguments.ArgumentC = new Random().Next(1, 101);
            System.Threading.Thread.Sleep(100);
            _arguments.ArgumentD = new Random().Next(1, 101);
            System.Threading.Thread.Sleep(100);
            _arguments.ArgumentE = new Random().Next(1, 101);
        }

        public int ArgumentA { get { return _arguments.ArgumentA; } set { _arguments.ArgumentA = value; } }

        public int ArgumentB { get { return _arguments.ArgumentB; } set { _arguments.ArgumentB = value; } }

        public int ArgumentC { get { return _arguments.ArgumentC; } set { _arguments.ArgumentC = value; } }

        public int ArgumentD { get { return _arguments.ArgumentD; } set { _arguments.ArgumentD = value; } }

        public int ArgumentE { get { return _arguments.ArgumentE; } set { _arguments.ArgumentE = value; } }

        public int ArgumentsAnswer { get; set; }

        public int CalculateAnswer()
        {
            return ArgumentA + ArgumentB;
        }

        public bool EquateAnswers()
        {
            return (ArgumentsAnswer == CalculateAnswer()) ? true : false;
        }
    }
}
