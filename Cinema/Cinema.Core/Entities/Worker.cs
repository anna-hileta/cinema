using System.Collections.Generic;

namespace Cinema.Core.Entities
{
    public class Worker: IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public string PassportData { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public List<Check> Checks { get; set; }
        public List<FoodcourtCheck> FoodcourtChecks { get; set; }
    }
}
