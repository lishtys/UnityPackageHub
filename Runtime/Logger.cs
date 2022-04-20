using System;
using System.Text;
using UnityEngine;

namespace xyz.iforrest.unity
{
    public static class  Logger
    {
        public static bool isDebugOpen = true;

        public static string separator = ",";

        /// <summary>
        ///  basic log method
        /// </summary>
        /// <param name="format">string format</param>
        /// <param name="logType">log levels</param>
        /// <param name="args">log content</param>
        public static void Log(string format = null, LogType logType = LogType.Information, params object[] args)
        {
           if(!isDebugOpen) return;

           switch (logType)
           {
               case LogType.Information:
                   Debug.Log(Combine(format,args)); 
                   break;
               case LogType.Warning:
                   Debug.LogWarning(Combine(format,args)); 
                   break;
               case LogType.Exception:
                   Debug.LogException(new Exception(Combine(format, args)));
                   break;
               case LogType.Error:
                   Debug.LogError(Combine(format, args));
                   break;
           }
        }
        
        public static void Log(LogType logType = LogType.Information, params object[] args) =>
            Logger.Log(null, logType, args);
        
        public static void Log(params object[] args) => Logger.Log(LogType.Information, args);
     
        public static void LogWarning(params object[] args) => Logger.Log(LogType.Warning, args);
        
        public static void LogError(params object[] args) => Logger.Log(LogType.Error, args);
        
        public static void LogException(Exception e) => Logger.Log(LogType.Exception,  e);

        /// <summary>
        ///  combine all infos into a text
        /// </summary>
        /// <param name="format"> text format</param>
        /// <param name="args">information array</param>
        /// <returns></returns>
        private static string Combine(string format = null, params object[] args)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (!string.IsNullOrEmpty(format))
            {
                stringBuilder.AppendFormat(format, args);
            }
            else
            {
                int count = 0;
                foreach (var arg in args)
                {
                    stringBuilder.Append(arg);
                    count++;
                    if (count != args.Length)
                    {
                        stringBuilder.Append(separator);
                    }
                }
            }
            return stringBuilder.ToString();
        }
        
        
    }
}

