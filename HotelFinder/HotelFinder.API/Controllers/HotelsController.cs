using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // kendisi otomatikman validation kontrollerini yapıyor.
    public class HotelsController : ControllerBase
    {
        // Burada HotelBusiness dan örnek gerekiyor.

        private IHotelService _hotelService;

        // Sonra bu Controllerın constructorında hotel service e değer ataması yapacağız.
        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        /// <summary>
        /// Get All Hotels
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var hotels = _hotelService.GetAllHotels();
            return Ok(hotels); // 200 + data
        }

        /// <summary>
        /// Get Hotel by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetHotelById(int id)
        {
            var hotel = _hotelService.GetHotelById(id);
            if(hotel != null)
            {
                return Ok(hotel); // 200 + data

            }
            return NotFound();
        }

        [HttpGet]
        [Route("[action]/{name}")]
        public IActionResult GetHotelByName(string name)
        {
            var hotel = _hotelService.GetHotelByName(name);
            if (hotel != null)
            {
                return Ok(hotel); // 200 + data
            }
            return NotFound();
        }

        // iki parametre alırsa ?

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetHotelByIdAndName(int id, string name)
        {
            return Ok();
        }


        /// <summary>
        /// Create a Hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult CreateHotel([FromBody]Hotel hotel) // body kısmında ben senden bir hotel bekliyorum. body kısmında bana bir hotel göndermek zorundasın.
        {
            var createdHotel = _hotelService.CreateHotel(hotel);
            return CreatedAtAction("Get", new { id = createdHotel.Id }, createdHotel); // 201 + data
        }

        /// <summary>
        /// Update the Hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdateHotel([FromBody] Hotel hotel) 
        {
            if (_hotelService.GetHotelById(hotel.Id) != null)
            {
                return Ok(_hotelService.UpdateHotel(hotel)); // 200 + data
            }
            return NotFound();
        }

        /// <summary>
        /// Delete the Hotel
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        [Route("[action]/{id}")]
        public IActionResult DeleteHotel(int id)
        {
            if (_hotelService.GetHotelById(id) != null)
            {
                _hotelService.DeleteHotel(id);
                return Ok(); // 200 
            }
            return NotFound();
            
        }
    }
}
