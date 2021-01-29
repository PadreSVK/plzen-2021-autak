namespace Autak.API.Models
{
    public class CarAdministrator
    {
        public string Name { get; set; }
        public string Note { get; set; }
        public CarAdministratorRole Role { get; set; }
    }

    public enum CarAdministratorRole
    {
        Programator,
        Manager,
        Spravca
    }
}