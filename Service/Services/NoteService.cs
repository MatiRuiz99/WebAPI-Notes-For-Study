using Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class NoteService
    {
        public List<NoteDTO> GetUserNotesList()
        {
            var noteList = new List<NoteDTO>();

            for (int i = 0; i < 4; i++)
            {
                noteList.Add(new NoteDTO()
                {
                    Id = i,
                    Title = "ea",
                    Description = "producto",
                    Category = 1,
                    AuthorId = 1

                });
            }
            return noteList;
        }

        public NoteDTO CreateNewNote(NoteDTO newnote)
        {
            _context.Add(new NoteDTO()
            {
                Id = newnote.Id, 
                Title = newnote.Title,
                Description = newnote.Description,
                AuthorId = newnote.AuthorId
            })
            return new NoteDTO();
        }

        public NoteDTO ModifyNote()
        {
            var response = _context.Notes.FirstOrDefault(p => p.Id == Id);

            if (response == null)
            {
                return null;
            }
            // AGREGAR CAMBIO DE NOTE.
            

            return new NoteDTO();
        }

        public NoteDTO DeleteNote()
        {

            return new NoteDTO();
        }
    }
}
