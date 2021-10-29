
using System.Collections.Generic;
using IiotContract.Requests;
using IiotContract.Results;
using IiotDomain;

namespace IiotApplication.Repositories
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }

}
