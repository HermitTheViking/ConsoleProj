using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProj
{
    class BattleSceen
    {
        private int DamageDelt (int attackDamage, int defenderArmor)
        {
            int damgeDelt = 0;
            return damgeDelt;
        }

        private int DamageHealed(int medicEnergy, int patientHealtPoint)
        {
            int healtPointHealed = 0;
            return healtPointHealed;
        }

        private int EnergyDraw(int energy)
        {
            int energyLeft = 0;
            return energyLeft;
        }

        private int EnergyRecovery()
        {
            return 1;
        }

        private int RNG(int min, int max)
        {
            Random rnd_Random = new Random();
            int rnd_Int = rnd_Random.Next(min, max);

            return rnd_Int;
        }
    }
}
