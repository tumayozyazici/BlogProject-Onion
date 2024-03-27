using BlogProject.Core.DomainModels.BaseModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Core.DomainModels.Models
{
    public class AppUser : IdentityUser, IBaseEntity
    {
        private string _firstName;
        private string _normalizedFirstName;

        private string _lastName;
        private string _normalizedLastName;

        
        public string NormalizedLastName
        {
            get { return _normalizedLastName; }
            set { _normalizedLastName = _lastName.ToUpper(); }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string NormalizedFirstName
        {
            get { return _normalizedFirstName; }
            set { _normalizedFirstName = _firstName.ToUpper(); }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        [NotMapped]
        public string FullName { get { return _firstName + " " + _lastName; } }



        //Navigation Properties
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
