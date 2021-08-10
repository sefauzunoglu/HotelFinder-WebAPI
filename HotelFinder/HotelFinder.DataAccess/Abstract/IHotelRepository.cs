using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.DataAccess.Abstract
{
    public interface IHotelRepository
    {
        List<Hotel> GetAllHotels(); // liste türünde hotelleri döndürecek. parametre almayacak.

        Hotel GetHotelById(int id);

        Hotel CreateHotel(Hotel hotel); //Hotel türünde parametre alacak

        Hotel UpdateHotel(Hotel hotel); //Hotel türünde parametre alacak

        void DeleteHotel(int id); //değer döndürmeyecek.
    }
}
