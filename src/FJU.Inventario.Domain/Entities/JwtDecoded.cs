namespace FJU.Inventario.Domain.Entities
{
    public class Jwt
    {
        public string? unique_name { get; set; }
        public string? nameid { get; set; }
        public List<string>? role { get; set; }
        public long? nbf { get; set; }
        public long? exp { get; set; }
        public long? iat { get; set; }


        public static explicit operator JwtDecoded(Jwt input)
        {
            return new JwtDecoded
            {
                UniqueName = input.unique_name,
                NameId = input.nameid,
                Role = input.role,
                Nbf = input.nbf,
                Exp = input.exp,
                Iat = input.iat
            };
        }
    }

    public class JwtDecoded
    {
        public string? UniqueName { get; set; }
        public string? NameId { get; set; }
        public List<string>? Role { get; set; }
        public long? Nbf { get; set; }
        public long? Exp { get; set; }
        public long? Iat { get; set; }
    }
}