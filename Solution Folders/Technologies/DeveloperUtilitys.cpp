"Diagnostic Open Source Tools"
"EventLogHelper_Cass"
"Log4Net_Notes"


"***********************************************"
"**** Diagnostic Open Source Tools ******"
"***********************************************"
http://getglimpse.com/ - Glimpse inspects web requests as they happen. Can be installed via NuGet

"***********************************************"
"**** Log4Net_Notes ******"   	
"***********************************************"
// How to implement log4net in a wcf service
http ://orkunsurucuoglu.blogspot.com/2013/03/sample-log4net-implementation-in-wcf.html

// To download go to http://logging.apache.org/log4net/download_log4net.cgi
// Click on link with the newKey under binaries. The log4net dll is in there.
_Log.DebugFormat(" : {0}", ex);
_Log.DebugFormat("Failed to : {0}", ex);
_Log.DebugFormat(" {0} {1}", ,);
_Log.Debug("");

_Log.Error("An error occurred.", ex);
_Log.ErrorFormat("An error occurred. fileName: {0} - the exceptions is {1}", fileName, ex);
_Log.Warn("Error reading from box.", ex);
_Log.WarnFormat("Box returned error [{0}].  Unable to complete request.", Enum.GetName(typeof(BoxErrorCodes), errorCode));

// Checks if Debug level is enabled
if (_Log.IsDebugEnabled)

// Once-per-application setup information. Right after the using statements in program.cs 
// and Global.asax.cs for a website.
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

// Add to the top within each class logging is to be used
private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

// Add to the configuration file
<configSections>
   <section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler, log4net"/>
</configSections>
<log4net>
   <appender name="RollingFileAppender" type="log4net.Appender.RollingFileAppender">
      <!-- Path to log to. Example:${ALLUSERSPROFILE}\ZOLL\RS3000 Communications Adapter\logs\RS3000CommunicationLog.txt-->
      <file value="RS3000CommunicationLog.txt" />
      <appendToFile value="true" />
      <rollingStyle value="Size" />
      <maxSizeRollBackups value="10" />
      <maximumFileSize value="6MB" />
      <staticLogFileName value="true" />
      <layout type="log4net.Layout.PatternLayout">
         <param name="ConversionPattern" value="%d [%t] %-5p %c %m%n" />
      </layout>
   </appender>
   <appender name="ConsoleAppender" type="log4net.Appender.ConsoleAppender" >
      <layout type="log4net.Layout.PatternLayout">
         <param name="Header" value="[Header]\r\n" />
         <param name="Footer" value="[Footer]\r\n" />
         <param name="ConversionPattern" value="%d [%t] %-5p %c %m%n" />
      </layout>
   </appender>

   <root>
      <!--Minimum value to log-->
      <level value="DEBUG" />
      <appender-ref ref="RollingFileAppender" />
      <appender-ref ref="ConsoleAppender" />
   </root>
</log4net>

// Example config file from service with multiple projects
<log4net>
  <appender name="RollingFileAppender" type="log4net.Appender.RollingFileAppender">
    <file value="${ALLUSERSPROFILE}\ZOLL\RS3000 Communications Adapter\logs\RS3000CommunicationLog.txt" />
    <appendToFile value="true" />
    <rollingStyle value="Size" />
    <maxSizeRollBackups value="10" />
    <maximumFileSize value="10MB" />
    <staticLogFileName value="true" />
    <layout type="log4net.Layout.PatternLayout">
      <param name="ConversionPattern" value="%d [%t] %-5p %c %m%n" />
    </layout>
  </appender>
  <appender name="ConsoleAppender" type="log4net.Appender.ConsoleAppender">
    <layout type="log4net.Layout.PatternLayout">
      <param name="Header" value="[Header]\r\n" />
      <param name="Footer" value="[Footer]\r\n" />
      <param name="ConversionPattern" value="%d [%t] %-5p %c %m%n" />
    </layout>
  </appender>
  <appender name="ErrorAppender" type="log4net.Appender.RollingFileAppender">
    <file value="${ALLUSERSPROFILE}\ZOLL\RS3000 Communications Adapter\logs\RS3000AdapterErrorLog.txt" />
    <appendToFile value="true" />
    <rollingStyle value="Size" />
    <maxSizeRollBackups value="100" />
    <maximumFileSize value="10MB" />
    <staticLogFileName value="true" />
    <layout type="log4net.Layout.PatternLayout">
      <param name="ConversionPattern" value="%d [%t] %-5p %c %m%n" />
    </layout>
  </appender>
  <appender name="DataBaseFileAppender" type="log4net.Appender.RollingFileAppender">
    <file value="${ALLUSERSPROFILE}\ZOLL\RS3000 Communications Adapter\logs\RS3000AdapterDataAccessLog.txt" />
    <appendToFile value="true" />
    <rollingStyle value="Size" />
    <maxSizeRollBackups value="100" />
    <maximumFileSize value="10MB" />
    <staticLogFileName value="true" />
    <layout type="log4net.Layout.PatternLayout">
      <param name="ConversionPattern" value="%d [%t] %-5p %c %m%n" />
    </layout>
  </appender>
  <appender name="CloudFileAppender" type="log4net.Appender.RollingFileAppender">
    <file value="${ALLUSERSPROFILE}\ZOLL\RS3000 Communications Adapter\logs\RS3000AdapterCloudLog.txt" />
    <appendToFile value="true" />
    <rollingStyle value="Size" />
    <maxSizeRollBackups value="100" />
    <maximumFileSize value="10MB" />
    <staticLogFileName value="true" />
    <layout type="log4net.Layout.PatternLayout">
      <param name="ConversionPattern" value="%d [%t] %-5p %c %m%n" />
    </layout>
  </appender>
   <appender name="CommunicationFileAppender" type="log4net.Appender.RollingFileAppender">
      <file value="${ALLUSERSPROFILE}\ZOLL\RS3000 Communications Adapter\logs\RS3000CommunicationLog.txt" />
      <appendToFile value="true" />
      <rollingStyle value="Size" />
      <maxSizeRollBackups value="100" />
      <maximumFileSize value="10MB" />
      <staticLogFileName value="true" />
      <layout type="log4net.Layout.PatternLayout">
         <param name="ConversionPattern" value="%d [%t] %-5p %c %m%n" />
      </layout>
   </appender>
