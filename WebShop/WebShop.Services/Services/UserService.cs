using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WebShop.Services.Contracts;

namespace WebShop.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        public UserService(IMapper mapper)
        {
            this.mapper = mapper;
        }
    }
}
