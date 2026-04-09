using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ISeguimiento : IGeneric<Seguimiento>
    {
        Task<int> AddComByUser(string user, int comId, string come);
    }
}
