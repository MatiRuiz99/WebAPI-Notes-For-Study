using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Service.Services;

namespace NotasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerNotes : ControllerBase
    {
        private readonly NoteService _service;

        public ControllerNotes(NoteService noteService)
        {
            _service = noteService;
        }

        [HttpGet("GetNotes")]
        public ActionResult<List<NoteDTO>> GetNotes()
        {
            
            var response = _service.GetUserNotesList();
            return Ok(response);
        }

        [HttpPost("CreateNotes")]
        public ActionResult<NoteDTO> CreateNewNote()
        {
            
            var response = _service.CreateNewNote();
            return Ok(response);
        }

        [HttpPut("ModifyNote")]
        public ActionResult<NoteDTO> ModifyNote()
        {
           
            var response = _service.ModifyNote();
            return Ok(response);
        }

        [HttpDelete("DeleteNote")]
        public ActionResult<NoteDTO> DeleteNote()
        {
            
            var response = _service.DeleteNote();
            return Ok(response);
        }
    }

    
}
