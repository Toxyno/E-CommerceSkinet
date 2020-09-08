using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skinet.Core.Entities;
using Skinet.Core.Interfaces;
using Skinet.Infrastructure.Data;

namespace skinetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        ////We need to detach the storeContext scope away from our Controller
        //So we need to Reference the InterfaceRepo that has been created for the controller
        // private readonly StoreContext _context;

        // public ProductsController(StoreContext context)
        // {
        //     _context = context;
        // }
        private readonly IProductRepository _productrepo;

        public ProductsController(IProductRepository productrepo)
        {
            _productrepo = productrepo;

        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _productrepo.GetProductsAsync();

            return Ok(products);
        }


        // PUBLIC ACTIONRESULT<LIST<PRODUCT>> GETPRODUCTS()
        // {
        //     VAR PRODUCTS = _CONTEXT.PRODUCTS.TOLIST();

        //     RETURN OK(PRODUCTS);
        // }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _productrepo.GetProductByIdAsync(id);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productrepo.GetProductBrandsAsync());
        }

         [HttpGet("types")]
         public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _productrepo.GetProductTypesAsync());
        }
    }
}