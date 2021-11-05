using System;
using Domain.Models;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    /// <summary>
    /// EquationsInt describes logic of equations within Integer range of numbers.
    /// </summary>
    class EquationsInt
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
            _arguments.ArgumentB = new Random().Next(1, 101);
            _arguments.ArgumentC = new Random().Next(1, 101);
            _arguments.ArgumentD = new Random().Next(1, 101);
            _arguments.ArgumentE = new Random().Next(1, 101);
        }
    }
}
