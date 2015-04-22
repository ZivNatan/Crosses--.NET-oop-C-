using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Crosses
{
    class function
    {
        Square[,] matrix = new Square[3, 3];
        public int counter = 1;
        public string player;

        public void intiBord()
        {
            Console.Clear();
            Console.ResetColor();
            player = "X";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrix[i, j].Type = "Empty";
                    matrix[i, j].Number = counter;
                    matrix[i, j].ChangeDrawSquare();
                    counter++;
                
                    Console.Write(matrix[i, j].DrawSquare);
                    
                     
                }
                Console.WriteLine();
              
            }
            Console.WriteLine();
        }

        public void Bord() 
        {
            
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {   
                    matrix[i, j].ChangeDrawSquare();
                    if (matrix[i, j].Type == "X")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(matrix[i, j].DrawSquare);
                        Console.ResetColor();

                    }
                    if (matrix[i, j].Type == "O")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(matrix[i, j].DrawSquare);
                        Console.ResetColor();
                    }
                    if(matrix[i, j].Type == "Empty")
                    {
                        Console.Write(matrix[i, j].DrawSquare);
                    }
                    
                }
                Console.WriteLine();
               
            }
            Console.WriteLine();
        }

        public int GetUserMove()
        {
            
                try
                {
                    Console.WriteLine("Please enter the number of the square that you want to use. 1-9 only!");
                    int sqareNumber = Convert.ToInt32(Console.ReadLine());
                    return sqareNumber;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a number between 1-9 only!");
                    Console.ResetColor();
                    return 0;
                }
            
        }

        public bool changeSqareTypeIfMoveLigel(int squareNumber) 
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (matrix[i, j].Number == squareNumber) 
                    {
                        if (matrix[i, j].Type == "Empty")
                        {
                            matrix[i, j].Type = player;
                            return true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("the sqare you tring to use allready have a value, try a diffrent one! ");
                            Console.ResetColor();
                            return false;
                        }
                    }
                }
            }
            return false;

        }
        public void alertPlayerTurn()
        {
              if (player == "O")
            {
                this.player = "O";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Player O move.");
                Console.ResetColor();
            }
             else
            {
                this.player = "X";
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Player X move.");
                Console.ResetColor();
            }
        
        }
        public void changePlayer(string player)
        {
            if (player == "X")
            {
                this.player = "O";
             
            }
            else
            {
                this.player = "X";
            }
        }

        public bool checkForWinner(string player) 
        {
            //chek for row win
            if (((matrix[0, 0].Type == player) && (matrix[0, 1].Type == player) && (matrix[0, 2].Type == player)) ||
           ((matrix[1, 0].Type == player) && (matrix[1, 1].Type == player) && (matrix[1, 2].Type == player)) ||
           ((matrix[2, 0].Type == player) && (matrix[2, 1].Type == player) && (matrix[2, 2].Type == player)))
            {
                return true;
            }
            // chek for  column win
            if (((matrix[0, 0].Type == player) && (matrix[1, 0].Type == player) && (matrix[2, 0].Type == player)) ||
              ((matrix[0, 1].Type == player) && (matrix[1, 1].Type == player) && (matrix[2, 1].Type == player)) ||
              ((matrix[0, 2].Type == player) && (matrix[1, 2].Type == player) && (matrix[2, 2].Type == player))) 
            {
                return true;
            }
            // check for  diangil win
            if (((matrix[0, 0].Type == player) && (matrix[1, 1].Type == player) && (matrix[2, 2].Type == player)) ||
              ((matrix[0, 2].Type == player) && (matrix[1, 1].Type == player) && (matrix[2, 0].Type == player)))
            {
                return true;
            }
            else 
            {
                return false; 
            }
        
        }

        public bool chekForTie() 
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (matrix[i, j].Type == "Empty")
                    return false;
                }
            }
            return true;
        
        }

        public void computerMood()
        {
            int cell;
            cell = checkWinMove();
            if (cell <= 9 && cell > 0) 
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (matrix[i, j].Number == cell) 
                        {
                            matrix[i, j].Type = "O";
                        }
                    }
                }  
            }
            else 
            {
               cell = checkBlockMove();
               if (cell <= 9 && cell > 0)
               {
                   for (int i = 0; i < 3; i++)
                   {
                       for (int j = 0; j < 3; j++)
                       {
                           if (matrix[i, j].Number == cell)
                           {
                               matrix[i, j].Type = "O";
                           }
                       }
                   }  
               }
               else 
               {
                   randomMove();
               }
            }
        }

        public void randomMove()
        {
            Random rnd = new Random();

            int cellNumber = rnd.Next(1, 10);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                    if (matrix[i, j].Number == cellNumber)
                    {
                        if (matrix[i, j].Type == "Empty")
                        {
                            matrix[i, j].Type = "O";
                        }
                        else
                        {
                            cellNumber = rnd.Next(1, 10);
                            i = 0;
                            j = 0;
                        }
                    }
                 }
             }
         }

        public int checkBlockMove() 
        {
            bool needToBlock = false;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                        if (matrix[i, j].Type == "Empty")
                        {
                            matrix[i, j].Type = "X";
                           needToBlock = this.checkForWinner("X");
                           matrix[i, j].Type = "Empty";
                        }
                        if (needToBlock == true) 
                        {
                            return matrix[i, j].Number; 
                        } 
                }
            }
            return 0;
        
         }

        public int checkWinMove()
        {
            bool checkWin = false;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (matrix[i, j].Type == "Empty")
                    {
                        matrix[i, j].Type = "O";
                        checkWin = this.checkForWinner("O");
                        matrix[i, j].Type = "Empty";
                    }
                    if (checkWin == true)
                    {
                        return matrix[i, j].Number;
                        
                    }
                }
            }
            return 0;

        }

        public bool checkEndMuch() 
        {

            bool Winerr = checkForWinner(player);
            if (Winerr == true)
            {
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("FUCK YA!! THE WINNNNER IS: " + player + "!");
                Thread.Sleep(1000);
                Console.ResetColor();
                return true;
                
               
            }
            bool tie = chekForTie();
            if (tie == true)
            {
               
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("SHHHHIT! THAT'S A TIE!");
                Thread.Sleep(1000);
                Console.ResetColor();
                return true;
            }
            return false;
        
        }
        public void Exit() 
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Bye Bye :)");
            Thread.Sleep(2000);
            Environment.Exit(0);
        }

        public int GameOverMenu(int GameOverMenu)
        {
            try
            {
                Console.Clear();
                Console.Write("To restart match press"); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine(" 1"); Console.ResetColor();
                Console.Write("To main menu press"); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine(" 2"); Console.ResetColor();
                Console.Write("To Exit press"); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine(" 3"); Console.ResetColor();
                int select = Convert.ToInt32(Console.ReadLine());
                if (select == 1 || select == 2 || select == 3)
                {
                    return select;
                }

                else
                {
                    return 0;
                }
            }
            catch
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a number between 1-3 only!");
                Console.ResetColor();
                return 0;
            }
        }

        public void Loding()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < 1; i++)
            {
                Console.Write("\rComputer thinking");
                Thread.Sleep(350);
                Console.Write("\r                     ");
                Thread.Sleep(200);
                Console.Write("\rComputer thinking.");
                Thread.Sleep(350);
                Console.Write("\r                     ");
                Thread.Sleep(200);
                Console.Write("\rComputer thinking..");
                Thread.Sleep(350);
                Console.Write("\r                     ");
                Thread.Sleep(200);
                Console.Write("\rComputer thinking...");
                Thread.Sleep(350);
                Console.Write("\r                     ");
                Thread.Sleep(200);
                Console.Write("\rComputer thinking....");
                Thread.Sleep(350);
                Console.Write("\r                     ");
                Thread.Sleep(200);
             
                
            }

        }

    }
}
