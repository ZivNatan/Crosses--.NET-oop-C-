using System;

namespace Crosses
{
    class Menu
    {
        public int mainMenu() 
        {
          
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("********XOXOXOXOXOXOXOXOXOXO   CROSSES GAME   XOXOXOXOXOXOXOXOXOXO********");
                Console.WriteLine();
                Console.ResetColor();
                Console.WriteLine("* To play against the computer enter '1'.");
                Console.WriteLine("* To play against a friend enter '2'.");
                Console.WriteLine("* To exit enter '3'.");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Goodluck!");
                
                int answer = Convert.ToInt32(Console.ReadLine());
                
                return answer;
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a number between 1 or 2 only!");
                Console.ResetColor();
                return 0;
            }
        
        }
    }
}
