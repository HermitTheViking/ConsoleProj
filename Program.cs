using System;

namespace ConsoleProj
{
    class Program
    {
        //Roles: Medic = 1 or Marine = 2
        //FRoles: Medic = 1, Marine = 2, Ghost = 3 or Marauder = 4
        //ERoles: Zergling = 11, Hydralisk = 12, Mutalisk = 13 or Roach = 14

        static void Main(string[] args)
        {
            //Classes from other files
            ConsoleInput input = new ConsoleInput();
            Roles role = new Roles();
            Error error = new Error();
            Fight battle = new Fight();

            //Placeholders
            string usr_Input = null;
            string chr_Name = null;
            string usr_Role = null;
            int usr_Role_Num = 0;
            string friendly_Role = null;
            int friendly_Role_Num = 0;
            int enemy_Role_Num = 0;

            //For random enemy
            Random rnd_Int;

            //Regex testing
            dynamic regexTestUInput = null;
            dynamic regexTestSimpelYes = null;
            dynamic regexTestSimpelNo = null;
            dynamic regexTestFRole = null;
            dynamic regexTestF0 = null;

            //Start of game
            Console.WriteLine("Hello stranger, what is your name?");
            
            //User name
            do
            {
                Console.WriteLine("HINT: Write a name with a least one letter");
                //Choose user name
                usr_Input = Console.ReadLine();

                //usr_Input != empty
                if (input.InputCheck(usr_Input))
                {
                    chr_Name = usr_Input;

                    Console.WriteLine(Environment.NewLine + "Hello " + usr_Input + ". Welcome to StarScape!" + Environment.NewLine);
                    break;
                }
                //usr_Input == empty
                else if (input.InputCheck(usr_Input) == false)
                {
                    error.UserError("usr_Input");
                }
            } while (true);
            
            Console.WriteLine("What is your profession?" + Environment.NewLine);

            //User role
            do
            {
                Console.WriteLine("HINT: Medic or Marine");
                Console.WriteLine("HINT: Choose between the above");

                //Choose user role
                usr_Input = Console.ReadLine();

                regexTestUInput = input.RegexTest("role", usr_Input);

                //usr_Input == empty
                if (input.InputCheck(usr_Input) == false)
                {
                    error.UserError("usr_Input");
                }
                //usr_Input != valid
                else if (regexTestUInput.bool_Test == false)
                {
                    error.UserError("roleU");
                }
                //usr_Input == valid
                else if (regexTestUInput.bool_Test)
                {
                    usr_Role = usr_Input;
                    usr_Role_Num = regexTestUInput.role_Num;
                    
                    role.UDescription(usr_Role_Num);
                    break;
                }

            } while (true);

            //Console.WriteLine("");
            Console.WriteLine("Is it okay that some one tag along with you?" + Environment.NewLine);
            //Console.WriteLine("");

            //Yes or No to friendly
            do
            {
                Console.WriteLine("HINT: Yes or No");

                //Simple answer
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
                    break;
                }
                //usr_Input == No
                else if (regexTestSimpelNo.bool_Test)
                {
                    regexTestFRole = input.RegexTest("roleF0", usr_Role);

                    //usr_Input == empty
                    if (input.InputCheck(usr_Input) == false)
                    {
                        error.UserError("usr_Input");
                    }
                    //usr_Role != medic
                    else if (regexTestFRole.bool_Test == false)
                    {
                        Console.WriteLine(Environment.NewLine + "Okay lone wolf, go ahead and enter the transport." + Environment.NewLine);
                        break;
                    }
                    //usr_Role == medic
                    else if (regexTestFRole.bool_Test)
                    {
                        friendly_Role = "Marine";
                        friendly_Role_Num = 2;

                        error.UserError("roleF0");

                        role.FDescription(friendly_Role_Num);

                        Console.WriteLine("Get on the transport!" + Environment.NewLine);
                        break;
                    }   
                }
            } while (true);
            
