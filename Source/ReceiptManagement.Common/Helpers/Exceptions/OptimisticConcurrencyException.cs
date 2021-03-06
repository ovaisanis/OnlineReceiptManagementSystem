//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace ReceiptManagement.Common.Helpers.Exceptions
{
    /// <summary>
    ///	The exception thrown when an error occurs while the entity you are going to update is already modified by another user.
    /// </summary>
    [System.Serializable]
    public sealed class OptimisticConcurrencyException : System.Exception
    {
    	#region Constructors & Factories
    
        //	Internal constructors since they shouldn't be called outside of the API.
        internal OptimisticConcurrencyException() { }
    	internal OptimisticConcurrencyException(System.Exception innerException) : base(innerException.Message, innerException) { }
        internal OptimisticConcurrencyException(System.String message):base(message) { }
    		
    	/// <summary>
    	///		The factory used to a new OptimisticConcurrencyException with inner exception.
    	/// </summary>
        public static Helpers.Exceptions.OptimisticConcurrencyException Factory(System.Exception innerException)
    	{		
            return new Helpers.Exceptions.OptimisticConcurrencyException(innerException);
        }
    	
    	/// <summary>
    	///		The factory used to a new OptimisticConcurrencyException with a message.
    	/// </summary>
        public static Helpers.Exceptions.OptimisticConcurrencyException Factory(System.String message)
    	{
            return new Helpers.Exceptions.OptimisticConcurrencyException(message);
        }
    		
    	#endregion
    }
}
