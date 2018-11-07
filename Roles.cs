using System;

namespace ConsoleProj
{
    class Roles
    {
        //Placeholders
        public int hp;
        public int armor;
        public short weapon;
        public dynamic dps;
        public short speed;
        public int sight;

        public string description;

        //For Program.cs
        public void RoleDescription(int input)
        {
            Description Description = new Description();
            Console.WriteLine(Description.RoleDescription(input));
        }

        //For Fight.cs
        public dynamic RoleStats(int input)
        {
            Stats Stats = new Stats();

            dps = Stats.Damage(input);

            dynamic result = new { hp = Stats.HP(input), armor = Stats.Armor(input), weapon = Stats.Weapon(input), dps.ground, dps.air, dps.energy, speed = Stats.Speed(input), sight = Stats.Sight(input) }; 

            return result;
        }
    }

    class Stats : Roles
    {
        public int HP(int input)
        {
            switch (input)
            {
                case 0:
                    hp = 0;
                    break;
                //Terran
                case 1:
                    hp = 60;
                    break;
                case 2:
                    hp = 45;
                    break;
                case 3:
                    hp = 100;
                    break;
                case 4:
                    hp = 125;
                    break;
                //Zerg
                case 11:
                    hp = 35;
                    break;
                case 12:
                    hp = 90;
                    break;
                case 13:
                    hp = 120;
                    break;
                case 14:
                    hp = 145;
                    break;
            }

            return hp;
        }

        public int Armor(int input)
        {
            switch (input)
            {
                case 0:
                    armor = 0;
                    break;
                //Terran
                case 1:
                    armor = 1;
                    break;
                case 2:
                    armor = 0;
                    break;
                case 3:
                    armor = 0;
                    break;
                case 4:
                    armor = 1;
                    break;
                //Zerg
                case 11:
                    armor = 0;
                    break;
                case 12:
                    armor = 0;
                    break;
                case 13:
                    armor = 0;
                    break;
                case 14:
                    armor = 1;
                    break;
            }

            return armor;
        }

        public short Weapon(int input)
        {
            switch (input)
            {
                case 0:
                    weapon = 0;
                    break;
                //Terran
                case 1:
                    weapon = 4;
                    break;
                case 2:
                    weapon = 5;
                    break;
                case 3:
                    weapon = 6;
                    break;
                case 4:
                    weapon = 6;
                    break;
                //Zerg
                case 11:
                    weapon = (short)0.1;
                    break;
                case 12:
                    weapon = 5;
                    break;
                case 13:
                    weapon = 3;
                    break;
                case 14:
                    weapon = 4;
                    break;
            }

            return weapon;
        }

        public dynamic Damage(int input)
        {
            switch (input)
            {
                case 0:
                    dps = new { ground = 0, air = 0, energy = 0 };
                    break;
                //Terran
                case 1:
                    dps = new { ground = 0, air = 0, energy = 50 };
                    break;
                case 2:
                    dps = new { ground = 6, air = 6, energy = 0 };
                    break;
                case 3:
                    dps = new { ground = 10, air = 10, energy = 75 };
                    break;
                case 4:
                    dps = new { ground = 10, air = 0, energy = 0 };
                    break;
                //Zerg
                case 11:
                    dps = new { ground = 5, air = 0, energy = 0 };
                    break;
                case 12:
                    dps = new { ground = 12, air = 12, energy = 0 };
                    break;
                case 13:
                    dps = new { ground = 9, air = 9, energy = 0 };
                    break;
                case 14:
                    dps = new { ground = 16, air = 0, energy = 0 };
                    break;
            }
            
            return dps;
        }

        public short Speed(int input)
        {
            switch (input)
            {
                case 0:
                    speed = 0;
                    break;
                //Terran
                case 1:
                    speed = (short)2.25;
                    break;
                case 2:
                    speed = (short)3.15;
                    break;
                case 3:
                    speed = (short)3.94;
                    break;
                case 4:
                    speed = (short)3.15;
                    break;
                //Zerg
                case 11:
                    speed = (short)4.13;
                    break;
                case 12:
                    speed = (short)3.15;
                    break;
                case 13:
                    speed = (short)5.6;
                    break;
                case 14:
                    speed = (short)3.15;
                    break;
            }

            return speed;
        }

        public int Sight(int input)
        {
            switch (input)
            {
                case 0:
                    sight = 0;
                    break;
                //Terran
                case 1:
                    sight = 9;
                    break;
                case 2:
                    sight = 9;
                    break;
                case 3:
                    sight = 11;
                    break;
                case 4:
                    sight = 10;
                    break;
                //Zerg
                case 11:
                    sight = 8;
                    break;
                case 12:
                    sight = 9;
                    break;
                case 13:
                    sight = 11;
                    break;
                case 14:
                    sight = 9;
                    break;
            }

            return sight;
        }
    }