            //Friendly role
            if ((regexTestSimpelYes.bool_Test) & (regexTestSimpelNo.bool_Test == false))
            {
                //Console.WriteLine("");
                Console.WriteLine(Environment.NewLine + "What profession do you what with you?");

                do
                {
                    Console.WriteLine("HINT: Medic, Marine, Ghost or Marauder");
                    Console.WriteLine("HINT: Choose between above");

                    //Choose friendly role
                    usr_Input = Console.ReadLine();

                    regexTestF0 = input.RegexTest("roleF2", usr_Input);
                    regexTestUInput = input.RegexTest("role", usr_Input);
                    regexTestFRole = input.RegexTest("roleF2", usr_Role);
                    
                    //usr_Input == empty
                    if (input.InputCheck(usr_Input) == false)
                    {
                        error.UserError("usr_Input");
                    }
                    //usr_Role | usr_Input != Medic
                    else if (regexTestFRole.bool_Test == false | regexTestF0.bool_Test == false)
                    {
                        friendly_Role = usr_Input;
                        friendly_Role_Num = regexTestUInput.role_Num;

                        Console.WriteLine(Environment.NewLine + "Don't loose your squard mate.");

                        role.FDescription(friendly_Role_Num);

                        Console.WriteLine("Get onboard the transport you two!" + Environment.NewLine);
                        break;
                    }
                    //usr_Role & usr_Input == Medic
                    else if ((regexTestFRole.bool_Test) & (regexTestUInput.bool_Test))
                    {
                        friendly_Role = "Marine";
                        friendly_Role_Num = 2;
                        
                        Console.WriteLine(Environment.NewLine + "Two medics should not go into combat with out a marine!");
                        Console.WriteLine("You will get a marine with you insted.");

                        role.FDescription(friendly_Role_Num);

                        Console.WriteLine("Get on the transport!" + Environment.NewLine);
                        break;
                    }
                } while (true);
            }
            
            Console.WriteLine("Are you ready for a battle?" + Environment.NewLine);

            //Battle Yes or No
            do
            {
                //Ready for battle?
                Console.WriteLine("HINT: Yes or No");

                //Simple answer
                usr_Input = Console.ReadLine();

                regexTestSimpelYes = input.RegexTest("simpleYes", usr_Input);
                regexTestSimpelNo = input.RegexTest("simpleNo", usr_Input);

                //usr_Input != Yes or No
                if (regexTestSimpelYes.bool_Test == false & regexTestSimpelNo.bool_Test == false)
                {
                    error.UserError("simple");
                }
                //usr_Input == No
                else if (regexTestSimpelNo.bool_Test)
                {
                    break;
                }
                //usr_Input == Yes
                else if (regexTestSimpelYes.bool_Test)
                {
                    Console.WriteLine(Environment.NewLine + "Your enemy for this battle is: ");

                    rnd_Int = new Random();
                    int rnd_Num = rnd_Int.Next(1, 5);

                    //Zergling
                    if (rnd_Num == 1)
                    {
                        enemy_Role_Num = 11;
                    }
                    //Hydralisk
                    else if (rnd_Num == 2)
                    {
                        enemy_Role_Num = 12;
                    }
                    //Mutalisk
                    else if (rnd_Num == 3)
                    {
                        enemy_Role_Num = 13;
                    }
                    //Roach
                    else if (rnd_Num == 4)
                    {
                        enemy_Role_Num = 14;
                    }

                    role.EDescription(enemy_Role_Num);

                    break;
                }
            } while (true);

            //Battle
            if ((regexTestSimpelYes.bool_Test) & (regexTestSimpelNo.bool_Test == false))
            {
                battle.Battle(usr_Role_Num, friendly_Role_Num, enemy_Role_Num);
            }
            
            Console.WriteLine(Environment.NewLine + "The end");

            Console.ReadLine();
        }
    }
}
