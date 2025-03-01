using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("avltree")]
public class AVLTreeController : Controller
{
    private static AVLTree _avlTree = new AVLTree();

    [HttpPost("insert")]
    public IActionResult Insert([FromBody] int value)
    {
        _avlTree.Insert(value);
        return Ok(new { message = "تمت إضافة العنصر بنجاح", treeValues = GetTreeValues() });
    }

    [HttpDelete("delete/{value}")]
    public IActionResult Delete(int value)
    {
        _avlTree.Delete(value);
        return Ok(new { message = "تم حذف العنصر بنجاح", treeValues = GetTreeValues() });
    }

    [HttpGet("search/{value}")]
    public IActionResult Search(int value)
    {
        var result = _avlTree.Search(value);
        return Ok(new { found = result.found, attempts = result.attempts });
    }

    [HttpGet("values")]
    public IActionResult GetValues()
    {
        return Ok(GetTreeValues());
    }

    [HttpGet("root")]
    public IActionResult GetRoot()
    {
        return Ok(new { rootValue = _avlTree.Root?.Value });
    }

    private List<int> GetTreeValues()
    {
        List<int> treeValues = new List<int>();
        _avlTree.InOrderTraversal(_avlTree.Root, treeValues);
        return treeValues;
    }

    public IActionResult Index()
    {
        return View();
    }
}
