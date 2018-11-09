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

        public RoleAttribute()
        {
            HealtPoints = 0;
            Armor = 0;
            Range = 0;
            GroundDamage = 0;
            AirDamage = 0;
            EnergyPoints = 0;
            MovmentSpeed = (short)0.0;
            SightRange = 0;
        }
    }
}
