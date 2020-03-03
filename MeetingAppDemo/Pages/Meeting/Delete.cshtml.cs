using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MeetingAppDemo.Data;
using MeetingAppDemo.Models;

namespace MeetingAppDemo
{
    public class DeleteModel : PageModel
    {
        private readonly MeetingAppDemo.Data.MeetingRoomContext _context;

        public DeleteModel(MeetingAppDemo.Data.MeetingRoomContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MeetingRoom MeetingRoom { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MeetingRoom = await _context.MeetingRooms.FirstOrDefaultAsync(m => m.ID == id);

            if (MeetingRoom == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MeetingRoom = await _context.MeetingRooms.FindAsync(id);

            if (MeetingRoom != null)
            {
                _context.MeetingRooms.Remove(MeetingRoom);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
