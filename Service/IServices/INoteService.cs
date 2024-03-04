using Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface INoteService
    {
        List<NoteDTO> GetUserNotesList(int id);
        string CreateNewNote(NoteDTO newnote);
        string ModifyNote(NoteDTO note);
        void DeleteNote(int id);
    }
}
