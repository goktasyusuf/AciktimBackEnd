﻿using log4net;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace Core.CrossCuttingConcern.Logging.Log4Net
{
    public class LoggerServiceBase
    {
        private readonly ILog _log;
        public LoggerServiceBase(string name)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(File.OpenRead("log4net.config"));

            ILoggerRepository loggerRepository = LogManager.CreateRepository(Assembly.GetEntryAssembly(),
                typeof(log4net.Repository.Hierarchy.Hierarchy));

            log4net.Config.XmlConfigurator.Configure(loggerRepository, xmlDocument["log4net"]);
            _log = LogManager.GetLogger(loggerRepository.Name, name);

        }


        public bool IsInfoEnabled => _log.IsInfoEnabled;
        public bool IsDebugEnabled => _log.IsDebugEnabled;
        public bool IsWarnEnabled => _log.IsWarnEnabled;
        public bool IsFatalEnabled => _log.IsFatalEnabled;
        public bool IsErrorEnabled => _log.IsErrorEnabled;

        public void Info(object logMessage)
        {
            if (IsInfoEnabled)
            {
                using (log4net.NDC.Push(Guid.NewGuid().ToString()))
                    _log.Info(logMessage);
            }
        }

        public void Debug(object logMessage)
        {
            if (IsDebugEnabled)
            {
                using (log4net.NDC.Push(Guid.NewGuid().ToString()))
                    _log.Debug(logMessage);
            }
        }

        public void Warn(object logMessage)
        {
            if (IsWarnEnabled)
            {
                using (log4net.NDC.Push(Guid.NewGuid().ToString()))
                    _log.Warn(logMessage);
            }
        }

        public void Fatal(object logMessage)
        {
            if (IsFatalEnabled)
            {
                using (log4net.NDC.Push(Guid.NewGuid().ToString()))
                    _log.Fatal(logMessage);
            }
        }

        public void Error(object logMessage)
        {
            if (IsErrorEnabled)
            {
                using (log4net.NDC.Push(Guid.NewGuid().ToString()))
                    _log.Error(logMessage);
            }
        }


    }
}
