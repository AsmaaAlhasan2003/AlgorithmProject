using AlgorithmProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlgorithmProject.Controllers
{

   
        public class KnightTourController : Controller
        {
            public IActionResult Index()
        {
            return View();
        }
      

            [HttpPost("solve")]
            public IActionResult SolveKnightTour([FromBody] KnightTourRequest request)
            {
                var board = KnightTour.KnightTourSolve(request.StartRow, request.StartCol);

                if (board != null)
                {
                    return Ok(board);
                }
                else
                {
                    return BadRequest("لا يوجد حل للمشكلة");
                }
            }
        }

        public class KnightTourRequest
        {
            public int StartRow { get; set; }
            public int StartCol { get; set; }
        }
    }



