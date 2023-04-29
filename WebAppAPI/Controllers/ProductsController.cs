using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppAPI.Data;
using WebAppAPI.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppAPI.Controllers
{
    // APICONTROLLER is used to get data from database as JSON format.
    // DataContext is created under the Data folder and the necessary links were made in program.cs and appsettings.json files.
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<ProductsController> _logger;
        
        public ProductsController(DataContext dataContext, ILogger<ProductsController> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        // Get all products objects from the database.
        // If all is Ok, return 200 code. 
        [HttpGet(Name = "GetProduct")]
        public async Task<IActionResult> GetAsync()
        {
            var students = await _dataContext.Products.ToListAsync();
            return Ok(students);
        }


    }
}

