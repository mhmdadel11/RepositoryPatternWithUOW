using App.Core.Interfaces;
using System;

namespace App.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IUnitRepository Units { get; }

        int Complete();
    }
}