using Mantel.Common.Data;

namespace Mantel.Course_Service.Domain.Entities
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }
        public int Credit { get; set; }


        public void UpdateValue(int newCredit)
        {
            Credit = newCredit;
        }
    }
}
