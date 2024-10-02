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
    public class DetailsModel : PageModel
    {
        private readonly AT_PB.Models.AppDbContext _context;

        public DetailsModel(AT_PB.Models.AppDbContext context)
        {
            _context = context;
        }

        public Models.Usuario Usuario { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (usuario == null)
            {
                return NotFound();
            }
            else
            {
                Usuario = usuario;
            }
            return Page();
        }
    }
}
