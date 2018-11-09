using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProj
{
    class TerranStats : RoleAttribute
    {
        public TerranStats()
        {
        }

        private void Medic()
        {
            HealtPoints = 60;
            Armor = 1;
            Range = 4;
            GroundDamage = 0;
            AirDamage = 0;
            EnergyPoints = 50;
            MovmentSpeed = (short)2.25;
            SightRange = 9;
        }

        private void Marine()
        {
            HealtPoints = 45;
            Armor = 0;
            Range = 5;
            GroundDamage = 6;
            AirDamage = 6;
            EnergyPoints = 0;
            MovmentSpeed = (short)3.15;
            SightRange = 9;
        }

        private void Ghost()
        {
            HealtPoints = 100;
            Armor = 0;
            Range = 6;
            GroundDamage = 10;
            AirDamage = 10;
            EnergyPoints = 75;
            MovmentSpeed = (short)3.94;
            SightRange = 11;
        }

        private void Marauder()
        {
            HealtPoints = 125;
            Armor = 1;
            Range = 6;
            GroundDamage = 10;
            AirDamage = 0;
            EnergyPoints = 0;
            MovmentSpeed = (short)3.15;
            SightRange = 10;
        }
    }
}
