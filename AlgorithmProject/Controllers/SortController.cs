using Microsoft.AspNetCore.Mvc;
using AlgorithmProject.Models;
using System.Collections.Generic;

namespace AlgorithmProject.Controllers
{
    public class SortController : Controller
    {
        private static List<int> _array = new List<int>();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SortArray([FromBody] SortRequest request)
        {
            List<int> arrayCopy = new List<int>(_array);
            int comparisons = 0;
            int swaps = 0;

            // بناءً على الخوارزمية المختارة، نقوم بالترتيب
            switch (request.Algorithm)
            {
                case "BubbleSort":
                    (arrayCopy, comparisons, swaps) = SortAlgorithms.BubbleSort(arrayCopy);
                    break;
                case "SelectionSort":
                    (arrayCopy, comparisons, swaps) = SortAlgorithms.SelectionSort(arrayCopy);
                    break;
                case "InsertionSort":
                    (arrayCopy, comparisons, swaps) = SortAlgorithms.InsertionSort(arrayCopy);
                    break;
                case "MergeSort":
                    arrayCopy = SortAlgorithms.MergeSort(arrayCopy);
                    break;
                default:
                    break;
            }

            var result = new
            {
                sortedArray = arrayCopy,
                comparisons = comparisons,
                swaps = swaps
            };

            return Json(result); // إعادة استجابة بصيغة JSON
        }

        [HttpPost]
        public IActionResult AddElement(int value)
        {
            _array.Add(value);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveElement(int value)
        {
            _array = SortAlgorithms.RemoveItem(_array, value);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateElement(int oldValue, int newValue)
        {
            _array = SortAlgorithms.UpdateItem(_array, oldValue, newValue);
            return RedirectToAction("Index");
        }

        public JsonResult GetArray()
        {
            return Json(_array);
        }
    }

    public class SortRequest
    {
        public string Algorithm { get; set; }
    }
}
