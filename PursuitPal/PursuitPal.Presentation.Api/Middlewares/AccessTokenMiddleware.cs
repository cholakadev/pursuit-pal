using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PursuitPal.Presentation.Api.Middlewares
{
    public class AccessTokenMiddleware
    {
        private readonly RequestDelegate _next;

        public AccessTokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var jwtBearer = httpContext.Request.Headers["Authorization"];
            var tokenArray = jwtBearer.ToString().Split(" ");

            if (!string.IsNullOrEmpty(jwtBearer))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jsonToken = tokenHandler.ReadToken(tokenArray[1]) as JwtSecurityToken;

                var id = jsonToken?.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;
                var email = jsonToken?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

                httpContext.Items["Id"] = id;
                httpContext.Items["Email"] = email;
            }

            await _next(httpContext);
        }
    }
}
