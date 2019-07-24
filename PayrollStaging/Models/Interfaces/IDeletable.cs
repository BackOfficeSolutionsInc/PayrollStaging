using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayrollStaging.Models.Interfaces
{
    public interface IDeletable
    {
        DateTime? DeleteTime { get; set;}
    }
}
