using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Nancy.Json;
using DataLayer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        ProductsDbProcessing data = new ProductsDbProcessing();
        
        [HttpGet]
        public string Get()
        {
            return (new JavaScriptSerializer().Serialize(data.GetAllProducts()));
        }

        //// GET api/<ProductsController>/5
        //[HttpGet("{Id}")]
        //public string Get(int Id)
        //{
        //    return (new JavaScriptSerializer().Serialize(data.GetAllProducts(Id)));
        //}

        [HttpGet("{ProductName}")]

        public string Get(string ProductName)
        {
            return (new JavaScriptSerializer().Serialize(data.GetProductsFromName(ProductName)));
        }

        // POST api/<ProductsController>
        [HttpPost]
        public Products Post(Products Product)
        {
            return data.CreatProducts(Product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public Products Put(int Id, Products Product)
        {
            return data.EditProducts(Id,Product);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int Id)
        {
            data.DeleteProducts(Id);
        }
    }
}
