using SMLHelper;
using SMLHelper.Patchers;
using System.Collections.Generic;
using UnityEngine;
using Utilites.Config;
using Logger = Utilites.Logger.Logger;
using LogType = Utilites.Logger.LogType;
using LogLevel = Utilites.Logger.LogLevel;
using System;
using Utilites.Logger;
using MoreIngots.MI;

namespace MoreIngots.MI
{
    public enum Status
    {
        /// <summary>
        /// Loading has started
        /// </summary>
        Start,

        /// <summary>
        /// Loading has finished
        /// </summary>
        Stop
    }

    /// <summary>
    /// Main class for debugging
    /// </summary>
    public static class Log
    {
        /// <summary>
        /// Logs the line with an [Info] prefix
        /// </summary>
        /// <param name="message">The message that should be logged</param>
        /// <param name="type">Where should the message be logged</param>
        public static void Info(string message, LogType type = LogType.Console)
        {
            try
            {
                Logger.Info(message, type);
            }
            catch (Exception e)
            {
                Log.e(e);
            }
        }

        /// <summary>
        /// Logs the line with an [Info] prefix
        /// </summary>
        /// <param name="prefix">Adds another prefix after [Info]</param>
        /// <param name="message">The message that should be logged</param>
        /// <param name="type">Where should the message be logged</param>
        public static void Info(string prefix, string message, LogType type = LogType.Console)
        {
            try
            {
                Logger.Info("[" + prefix + "] " + message, type);
            }
            catch (Exception e)
            {
                Log.e(e);
            }
        }

        /// <summary>
        /// Logs the line with a [Warning] prefix
        /// </summary>
        /// <param name="message">The message that should be logged</param>
        /// <param name="type">Where should the message be logged</param>
        public static void Warning(string message, LogType type = LogType.Console)
        {
            try
            { 
                Logger.Warning(message, type);
            }
            catch (Exception e)
            {
                Log.e(e);
            }
        }

        /// <summary>
        /// Logs the line with a [Warning] prefix
        /// </summary>
        /// <param name="prefix">Adds another prefix after [Warning]</param>
        /// <param name="message">The message that should be logged</param>
        /// <param name="type">Where should the message be logged</param>
        public static void Warning(string prefix, string message, LogType type = LogType.Console)
        {
            try
            {
                Logger.Warning("[" + prefix + "] " + message, type);
            }
            catch (Exception e)
            {
                Log.e(e);
            }
        }

        /// <summary>
        /// Logs the line with an [Error] prefix
        /// </summary>
        /// <param name="message">The message that should be logged</param>
        /// <param name="type">Where should the message be logged</param>
        public static void Error(string message, LogType type = LogType.Console)
        {
            try
            { 
                Logger.Error(message, type);
            }
            catch (Exception e)
            {
                Log.e(e);
            }
        }

        /// <summary>
        /// Logs the line with an [Error] prefix
        /// </summary>
        /// <param name="prefix">Adds another prefix after [Error]</param>
        /// <param name="message">The message that should be logged</param>
        /// <param name="type">Where should the message be logged</param>
        public static void Error(string prefix, string message, LogType type = LogType.Console)
        {
            try
            { 
                Logger.Error("[" + prefix + "] " + message, type);
            }
            catch (Exception e)
            {
                Log.e(e);
            }
        }

        /// <summary>
        /// Logs the line with a [Debug] prefix only if _debug is true
        /// </summary>
        /// <param name="message">The message that should be logged</param>
        /// <param name="always">Logs the line even if _debug is false</param>
        /// <param name="type">Where should the message be logged</param>
        public static void Debug(string message, bool always = false, LogType type = LogType.Console)
        {
            try
            { 
                if (MI.Config._debug || always)
                {
                    Logger.Debug(message, type);
                }
            }
            catch (Exception e)
            {
                Log.e(e);
            }
        }

        /// <summary>
        /// Logs the line with a [Debug] prefix only if _debug is true
        /// </summary>
        /// <param name="prefix">Adds another prefix after [Debug]</param>
        /// <param name="message">The message that should be logged</param>
        /// <param name="always">Logs the line even if _debug is false</param>
        /// <param name="type">Where should the message be logged</param>
        public static void Debug(string prefix, string message, bool always = false, LogType type = LogType.Console)
        {
            try
            { 
                if (MI.Config._debug || always)
                {
                    Logger.Debug("[" + prefix + "] " + message, type);
                }
            }
            catch (Exception e)
            {
                Log.e(e);
            }
        }

        /// <summary>
        /// Logs a [Debug] line specific for loading an item
        /// </summary>
        /// <param name="name">The name of the item</param>
        /// <param name="status">The status of the loading</param>
        /// <param name="always">Logs the line even if _debug is false</param>
        public static void Debug(string name, Status status, bool always = false)
        {
            try
            {
                if (status == Status.Start)
                {
                    if (MI.Config._debug || always)
                    {
                        Logger.Debug("Loading " + name + "...");
                    }
                    if (status == Status.Stop)
                    {
                        if (MI.Config._debug || always)
                        {
                            Logger.Debug(name + " loaded");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log.e(e);
            }
        }
        /// <summary>
        /// Logs an exception
        /// </summary>
        /// <param name="e">Exception</param>
        public static void e(Exception e)
        {
            try
            {
                e.Log(LogType.Console);
            }
            catch
            {
                e.Log(LogType.Custom);
            }
        }
    }
    public static class LoadingStartStop
    {
        public static void LoadingStarted()
        {
            Log.Info("Started loading");
        }
        public static void LoadingFinished()
        {
            Log.Info("Finished loading");
            if (Config._alttextures)
            {
                Log.Info("Hey, it looks like you are using alternative textures.", LogType.Console | LogType.Custom | LogType.PlayerScreen);
                Log.Info("Please note that these are no longer supported and will be removed in a future update!", LogType.Console | LogType.Custom | LogType.PlayerScreen);
            }
        }
    }
}
