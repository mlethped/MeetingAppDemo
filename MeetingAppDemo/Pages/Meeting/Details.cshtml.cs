using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain.MeetingRooms;
using Persistance;

namespace MeetingAppDemo
{
    public class DetailsModel : PageModel
    {
        private readonly DatabaseContext _context;

        public DetailsModel(DatabaseContext context)
        {
            _context = context;
        }

        public MeetingRoom MeetingRoom { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MeetingRoom = await _context.MeetingRooms.FirstOrDefaultAsync(m => m.Id == id);

            if (MeetingRoom == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
