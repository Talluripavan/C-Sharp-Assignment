using System;
namespace TIC_TAC_TOE
{
    class TTT_Game
    {

        static char[] nums = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        //static bool[] copy_nums = { 'True', "False", 'False', 'False', 'False', 'False', 'False', 'False', 'False', 'False' };
        //static bool[] copy_nums = { false, false, false, false, false, false, false, false, false, false };
        static int game_player = 0;
         static int choice;
        static int tmp;
        static int result = 0;

        private static void game_Board()
        {
            Console.WriteLine(" {0}  |  {1}  |  {2}", nums[1], nums[2], nums[3]);
            Console.WriteLine("____|_____|____ ");
            Console.WriteLine("    |     |      ");
            Console.WriteLine(" {0}  |  {1}  |  {2}", nums[4], nums[5], nums[6]);
            Console.WriteLine("____|_____|____ ");
            Console.WriteLine("    |     |      ");
            Console.WriteLine(" {0}  |  {1}  |  {2}", nums[7], nums[8], nums[9]);
        }
        private static int function_to_check_Winnner()
        {   //check row-1,2,3
            for (int i = 1; i <= 9; i += 3) {
                if (nums[i] == nums[i + 1] && nums[i + 1] == nums[i + 2])
                    return 1;
            }

            //check col-1,2,3
            for (int i = 1; i <= 3; i++)
            {
                if (nums[i] == nums[i + 3] && nums[i + 3] == nums[i + 6])
                    return 1;
            }

            //check diagonals
            if (nums[1] == nums[5] && nums[5] == nums[9])
                return 1;
            if (nums[3] == nums[5] && nums[5] == nums[7])
                return 1;
            //check if all are occupied before
            if (nums[1] != '1' && nums[2] != '2' && nums[3] != '3' && nums[4] != '4' && nums[5] != '5' && nums[6] != '6' && nums[7] != '7' && nums[8] != '8' && nums[9] != '9')
                return -1;
            else
                return 0;
        }
       /* class InvalidchoiceException : Exception
        {
            public InvalidchoiceException(string Message):base (Message)
            {

            }
        }*/
        static void Main(string[] args)
        {
            Console.WriteLine("!!Tick Toc Toe Game!!");
            Console.WriteLine("PLAYER-1:X & PLAYER-2:O");
            Console.WriteLine("\n");
            while (result != 1 && result != -1) 
            {
                //Console.Clear();
                //Console.WriteLine("PLAYER-1:X & PLAYER-2:O");
                //Console.WriteLine("\n");
                //calling board
                game_Board();
                if (game_player % 2 == 0)
                    Console.Write("PLAYER 2 CHANCE:");
                else
                    Console.Write("PLAYER 1 CHANCE:");
                // ------------Exception Handling------------;
                string u_input;
                int flag;
                do
                {
                    u_input = Console.ReadLine();
                    flag = Validate_U_input(u_input);
                } while (flag != 1);

                //validating user input
                int Validate_U_input(string word)
                {
                    try
                    {
                        choice = Int32.Parse(word);
                        if (choice >= 10 || choice <= 0)
                        {
                            throw new Exception("PLEASE CHOOSE BETWEEN (1-9)!");
                        }
                        return 1;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("PLEASE ENTER VALID INPUT!:");
                        return 0;
                    }
                }
                //-----Exception end
                
                //which player has to take chance  
                if (nums[choice] == 'X' || nums[choice] == 'O')
                {
                    Console.WriteLine("{0} ROW IS ALREADY PLACED WITH {1} PLEASE SELECT ANOTHER ONE", choice, nums[choice]);
                }
                else if (nums[choice] != 'X' && nums[choice] != 'O')
                {
                    if (game_player % 2 == 0)
                    {
                        nums[choice] = 'O';
                        game_player++;
                    }
                    else
                    {
                        nums[choice] = 'X';
                        game_player++;
                    }
                }
                else
                {
                    Console.WriteLine("{0} ROW IS ALREADY PLACED WITH {1}", choice, nums[choice]);
                }
                result = function_to_check_Winnner();
            }
            Console.Clear();
            game_Board();
            if (result == 1)
                Console.WriteLine("------PLAYER {0} HAS WON------", (game_player % 2) + 1);
            else
                Console.WriteLine("-----DRAW GAME------");
            Console.ReadLine();
        }

    }
}