using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MeetingAppDemo.Data;
using Domain.MeetingRooms;

namespace MeetingAppDemo
{
    public class CreateModel : PageModel
    {
        private readonly MeetingAppDemo.Data.MeetingRoomContext _context;

        public CreateModel(MeetingAppDemo.Data.MeetingRoomContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MeetingRoom MeetingRoom { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MeetingRooms.Add(MeetingRoom);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
