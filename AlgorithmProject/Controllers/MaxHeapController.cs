
using Microsoft.AspNetCore.Mvc;

public class MaxHeapController : Controller
{
    private static MaxHeap _maxHeap = new MaxHeap();

    public IActionResult Index()
    {
        return View(_maxHeap.ToList());
    }

    [HttpPost]
    public IActionResult Push(int val)
    {
        _maxHeap.Push(val);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Pop()
    {
        if (_maxHeap.ToList().Count > 0)
            _maxHeap.Pop();
        return RedirectToAction("Index");
    }
}
