using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAPI.ApplicationServices.IServices;
using FluentAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FluentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IVendorServices _IVendorServices;



        public VendorController(IVendorServices iVendorServices)
        {
            _IVendorServices = iVendorServices;
        }

        [HttpGet("{id}")]
        public IActionResult GetAllVendors([FromRoute] int id)
        {
            //    return Ok(_IVendorServices.GetListVendorServices());
            return Ok(_IVendorServices.GetVendorByIdervices(id));
            // return null;

        }
        [HttpPost]
        public IActionResult AddVendor(InsertVendorDto dto)
        {

            return _IVendorServices.InsertNewVendorServices(dto);
        }


        //[HttpPatch("{id}")]
        //public IActionResult UpdateVendor([FromRoute]int id, UpdateVendorDto dto)
        //{
        //    return _IVendorServices.UpdateVendorServices(dto , id);
        //}


        [HttpPatch("{id}")]
        public IActionResult UpdateVendor([FromRoute] int id, [FromBody] JsonPatchDocument<UpdateVendorDto> vendorPatch)
        {



            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            return _IVendorServices.UpdateVendorServices(vendorPatch, id);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteVendor([FromRoute] int id)
        {
            return _IVendorServices.DeleteVendorServices(id);
        }
    }
}
