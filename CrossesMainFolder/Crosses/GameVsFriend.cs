﻿
namespace Crosses
{
    class GameVsFriend
    {
        public int GameOverMenu;
       
       
        public void GamePlan() 
        {
            GameOverMenu = 1;
            bool matchEnd = false;
            while (GameOverMenu == 1)
            {
                function game = new function();
                game.intiBord();

                for (int i = 0; i < 100; i++)
                {
                    bool MoveLigel = false;
                    while (MoveLigel == false)
                    {
                        int numberOfTheSqare;

                        do
                        {
                          numberOfTheSqare = game.GetUserMove();
                        } while (numberOfTheSqare  < 1 || numberOfTheSqare > 9);

                        MoveLigel = game.changeSqareTypeIfMoveLigel(numberOfTheSqare);
                        if (MoveLigel == true)
                        {
                            game.Bord();
                        }
                    }

                    matchEnd = game.checkEndMuch();
                    game.changePlayer(game.player);
                    
                   
                    if (matchEnd == true)
                    {
                        break;
                    }
                    game.alertPlayerTurn();
                }

                GameOverMenu = 0;
                while (!(GameOverMenu == 1 || GameOverMenu == 2 || GameOverMenu == 3))
                {
                    GameOverMenu = game.GameOverMenu(GameOverMenu);
                }
                if (GameOverMenu == 2)
                {
                    startGame mainMenu = new startGame();
                    mainMenu.start();
                }
                if (GameOverMenu == 3)
                {
                    game.Exit();
                }
            }
        
        }
    }
}
