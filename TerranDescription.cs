using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProj
{
    class TerranDescription : RoleDescription
    {
        public override string Description()
        {
            string output;

            output = Environment.NewLine;
            output += "You get " + "HP" + " hit points. " + Environment.NewLine;
            output += "You have " + "Armor" + " point(s) of armor. " + Environment.NewLine;
            output += "You can heal targets that are a maximum of " + "Weapon" + " units away. " + Environment.NewLine;
            output += "Your damage agints ground targets is " + "Ground" + " hit points. " + Environment.NewLine;
            output += "Your damage agints air targets is " + "Air" + " hit points. " + Environment.NewLine;
            output += "You get " + "Energy" + " points(s) of energy to start with. " + Environment.NewLine;
            output += "You can have a total of 200 points of energy" + Environment.NewLine;
            output += "You have a movment speed of" + "Speed" + " units. " + Environment.NewLine;
            output += "You can se " + "Sight" + " units in any direction. " + Environment.NewLine;

            return output;
        }
    }
}
