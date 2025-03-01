using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text;

namespace TrieApp.Controllers
{
    [ApiController]
    [Route("trie")]
    public class TrieController : Controller
    {
        private static Trie _trie = new Trie();

        // إضافة كلمة جديدة
        [HttpPost("insert")]
        public IActionResult InsertWord([FromBody] string word)
        {
            foreach (char c in word)
            {

                _trie.Insert(word);
            }
            
            return Ok(new { message = $"تمت إضافة الكلمة: {word}" });
        }

        // البحث عن كلمة
        [HttpGet("search/{word}")]
        public IActionResult SearchWord(string word)
        {
            bool exists = _trie.Search(word);
            return Ok(new { message = exists ? $"الكلمة '{word}' موجودة" : $"الكلمة '{word}' غير موجودة" });
        }
        // حذف كلمة
        [HttpDelete("delete")]
        public IActionResult DeleteWord([FromBody] string word)  // تغيير هنا ليتوافق مع طريقة إرسال الكلمة في الجسم
        {
            bool deleted = _trie.Delete(word);
            return Ok(new { success = deleted });
        }

        // تعديل كلمة
        [HttpPut("modify")]
        public IActionResult ModifyWord([FromBody] Dictionary<string, string> data)
        {
            if (!data.ContainsKey("oldWord") || !data.ContainsKey("newWord"))
                return BadRequest(new { message = "يجب إرسال الكلمات القديمة والجديدة" });

            bool updated = _trie.Update(data["oldWord"], data["newWord"]);
            return Ok(new { success = updated });
        }

        // إعادة جميع الكلمات في الشجرة
        [HttpGet("words")]
        public IActionResult GetAllWords()
        {
            return Ok(_trie.GetAllWords());
        }

        // إعادة بيانات الشجرة بتنسيق متوافق مع الرسم
        [HttpGet("tree")]
        public IActionResult Index()
        {
            var root = _trie.GetRoot();
            var treeData = ConvertToTreeStructure(root);
            // هنا نرجع View بدلاً من البيانات المباشرة
            return View("Index", treeData);
        }

        // تحويل شجرة Trie إلى هيكل بيانات مناسب للرسم
        private object ConvertToTreeStructure(TrieNode node)
        {
            var children = new List<object>();

            foreach (var child in node.Children)
            {
                var childData = ConvertToTreeStructure(child.Value);
                children.Add(new
                {
                    name = child.Key,
                    children = childData
                });
            }

            return new
            {
                name = node.Value,
                children = children
            };
        }
    }
}
