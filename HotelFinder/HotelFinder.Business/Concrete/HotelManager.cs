﻿using HotelFinder.Business.Abstract;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.Business.Concrete
{
    public class HotelManager : IHotelService
    {
        // Önemli kısım.

        // Burada bana bir HotelRepository örneği lazım.

        private IHotelRepository _hotelRepository;

        public HotelManager(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public Hotel CreateHotel(Hotel hotel)
        {
            return _hotelRepository.CreateHotel(hotel);
        }

        public void DeleteHotel(int id)
        {
            _hotelRepository.DeleteHotel(id);
        }

        public List<Hotel> GetAllHotels()
        {
           return _hotelRepository.GetAllHotels();
        }

        public Hotel GetHotelById(int id)
        {
            // iş kuralı ekleyelim kafadan

            if(id > 0)
            {
                return _hotelRepository.GetHotelById(id);
            }

            throw new Exception("id cannot be less than 1");
        }

        public Hotel GetHotelByName(string name)
        {
            return _hotelRepository.GetHotelByName(name);
        }

        public Hotel UpdateHotel(Hotel hotel)
        {
            return _hotelRepository.UpdateHotel(hotel);
        }
    }
}
