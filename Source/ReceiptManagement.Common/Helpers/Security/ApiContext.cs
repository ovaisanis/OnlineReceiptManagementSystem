using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace ReceiptManagement.Common.Helpers
{
	/// <summary>
	///		The ApiContext provides a set of credentials used to authenticate and authorize
	///		every request made against the EResolutionOffice API.
	/// </summary>
	public sealed class ApiContext : System.IDisposable
	{
		#region Properties/Methods
                
        // TODO : Put more info into ApiContext UesrId | UserName | CustomerId | FirstName | LastName

        #region System

        /// <summary>
        ///		The version of the API being called.
        /// </summary>
        public System.String ApiVersion       { get; set; }

        /// <summary>
        ///		The connection string to the customer's database.
        /// </summary>
        public System.String ConnectionString { get; set; }

        #endregion

        #region Customer

        /// <summary>
        ///		The customer to whom the user belongs.
        /// </summary>
        //public Entities.Customer Customer       { get; set; }

        /// <summary>
        ///		The 3 character customer identifier of the API user.
        /// </summary>
        public System.String CustomerIdentifier { get; set; } 

        #endregion

        #region User

        /// <summary>
        ///		The authenticated user.
        /// </summary>
      //  public Entities.User User     { get; set; }

        /// <summary>
        ///		The user name of the API user.
        /// </summary>
        public System.String UserName { get; set; }

        /// <summary>
        ///		The password of the API user.
        /// </summary>
        public System.String Password { get; set; }

        public UserSession UserSessionData { get; set; }

        #endregion

        #region Authentication

        /// <summary>
        ///		A boolean indicating if the current user is authenticated.
        /// </summary>
        public System.Boolean IsAuthenticated { get; set; }

        /// <summary>
        ///		A boolean indicating user is not authenticated but ApiContext object is using just to perform
        ///		unauthorized user's transactions.
        /// </summary>
        public System.Boolean IsTemporaryApiContext { get; set; }

        #endregion

        #region Application Object & Permission

        /// <summary>
        /// Get or Set the Code of SecurableObject created in application for requested operation in the application
        /// </summary>
        public System.String SecurableObjectCode { get; set; }

        /// <summary>
        /// Get or Set the Code of Permission created in application for requested operation in the application
        /// </summary>
        public System.String PermissionCode { get; set; }

        #endregion

        #region Transaction

        /// <summary>
        ///		A bool indicating if the api context is currently in a transaction.
        /// </summary>
        public System.Boolean IsInTransaction { get; private set; }

        // TransactionScope
        private System.Transactions.TransactionScope _transactionScope = null;

        #endregion

        #region CurrentContext

        /// <summary>
        ///     Current DataContext
        /// </summary>
        public System.Data.Objects.ObjectContext CurrentContext 
        {
            get
            {
                // Indicate that you must call SecurityHandler.Authorize() before anything
                /*if (_currentContext == null)
                    throw Helpers.Exceptions.NotAuthorizedException.Factory("Authorization Failed.");
                */

                return _currentContext;
            }
            set { _currentContext = value; }
        }
        private System.Data.Objects.ObjectContext _currentContext = null;

        // Is Current DataContext initialized
        public bool IsContextInitialized { get { return (_currentContext != null); } }

        #endregion
        
        #endregion

        #region Constructors & Factories

        //	private constructor since it shouldn't be called outside of the API.
		private ApiContext() 
		{
            IsInTransaction = false;
		}

		/// <summary>
		///		Creates a new instance of an ApiContext object.
		/// </summary>
		/// <param name="customerIdentifier">The customer id of the API user.</param>
		/// <param name="username">The user name of the API user.</param>
		/// <param name="password">The password of the API user.</param>
		/// <param name="apiVersion">The version of the API being called.</param>
		/// <returns>An instance of an ApiContext object.</returns>
		/*public static Helpers.ApiContext Factory(System.String customerIdentifier, 
                                                 System.String username, 
                                                 System.String password, 
                                                 System.String apiVersion,
                                                 System.String connectionString) 
		{
            Helpers.ApiContext apiContext = new Helpers.ApiContext();
            try
            { 
                apiContext.CustomerIdentifier = customerIdentifier;
                apiContext.UserName = username;
                apiContext.Password = password;
                apiContext.ApiVersion = apiVersion;
                apiContext.ConnectionString = connectionString;
                apiContext.IsAuthenticated = true;
                apiContext.UserSessionData = new UserSession();
            }
            catch
            {
                apiContext.Dispose();
                throw;
            }
            return apiContext;
		}*/

        public static Helpers.ApiContext Factory(System.String connectionString)
        {
            Helpers.ApiContext apiContext = new Helpers.ApiContext();
            try
            {              
                apiContext.ConnectionString = connectionString;
                apiContext.IsAuthenticated = true;
                apiContext.UserSessionData = new UserSession();
              
            }
            catch
            {
                apiContext.Dispose();
                throw;
            }
            return apiContext;
        }

		#endregion

		#region Methods

        #region Transaction Specific

        /// <summary>
        ///		Call this method to begin a new transaction.
        /// </summary>
        /// <returns>The result of creating the transaction.</returns>
        public ActionResult BeginTransaction()
        {
            // throw exception if ApiContext already in Transaction
            if (IsInTransaction || _transactionScope != null)
                Exceptions.TransactionException.Factory("ApiContext already in Transaction");
                         
            IsInTransaction   = true;
            _transactionScope = new System.Transactions.TransactionScope();

            return Helpers.ActionResult.Factory(true);
        }

        /// <summary>
        /// Begins the transaction.
        /// </summary>
        /// <param name="timeOut">The time out in minutes after which this transaction will be timed out.</param>
        /// <returns></returns>
        public ActionResult BeginTransaction(uint timeOut)
        {
            // throw exception if ApiContext already in Transaction
            if (IsInTransaction || _transactionScope != null)
                Exceptions.TransactionException.Factory("ApiContext already in Transaction");

            IsInTransaction = true;
            _transactionScope = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Required, System.TimeSpan.FromMinutes(timeOut));

            return Helpers.ActionResult.Factory(true);
        }


        /// <summary>
        ///		Call this method to commit a transaction.
        /// </summary>
        /// <returns></returns>
        public ActionResult CommitTransaction()
        {
            try
            {
                // throw exception if ApiContext not in Transaction
                if (!IsInTransaction || _transactionScope == null)
                    Exceptions.TransactionException.Factory("ApiContext is not in Transaction");

                IsInTransaction = false;

                // Complete
                _transactionScope.Complete();
            }
            catch (System.Exception ex)
            {                
                throw Helpers.Exceptions.TransactionException.Factory(ex);
            }
            finally
            {
                if (_transactionScope != null)
                {
                    _transactionScope.Dispose();
                    _transactionScope = null;
                }
            }

            return Helpers.ActionResult.Factory(true);
        }

        /// <summary>
        ///		Call this mehtod to roll back an existing transaction.
        /// </summary>
        /// <returns>The result of the roll back.</returns>
        public ActionResult RollbackTransaction()
        {
            /*
             * Dispose currentContext 
             * Dispose transactionScope 
             * SET IsInTransaction=False
             */
            Dispose(); 

            // return
            return Helpers.ActionResult.Factory(true);
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Dispose current context, transaction scope, set is_in_transaction flag to false
        /// </summary>
        public void Dispose()
        {            
            if (_currentContext != null)
                _currentContext.Dispose();
            _currentContext = null;
                        
            if (_transactionScope != null)
                _transactionScope.Dispose();
            _transactionScope = null;

            IsInTransaction = false;

            //CustomerIdentifier = null;
            //UserName = null;
            //Password = null;
            //ApiVersion = null;
            //ConnectionString = null;
        }

        #endregion

        #endregion
    }
}