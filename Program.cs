using System;

namespace console_app___T3
{
    class Program
    {
            static void Main(string [] args)
            {
                
                bool AppStart = true;

                menuChoices();
                
                while(AppStart){
                     var selection = Console.ReadLine();
                    switch(selection)
                        {
                            case "O" : start(); AppStart = false; break;
                            case "X" : Environment.Exit(0); break;
                            default: menuChoices(); Console.WriteLine("Invalid command"); break;
                        }
                }

                 void menuChoices(){
                        Console.Clear();
                     Console.WriteLine(" O - start game | X - exit game ");
                 }

            }
            public static void start()
            {
                Board board = new Board();
            WinChecker winChecker = new WinChecker();
            Renderer renderer = new Renderer();
            Player player1 = new Player();
            Player player2 = new Player();

            while(!winChecker.IsDraw(board) && winChecker.Check(board) == State.Undecided)
            {
                renderer.Render(board);
                
                    Position nextMove;
                    if(board.NextTurn == State.X)  nextMove = player1.GetPosition(board);
                    else  nextMove = player2.GetPosition(board);
                    

                    if(!board.SetState(nextMove, board.NextTurn))
                        Console.WriteLine("That is not a legal move.");
                    
            }

            renderer.Render(board);
            renderer.RenderResults(winChecker.Check(board));


            Console.ReadKey();
            }

            
                       
        }
    }

