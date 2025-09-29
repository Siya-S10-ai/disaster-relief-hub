namespace GiftOfGivers.Server.Services
{
    public interface ITokenService
    {
        string BuildToken(string userId, string email, IEnumerable<string> roles, IDictionary<string,string>? extraClaims = null);
    }
}