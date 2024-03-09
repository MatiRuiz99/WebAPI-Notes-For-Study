using Model.DTO;
using Model.ViewModel;
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
        string CreateNewNote(NotesViewModel newnote);
        string ModifyNote(NoteDTO note);
        void DeleteNote(int id);
    }
}
