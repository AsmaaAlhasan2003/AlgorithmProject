public class NQueensService
{
    public List<List<string>> SolveNQueens(int n)
    {
        List<List<string>> solutions = new List<List<string>>();
        int[] board = new int[n];
        Solve(board, 0, n, solutions);
        return solutions;
    }

    private void Solve(int[] board, int row, int n, List<List<string>> solutions)
    {
        if (row == n)
        {
            solutions.Add(ConvertBoardToSolution(board, n));
            return;
        }

        for (int col = 0; col < n; col++)
        {
            if (IsSafe(board, row, col, n))
            {
                board[row] = col;
                Solve(board, row + 1, n, solutions);
                board[row] = -1;
            }
        }
    }

    private bool IsSafe(int[] board, int row, int col, int n)
    {
        for (int i = 0; i < row; i++)
        {
            if (board[i] == col || Math.Abs(board[i] - col) == Math.Abs(i - row))
            {
                return false;
            }
        }
        return true;
    }

    private List<string> ConvertBoardToSolution(int[] board, int n)
    {
        List<string> solution = new List<string>();
        for (int i = 0; i < n; i++)
        {
            char[] row = new char[n];
            for (int j = 0; j < n; j++)
            {
                row[j] = (j == board[i]) ? 'Q' : '.';
            }
            solution.Add(new string(row));
        }
        return solution;
    }
}
