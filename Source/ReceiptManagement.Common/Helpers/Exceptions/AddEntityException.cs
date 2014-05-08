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
    ///	The exception thrown when an error occurs while adding an entity.
    /// </summary>
    [System.Serializable]
    public sealed class AddEntityException : System.Exception
    {
    	#region Constructors & Factories
    
        //	Internal constructors since they shouldn't be called outside of the API.
        internal AddEntityException() { }
    	internal AddEntityException(System.Exception innerException) : base(innerException.Message, innerException) { }
        internal AddEntityException(System.String message):base(message) { }
    		
    	/// <summary>
    	///		The factory used to a new AddEntityException with inner exception.
    	/// </summary>
        public static Helpers.Exceptions.AddEntityException Factory(System.Exception innerException)
    	{		
            return new Helpers.Exceptions.AddEntityException(innerException);
        }
    	
    	/// <summary>
    	///		The factory used to a new AddEntityException with a message.
    	/// </summary>
        public static Helpers.Exceptions.AddEntityException Factory(System.String message)
    	{
            return new Helpers.Exceptions.AddEntityException(message);
        }
    		
    	#endregion
    }
}
