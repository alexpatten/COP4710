using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Models
{
    public class Doctors_User
    {
        [Key]
        public int UserID { get; set; }
        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Specialization { get; set; } = null!;
        public string PatientAgeGroup { get; set; } = null!;
    }

    public class Doctors
    {
        [Key]
        public int DoctorID { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        [Required]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public ICollection<Doctors_User>? Users { get; set; }
    }

    public class Patients_User
    {
        [Key]
        public int UserID { get; set; }
        [ForeignKey("Patient")]
        public int PatientID { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string InsuranceProvider { get; set; } = null!;
        public string Allergies { get; set; } = null!;
    }

    public class Patients
    {
        [Key]
        public int PatientID { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string FullName => $"{FirstName} {MiddleName} {LastName}";
        public string EmailAddress { get; set; } = null!;
        [Required]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
        public string PhoneNumber { get; set; } = null!;
    }
}
