using Mantel.Common.Data;

namespace Mantel.Student_Service.Domain.Entities
{
    public class Student: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
