using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Player
    {
        public string Name { get; set; }
        public int Cash { get; set; }
        public List<Card> Hand { get; set; }
    }
}
