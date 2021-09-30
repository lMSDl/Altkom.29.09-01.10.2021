using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    public class UsersController : BaseCrudController<User>
    {
        public UsersController(IService<User> service) : base(service)
        {
        }
    }
}
