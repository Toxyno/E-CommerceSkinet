using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skinet.Core.Entities;
using Skinet.Infrastructure.Data;

namespace skinetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var producta = await _context.Products.ToListAsync();

            return Ok(producta);
        }


        // PUBLIC ACTIONRESULT<LIST<PRODUCT>> GETPRODUCTS()
        // {
        //     VAR PRODUCTS = _CONTEXT.PRODUCTS.TOLIST();

        //     RETURN OK(PRODUCTS);
        // }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>>  GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }
    }
}