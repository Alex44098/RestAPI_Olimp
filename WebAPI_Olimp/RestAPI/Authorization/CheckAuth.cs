
using Application.Authorization;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Text;

namespace RestAPI.Authorization
{
    public class CheckAuth
    {
        private readonly HttpRequest httpRequest;
        private readonly ICheckAuthorization checkAuthorization;
        public CheckAuth(HttpRequest httpRequest, ICheckAuthorization checkAuthorization)
        {
            this.httpRequest = httpRequest;
            this.checkAuthorization = checkAuthorization;
        }

        public bool checkAuth()
        {
            if (httpRequest.Headers.TryGetValue("Authorization", out StringValues authToken))
            {
                string? authHeader = authToken.First();
                if (authHeader != null)
                {
                    string encodedLoginPassword = authHeader.Substring("Basic ".Length).Trim();
                    Encoding encoding = Encoding.GetEncoding("iso-8859-1");
                    string loginPassword = encoding.GetString(Convert.FromBase64String(encodedLoginPassword));
                    int separatorIndex = loginPassword.IndexOf(':');
                    if (separatorIndex != -1)
                    {
                        string login = loginPassword.Substring(0, separatorIndex);
                        string password = loginPassword.Substring(separatorIndex + 1);
                        return checkAuthorization.Check(login, password).Result;
                    }
                    else return false;
                }
                else return false;
            }
            else throw new Exception();
        }
    }
}