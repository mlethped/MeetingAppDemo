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
    public class IndexModel : PageModel
    {
        private readonly MeetingRoomContext _context;

        public IndexModel(MeetingRoomContext context)
        {
            _context = context;
        }

        public IList<MeetingRoom> MeetingRoom { get;set; }

        public async Task OnGetAsync()
        {
            MeetingRoom = await _context.MeetingRooms.ToListAsync();
        }
    }
}
