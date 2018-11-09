using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProj
{
    class ZergStats : RoleAttribute
    {
        public ZergStats()
        {
        }

        private void Zergling()
        {
            HealtPoints = 35;
            Armor = 0;
            Range = (short)0.1;
            GroundDamage = 5;
            AirDamage = 0;
            EnergyPoints = 0;
            MovmentSpeed = (short)4.13;
            SightRange = 8;
        }

        private void Hydralisk()
        {
            HealtPoints = 90;
            Armor = 0;
            Range = 5;
            GroundDamage = 12;
            AirDamage = 12;
            EnergyPoints = 0;
            MovmentSpeed = (short)3.15;
            SightRange = 9;
        }

        private void Mutalisk()
        {
            HealtPoints = 120;
            Armor = 0;
            Range = 3;
            GroundDamage = 9;
            AirDamage = 9;
            EnergyPoints = 0;
            MovmentSpeed = (short)5.6;
            SightRange = 11;
        }

        private void Roach()
        {
            HealtPoints = 145;
            Armor = 1;
            Range = 4;
            GroundDamage = 16;
            AirDamage = 0;
            EnergyPoints = 0;
            MovmentSpeed = (short)3.15;
            SightRange = 9;
        }
    }
}
