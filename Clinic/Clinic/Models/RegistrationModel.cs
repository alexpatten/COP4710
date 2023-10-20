using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clinic.Models
{
    public partial class RegistrationModel
    {
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }

        // Add a property to indicate the selected user type
        public string SelectedUserType { get; set; }
    }
}