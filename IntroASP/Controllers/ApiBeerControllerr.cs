using IntroASP.Models;
using IntroASP.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBeerControllerr : ControllerBase
    {
        private readonly PubContext _context;

        public ApiBeerControllerr(PubContext context)
        {
            _context = context;
        }

        public async Task<List<BeerBrandViewModel>> Get()
            => await _context.Beers.Include(b=>b.Brand)
            .Select(b=> new BeerBrandViewModel
            {
                Name=b.Name,
                Brand=b.Brand.Name,
            })
            .ToListAsync();
    }
}
