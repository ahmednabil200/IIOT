
using System.Collections.Generic;
using IiotApi.Entities;
using IiotApi.Models;

namespace IiotApi.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }

}
