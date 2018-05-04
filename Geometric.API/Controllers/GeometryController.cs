using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Geometric.API.Controllers
{
    [Route("api/[controller]")]
    public class GeometryController : Controller
    {
        /// <summary>
        /// Examings the triangle.
        /// </summary>
        /// <returns>the triangle type (right, acute, abtuse)</returns>
        /// <param name="A">A. length of A</param>
        /// <param name="B">B. length of B</param>
        /// <param name="C">C. length of C, C must be the longste side</param>
        [HttpGet]
        public string ExamingTriangle(float A, float B, float C) {

            if (C != Math.Max(C,Math.Max(B,A))) {
                return "make sure that C is the longste side";
            }

            TriangleType type = TriangleType.unknown;

            var A2B2 = Math.Pow(A, 2) + Math.Pow(B, 2);

            var C2 = Math.Pow(C, 2);

            if (C2 == A2B2) {
                type = TriangleType.right;
            } else if (C2 < A2B2) {
                type = TriangleType.acute;
            } else if (C2 > A2B2) {
                type = TriangleType.obtuse;
            }

            return $"the triangle is a {type.ToString()} triangle A={A}, B={B}, C={C}";
        }
    }


    /// <summary>
    /// Triangle type.
    /// </summary>
    enum TriangleType
    {
        unknown,
        right,
        acute,
        obtuse
    }
}
