using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public interface IArguments<T>
    {
        T ArgumentA { get; set; }

        T ArgumentB { get; set; }

        T ArgumentC { get; set; }

        T ArgumentD { get; set; }

        T ArgumentE { get; set; }
    }
}
