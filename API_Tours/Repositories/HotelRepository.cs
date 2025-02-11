﻿using API_Tours.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace API_Tours.Repositories
{
    public class HotelRepository:BaseRepository
    {
        public HotelRepository(ToursContext testContext) : base(testContext) { }

        //get all
        public async Task<List<Hotel>> GetHotels() => await testContext.Hotels.ToListAsync();

        //add - post
        public async Task AddHotel(Hotel hotel)
        {
            testContext.Hotels.Add(hotel);
            testContext.SaveChanges();
        }
        //update - put
        public async Task UpdateHotel(Hotel hotel)
        {
            testContext.Hotels.Update(hotel);
            testContext.SaveChanges();
        }

        //delete
        public async Task DeleteHotel(int id)
        {
            testContext.Remove(await testContext.Hotels.FirstOrDefaultAsync(x => x.Id == id));
            testContext.SaveChanges();
        }
    }
}
