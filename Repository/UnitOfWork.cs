﻿using HotelListing.Data;
using HotelListing.IRepository;
using System;
using System.Threading.Tasks;

namespace HotelListing.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        private IGenericRepository<Country> _countries;
        private IGenericRepository<Hotel> _hotels;

        public IGenericRepository<Country> Countries { get => _countries ??= new GenericRepository<Country>(_context); }
        public IGenericRepository<Hotel> Hotels { get => _hotels ??= new GenericRepository<Hotel>(_context); }

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
