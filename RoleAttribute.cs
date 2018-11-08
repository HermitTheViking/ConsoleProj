using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProj
{
    class RoleAttribute
    {
        public int HealtPoints { get; set; }
        public int Armor { get; set; }
        public short Range { get; set; }
        public int GroundDamage { get; set; }
        public int AirDamage { get; set; }
        public int EnergyPoints { get; set; }
        public short MovmentSpeed { get; set; }
        public int SightRange { get; set; }
    }
}
