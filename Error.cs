using System;

namespace ConsoleProj
{
    class Error
    {
        //Error dialog
        public void UserError(string variable)
        {
            //Error dialog if usr_Input have no letters in it
            if (variable == "usr_Input")
            {
                Console.WriteLine("Sorry, I didn't get what you sad.");
                Console.WriteLine("If won't speak up then piss off mate!");
            }
            //Error dialog if usr_Input doesn't match any role
            else if (variable == "roleU")
            {
                Console.WriteLine("I have never head of that profession.");
                Console.WriteLine("Come back when you have a real profession!");
            }
            else if (variable == "roleF")
            {
                Console.WriteLine("I have never head of that profession.");
                Console.WriteLine("Come back when you have a real profession!");
            }
            //Error dialog if medic choose another medic
            else if (variable == "roleF2medic")
            {
                Console.WriteLine("Two medics can't go in together with out a least one marine!");
                Console.WriteLine("You will get a marine insted!");
            }
            //Error dialog if medic choose no friendly
            else if (variable == "roleF0")
            {
                Console.WriteLine("A medic should not go in alone!");
                Console.WriteLine("You will get a marine with you!");
            }
            //Error dialog if usr_Input is != yes or != no
            else if (variable == "simple")
            {
                Console.WriteLine("It was a simple yes or no question");
            }
        }
    }
}
