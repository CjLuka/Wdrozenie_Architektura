using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Account
{
    public class UsersViewModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email{ get; set; }
    }
}
