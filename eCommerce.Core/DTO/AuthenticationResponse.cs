namespace eCommerce.Core.DTO
{
    public record AuthenticationResponse(Guid UserId,string? Email,string? PersonName,string? Gender,string? token,bool success)
    {
        public AuthenticationResponse() : this(default, default, default, default, default, default)
        {
        }
    }
}
