using GhostVillages.DataAccess.Entities;
using Microsoft.AspNetCore.Http;

namespace GhostVillages.Application.Services
{
    public interface IUserService
    {
        Task<bool> Authorize(UserEntity user, HttpContext context);
        Task<UserEntity?> Create(string username, string password);
        Task<UserEntity?> Get(Guid id);
        Task<UserEntity?> Get(string username, string password);
    }
}