using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPIApp.Models;
using MyWebAPIApp.Services;

namespace MyWebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiByRepoPatternController : ControllerBase
    {
        private readonly ILoaiRepository _loaiRepository;

        public LoaiByRepoPatternController(ILoaiRepository loaiRepository)
        {
            _loaiRepository = loaiRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_loaiRepository.GetAll());
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("/findById/{id}")]
        public IActionResult GetById([FromRoute(Name ="id")] int id)
        {
            try
            {
                var data = _loaiRepository.GetById(id);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        [HttpPut("{id}")]
        public IActionResult Update(int id, LoaiVM loai)
        {
            try
            {
                if (id != loai.MaLoai)
                {
                    return BadRequest();
                }
                var data = _loaiRepository.GetById(id);
                if (data != null)
                {
                    _loaiRepository.Update(loai);
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _loaiRepository.Delete(id);
                return Ok("Delete by id: "+id+" is successful!");
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Add(LoaiModel loai)
        {
            try
            {
                return Ok(_loaiRepository.Add(loai));
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
