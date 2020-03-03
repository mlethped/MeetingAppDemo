using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MeetingAppDemo.Data;
using Domain.MeetingRooms;

namespace MeetingAppDemo
{
    public class IndexModel : PageModel
    {
        private readonly MeetingAppDemo.Data.MeetingRoomContext _context;

        public IndexModel(MeetingAppDemo.Data.MeetingRoomContext context)
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
