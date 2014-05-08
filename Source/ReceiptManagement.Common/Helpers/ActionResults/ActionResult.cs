using System.Linq;

namespace ReceiptManagement.Common.Helpers
{
	/// <summary>
	///		The result of an action taken in the system.
	/// </summary>
	public sealed class ActionResult
	{
		#region Properties

		#region MessageCounts
		
		/// <summary>
		///		Indicates the number of error messages returned for the action taken.
		/// </summary>
		public int ErrorMessageCount
		{
			get { return Messages.Where(m => m.MessageType == Helpers.ActionResultMessageType.Error).Count(); }
		}

		/// <summary>
		///		Indicates the number of informational messages returned for the action taken.
		/// </summary>
		public int InformationalMessageCount
		{
			get { return Messages.Where(m => m.MessageType == Helpers.ActionResultMessageType.Information).Count(); }
		}

		/// <summary>
		///		Indicates the number of warning messages returned for the action taken.
		/// </summary>
		public int WarningMessageCount
		{
			get { return Messages.Where(m => m.MessageType == Helpers.ActionResultMessageType.Warning).Count(); }
		}
		
		/// <summary>
		///		Indicates the number of messages returned for the action taken.
		/// </summary>
		public int MessageCount
		{
			get { return Messages.Count; }
		}

		#endregion

		/// <summary>
		///		A collection of ActionResultMessages related to the action taken.
		/// </summary>
		public System.Collections.Generic.List<Helpers.ActionResultMessage> Messages
		{
			get
			{
				if (_messages == null)
					_messages = new System.Collections.Generic.List<Helpers.ActionResultMessage>();

				return _messages;
			}
		}
		private System.Collections.Generic.List<Helpers.ActionResultMessage> _messages;

		/// <summary>
		///		A boolean indicating if the action was successful.
		/// </summary>
		public bool WasSuccessful { get; set; }

		#endregion

		#region Constructors & Factories

		//	Internal constructor since it shouldn't be called outside of the API.
		internal ActionResult() { }

		/// <summary>
		///		Creates a new instance of an ActionResult.
		/// </summary>
		/// <returns>The new ActionResult instance.</returns>
		public static Helpers.ActionResult Factory()
		{              
			return new Helpers.ActionResult();
		}

		/// <summary>
		///		Creates a new instance of an ActionResult.
		/// </summary>
		/// <param name="wasSuccessful">Indicates if the action was successful.</param>
		/// <returns>The new ActionResult instance.</returns>
		public static Helpers.ActionResult Factory(bool wasSuccessful)
		{
			return new Helpers.ActionResult { WasSuccessful = wasSuccessful };
		}

		#endregion

        #region Methods

        /// <summary>
        /// Append ActionResult messages
        /// </summary>
        /// <param name="result"></param>
        public void Append(ActionResult result)
        {
            this.Messages.AddRange(result.Messages);

            if (!result.WasSuccessful)
            {
                this.WasSuccessful = false;
            }
        }

        #endregion
    }
}
