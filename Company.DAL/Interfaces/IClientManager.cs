using NLayerApp.DAL.Entities;
using System;

namespace NLayerApp.DAL.Interfaces
{
    public interface IClientManager : IDisposable
    {
        void Create(ClientProfile item);
    }
}