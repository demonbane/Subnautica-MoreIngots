using SMLHelper;
using SMLHelper.Patchers;
using System.Collections.Generic;
using UnityEngine;
using Utilites.Config;
using Logger = Utilites.Logger.Logger;
using LogType = Utilites.Logger.LogType;
using LogLevel = Utilites.Logger.LogLevel;

namespace MoreIngots.MI
{
    /// <summary>
    /// Main class for debugging
    /// </summary>
    public static class Log
    {
        /// <summary>
        /// Logs the line with an [Info] prefix
        /// </summary>
        /// <param name="message">The message that should be logged</param>
        /// <param name="type">Where the message should be logged (Use Utilites.Logger.LogType)</param>
        public static void Info(string message, LogType type = LogType.Console)
        {
            Logger.Info(message, type);
        }

        /// <summary>
        /// Logs the line with a [Warning] prefix
        /// </summary>
        /// <param name="message">The message that should be logged</param>
        /// <param name="type">Where the message should be logged (Use Utilites.Logger.LogType)</param>
        public static void Warning(string message, LogType type = LogType.Console)
        {
            Logger.Warning(message, type);
        }

        /// <summary>
        /// Logs the line with an [Error] prefix
        /// </summary>
        public static void Error(string message, LogType type = LogType.Console)
        {
            Logger.Error(message, type);
        }

        /// <summary>
        /// Logs the line with a [Debug] prefix only if _debug is true
        /// </summary>
        /// <param name="message">The message that should be logged</param>
        /// <param name="type">Where the message should be logged</param>
        /// <param name="always">Logs the line even if _debug is false</param>
        public static void Debug(string message, LogType type = LogType.Console, bool always = false)
        {
            if (QPatch._debug || always)
            {
                Logger.Debug(message, type);
            }
        }
    }
}
