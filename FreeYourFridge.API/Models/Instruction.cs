using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeYourFridge.API.Models
{
    public class Instruction
    {
        public string name { get; set; }
        public Step[] steps { get; set; }
    }
}
