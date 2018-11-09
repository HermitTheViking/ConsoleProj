﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProj
{
    class Zerg : RoleAttribute
    {
        public Zerg(int hp, int armor, short range, int ground, int air, int energy, short speed, int shigt)
        {
            HealtPoints = hp;
            Armor = armor;
            Range = range;
            GroundDamage = ground;
            AirDamage = air;
            EnergyPoints = energy;
            MovmentSpeed = speed;
            SightRange = shigt;
        }
    }
}
