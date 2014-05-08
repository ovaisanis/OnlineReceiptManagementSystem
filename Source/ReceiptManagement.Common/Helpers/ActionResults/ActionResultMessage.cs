
using System.Collections;
namespace ReceiptManagement.Common.Helpers
{
	/// <summary>
	///		A message about the result of an action taken in the system.
	/// </summary>
	public sealed class ActionResultMessage
	{
		#region Properties

		/// <summary>
		///		The entity to which a message pertains.
		/// </summary>
		public System.Object Entity      { get; private set; }

		/// <summary>
		///		The message about the action taken.
		/// </summary>
		public System.String Message     { get; private set; }

        /// <summary>
        ///		The message code about the action taken. This would help in setting up and display localized messages
        /// </summary>
        public System.String MessageCode { get; private set; }

		/// <summary>
		///		The ActionResultMessageType of the message.
		/// </summary>
		public Helpers.ActionResultMessageType MessageType { get; private set; }

		#endregion

		#region Constructors & Factories

		//	Internal constructor since it shouldn't be called outside of the API.
		internal ActionResultMessage() { }

        /// <summary>
        ///		Creates a new instance of an ActionResult.
        /// </summary>
        /// <param name="entity">The entity to which the entity relates.</param>
        /// <param name="message">The message about the action.</param>
        /// <param name="messageType">The type of the message.</param>
        /// <returns>The new ActionResultMessage instance.</returns>
        public static Helpers.ActionResultMessage Factory(object entity, string message, Helpers.ActionResultMessageType messageType)
        {
            System.String messageCode = ActionResultMessageCode.NA.ToString(); // Default
            return new Helpers.ActionResultMessage { Entity = entity, Message = message, MessageCode = messageCode, MessageType = messageType };
        }
        
        /// <summary>
        ///		Creates a new instance of an ActionResult.
        /// </summary>
        /// <param name="entity">The entity to which the entity relates.</param>
        /// <param name="messageCode">The code of the message.</param>
        /// <param name="messageType">The type of the message.</param>
        /// <returns>The new ActionResultMessage instance.</returns>
        public static Helpers.ActionResultMessage Factory(object entity, Helpers.ActionResultMessageCode messageCode, Helpers.ActionResultMessageType messageType)
                    {
            return new Helpers.ActionResultMessage { Entity = entity, Message = MessageParser.GetMessage(messageCode.ToString()), MessageCode = messageCode.ToString(), MessageType = messageType };
        }

        /// <summary>
        ///		Creates a new instance of an ActionResult.
        /// </summary>
        /// <param name="entity">The entity to which the entity relates.</param>
        /// <param name="messageCode">The code of the message.</param>
        /// <param name="messageType">The type of the message.</param>
        /// <param name="messageTokens">Message tokens.</param>
        /// <returns>The new ActionResultMessage instance.</returns>
        public static Helpers.ActionResultMessage Factory(object entity, Helpers.ActionResultMessageCode messageCode, Helpers.ActionResultMessageType messageType, params System.String[] messageTokens)
        {
            return new Helpers.ActionResultMessage { Entity = entity, Message = MessageParser.GetMessage(messageCode.ToString(), messageTokens), MessageCode = messageCode.ToString(), MessageType = messageType };
        }

        #endregion

        #region IEqualityComparer Members

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            ActionResultMessage objB = (ActionResultMessage)obj;

            return this.Message.GetHashCode() == objB.Message.GetHashCode() &&
                        this.MessageCode.GetHashCode() == objB.MessageCode.GetHashCode() &&
                        this.MessageType == objB.MessageType;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override  int GetHashCode()
        {
            return this.Message.GetHashCode() ^ this.MessageCode.GetHashCode() ^ this.MessageType.GetHashCode();
        }

        #endregion
    }
}
