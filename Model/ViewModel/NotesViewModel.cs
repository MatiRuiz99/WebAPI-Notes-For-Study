using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class NotesViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
        public int UserId { get; set; }
    }
}
