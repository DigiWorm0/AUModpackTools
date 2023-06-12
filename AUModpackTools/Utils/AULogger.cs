using BepInEx.Logging;

namespace AUModpackTools.Utils
{
    /// <summary>
    /// Logs and displays data throughout the mod.
    /// </summary>
    public static class AULogger
    {
        // Set to true to log Unity Stack traces to the 
        private static ManualLogSource? _logger;

        /// <summary>
        /// Initializes AULogger instance.
        /// Ran in AUModpackTools.Load()
        /// </summary>
        public static void Init()
        {
            _logger = BepInEx.Logging.Logger.CreateLogSource("AUModpackTools");
        }

        /// <summary>
        /// Logs a message to BepInEx console
        /// </summary>
        /// <param name="logLevel">Log type/level</param>
        /// <param name="data">String or object to log</param>
        public static void Log(LogLevel logLevel, object data)
        {
            _logger?.Log(logLevel, data);
        }

        /// <summary>
        /// Logs info text to BepInEx console (gray text)
        /// </summary>
        /// <param name="data">String or object to log</param>
        public static void Info(object data)
        {
            Log(LogLevel.Info, data);
        }

        /// <summary>
        /// Logs message text to BepInEx console (white text)
        /// </summary>
        /// <param name="data">String or object to log</param>
        public static void Msg(object data)
        {
            Log(LogLevel.Message, data);
        }

        /// <summary>
        /// Logs error text to BepInEx console (red text)
        /// </summary>
        /// <param name="data">String or object to log</param>
        public static void Error(object data)
        {
            Log(LogLevel.Error, data);
        }

        /// <summary>
        /// Logs warning text to BepInEx console (yellow text).
        /// </summary>
        /// <param name="data">String or object to log</param>
        public static void Warn(object data)
        {
            Log(LogLevel.Warning, data);
        }
    }
}
