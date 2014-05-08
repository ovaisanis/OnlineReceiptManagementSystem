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
    ///	The exception thrown when an error occurs while deleting an entity.
    /// </summary>
    [System.Serializable]
    public sealed class DeleteEntityException : System.Exception
    {
    	#region Constructors & Factories
    
        //	Internal constructors since they shouldn't be called outside of the API.
        internal DeleteEntityException() { }
    	internal DeleteEntityException(System.Exception innerException) : base(innerException.Message, innerException) { }
        internal DeleteEntityException(System.String message):base(message) { }
    		
    	/// <summary>
    	///		The factory used to a new DeleteEntityException with inner exception.
    	/// </summary>
        public static Helpers.Exceptions.DeleteEntityException Factory(System.Exception innerException)
    	{		
            return new Helpers.Exceptions.DeleteEntityException(innerException);
        }
    	
    	/// <summary>
    	///		The factory used to a new DeleteEntityException with a message.
    	/// </summary>
        public static Helpers.Exceptions.DeleteEntityException Factory(System.String message)
    	{
            return new Helpers.Exceptions.DeleteEntityException(message);
        }
    		
    	#endregion
    }
}