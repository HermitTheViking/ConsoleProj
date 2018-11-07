using System;

namespace ConsoleProj
{
    class Fight
    {
        int hitMiss;
        Random rnd_Int;

        int turn;

        int damage;
        int defence;
        int hpLeft;
        dynamic heal;
        int healDone;
        int energyLeft;

        //Fight
        public void Battle(int uRole, int fRole, int eRole)
        {
            ConsoleInput input = new ConsoleInput();
            Error error = new Error();

            //For stats
            dynamic uStats = BattleStats(uRole);
            dynamic fStats = BattleStats(fRole);
            dynamic eStats = BattleStats(eRole);
            
            //Place holders
            string usr_Input = null;

            //Regex testing
            dynamic regexTestSimpelYes = null;
            dynamic regexTestSimpelNo = null;

            //Combat
            do
            {
                Console.WriteLine("Terran attack");

                //U / F attack
                if ((fRole == 0) & (fStats.hp >= 1))
                {
                    turn = One_Two();
                }
                else
                {
                    turn = 1;
                }

                //U attacking
                if (turn == 1)
                {
                    if ((uRole == 1) & (fStats.hp >= 1) & (uStats.energy >= 24))
                    {
                        Console.WriteLine(Environment.NewLine + "Do you wan't heal your squard mate?");

                        do
                        {
                            Console.WriteLine("HINT: Yes or No");

                            //Choose user name
                            usr_Input = Console.ReadLine();
                                
                            regexTestSimpelYes = input.RegexTest("simpleYes", usr_Input);
                            regexTestSimpelNo = input.RegexTest("simpleNo", usr_Input);
                                
                            //usr_Input != Yes or No
                            if (regexTestSimpelYes.bool_Test == false & regexTestSimpelNo.bool_Test == false)
                            {
                                error.UserError("simple");
                            }
                            //usr_Input == Yes
                            else if (regexTestSimpelYes.bool_Test)
                            {
                                heal = Healing(uStats, fStats);

                                uStats = new { uStats.hp, uStats.armor, uStats.weapon, uStats.ground, uStats.air, energy = heal.energyLeft, uStats.speed, uStats.sight };
                                Console.WriteLine("You have " + uStats.energy + " energy left. ");
                                hpLeft = fStats.hp + heal.healDone;

                                fStats = new { hp = hpLeft, fStats.armor, fStats.weapon, fStats.ground, fStats.air, fStats.energy, fStats.speed, fStats.sight };
                                Console.WriteLine("Friendly have " + fStats.hp + " HP left. ");
                                break;
                            }
                            //usr_Input == No
                            else if (regexTestSimpelNo.bool_Test)
                            {
                                break;
                            }
                        } while (true);
                    }
                    else if ((uRole == 1) & (fStats.hp <= 0))
                    {
                        Console.WriteLine(Environment.NewLine + "Your squard mate is dead, you can't do anything except of runing away!! ");
                        break;
                    }
                    else if (uRole != 1)
                    {
                        hpLeft = Attack(uRole, eRole, uStats, eStats);

                        eStats = new { hp = hpLeft, eStats.armor, eStats.weapon, eStats.ground, eStats.air, eStats.energy, eStats.speed, eStats.sight };
                        Console.WriteLine("It has " + eStats.hp + " HP left. ");

                        //Check enemy HP
                        if (eStats.hp <= 0)
                        {
                            Console.WriteLine(Environment.NewLine + "You have killed it!!");
                            break;
                        }
                    }
                }
                //F attacking
                else if ((turn == 2) & (fStats.hp >= 1))
                {
                    if (fRole == 1)
                    {
                        //Friendly healing U
                        if (One_Two() == 2)
                        {
                            heal = Healing(fStats, uStats);

                            fStats = new { fStats.hp, fStats.armor, fStats.weapon, fStats.ground, fStats.air, energy = heal.energyLeft, fStats.speed, fStats.sight };
                            Console.WriteLine("Friendly have " + uStats.energy + " energy left. ");

                            hpLeft = uStats.hp + heal.healDone;

                            uStats = new { hp = hpLeft, uStats.armor, uStats.weapon, uStats.ground, uStats.air, uStats.energy, uStats.speed, uStats.sight };
                            Console.WriteLine("You have " + uStats.hp + " HP left. ");
                        }
                    }
                    else if (fRole != 1)
                    {
                        hpLeft = Attack(fRole, eRole, fStats, eStats);

                        eStats = new { hp = hpLeft, eStats.armor, eStats.weapon, eStats.ground, eStats.air, eStats.energy, eStats.speed, eStats.sight };
                        Console.WriteLine("It has " + eStats.hp + " HP left. ");

                        //Check enemy HP
                        if (eStats.hp <= 0)
                        {
                            Console.WriteLine(Environment.NewLine + "Friendly have killed it!!");
                            break;
                        }
                    }
                }
                    
                Console.WriteLine(Environment.NewLine + "Zerg attack");

                //E attack
                if ((fStats.hp >= 1) & (fRole == 0))
                {
                    turn = One_Two();
                }
                else
                {
                    turn = 1;
                }

                //U attacked
                if (turn == 1)
                {
                    hpLeft = Attack(eRole, uRole, eStats, uStats);

                    uStats = new { hp = hpLeft, uStats.armor, uStats.weapon, uStats.ground, uStats.air, uStats.energy, uStats.speed, uStats.sight };
                    Console.WriteLine("You have " + uStats.hp + " HP left. ");

                    //Check user HP
                    if (uStats.hp <= 0)
                    {
                        Console.WriteLine(Environment.NewLine + "You have died!!");
                        break;
                    }
                }
                //F attacked
                else if ((turn == 2) & (fStats.hp >= 1))
                {
                    hpLeft = Attack(eRole, fRole, eStats, fStats);

                    fStats = new { hp = hpLeft, fStats.armor, fStats.weapon, fStats.ground, fStats.air, fStats.energy, fStats.speed, fStats.sight };
                    Console.WriteLine("Friendly have " + fStats.hp + " HP left. ");

                    //Check user HP
                    if (fStats.hp <= 0)
                    {
                        Console.WriteLine(Environment.NewLine + "Friendly have died!!");
                    }
                }

                Console.WriteLine("");
            } while (true);
                
            Console.WriteLine(Environment.NewLine + "You have " + uStats.hp + " HP left. ");
            Console.WriteLine("You have " + uStats.energy + " point of energy left. ");
            Console.WriteLine("Friendly have " + fStats.hp + " HP left. ");
            Console.WriteLine("Friendly have " + fStats.energy + " point of energy left. ");
            Console.WriteLine("Enemy have " + eStats.hp + " HP left. ");
        }

