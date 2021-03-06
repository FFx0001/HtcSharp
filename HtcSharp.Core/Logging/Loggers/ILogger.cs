﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HtcSharp.Core.Logging.Loggers {
    public interface ILogger {

        void Log(Type type, DateTime time, object obj, Exception ex);

        void Debug(Type type, DateTime time, object obj, Exception ex);

        void Info(Type type, DateTime time, object obj, Exception ex);

        void Warn(Type type, DateTime time, object obj, Exception ex);

        void Error(Type type, DateTime time, object obj, Exception ex);

        void Fatal(Type type, DateTime time, object obj, Exception ex);

        void Trace(Type type, DateTime time, object obj, Exception ex);

    }
}
