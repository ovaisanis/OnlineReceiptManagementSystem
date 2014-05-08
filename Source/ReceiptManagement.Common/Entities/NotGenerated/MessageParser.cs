
namespace ReceiptManagement.Common.Helpers
{
    /// <summary>
    /// Message Parser
    /// </summary>
    public class MessageParser
    {
        #region Public Methods

        /// <summary>
        /// Used to get message from localization file based on message code
        /// </summary>
        /// <param name="messageCode"></param>
        /// <returns></returns>
        public static string GetMessage(System.String messageCode)
        {
            return GetMessage(messageCode, new string[0]);
        }

        /// <summary>
        /// Used to get message from localization file based on message code
        /// </summary>
        /// <param name="messageCode"></param>
        /// <param name="messageTokens"></param>
        /// <returns></returns>
        public static string GetMessage(System.String messageCode, params string[] messageTokens)
        {
            string message = Resources.en_US_Resource.ResourceManager.GetString(messageCode);

            // throw exception if no match found
            if (string.IsNullOrEmpty(message))
                throw new Exceptions.MessageNotFoundException();

            System.Text.StringBuilder processedMessage = new System.Text.StringBuilder(message);
            if (messageTokens != null)
            {
                foreach (var token in messageTokens)
                {
                    processedMessage.Replace(token.Split(':')[0], token.Split(':')[1]); // token : value
                }
            }

            /*
             * OLD snippet
            if (messageTokens != null)
            {
                int indx = 0;
                for (int i = 0; i < messageTokens.Length; i++)
                {
                    if (messageTokens[i] != string.Empty)
                    {
                        indx = processedMessage.ToString().IndexOf("__", indx);
                        if (indx == -1)
                            break;
                        processedMessage.Replace("__", messageTokens[i].Replace("&amp;#44;", ","), indx, 2);
                        indx += 2;
                    }
                }
            }
            //*/

            return processedMessage.ToString();
        }

        #endregion
    }
}
