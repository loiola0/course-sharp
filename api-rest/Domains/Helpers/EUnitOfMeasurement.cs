using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace api_rest.Domains.Helpers
{
    public enum EUnitOfMeasurement : byte{
        
        [Description("UN")]
        Unity = 1,

        [Description("MG")]
        Milligram = 2,

        [Description("G")]
        Gram = 3,

        [Description("KG")]
        Killogram = 4,

        [Description("L")]
        Liter  = 5

        
    }
}