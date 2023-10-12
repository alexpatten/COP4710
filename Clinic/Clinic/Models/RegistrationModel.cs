using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinic.Models
{
    public partial class RegistrationModel
    {
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }

        // Add a property to indicate the selected user type
        public string SelectedUserType { get; set; }
    }
}