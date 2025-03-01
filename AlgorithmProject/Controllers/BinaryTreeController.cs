using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AVLTreeApp.Controllers
{
    [Route("binarytree")]
    public class BinaryTreeController : Controller
    {
        private static BinaryTree _binaryTree = new BinaryTree();
        private static int _insertAttempts = 0;
        private static int _deleteAttempts = 0;
        private static int _updateAttempts = 0;
        // دالة لإدخال قيمة جديدة في الشجرة
        [HttpPost("insert")]
        public IActionResult Insert([FromBody] int value)
        {
            var stopwatch = Stopwatch.StartNew(); // بدء التوقيت
            _binaryTree.Insert(value);
            stopwatch.Stop(); // إيقاف التوقيت
            return Ok(new { message = "تم إدخال العنصر بنجاح", executionTime = stopwatch.ElapsedMilliseconds });
        }
        // دالة لحذف قيمة من الشجرة
        [HttpDelete("delete/{value}")]
        public IActionResult Delete(int value)
        {
            var stopwatch = Stopwatch.StartNew();
            _deleteAttempts++;
            var result = _binaryTree.Delete(value);
            stopwatch.Stop();
            return Ok(new { message = result ? "تم حذف العنصر بنجاح" : "العنصر غير موجود", executionTime = stopwatch.ElapsedMilliseconds, deleteAttempts = _deleteAttempts });
        }

        // دالة لتعديل قيمة في الشجرة
        [HttpPut("update/{oldValue}")]
        public IActionResult Update(int oldValue, [FromBody] int newValue)
        {
            var stopwatch = Stopwatch.StartNew();
            _updateAttempts++;
            var result = _binaryTree.Update(oldValue, newValue);
            stopwatch.Stop();
            return Ok(new { message = result ? "تم تعديل العنصر بنجاح" : "العنصر غير موجود", executionTime = stopwatch.ElapsedMilliseconds, updateAttempts = _updateAttempts });
        }
        // دالة للحصول على القيم بترتيب Inorder
        [HttpGet("inorder")]
        public IActionResult Inorder()
        {
            var stopwatch = Stopwatch.StartNew(); // بدء التوقيت
            var result = _binaryTree.InOrderTraversal(_binaryTree.Root);
            stopwatch.Stop(); // إيقاف التوقيت
            return Ok(new { result, executionTime = stopwatch.ElapsedMilliseconds });
        }

        // دالة للحصول على القيم بترتيب Preorder
        [HttpGet("preorder")]
        public IActionResult Preorder()
        {
            var stopwatch = Stopwatch.StartNew(); // بدء التوقيت
            var result = _binaryTree.PreOrderTraversal(_binaryTree.Root);
            stopwatch.Stop(); // إيقاف التوقيت
            return Ok(new { result, executionTime = stopwatch.ElapsedMilliseconds });
        }

        // دالة للحصول على القيم بترتيب Postorder
        [HttpGet("postorder")]
        public IActionResult Postorder()
        {
            var stopwatch = Stopwatch.StartNew(); // بدء التوقيت
            var result = _binaryTree.PostOrderTraversal(_binaryTree.Root);
            stopwatch.Stop(); // إيقاف التوقيت
            return Ok(new { result, executionTime = stopwatch.ElapsedMilliseconds });
        }

        // دالة للحصول على جميع القيم في الشجرة
        [HttpGet("values")]
        public IActionResult GetValues()
        {
            List<int> treeValues = new List<int>();
            _binaryTree.InOrderTraversal(_binaryTree.Root, treeValues); // استخراج القيم من الشجرة
            return Ok(treeValues); // إرجاع القيم للـ View
        }

        public IActionResult Index()
        {
            List<int> treeValues = new List<int>();
            _binaryTree.InOrderTraversal(_binaryTree.Root, treeValues); // استخراج القيم من الشجرة
            return View(treeValues); // إرجاع القيم للـ View
        }
    }

  
}
