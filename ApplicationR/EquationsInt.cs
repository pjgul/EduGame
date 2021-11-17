﻿using System;
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
    public class EquationsInt
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
