using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Constants
{
    public class StatusCodeConst
    {
        public const string QUERY_EXCEPTION = nameof(QUERY_EXCEPTION);
        public const string USE_MINUTE_EXCEPTION = nameof(USE_MINUTE_EXCEPTION);
        public const string VIETTEL_EXCEPTION = nameof(VIETTEL_EXCEPTION);
        public const string GRPC_CLIENT_VIETTEL_EXCEPTION = nameof(GRPC_CLIENT_VIETTEL_EXCEPTION);
        public const string FILE_EXCEPTION = nameof(FILE_EXCEPTION);
        public const string SIGNALR_EXCEPTION = nameof(SIGNALR_EXCEPTION);
        public const string USER_EXCEPTION = nameof(USER_EXCEPTION);
        public const string TracingCode = nameof(TracingCode);
        public const string Exception = nameof(Exception);
        public const string Data = nameof(Data);
        public const string GRPC_EXCEPTION = nameof(GRPC_EXCEPTION);
        public const int NONE = 0;
        public const int GENERAL_EX = 100000;
        public const int UPLOAD_FILE_EX = 100002;
    }
}