<!--<root>
    <level value="DEBUG" />
    <appender-ref ref="RollingFileAppender" />
    <appender-ref ref="ConsoleAppender" />
  </root>-->
   <logger name="ZOLL.Services.RS3000.Adapter.Communication"
          additivity="false">
      <level value="DEBUG" />
      <appender-ref ref="CommunicationFileAppender" />
   </logger>
  <logger name="ZOLL.Services.RS3000.Adapter.DataAccess"
			additivity="false">
    <level value="DEBUG" />
    <appender-ref ref="DataBaseFileAppender" />
  </logger>
  <logger name="ZOLL.Services.RS3000.Adapter.CloudUtilities"
			additivity="false">
    <level value="DEBUG" />
    <appender-ref ref="CloudFileAppender" />
  </logger>
  <logger name="ZOLL"
    additivity="false">
    <level value="ERROR" />
    <appender-ref ref="ErrorAppender" />
  </logger>
</log4net>

http://www.codeproject.com/Articles/140911/log4net-tutorial

// Configuration Notes:
There are seven logging levels, five of which can be called in your code. They are as follows 
(with the highest being at the top of the list):

OFF - nothing gets logged (cannot be called)
FATAL
ERROR
WARN
INFO
DEBUG
ALL - everything gets logged (cannot be called)

Filters are another big part of any appender. With a filter, you can specify which level(s) to log 
and you can even look for keywords in the message.

The string match filter looks to find a specific string inside of the information being logged. 
You can have multiple string match filters specified. They work like OR statements in a query.

A level range filter tells the system to only log entries that are inside of the range specified. 
This range is inclusive, so in the below example, events with a level of INFO, WARN, ERROR, or 
FATAL will be logged, but DEBUG events will be ignored. You do not need the deny all filter after 
this entry since the deny is implied.
 
<filter type="log4net.Filter.LevelRangeFilter">
  <levelMin value="INFO" />
  <levelMax value="FATAL" />
</filter>

// Coding Notes:


"***********************************************"
"**** EventLogHelper_Cass ******"   	
"***********************************************"
public static class EventLogHelper
{
   private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
   const string SOURCE_STRING = "RS3000 Communication Program";
   const string LOG_STRING = "Application";

   static EventLogHelper()
   {
      if (!EventLog.SourceExists(SOURCE_STRING))
         EventLog.CreateEventSource(SOURCE_STRING, LOG_STRING);
   }

   /// <summary>
   /// Writes an entry to the Application event log.
   /// </summary>
   public static void WriteEventLog(EventLogEntryType eventType, string eventString, int eventId)
   {
      string event_string = eventString;

      if (!EventLog.SourceExists(SOURCE_STRING))
         EventLog.CreateEventSource(SOURCE_STRING, LOG_STRING);

      EventLog.WriteEntry(SOURCE_STRING, event_string, eventType, eventId);
   }

   /// <summary>
   /// Writes an entry to the Application event log and the log4net file.
   /// </summary>
   public static void WriteLogs(EventLogEntryType eventType, string eventString, int eventId)
   {
      WriteEventLog(eventType, eventString, eventId);

      if(eventType == EventLogEntryType.Information)
         log.Info(eventString);
      else
         log.Debug(eventString);
   }
}