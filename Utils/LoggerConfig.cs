using NLog;
using NLog.Config;
using NLog.Targets;
using NLog.Layouts;
using NLog.Targets.Wrappers;

namespace Ivy.Utils
{
	public class LoggerConfig
	{
		public NLog.Logger Log;

		public LoggerConfig()
		{
			var config = new LoggingConfiguration();

			var consoleTarget = new ColoredConsoleTarget("console")
			{
				Layout = Layout.FromString("[${longdate}] | ${level:uppercase=true} | ${logger} > ${message}"),
				UseDefaultRowHighlightingRules = true
			};

			consoleTarget.RowHighlightingRules.Add(new ConsoleRowHighlightingRule("level == LogLevel.Trace", ConsoleOutputColor.DarkGray, ConsoleOutputColor.NoChange));
			consoleTarget.RowHighlightingRules.Add(new ConsoleRowHighlightingRule("level == LogLevel.Debug", ConsoleOutputColor.DarkBlue, ConsoleOutputColor.NoChange));
			consoleTarget.RowHighlightingRules.Add(new ConsoleRowHighlightingRule("level == LogLevel.Info", ConsoleOutputColor.Blue, ConsoleOutputColor.NoChange));
			consoleTarget.RowHighlightingRules.Add(new ConsoleRowHighlightingRule("level == LogLevel.Warn", ConsoleOutputColor.Yellow, ConsoleOutputColor.NoChange));
			consoleTarget.RowHighlightingRules.Add(new ConsoleRowHighlightingRule("level == LogLevel.Error", ConsoleOutputColor.Red, ConsoleOutputColor.NoChange));
			consoleTarget.RowHighlightingRules.Add(new ConsoleRowHighlightingRule("level == LogLevel.Fatal", ConsoleOutputColor.DarkRed, ConsoleOutputColor.NoChange));
			config.AddTarget(consoleTarget);
			config.LoggingRules.Add(new LoggingRule("*", LogLevel.Trace, consoleTarget));
			LogManager.Configuration = config;
			Log = LogManager.GetLogger("console");
		}
	}
}
