using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeInfoController : ControllerBase
    {
        public IMyTypesCollection _MyTypes { get; private set; }

        public TypeInfoController(IMyTypesCollection myTypes)
        {
            _MyTypes = myTypes;
        }

        [HttpGet("coretypes/about")]
        public IActionResult AboutTypeInfo()
        {
            return Ok("DAFM woz 'ere.  TypeInfo is just a test .NET Core Web API app");
        }

        [HttpPost("coretypes/add")]
        public IActionResult AddType([FromBody] MyTypeInfo newType)
        {
            if (_MyTypes.FindType(newType.TypeName) == null)
            {
                _MyTypes.AddType(newType);

                return Ok($"Type {newType.TypeName} added successfuu=lly");
            }
            else
            {
                // POST not indempotent, but we will protect from multiple posts of the same type
                return StatusCode(303, $"Resource already exists.");
            }
        }

        [HttpGet("coretypes/gettype/{type}")]
        public IActionResult GetTypeInfo(string type)
        {
            var typeInfo = _MyTypes.FindType(type);

            if (typeInfo == null)
            {
                return NotFound($"{type} not found");
            }
            else
            {
                return new JsonResult(typeInfo);
            }
        }

        [HttpDelete("coretypes/deltype/{type}")]
        public IActionResult DeleteType(string type)
        {
            if(_MyTypes.RemoveType(type))
            {
                return Ok($"{type} record deleted!");
            }
            else
            {
                return NotFound($"{type} record not found.");
            }
        }

        [HttpPatch("coretypes/update")]
        public IActionResult UpdateType([FromBody] MyTypeInfo updatedTypeInfo)
        {
            if (_MyTypes.UpdateType(updatedTypeInfo))
            {
                return Ok($"{updatedTypeInfo.TypeName} record updated!");
            }
            else
            {
                return NotFound($"{updatedTypeInfo.TypeName} record not found.");
            }
        }
    }
}