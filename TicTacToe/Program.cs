namespace TicTacToe
{
    class Program
    {
        static char[,] playField =
        {
            { '1', '2', '3' },  // row 1
            { '4', '5', '6' },  // row 2
            { '7', '8', '9' }   // row 3
        };

        static int turns = 0;

        static void Main(string[] args)
        {
            int player = 2;
            int input = 0;
            bool inputCorrect = true;

            do
            {

                if (player == 2)
                {
                    player = 1;
                    EnterXorO('O', input);
                }
                else if (player == 1)
                {
                    player = 2;
                    EnterXorO('X', input);
                }

                SetField();

                CheckForWinner();

                #region Test if field is already taken
                do
                {
                    inputCorrect = IsValidInput(player, ref input);

                } while (!inputCorrect);
                #endregion

            } while (true);
        }

        /// <summary>
        /// Set X or O in the grid based on Player and Input
        /// </summary>
        /// <param name="player"></param>
        /// <param name="input"></param>
        public static void EnterXorO(char playerSign, int input)
        {
            switch (input)
            {
                case 1: playField[0, 0] = playerSign; break;
                case 2: playField[0, 1] = playerSign; break;
                case 3: playField[0, 2] = playerSign; break;
                case 4: playField[1, 0] = playerSign; break;
                case 5: playField[1, 1] = playerSign; break;
                case 6: playField[1, 2] = playerSign; break;
                case 7: playField[2, 0] = playerSign; break;
                case 8: playField[2, 1] = playerSign; break;
                case 9: playField[2, 2] = playerSign; break;
            }

        }

        /// <summary>
        /// Set the grid to play
        /// </summary>
        public static void SetField()
        {
            Console.Clear();

            Console.WriteLine("\n\n");

            Console.WriteLine("                     |       |       ");
            Console.WriteLine("                 {0}   |   {1}   |   {2}   ", playField[0, 0], playField[0, 1], playField[0, 2]);
            Console.WriteLine("              _______|_______|_______");

            Console.WriteLine("                     |       |       ");
            Console.WriteLine("                 {0}   |   {1}   |   {2}   ", playField[1, 0], playField[1, 1], playField[1, 2]);
            Console.WriteLine("              _______|_______|_______");

            Console.WriteLine("                     |       |       ");
            Console.WriteLine("                 {0}   |   {1}   |   {2}   ", playField[2, 0], playField[2, 1], playField[2, 2]);

            Console.WriteLine("                     |       |       ");

            turns++;
        }

        /// <summary>
        /// Check for the possible winner
        /// </summary>
        private static void CheckForWinner()
        {
            char[] playerChars = { 'X', 'O' };

            foreach (char playerChar in playerChars)
            {
                if (((playField[0, 0] == playerChar) && (playField[0, 1] == playerChar) && (playField[0, 2] == playerChar))
                    || ((playField[1, 0] == playerChar) && (playField[1, 1] == playerChar) && (playField[1, 2] == playerChar))
                    || ((playField[2, 0] == playerChar) && (playField[2, 1] == playerChar) && (playField[2, 2] == playerChar))
                    || ((playField[0, 0] == playerChar) && (playField[1, 0] == playerChar) && (playField[2, 0] == playerChar))
                    || ((playField[0, 1] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 1] == playerChar))
                    || ((playField[0, 2] == playerChar) && (playField[1, 2] == playerChar) && (playField[2, 2] == playerChar))
                    || ((playField[0, 0] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 2] == playerChar))
                    || ((playField[0, 2] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 0] == playerChar)))
                {
                    if (playerChar == 'X')
                    {
                        Console.WriteLine("\nPlayer 2 has won!");
                    }
                    else
                    {
                        Console.WriteLine("\nPlayer 1 has won!");
                    }

                    Console.WriteLine("Please press any key to reset the game!");
                    Console.ReadKey();

                    ResetField();

                    break;
                }
                else if (turns == 10)
                {
                    Console.WriteLine("\nDRAW!");

                    Console.WriteLine("Please press any key to reset the game!");
                    Console.ReadKey();

                    ResetField();

                    break;
                }

            }
        }

        /// <summary>
        /// Reset the field
        /// </summary>
        public static void ResetField()
        {
            char[,] playFieldInitial =
            {
                { '1', '2', '3' },  // row 1
                { '4', '5', '6' },  // row 2
                { '7', '8', '9' }   // row 3
            };


            playField = playFieldInitial;
            turns = 0;
            SetField();
        }

        /// <summary>
        /// Is a valid input
        /// </summary>
        /// <param name="player"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        private static bool IsValidInput(int player, ref int input)
        {
            bool inputCorrect;
            Console.Write("\n Player {0}: Choose your field! ", player);
            try
            {
                input = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please enter a number!");
            }

            if ((input == 1) && (playField[0, 0] == '1'))
                inputCorrect = true;
            else if ((input == 2) && (playField[0, 1] == '2'))
                inputCorrect = true;
            else if ((input == 3) && (playField[0, 2] == '3'))
                inputCorrect = true;
            else if ((input == 4) && (playField[1, 0] == '4'))
                inputCorrect = true;
            else if ((input == 5) && (playField[1, 1] == '5'))
                inputCorrect = true;
            else if ((input == 6) && (playField[1, 2] == '6'))
                inputCorrect = true;
            else if ((input == 7) && (playField[2, 0] == '7'))
                inputCorrect = true;
            else if ((input == 8) && (playField[2, 1] == '8'))
                inputCorrect = true;
            else if ((input == 9) && (playField[2, 2] == '9'))
                inputCorrect = true;
            else
            {
                Console.WriteLine("\nIncorrect input! Please use another field!");
                inputCorrect = false;
            }

            return inputCorrect;
        }

    }
}