using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crosses
{
    class startGame
    {
        public void start()
        {
            function f = new function();
            Menu m = new Menu();
            int mood;
            do
            {
                Console.Clear();
                mood = m.mainMenu();
            } while (!(mood == 1 || mood == 2 || mood ==3));
            if (mood == 2)
            {
                Console.Clear();
                GameVsFriend twoPlayer = new GameVsFriend();
                twoPlayer.GamePlan();
            }
            if (mood == 1)
            {
                Console.Clear();
                GameVsComputer onePlayer = new GameVsComputer();
                onePlayer.GamePlan();
            }
            else 
            {
                f.Exit(); 
            }
            
        }
    }
}
