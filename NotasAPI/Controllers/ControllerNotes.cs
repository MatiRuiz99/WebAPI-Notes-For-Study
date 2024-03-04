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
        public ActionResult<List<NoteDTO>> GetNotes([FromBody]int id)
        {
            
            var response = _service.GetUserNotesList(id);
            return Ok(response);
        }

        [HttpPost("CreateNotes")]
        public ActionResult<NoteDTO> CreateNewNote([FromBody] NoteDTO note)
        {
            
            var response = _service.CreateNewNote(note);
            return Ok(response);
        }

        [HttpPut("ModifyNote")]
        public ActionResult<NoteDTO> ModifyNote([FromBody] NoteDTO note)
        {
           
            var response = _service.ModifyNote(note);
            return Ok(response);
        }

        [HttpDelete("DeleteNote")]
        public ActionResult<NoteDTO> DeleteNote([FromBody]int id)
        { 
            _service.DeleteNote(id);
            return Ok();
        }
    }

    
}
