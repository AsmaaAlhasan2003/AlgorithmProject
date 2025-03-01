namespace AlgorithmProject.Models
{
    using System;

    class KnightTour
    {
        static int N = 8; // حجم اللوحة 8x8
        static int[] xMove = new int[] { 2, 1, -1, -2, -2, -1, 1, 2 };
        static int[] yMove = new int[] { 1, 2, 2, 1, -1, -2, -2, -1 };

        public static bool IsSafe(int[,] board, int row, int col)
        {
            return (row >= 0 && row < N && col >= 0 && col < N && board[row, col] == -1);
        }

        public static bool SolveKT(int[,] board, int currRow, int currCol, int moveCount)
        {
            if (moveCount == N * N)
                return true;

            for (int i = 0; i < 8; i++)
            {
                int newRow = currRow + xMove[i];
                int newCol = currCol + yMove[i];

                if (IsSafe(board, newRow, newCol))
                {
                    board[newRow, newCol] = moveCount;
                    if (SolveKT(board, newRow, newCol, moveCount + 1))
                        return true;

                    board[newRow, newCol] = -1; // الرجوع (Backtrack)
                }
            }

            return false; // لا يوجد حل
        }

        public static void PrintSolution(int[,] board)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write(board[i, j] + "\t");
                Console.WriteLine();
            }
        }

        public static int[,] KnightTourSolve(int startRow, int startCol)
        {
            int[,] board = new int[N, N];
            for (int i = 0; i < N-1; i++)
                for (int j = 0; j < N-1; j++)
                    board[i, j] = -1;

            board[startRow, startCol] = 0;

            if (SolveKT(board, startRow, startCol, 1))
                return board;
            else
                return null; // لا يوجد حل
        }
    }

}
