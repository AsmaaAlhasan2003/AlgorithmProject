using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AlgorithmProject.Controllers
{
    public class MinHeapController : Controller
    {
        private static MinHeap _minHeap = new MinHeap();

        public IActionResult Index()
        {
            return View(_minHeap.ToList());
        }

        [HttpPost]
        public IActionResult Push(int val)
        {
            _minHeap.Push(val);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Pop()
        {
            if (_minHeap.ToList().Count > 0)
                _minHeap.Pop();
            return RedirectToAction("Index");
        }
    }
}
