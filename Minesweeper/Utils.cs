using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper
{
    public class Utils
    {
        public static string AssignMinedOrNonMinedGivenBool(bool value)
        {
            return value ? "M" : "Non-mined";
        }

        public static bool ValidateMinedFields(bool[,] board)
        {
            int minedFields = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j])
                    {
                        minedFields++;
                    }
                }
            }

            return (minedFields > 0 && minedFields < 9);
        }
    }
}
