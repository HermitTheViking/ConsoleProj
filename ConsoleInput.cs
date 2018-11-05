using System.Text.RegularExpressions;

namespace ConsoleProj
{
    class ConsoleInput
    {
        //Check if there is letters in user input
        public bool InputCheck(string input)
        {
            if (Regex.Matches(input, @"[a-zA-Z]").Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Regex test for roles
        public dynamic RegexTest(string variable, string input)
        {
            dynamic output = new { bool_Test = false, role_Num = 0 };

            if (InputCheck(input))
            {
                //User role regex patterne
                Regex medicRegex = new Regex(@"(?i)medic");
                Regex marineRegex = new Regex(@"(?i)marine");

                //Yes / No regex patterne
                Regex agreeRegex = new Regex(@"(?i)yes");
                Regex disagreeRegex = new Regex(@"(?i)no");

                //Friendly role regex patterne
                Regex ghostRegex = new Regex(@"(?i)ghost");
                Regex marauderRegex = new Regex(@"(?i)marauder");

                //Check if match
                Match medicMatch = medicRegex.Match(input);
                Match marineMatch = marineRegex.Match(input);
                Match agreeMatch = agreeRegex.Match(input);
                Match disagreeMatch = disagreeRegex.Match(input);
                Match ghostMatch = ghostRegex.Match(input);
                Match marauderMatch = marauderRegex.Match(input);

                switch (variable)
                {
                    //For user role
                    case "role":
                        if (medicMatch.Success)
                        {
                            output = new { bool_Test = true, role_Num = 1 };
                        }
                        else if (marineMatch.Success)
                        {
                            output = new { bool_Test = true, role_Num = 2 };
                        }
                        else if (ghostMatch.Success)
                        {
                            output = new { bool_Test = true, role_Num = 3 };
                        }
                        else if (marauderMatch.Success)
                        {
                            output = new { bool_Test = true, role_Num = 4 };
                        }
                        break;
                    //For simpel anwser
                    case "simpleYes":
                        if (agreeMatch.Success)
                        {
                            output = new { bool_Test = true };
                        }
                        break;
                    //For simpel anwser
                    case "simpleNo":
                        if (disagreeMatch.Success)
                        {
                            output = new { bool_Test = true };
                        }
                        break;
                    //If medic choose another medic
                    case "roleF2":
                        if (medicMatch.Success)
                        {
                            output = new { bool_Test = true, role_Num = 1 };
                        }
                        break;
                    //If medic choose no friendly
                    case "roleF0":
                        if (medicMatch.Success)
                        {
                            output = new { bool_Test = true, role_Num = 1 };
                        }
                        break;
                }                
            }

            return output;
        }
    }
}