        //Stats for roles pulled from Roles.cs
        private dynamic BattleStats(int roleID)
        {
            Roles role = new Roles();

            //Task<dynamic> stats = role.RoleStats(roleID);

            //return stats;
            return role.RoleStats(roleID);
        }

        //Hit, hit half or miss
        private int HitMiss()
        {
            //miss = 1
            //full = 2
            //half = 3

            rnd_Int = new Random();
            hitMiss = rnd_Int.Next(1, 4);

            return hitMiss;
        }

        //1 or 2
        private int One_Two()
        {
            //U = 1
            //F = 2

            rnd_Int = new Random();
            turn = rnd_Int.Next(1, 3);

            return turn;
        }

        //How much damage will be delt
        private int Attack(int aRoleId, int dRoleId, dynamic attacker, dynamic defender)
        {
            hpLeft = defender.hp;
            hitMiss = HitMiss();

            //User or Friendly have air damage
            if ((attacker.air >= 1) & (dRoleId == 13))
            {
                switch (hitMiss)
                {
                    case 1:
                        Console.WriteLine(Environment.NewLine + "Hit missed!! ");
                        break;
                    case 2:
                        damage = attacker.air;
                        Console.WriteLine(Environment.NewLine + "Hit for " + damage + "! ");
                        defence = Defence(dRoleId, defender);

                        if (defence == 1)
                        {
                            damage = 0;
                        }
                        else if (defence == 2)
                        {
                            damage = damage / 2;
                        }

                        hpLeft = defender.hp - damage;
                        break;
                    case 3:
                        damage = attacker.air / 2;
                        Console.WriteLine(Environment.NewLine + "Hit for half damage " + damage + "! ");
                        defence = Defence(dRoleId, defender);

                        if (defence == 1)
                        {
                            damage = 0;
                        }
                        else if (defence == 2)
                        {
                            damage = damage / 2;
                        }

                        hpLeft = defender.hp - damage;
                        break;
                }
            }
            //User or Friendly have no air damage
            else if ((attacker.air == 0) & (dRoleId == 13))
            {
                Console.WriteLine(Environment.NewLine + "No air damage!!");
            }
            //No damage roles
            else if ((attacker.ground == 0) & (attacker.air == 0))
            {
                Console.WriteLine(Environment.NewLine + "No weapon!!");
            }
            //Attacker not flying or medic
            else if (attacker.ground >= 1)
            {
                switch (hitMiss)
                {
                    case 1:
                        Console.WriteLine(Environment.NewLine + "Hit missed!! ");
                        break;
                    case 2:
                        damage = attacker.ground;
                        Console.WriteLine(Environment.NewLine + "Hit for " + damage + "! ");
                        defence = Defence(dRoleId, defender);

                        if (defence == 1)
                        {
                            damage = 0;
                        }
                        else if (defence == 2)
                        {
                            damage = damage / 2;
                        }

                        hpLeft = defender.hp - damage;
                        break;
                    case 3:
                        damage = attacker.ground / 2;
                        Console.WriteLine(Environment.NewLine + "Hit for half damage " + damage + "! ");
                        defence = Defence(dRoleId, defender);

                        if (defence == 1)
                        {
                            damage = 0;
                        }
                        else if (defence == 2)
                        {
                            damage = damage / 2;
                        }

                        hpLeft = defender.hp - damage;
                        break;
                }
            }
            
            return hpLeft;
        }

        //If role have armor or not and how much damage is taken of
        private int Defence (int dRoleId, dynamic defender)
        {
            defence = 0;
            int armor = defender.armor;
            hitMiss = HitMiss();

            if (defender.armor >= 1)
            {
                switch (hitMiss)
                {
                    case 1:
                        defence = armor;
                        Console.WriteLine("Armor full hit, no damage. ");
                        break;
                    case 2:
                        defence = armor / 2;
                        Console.WriteLine("Armor half hit, half damage delt. ");
                        break;
                    case 3:
                        Console.WriteLine("Arrmor missed full damage delt.");
                        break;
                }
            }

            return defence;
        }
        
        //Healing of either U or F
        private dynamic Healing(dynamic medic, dynamic patient)
        {
            healDone = 0;
            energyLeft = medic.energy;

            if (energyLeft <= 24)
            {
                Console.WriteLine(Environment.NewLine + "Not enough energy!! ");
            }
            else
            {
                Console.WriteLine(Environment.NewLine + "Healed for 13 HP for the cost of 25 energy points. ");

                energyLeft = energyLeft - 25;

                healDone = 13;
            }

            return new { healDone, energyLeft };
        }

        //Need work - Restore energy over time
        private int Energy ()
        {
            return 0;
        }
    }
}
