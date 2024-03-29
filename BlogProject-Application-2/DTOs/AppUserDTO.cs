using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject_Application_2.DTOs
{
    public class AppUserDTO
    {
        //Mapper kullanacağımız için SQL deki isimlere uyumlu olmasını istiyoruz
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
    }
}
