//using Lib = Microsoft.Practices.EnterpriseLibrary;

//namespace ResolutionOffice.Common.Helpers.Logger
//{
//    /// <summary>
//    /// File Logger
//    /// </summary>
//    public static class FileLogger
//    {
//        #region Constructors

//        // constructor
//        static FileLogger()
//        {
//            IsLoggingEnable = true; // By Default
//        }

//        #endregion

//        #region Properties

//        /// <summary>
//        /// IsLoggingEnable
//        /// </summary>
//        public static bool IsLoggingEnable { get; set; } 

//        #endregion

//        #region Methods

//        /// <summary>
//        /// Write
//        /// </summary>
//        /// <param name="opertaionName"></param>
//        /// <param name="message"></param>
//        /// <param name="traceEventType"></param>
//        public static bool Write(System.String opertaionName, System.String message, System.Diagnostics.TraceEventType traceEventType)
//        {
//            try
//            {
//                if (IsLoggingEnable)
//                {
//                    using (Lib.Logging.LogWriter lw = new Lib.Logging.LogWriterFactory().Create())
//                    {
//                        Lib.Logging.LogEntry le = new Lib.Logging.LogEntry();

//                        le.Title = opertaionName;
//                        le.Message = message;
//                        le.Severity = traceEventType;                        
//                        lw.Write(le);
//                    }
//                }
//                return true;
//            }
//            catch (System.Exception ex)
//            {
//                object forDebugging = ex;
//                return false; 
//            }
//        }

//        /// <summary>
//        /// Write
//        /// </summary>
//        /// <param name="opertaionName"></param>
//        /// <param name="exception"></param>
//        /// <param name="traceEventType"></param>
//        public static bool Write(System.String opertaionName, System.Exception exception, System.Diagnostics.TraceEventType traceEventType)
//        {
//            return Write(opertaionName, exception.ToString(), traceEventType);
//        }

//        /// <summary>
//        /// Handle Exceptions
//        /// </summary>
//        /// <param name="exception"></param>
//        /// <returns></returns>
//        public static bool ExceptionHandler(System.Exception exception)
//        {
//            try
//            {
//                return Lib.ExceptionHandling.ExceptionPolicy.HandleException(exception, "EResolutionOfficeApiExceptionPolicy");
//            }
//            catch(System.Exception ex)
//            {
//                object forDebugging = ex;
//                return false;
//            }
//        } 

//        #endregion
//    }
//}

