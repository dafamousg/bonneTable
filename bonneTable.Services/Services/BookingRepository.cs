﻿using bonneTable.Data;
using bonneTable.Models;
using bonneTable.Services.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bonneTable.Services.Services
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DbContext _context = null;

        public BookingRepository(IOptions<Settings> settings)
        {
            _context = new DbContext(settings);
        }

        public async Task<List<Booking>> GetAll()
        {
            try
            {
                return await _context.Booking.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Booking>> GetByDate(DateTime dateTime)
        {
            try
            {
                return await _context.Booking.Find(b => b.Time == dateTime).ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Booking>> GetByEmail(string email)
        {
            try
            {
                return await _context.Booking.Find(b => b.Email == email).ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Booking> GetByID(Guid ID)
        {
            try
            {
                return await _context.Booking.Find(b => b.Id == ID).SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        Task<List<Booking>> IBookingRepository.GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(Booking entity)
        {
            try
            {
                await _context.Booking.InsertOneAsync(entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task Delete(Guid ID)
        {
            try
            {
                await _context.Booking.DeleteOneAsync(b => b.Id == ID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> EditAsync(Guid ID, Booking entity)
        {
            try
            {
                var filter = Builders<Booking>.Filter.Eq(t => t.Id, ID);
                var update = Builders<Booking>.Update.Set(x => x.Seats, entity.Seats);

                var updateResult = await _context.Booking.UpdateOneAsync(filter, update, new UpdateOptions { IsUpsert = true });

                return updateResult.IsAcknowledged && updateResult.MatchedCount > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task Commit()
        {
            throw new NotImplementedException();
        }
               
    }
}
