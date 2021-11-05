using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    class Arguments : IArguments<int>
    {
        public int ArgumentA { get; set; }

        public int ArgumentB { get; set; }

        public int ArgumentC { get; set; }

        public int ArgumentD { get; set; }

        public int ArgumentE { get; set; }
    }
}
