using System;
using MyPetsAPI.Persistence.DAOs;
using MyPetsAPI.Persistence.Repositories;

namespace MyPetsAPI.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        int Save();
    }
}
