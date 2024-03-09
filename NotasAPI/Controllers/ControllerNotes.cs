using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Model.ViewModel;
using Service.IServices;
using Service.Services;

namespace NotasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerNotes : ControllerBase
    {
        private readonly INoteService _service;

        public ControllerNotes(INoteService noteService)
        {
            _service = noteService;
        }

        [HttpGet("GetNotes/{id}")]
        public ActionResult<List<NoteDTO>> GetNotes([FromRoute]int id)
        {
            
            var response = _service.GetUserNotesList(id);
            return Ok(response);
        }

        [HttpPost("CreateNotes")]
        public ActionResult<string> CreateNewNote([FromBody] NotesViewModel note)
        {
            
            var response = _service.CreateNewNote(note);
            return Ok(response);
        }

        [HttpPut("ModifyNote")]
        public ActionResult<string> ModifyNote([FromBody] NoteDTO note)
        {
           
            var response = _service.ModifyNote(note);
            return Ok(response);
        }

        [HttpDelete("DeleteNote")]
        public ActionResult<string> DeleteNote([FromBody]int id)
        { 
            _service.DeleteNote(id);
            return Ok("deleteado");
        }
    }

    
}
