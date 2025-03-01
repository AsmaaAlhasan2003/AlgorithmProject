using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace NQueensApp.Controllers
{
    public class NQueensController : Controller
    {
        // عرض الصفحة الأولى
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // حل المشكلة عند إرسال البيانات من المستخدم
        [HttpPost]
        public IActionResult SolveNQueens(int n)
        {
            if (n <= 0)
            {
                ModelState.AddModelError("n", "عدد الملكات يجب أن يكون أكبر من 0");
                return View("Index");
            }

            var solutions = SolveNQueensLogic(n);

            if (solutions.Count == 0)
            {
                ViewBag.Message = "لا توجد حلول لهذه المشكلة";
                return View("Index");
            }

            // عرض عدد الحلول وعدد الزمن
            ViewBag.SolutionsCount = solutions.Count;
            return View("Index", solutions);
        }

        // منطق حل مشكلة N-Queens
        private List<List<string>> SolveNQueensLogic(int n)
        {
            var solutions = new List<List<string>>();
            var board = new int[n]; // تعيين مصفوفة لتخزين ترتيب الملكات
            SolveNQueensUtil(board, 0, n, solutions);
            return solutions;
        }

        // الخوارزمية الخاصة بحل N-Queens باستخدام Backtracking
        private void SolveNQueensUtil(int[] board, int row, int n, List<List<string>> solutions)
        {
            // إذا وصلنا لعدد الملكات المطلوب، نضيف الحل
            if (row == n)
            {
                AddSolution(board, solutions, n);
                return;
            }

            // محاولة وضع ملكة في كل صف
            for (int col = 0; col < n; col++)
            {
                if (IsSafe(board, row, col, n))
                {
                    board[row] = col; // وضع الملكة في مكان آمن
                    SolveNQueensUtil(board, row + 1, n, solutions); // الانتقال للصف التالي
                    board[row] = -1; // التراجع بعد المحاولة
                }
            }
        }

        // التأكد إذا كانت الملكة في الموقع (row, col) آمنة أم لا
        private bool IsSafe(int[] board, int row, int col, int n)
        {
            for (int i = 0; i < row; i++)
            {
                // تحقق من التهديدات العمودية والأقطار
                if (board[i] == col || Math.Abs(board[i] - col) == Math.Abs(i - row))
                    return false;
            }
            return true;
        }

        private void AddSolution(int[] board, List<List<string>> solutions, int n)
        {
            var solution = new List<string>();
            for (int i = 0; i < n; i++)
            {
                var row = new char[n]; // تغيير نوع السلسلة إلى char[]
                for (int j = 0; j < n; j++)
                {
                    row[j] = (j == board[i]) ? 'Q' : '.';
                    
                }
                solution.Add(new string(row)); 

            }
            solutions.Add(solution);
        }
    }
}
