using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Constants
{
    public class AppConst
    {
        public const string JWT_KEY = "0dcbebf0e23847e282e7a98e6ff7a7ce";
        public const string REFRESH_TOKEN_KEY = "0dcbebf0e23847e2";
        public const string JWT_ISSUER = "self";
        public const string JWT_AUDIENCE = "user";
        public const string TOKEN_PREFIX_CACHE = "USER_TOKEN";
        public const int TOKEN_EXPIRED = 1400;
        public const int TOKEN_REFRESH_EXPIRED = 1400;
    }
}
