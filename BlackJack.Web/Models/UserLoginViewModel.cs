using BlackJack.BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace BlackJack.Web.Models
{
    public class UserLoginViewModel
    {
        public string UserName { get; set; }

        [BindNever]
        public IEnumerable<UserModel> Users { get; set; }
    }
}
