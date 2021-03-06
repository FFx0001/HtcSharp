﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace HtcSharp.Core.Models.Http {
    public class HttpConnectionContext {
        private readonly ConnectionInfo _connection;

        public X509Certificate ClientCertificate => _connection.ClientCertificate;
        public string Id => _connection.Id;
        public IPAddress LocalIpAddress => _connection.LocalIpAddress;
        public int LocalPort => _connection.LocalPort;
        public IPAddress RemoteIpAddress => _connection.RemoteIpAddress;
        public int RemotePort => _connection.RemotePort;

        public HttpConnectionContext(ConnectionInfo connection) {
            _connection = connection;
        }

    }
}
