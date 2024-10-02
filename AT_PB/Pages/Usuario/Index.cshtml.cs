using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AT_PB.Models;

namespace AT_PB.Pages.Usuario
{
    public class IndexModel : PageModel
    {
        private readonly AT_PB.Models.AppDbContext _context;

        public IndexModel(AT_PB.Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<Models.Usuario> Usuario { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Usuario = await _context.Usuarios.ToListAsync();
        }
    }
}