    class Description : Roles
    {
        public string RoleDescription(int input)
        {
            Stats Stats = new Stats();

            string output;
            dps = Stats.Damage(input);

            switch (input)
            {
                //Terran
                case 1:
                    output = Environment.NewLine;
                    output += "As a medic your job is to keep your squad member alive, " + Environment.NewLine;
                    output += "you don't get a weapone as a medic so you will have to relay on your squad. " + Environment.NewLine;
                    output += "You can heal targets that are a maximum of " + Stats.Weapon(input) + " units away. " + Environment.NewLine;
                    output += "You get " + Stats.HP(input) + " hit points. " + Environment.NewLine;
                    output += "You have " + Stats.Armor(input) + " point(s) of armor. " + Environment.NewLine;
                    output += "You get " + dps.energy + " points(s) of energy to start with. " + Environment.NewLine;
                    output += "You can have a total of 200 points of energy" + Environment.NewLine;
                    output += "You have a movment speed of" + Stats.Speed(input) + " units. " + Environment.NewLine;
                    output += "You can se " + Stats.Sight(input) + " units in any direction. " + Environment.NewLine;

                    description = output;
                    break;
                case 2:
                    output = Environment.NewLine;
                    output += "As an marine you get a rifle. " + Environment.NewLine;
                    output += "You get " + Stats.HP(input) + " hit points. " + Environment.NewLine;
                    output += "Your weapone can hit targets that are a maximum of " + Stats.Weapon(input) + " units away. " + Environment.NewLine;
                    output += "Your damage agints ground targets is " + dps.ground + " hit points. " + Environment.NewLine;
                    output += "Your damage agints air targets is " + dps.air + " hit points. " + Environment.NewLine;
                    output += "You have a movment speed of" + Stats.Speed(input) + " units. " + Environment.NewLine;
                    output += "You can se " + Stats.Sight(input) + " units in any direction. " + Environment.NewLine;

                    description = output;
                    break;
                case 3:
                    output = Environment.NewLine;
                    output += "As a ghost you will get a high powered rifle and a cloaking device. " + Environment.NewLine;
                    output += "You get " + Stats.HP(input) + " hit points. " + Environment.NewLine;
                    output += "Your weapone can hit targets that are a maximum of " + Stats.Weapon(input) + " units away. " + Environment.NewLine;
                    output += "Your damage agints ground targets is " + dps.ground + " hit points. " + Environment.NewLine;
                    output += "Your damage agints air targets is " + dps.air + " hit points. " + Environment.NewLine;
                    output += "You get " + dps.energy + " points(s) of energy to start with. " + Environment.NewLine;
                    output += "You can have a total of 200 points of energy" + Environment.NewLine;
                    output += "You have a movment speed of" + Stats.Speed(input) + " units. " + Environment.NewLine;
                    output += "You can se " + Stats.Sight(input) + " units in any direction. " + Environment.NewLine;

                    description = output;
                    break;
                case 4:
                    output = Environment.NewLine;
                    output += "As a marauder. " + Environment.NewLine;
                    output += "You get " + Stats.HP(input) + " hit points. " + Environment.NewLine;
                    output += "You have " + Stats.Armor(input) + " point(s) of armor. " + Environment.NewLine;
                    output += "Your weapone can hit targets that are a maximum of " + Stats.Weapon(input) + " units away. " + Environment.NewLine;
                    output += "Your damage agints ground targets is " + dps.ground + " hit points. " + Environment.NewLine;
                    output += "You have a movment speed of" + Stats.Speed(input) + " units. " + Environment.NewLine;
                    output += "You can se " + Stats.Sight(input) + " units in any direction. " + Environment.NewLine;

                    description = output;
                    break;
                //Zerg
                case 11:
                    output = Environment.NewLine;
                    output += "Zergling. " + Environment.NewLine;
                    output += "It has " + Stats.HP(input) + " hit points. " + Environment.NewLine;
                    output += "It's weapone can hit targets that are a maximum of " + Stats.Weapon(input) + " units away. " + Environment.NewLine;
                    output += "It has a damage agints ground targets is " + dps.ground + " hit points. " + Environment.NewLine;
                    output += "It has a movment speed of " + Stats.Speed(input) + " units. " + Environment.NewLine;
                    output += "It can see " + Stats.Sight(input) + " units in any direction. " + Environment.NewLine;

                    description = output;
                    break;
                case 12:
                    output = Environment.NewLine;
                    output += "Hydralisk. " + Environment.NewLine;
                    output += "It has " + Stats.HP(input) + " hit points. " + Environment.NewLine;
                    output += "It's weapone can hit targets that are a maximum of " + Stats.Weapon(input) + " units away. " + Environment.NewLine;
                    output += "It has a damage agints ground targets is " + dps.ground + " hit points. " + Environment.NewLine;
                    output += "It has a damage agints air targets is " + dps.air + " hit points. " + Environment.NewLine;
                    output += "It has a movment speed of " + Stats.Speed(input) + " units. " + Environment.NewLine;
                    output += "It can see " + Stats.Sight(input) + " units in any direction. " + Environment.NewLine;

                    description = output;
                    break;
                case 13:
                    output = Environment.NewLine;
                    output += "Mutalisk. " + Environment.NewLine;
                    output += "It has " + Stats.HP(input) + " hit points. " + Environment.NewLine;
                    output += "It's weapone can hit targets that are a maximum of " + Stats.Weapon(input) + " units away. " + Environment.NewLine;
                    output += "It has a damage agints ground targets is " + dps.ground + " hit points. " + Environment.NewLine;
                    output += "It has a damage agints air targets is " + dps.air + " hit points. " + Environment.NewLine;
                    output += "It has a movment speed of " + Stats.Speed(input) + " units. " + Environment.NewLine;
                    output += "It can see " + Stats.Sight(input) + " units in any direction. " + Environment.NewLine;

                    description = output;
                    break;
                case 14:
                    output = Environment.NewLine;
                    output += "Roach. " + Environment.NewLine;
                    output += "It has " + Stats.HP(input) + " hit points. " + Environment.NewLine;
                    output += "It's weapone can hit targets that are a maximum of " + Stats.Weapon(input) + " units away. " + Environment.NewLine;
                    output += "It has a damage agints ground targets is " + dps.ground + " hit points. " + Environment.NewLine;
                    output += "It has a movment speed of " + Stats.Speed(input) + " units. " + Environment.NewLine;
                    output += "It can see " + Stats.Sight(input) + " units in any direction. " + Environment.NewLine;

                    description = output;
                    break;
            }

            return description;
        }
    }
}
