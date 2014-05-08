
namespace ReceiptManagement.Common.Helpers
{
	/// <summary>
	///		The allowed types of ActionResultMessages.
	/// </summary>
	public enum ActionResultMessageType
	{
		/// <summary>
		///		Indicates no type was applied to this message.
		/// </summary>
		Unspecified,

		/// <summary>
		///		Indicates the message is for information purposes only.
		/// </summary>
		Information,
		
		/// <summary>
		///		Indicates the message is warning the user of an unexpected condition.
		/// </summary>
		Warning,
		
		/// <summary>
		///		Indicates the message is an error.
		/// </summary>
		Error
	}
}
