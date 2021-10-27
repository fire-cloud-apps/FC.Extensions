using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;

namespace FC.Extension.HTTP.APIHandler
{

    public interface IConnectionService
    {
        string GetDBConnection(IConfiguration configuration, IHttpContextAccessor httpContext,
            string connectionValue = "DBSettings:ClientDB", string tokenHeader = "Authorization", string additionalInfo = "info");
        AuthUser GetAuthUser();
    }

    public class ConnectionService : IConnectionService
    {
        string _connectionString;
        public AuthUser _AuthUser;

        public string GetDBConnection(IConfiguration configuration, IHttpContextAccessor httpContext,
            string connectionValue = "DBSettings:ClientDB", string tokenHeader = "Authorization", string additionalInfo = "info")
        {
            IHeaderDictionary headers = httpContext.HttpContext.Request.Headers;
            _connectionString = configuration.GetValue<string>(connectionValue);
            StringValues tokenString;
            headers.TryGetValue(tokenHeader, out tokenString);
            var jwt = tokenString.ToString();
            var jwtEncodedString = jwt.Substring(7); // trim 'Bearer ' from the start since its just a prefix for the 
            var token = new JwtSecurityToken(jwtEncodedString: jwtEncodedString);
            var userInfo = token.Claims.First(c => c.Type == additionalInfo).Value;
            //Console.WriteLine("email => " + token.Claims.First(c => c.Type == "email").Value);
            AuthUser authUser = JsonConvert.DeserializeObject<AuthUser>(userInfo);            
            _connectionString = string.Format(_connectionString, authUser.ClientDBName);
            _AuthUser = authUser;
            return _connectionString;
        }

        public AuthUser GetAuthUser()
        {
            return _AuthUser;
        }

    }

    public class AuthUser
    {
        public int Id
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string Phone
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string PasswordHash
        {
            get;
            set;
        }

        public bool IsActive
        {
            get;
            set;
        } = true;


        public string Role
        {
            get;
            set;
        }

        public string Token
        {
            get;
            set;
        }

        public string LoginIp
        {
            get;
            set;
        }

        public string ClientDBName
        {
            get;
            set;
        }

        public int StaffId
        {
            get;
            set;
        }

        public DateTime LastLogin
        {
            get;
            set;
        }

        public int AccountId
        {
            get;
            set;
        }
    }
}
