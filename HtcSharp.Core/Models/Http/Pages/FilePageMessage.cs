﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HtcSharp.Core.Models.Http.Pages {
    public class FilePageMessage : IPageMessage {

        private readonly string _pageFileName;   
        public int StatusCode { get; }

        public FilePageMessage(string fileName, int statusCode) {
            _pageFileName = fileName;
            StatusCode = statusCode;
        }

        public string GetPageMessage(HtcHttpContext httpContext) {
            var fileContent = File.ReadAllText(_pageFileName, Encoding.UTF8);
            fileContent = fileContent.Replace("{Request.Path}", httpContext.Request.Path);
            fileContent = fileContent.Replace("{Request.Host}", httpContext.Request.Host);
            fileContent = fileContent.Replace("{Request.PathBase}", httpContext.Request.PathBase);
            fileContent = fileContent.Replace("{Request.Protocol}", httpContext.Request.Protocol);
            fileContent = fileContent.Replace("{Request.QueryString}", httpContext.Request.QueryString);
            fileContent = fileContent.Replace("{Request.RequestFilePath}", httpContext.Request.RequestFilePath);
            fileContent = fileContent.Replace("{Request.RequestPath}", httpContext.Request.RequestPath);
            fileContent = fileContent.Replace("{Request.Scheme}", httpContext.Request.Scheme);
            fileContent = fileContent.Replace("{Request.TranslatedPath}", httpContext.Request.TranslatedPath);
            fileContent = fileContent.Replace("{Request.IsHttps}", httpContext.Request.IsHttps.ToString());
            fileContent = fileContent.Replace("{Request.Method}", httpContext.Request.Method.ToString());
            fileContent = fileContent.Replace("{Connection.Id}", httpContext.Connection.Id);
            fileContent = fileContent.Replace("{Connection.RemoteIpAddress}", httpContext.Connection.RemoteIpAddress.ToString());
            fileContent = fileContent.Replace("{Connection.RemotePort}", httpContext.Connection.RemotePort.ToString());
            return fileContent;
        }

        public void ExecutePageMessage(HtcHttpContext httpContext) {
            if (httpContext.Response.HasStarted) return;
            var fileContent = File.ReadAllText(_pageFileName, Encoding.UTF8);
            fileContent = fileContent.Replace("{Request.Path}", httpContext.Request.Path);
            fileContent = fileContent.Replace("{Request.Host}", httpContext.Request.Host);
            fileContent = fileContent.Replace("{Request.PathBase}", httpContext.Request.PathBase);
            fileContent = fileContent.Replace("{Request.Protocol}", httpContext.Request.Protocol);
            fileContent = fileContent.Replace("{Request.QueryString}", httpContext.Request.QueryString);
            fileContent = fileContent.Replace("{Request.RequestFilePath}", httpContext.Request.RequestFilePath);
            fileContent = fileContent.Replace("{Request.RequestPath}", httpContext.Request.RequestPath);
            fileContent = fileContent.Replace("{Request.Scheme}", httpContext.Request.Scheme);
            fileContent = fileContent.Replace("{Request.TranslatedPath}", httpContext.Request.TranslatedPath);
            fileContent = fileContent.Replace("{Request.IsHttps}", httpContext.Request.IsHttps.ToString());
            fileContent = fileContent.Replace("{Request.Method}", httpContext.Request.Method.ToString());
            fileContent = fileContent.Replace("{Connection.Id}", httpContext.Connection.Id);
            fileContent = fileContent.Replace("{Connection.RemoteIpAddress}", httpContext.Connection.RemoteIpAddress.ToString());
            fileContent = fileContent.Replace("{Connection.RemotePort}", httpContext.Connection.RemotePort.ToString());
            httpContext.Response.StatusCode = StatusCode;
            httpContext.Response.WriteAsync(fileContent).GetAwaiter().GetResult();
        }
    }
}
