using Model.DTO;
using Model.Models;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class NoteService : INoteService
    {
        private readonly NotesWebsiteContext _context;

        public NoteService(NotesWebsiteContext context)
        {
            _context = context;
        }

        public List<NoteDTO> GetUserNotesList(int id)
        {
            var userNotes = _context.Notes
            .Where(note => id == note.UserId)
            .Select(note => new NoteDTO
            {
                Id = note.Id,
                Title = note.Title,
                Description = note.Description,
                Category = note.Category,
                UserId = note.UserId
            })
            .ToList();

            return userNotes;
        }

        public string CreateNewNote(NoteDTO newnote)
        {
            _context.Notes.Add(new Notes()
            {
                Id = newnote.Id,
                Title = newnote.Title,
                Description = newnote.Description,
                UserId = newnote.UserId
            });

            _context.SaveChanges();

            return "Created";
        }

        public string ModifyNote(NoteDTO note)
        {
            var existingNote = _context.Notes.FirstOrDefault(p => p.Id == note.Id);

            if (existingNote == null)
            {
                return "Not Found";
            }

            existingNote.Title = note.Title;
            existingNote.Description = note.Description;
            existingNote.Category = note.Category;

            _context.SaveChanges();

            return "Change complete";
        }

        public void DeleteNote(int id)
        {
            var note = _context.Notes.FirstOrDefault(p => p.Id == id);
            if (note == null)
            {
                return;
            }
            _context.Notes.Remove(note);
            _context.SaveChanges();

            return;
        }
    }
}
