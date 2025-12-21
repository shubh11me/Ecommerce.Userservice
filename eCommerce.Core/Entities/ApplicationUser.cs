namespace eCommerce.Core.Entities
{
    /// <summary>
    /// Define user class, which acts as entity model to store user details in data source
    /// </summary>
    public class ApplicationUser
    {
        public Guid UserId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PersonName { get; set; }
        public string? Gender
        {
            get; set;
        }
    }
}
