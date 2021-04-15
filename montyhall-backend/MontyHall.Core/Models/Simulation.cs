using System;

namespace MontyHall.Core.Models
{
    public class Simulation
    {
        public int Id { get; set; }
        public int NumberOfRounds { get; set; }
        public int SuccessfulRounds { get; set; }
        public bool ChangeDoor { get; set; }
    }
}