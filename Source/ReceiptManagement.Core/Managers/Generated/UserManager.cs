using System.Linq;
using System.Linq.Dynamic;
using Entities = ReceiptManagement.Common.Entities;
using Helpers  = ReceiptManagement.Common.Helpers;

namespace ReceiptManagement.Core.Managers
{
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public sealed partial class UserManager : EntityManager
    {	
    	#region Methods
    	
    			#region Partial Methods
    
            //	This partial method gives us a way to update an object before it is added to the system.
            static partial void OnAdding(Helpers.ApiContext apiContext, Entities.User user);
    
            //	This partial method gives us a way to access an object after it has been added to the system.
            static partial void OnAdded(Helpers.ApiContext apiContext, Entities.User user);
    
            //	This partial method gives us a way to update an object before it is updated in the system.        
            static partial void OnUpdating(Helpers.ApiContext apiContext, Entities.User user, bool isBulkUpdate);
    
            //	This partial method gives us a way to access an object after it has been updated in the system.        
            static partial void OnUpdated(Helpers.ApiContext apiContext, Entities.User user, bool isBulkUpdate);
    
            //	This partial method gives us a way to update an object before it is deleted from the system.
            static partial void OnDeleting(Helpers.ApiContext apiContext, Entities.User user);
    
            //	This partial method gives us a way to access an object after it has been deleted from the system.
            static partial void OnDeleted(Helpers.ApiContext apiContext, Entities.User user);
    
            //	This partial method gives us a way to update an object before it is imported into the system.
            static partial void OnImporting(Helpers.ApiContext apiContext, Entities.User user);
    
            //	This partial method gives us a way to access an object after it has been imported into the system.
            static partial void OnImported(Helpers.ApiContext apiContext, Entities.User user);
    
            //	This partial method gives us a way to bulk update an object before it is bulk updated in the system.
            static partial void OnBulkUpdating(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.User> users);
    
            //	This partial method gives us a way to access an object after it has been bulk updated in the system.
            static partial void OnBulkUpdated(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.User> users);
    
            //	This partial method gives us a way to access an object during it is bulk updated in the system.
            static partial void OnPartialUpdate(Helpers.ApiContext apiContext, Entities.User user);
    		
    		//	This partial method gives us a way to access an object before it is validated in the system.
            static partial void OnValidating(Helpers.ApiContext apiContext, Entities.User user, ref Helpers.ActionResult result);
    		
            //	This partial method gives us a way to access an object after it has been validated in the system.
    		static partial void OnValidated(Helpers.ApiContext apiContext, Entities.User user, ref Helpers.ActionResult result);
    
            //	This partial method gives us a way to update an object before it is purged from the system.
            static partial void OnPurging(Helpers.ApiContext apiContext, Entities.User user);
    
            //	This partial method gives us a way to access an object after it has been purged from the system.
            static partial void OnPurged(Helpers.ApiContext apiContext, Entities.User user);
    
    		#endregion
    
    		#region Add Methods
    	
    
    		public static Helpers.ActionResult Add(Helpers.ApiContext apiContext, Entities.User user,out long id)
        	{
        		// API doesn't allow null parameters. This method requires at least 1 item in the collection.
                if (apiContext == null)
                    throw new System.ArgumentNullException("apiContext");
                if (user == null)
                    throw new System.ArgumentNullException("image");              
        				
        		// Verify user is authorized to perform action, otherwise throw exception.
                Security.SecurityHandler.SetApiContext(apiContext);
        
        		Helpers.ActionResult result = Helpers.ActionResult.Factory(true);
        
        		try
        		{
        			Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
        				
        			// ADD to context
        			OnAdding(apiContext, user);
    
        			context.AddObject("Images", user);
        				    
        			context.SaveChanges(); // Save Changes	
    			
                    id = user.Id;
    
        			DetachObjects(apiContext, new System.Collections.Generic.List<Entities.User> {user }); // Clean ObjectState cache
        				
        		}
        		catch (System.Exception ex)
        		{		
        			object forDebugging = ex;
        			throw;// Helpers.Exceptions.AddEntityException.Factory(ex);
        		}
        
        		return result;
        	}  
    
    		/// <summary>
    		///	No Metadata Documentation available.
    		/// </summary>
    		/// <param name="apiContext"></param>
    		/// <param name="users"></param>
    		/// <returns></returns>
    		public static Helpers.ActionResult Add(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.User> users)
    		{
    			return Add(apiContext, users, false);
    		}
    		
    		/// <summary>
    		///	No Metadata Documentation available.
    		/// </summary>
    		/// <param name="apiContext"></param>
    		/// <param name="users"></param>
    		/// <param name="clientWins">if true system properties will not be overwritten by Api</param>
    		/// <returns></returns>
    		public static Helpers.ActionResult Add(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.User> users, System.Boolean clientWins)
    		{
    			// API doesn't allow null parameters. This method requires at least 1 item in the collection.
                if (apiContext == null)
                    throw new System.ArgumentNullException("apiContext");
                if (users == null)
                    throw new System.ArgumentNullException("users");
                if (users.Count() == 0)
                    throw new System.ArgumentOutOfRangeException("users");
    				
    			 // Verify user is authorized to perform action, otherwise throw exception.
                    Security.SecurityHandler.SetApiContext(apiContext);
    
    			Helpers.ActionResult result = Helpers.ActionResult.Factory(true);
    
    			try
    			{
    				Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
    				foreach (Entities.User user in users)
    				{
    					if (!clientWins)
    					{
    						// SET system level properties
    				    	SetSystemProperties(apiContext, user, false);
    					}
    
    					// ADD to context
    					OnAdding(apiContext, user);
    					context.AddObject("Users", user);
    				}
    
    				context.SaveChanges(); // Save Changes				
    				DetachObjects(apiContext, users); // Clean ObjectState cache
    				
    				foreach (Entities.User user in users)
    					OnAdded(apiContext, user);
    			}
    			catch (System.Exception ex)
    			{		
    				object forDebugging = ex;
    				throw;// Helpers.Exceptions.AddEntityException.Factory(ex);
    			}
    
    			return result;
    		}
    	
    		#endregion
    
    		#region Update Methods
    		
    		/// <summary>
    		///		No Metadata Documentation available.
    		/// </summary>
    		/// <param name="apiContext"></param>
    		/// <param name="users"></param>
    		/// <returns></returns>
    		public static Helpers.ActionResult Update(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.User> users)
    		{
    			return Update(apiContext, users, false);
    		}
    		
    		/// <summary>
    		///		No Metadata Documentation available.
    		/// </summary>
    		/// <param name="apiContext"></param>
    		/// <param name="users"></param>
    		/// <param name="clientWins">if true system properties will not be overwritten by Api</param>
    		/// <returns></returns>
    		public static Helpers.ActionResult Update(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.User> users, System.Boolean clientWins)
    		{
    			// API doesn't allow null parameters. This method requires at least 1 item in the collection.
                if (apiContext == null)
                    throw new System.ArgumentNullException("apiContext");
                if (users == null)
                    throw new System.ArgumentNullException("users");
                if (users.Count() == 0)
                    throw new System.ArgumentOutOfRangeException("users");
    
    				 // Verify user is authorized to perform action, otherwise throw exception.
                    Security.SecurityHandler.SetApiContext(apiContext);
    			Helpers.ActionResult result = Helpers.ActionResult.Factory(true);
    
                try
                {
                    Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
                    foreach (Entities.User user in users)
                    {
    					OnUpdating(apiContext, user, false);
    					
    					// ATTACH object					
    					AttachObject(apiContext, "Users", user);
    
    					if (!clientWins)
    					{
    						// SET system level properties
                	    	SetSystemProperties(apiContext, user);
    					}
    					
    					// SET modified										
                        SetModified(apiContext, user);
                    }
    
    				if (clientWins) {
    					context.Refresh(System.Data.Objects.RefreshMode.ClientWins, users);
    				}
    				
    				context.SaveChanges(); // Save Changes
    				DetachObjects(apiContext, users); // Clean ObjectState cache
    
                    foreach (Entities.User user in users)
                        OnUpdated(apiContext, user, false);
                }
    			catch (System.Data.OptimisticConcurrencyException ex)
                {
    				object forDebugging = ex;
    				HandleOptimisticConcurrencyException(apiContext, users, ex, ref result);
                    //throw Helpers.Exceptions.OptimisticConcurrencyException.Factory(ex);
                }
                catch (System.Exception ex)
                {      
    				object forDebugging = ex;
                    throw;// Helpers.Exceptions.UpdateEntityException.Factory(ex);
                }
    
    			return result;
    		}
    		
    		#endregion
    
    		#region Delete Methods
    		
    		/// <summary>
    		///		No Metadata Documentation available.
    		/// </summary>
    		/// <param name="apiContext"></param>
    		/// <param name="users"></param>
    		/// <returns></returns>
            public static Helpers.ActionResult Delete(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.User> users)
            {
    			// API doesn't allow null parameters. This method requires at least 1 item in the collection.
                if (apiContext == null)
                    throw new System.ArgumentNullException("apiContext");
                if (users == null)
                    throw new System.ArgumentNullException("users");
                if (users.Count() == 0)
                    throw new System.ArgumentOutOfRangeException("users");
    
    				 // Verify user is authorized to perform action, otherwise throw exception.
                    Security.SecurityHandler.SetApiContext(apiContext);
    			Helpers.ActionResult result = Helpers.ActionResult.Factory(true);
                try
                {				
                    Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
                    foreach (Entities.User user in users)
                    {
    					OnDeleting(apiContext, user);
    					
    					// ATTACH object					
    					AttachObject(apiContext, "Users", user);
    					
    					// SET system level properties
                	    SetSystemProperties(apiContext, user);
    					SetSystemPropertiesModified(apiContext, user);
    					
    					// SET SoftDeleted
    					SetDeleted(apiContext, user);
                    }
    
    				context.SaveChanges(); // Save Changes
    				DetachObjects(apiContext, users); // Clean ObjectState cache
    				
                    foreach (Entities.User user in users)
                        OnDeleted(apiContext, user);
                }
    			catch (System.Data.OptimisticConcurrencyException ex)
                {
    				object forDebugging = ex;
                    HandleOptimisticConcurrencyException(apiContext, users, ex, ref result);
                    //throw Helpers.Exceptions.OptimisticConcurrencyException.Factory(ex);
                }
                catch (System.Exception ex)
                {     
    				object forDebugging = ex;
                    throw;// Helpers.Exceptions.DeleteEntityException.Factory(ex);
                }
    
                return result;
            }
    		
    		#endregion
    
    		#region Purge Methods
    		
    		/// <summary>
    		///		No Metadata Documentation available.
    		/// </summary>
    		/// <param name="apiContext"></param>
    		/// <param name="users"></param>
    		/// <returns></returns>
            public static Helpers.ActionResult Purge(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.User> users)
            {
    			// API doesn't allow null parameters. This method requires at least 1 item in the collection.
                if (apiContext == null)
                    throw new System.ArgumentNullException("apiContext");
                if (users == null)
                    throw new System.ArgumentNullException("users");
                if (users.Count() == 0)
                    throw new System.ArgumentOutOfRangeException("users");
    
    				 // Verify user is authorized to perform action, otherwise throw exception.
                    Security.SecurityHandler.SetApiContext(apiContext);
    			Helpers.ActionResult result = Helpers.ActionResult.Factory(true);
                try
                {				
                    Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
                    foreach (Entities.User user in users)
                    {
    					OnPurging(apiContext, user);
    					
    					// ATTACH object					
    					AttachObject(apiContext, "Users", user);
    					
    					// DELETE object
    					context.DeleteObject(user);
                    }
    
    				context.SaveChanges(); // Save Changes
    								
                    foreach (Entities.User user in users)
                        OnPurged(apiContext, user);
                }
    			catch (System.Data.OptimisticConcurrencyException ex)
                {
    				object forDebugging = ex;
                    HandleOptimisticConcurrencyException(apiContext, users, ex, ref result);
                    //throw Helpers.Exceptions.OptimisticConcurrencyException.Factory(ex);
                }
                catch (System.Exception ex)
                {     
    				object forDebugging = ex;
                    throw;// Helpers.Exceptions.DeleteEntityException.Factory(ex);
                }
    
                return result;
            }
    		
    		#endregion
    
    		#region Get Methods
    		
    		/// <summary>
    		///		No Metadata Documentation available.
    		/// </summary>
    		/// <param name="apiContext"></param>
    		/// <param name="id"></param>
    		/// <param name="user"></param>
    		/// <returns></returns>
            public static Helpers.ActionResult Get(Helpers.ApiContext apiContext, int id, out Entities.User user)
    		{
                // API doesn't allow null parameters.
                if (apiContext == null)
                    throw new System.ArgumentNullException("apiContext");
                if (id == null)
                    throw new System.ArgumentNullException("id");
    		
    		 // Verify user is authorized to perform action, otherwise throw exception.
                    Security.SecurityHandler.SetApiContext(apiContext);
                Helpers.ActionResult result = Helpers.ActionResult.Factory(true);			
    			
                try
                {
                    Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
                    var qry = context.Users.Where(r => r.Id.Equals(id)).FirstOrDefault();
    
    				// See what would be default value in this case
                    // Also to see if no value found what shall be put into Action Result                
    				if (qry != null)
    				{
    					user = qry;
    					
                    	// must detach the object before return
                    	DetachObject(apiContext, user);
    				}
    				else
    				{
                		user = new Entities.User();
    					user.Id = id;
    
    					result.WasSuccessful = false;
    					result.Messages.Add(Helpers.ActionResultMessage.Factory(user, "Object not Found", Helpers.ActionResultMessageType.Warning));
    				}
                }
                catch (System.Exception ex)
                {      
    				object forDebugging = ex;
                    throw;// Helpers.Exceptions.GetEntityException.Factory(ex);
                }
    
    			return result;            
    		}
    
    		/// <summary>
    		///		No Metadata Documentation available.
    		/// </summary>
    		/// <param name="apiContext"></param>
    		/// <param name="querySettings"></param>
    		/// <param name="users"></param>
    		/// <returns></returns>
    		public static Helpers.ActionResult Get(Helpers.ApiContext apiContext, Helpers.QuerySettings<Entities.User> querySettings, out System.Collections.Generic.List<Entities.User> users)
    		{
                // API doesn't allow null parameters.
                if (apiContext == null)
                    throw new System.ArgumentNullException("apiContext");
                if (querySettings == null)
                    throw new System.ArgumentNullException("querySettings");
    
    				 // Verify user is authorized to perform action, otherwise throw exception.
                    Security.SecurityHandler.SetApiContext(apiContext);
    			Helpers.ActionResult result = Helpers.ActionResult.Factory(true);
    
                try
                {
                    Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
    
                    // make entities query and set the NoTracking option to stop tracking of entities by entity framework
                    System.Data.Objects.ObjectQuery<Entities.User> query = context.Users;
                    query.MergeOption = System.Data.Objects.MergeOption.NoTracking;
    				
    				// include entities
    				foreach (System.String include in querySettings.IncludedEntities) { query = query.Include(include); }
    
                    // execute the query with query settings applied
    				users = query
    						.Where(querySettings.GetWhereExpression())
    						.OrderBy(querySettings.SortExpression)
    						.Skip(querySettings.ResultsStartIndex)
    						.Take(querySettings.MaxResultsSize)
    						.ToList();
                }
                catch (System.Exception ex)
                {      
    				object forDebugging = ex;
                    throw;// Helpers.Exceptions.GetEntityException.Factory(ex);
                }			
    
    			return result;
    		}
    		
    		#endregion
    
    		#region Count Methods
    		
    		
    		/// <summary>
    		///		No Metadata Documentation available.
    		/// </summary>
            /// <param name="apiContext"></param>
    		/// <param name="querySettings"></param>
    		/// <param name="count"></param>
    		/// <returns></returns>
    		public static Helpers.ActionResult Count(Helpers.ApiContext apiContext, Helpers.QuerySettings<Entities.User> querySettings, out int count)
    		{
                // TODO: Perform QuerySettings Sort  Expression validation here (Match SortColumn type with TType)
                // TODO: Perform QuerySettings Where Expression validation here (Match Expression; Add Default Where Expr)
    
                // API doesn't allow null parameters.
                if (apiContext == null)
                    throw new System.ArgumentNullException("apiContext");
                if (querySettings == null)
                    throw new System.ArgumentNullException("querySettings");
    
    				 // Verify user is authorized to perform action, otherwise throw exception.
                    Security.SecurityHandler.SetApiContext(apiContext);
    			Helpers.ActionResult result = Helpers.ActionResult.Factory(true);
    
                try
                {
                    Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
    
                    // execute the query with query settings applied
    				count = context.Users.Where(querySettings.GetWhereExpression()).Count();
                }
                catch (System.Exception ex)
                {      
    				object forDebugging = ex;
                    throw;// Helpers.Exceptions.GetEntityException.Factory(ex);
                }			
    
    			return result;
    		}
    		
    		#endregion
    
    		#region BulkUpdate Methods
    		
    		/// <summary>
            ///		No Metadata Documentation available.
    		/// </summary>
    		/// <param name="apiContext"></param>
    		/// <param name="users"></param>
            /// <returns></returns>
            public static Helpers.ActionResult BulkUpdate(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.User> users)
            {
                // API doesn't allow null parameters. This method requires at least 1 item in the collection.
                if (apiContext == null)
                    throw new System.ArgumentNullException("apiContext");
                if (users == null)
                    throw new System.ArgumentNullException("users");
                if (users.Count() == 0)
                    throw new System.ArgumentOutOfRangeException("users");
    
    				 // Verify user is authorized to perform action, otherwise throw exception.
                    Security.SecurityHandler.SetApiContext(apiContext);
    			Helpers.ActionResult result = Helpers.ActionResult.Factory(true);
                try
                {
                    Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
    				
    				OnBulkUpdating(apiContext, users);
    
    				foreach (Entities.User user in users)
                    {
    					OnUpdating(apiContext, user, true);					
    
    					// ATTACH object					
    					AttachObject(apiContext, "Users", user);
    					
    					// SET system level properties
                	    SetSystemProperties(apiContext, user);
    					SetSystemPropertiesModified(apiContext, user);
    					
    					// PARTIAL update					
                        OnPartialUpdate(apiContext, user);
                    }
    
    				context.SaveChanges(); // Save Changes
    				DetachObjects(apiContext, users); // Clean ObjectState cache
    
                    foreach (Entities.User user in users)
                        OnUpdated(apiContext, user, true);
    					
    				OnBulkUpdated(apiContext, users);
                }
    			catch (System.Data.OptimisticConcurrencyException ex)
                {
    				object forDebugging = ex;
                    HandleOptimisticConcurrencyException(apiContext, users, ex, ref result);
                    //throw Helpers.Exceptions.OptimisticConcurrencyException.Factory(ex);
                }
                catch (System.Exception ex)
                {      
    				object forDebugging = ex;
                    throw;// Helpers.Exceptions.UpdateEntityException.Factory(ex);
                }
    
                return result;
            }
    		
    		#endregion
    
    		#region UpdateStatus Methods
    		
    		/// <summary>
            ///		No Metadata Documentation available.
    		/// </summary>
    		/// <param name="apiContext"></param>
    		/// <param name="users"></param>
            /// <returns></returns>
            public static Helpers.ActionResult UpdateStatus(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.User> users)
            {
                // API doesn't allow null parameters. This method requires at least 1 item in the collection.
                if (apiContext == null)
                    throw new System.ArgumentNullException("apiContext");
                if (users == null)
                    throw new System.ArgumentNullException("users");
                if (users.Count() == 0)
                    throw new System.ArgumentOutOfRangeException("users");
    
    				 // Verify user is authorized to perform action, otherwise throw exception.
                    Security.SecurityHandler.SetApiContext(apiContext);
    			Helpers.ActionResult result = Helpers.ActionResult.Factory(true);
                try
                {
                    Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
    
    				foreach (Entities.User user in users)
                    {                    
    					// ATTACH object					
    					AttachObject(apiContext, "Users", user);
    						
    					// SET system level properties
                	    SetSystemProperties(apiContext, user);
    					SetSystemPropertiesModified(apiContext, user);
    					
    					// SET IsActive property modified
    					System.Data.Objects.ObjectStateEntry ose = apiContext.CurrentContext.ObjectStateManager.GetObjectStateEntry(user);
    					ose.SetModifiedProperty("IsActive");
                    }
    
    				context.SaveChanges(); // Save Changes
    				DetachObjects(apiContext, users); // Clean ObjectState cache
                }
    			catch (System.Data.OptimisticConcurrencyException ex)
                {
    				object forDebugging = ex;
    				//HandleOptimisticConcurrencyException(apiContext, users, ex, ref result);
                    //throw Helpers.Exceptions.OptimisticConcurrencyException.Factory(ex);
    				throw;
                }
                catch (System.Exception ex)
                {     
    				object forDebugging = ex;
                    throw;// Helpers.Exceptions.UpdateEntityException.Factory(ex);
                }
    
                return result;
            }
    		
    		#endregion
    
    		#region Import Methods
    		
    		/// <summary>
            ///		No Metadata Documentation available.
            /// </summary>
            /// <param name="apiContext"></param>
            /// <param name="users"></param>
            /// <returns></returns>
            public static Helpers.ActionResult Import(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.User> users)
            {
                // API doesn't allow null parameters. This method requires at least 1 item in the collection.
                //if (apiContext == null)
                //    throw new System.ArgumentNullException("apiContext");
    
    			throw new System.NotImplementedException();
    
                // Actual implementation is TBD. For consistency we'd want each imported item to go through the same ValidateSave method
                // as is called on any add or edit. That way the same block of logic is used on every item before it goes into
                // the database which assures data consistency.
                // 
                // For the old import this wouldn't have been a problem since all fields were required in the import file. Now imported
                // records could be partial. This raises a bit of an issue since in some cases we'll have to return the existing data
                // from the database before we can validate it. I expect that would be done before this method is called As a result I think we'll have to expect that there will be some 
                // performance loss as a result of this new strategy. I think that the trade off for one set of validation logic is worth
                // it and hopefully with some optimizations it won't be too bad.
                //
                // I have no idea what the final method will look like.
            }
    		
    		#endregion
    
    		#region Helper Methods
    		
    		/// <summary>
            /// No Metadata Documentation available.
            /// </summary>
            /// <param name="apiContext"></param>
            /// <param name="whereClause"></param>
            /// <returns></returns>
            public static bool IsExists(Helpers.ApiContext apiContext, System.Linq.Expressions.Expression<System.Func<Entities.User, bool>> whereClause)
            {
                // API doesn't allow null parameters. This method requires at least 1 item in the collection.
                if (apiContext == null)
                    throw new System.ArgumentNullException("apiContext");
                if (whereClause == null)
                    throw new System.ArgumentNullException("whereClause");
    			
                try
                {
                    Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
                    return context.Users.Any(whereClause);
                }
                catch (System.Exception ex)
                {      
    				object forDebugging = ex;
                    throw;// Helpers.Exceptions.ExistsException.Factory(ex);
                }
            }
    		
    		/// <summary>
            /// No Metadata Documentation available.
            /// </summary>
            /// <param name="apiContext"></param>
            /// <param name="whereClause"></param>
    		/// <param name="id"></param>
            /// <returns></returns>
            public static bool IsExists(Helpers.ApiContext apiContext, System.Linq.Expressions.Expression<System.Func<Entities.User, bool>> whereClause, long id)
            {
                // API doesn't allow null parameters. This method requires at least 1 item in the collection.
                if (apiContext == null)
                    throw new System.ArgumentNullException("apiContext");
                if (whereClause == null)
                    throw new System.ArgumentNullException("whereClause");
    			
                try
                {
                    Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
                    id = context.Users.Where(whereClause).Select(e => e.Id).FirstOrDefault();                 
    
                    return (id != null);
                }
                catch (System.Exception ex)
                {      
    				object forDebugging = ex;
                    throw;// Helpers.Exceptions.ExistsException.Factory(ex);
                }
            }
    		
    		/// <summary>
            /// No Metadata Documentation available.
            /// </summary>
            /// <param name="apiContext"></param>
            /// <param name="whereClause"></param>
            /// <param name="iDs"></param>
            /// <returns></returns>
           /* public static bool IsExists(Helpers.ApiContext apiContext, System.Linq.Expressions.Expression<System.Func<Entities.User, bool>> whereClause, out System.Collections.Generic.List<int> iDs)
            {
                // API doesn't allow null parameters. This method requires at least 1 item in the collection.
                if (apiContext == null)
                    throw new System.ArgumentNullException("apiContext");
                if (whereClause == null)
                    throw new System.ArgumentNullException("whereClause");
    
    				 // Verify user is authorized to perform action, otherwise throw exception.
                    Security.SecurityHandler.SetApiContext(apiContext);
                try
                {
                    Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
                    iDs = context.Users.Where(whereClause).Select(e => e.Id).ToList();
    
                    return (iDs.Count > 0);
                }
                catch (System.Exception ex)
                {      
    				object forDebugging = ex;
                    throw;// Helpers.Exceptions.ExistsException.Factory(ex);
                }
            }*/
    		
    		/// <summary>
            /// No Metadata Documentation available.
            /// </summary>
            /// <param name="apiContext"></param>
            /// <param name="whereClause"></param>
    		/// <param name="selectClause"></param>
            /// <param name="iDs"></param>
            /// <returns></returns>
            public static bool IsExists(Helpers.ApiContext apiContext, System.Linq.Expressions.Expression<System.Func<Entities.User, bool>> whereClause, System.Linq.Expressions.Expression<System.Func<Entities.User, long>> selectClause, out System.Collections.Generic.List<long> iDs)
            {
                // API doesn't allow null parameters. This method requires at least 1 item in the collection.
                if (apiContext == null)
                    throw new System.ArgumentNullException("apiContext");
                if (whereClause == null)
                    throw new System.ArgumentNullException("whereClause");
    			if (selectClause == null)
                    throw new System.ArgumentNullException("selectClause");
    
    				 // Verify user is authorized to perform action, otherwise throw exception.
                    Security.SecurityHandler.SetApiContext(apiContext);
                try
                {
                    Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
                    iDs = context.Users.Where(whereClause).Select(selectClause).ToList();
    
                    return (iDs.Count > 0);
                }
                catch (System.Exception ex)
                {        
    				object forDebugging = ex;
                    throw;// Helpers.Exceptions.ExistsException.Factory(ex);
                }
            }
    
    		/// <summary>
            /// No Metadata Documentation available.
            /// </summary>
            /// <param name="apiContext"></param>
            /// <param name="whereClause"></param>
            /// <param name="entityKeys"></param>
            /// <returns></returns>
            public static bool IsExists(Helpers.ApiContext apiContext, System.Linq.Expressions.Expression<System.Func<Entities.User, bool>> whereClause, out System.Collections.Generic.List<Helpers.EntityKey> entityKeys)
            {
                // API doesn't allow null parameters. This method requires at least 1 item in the collection.
                if (apiContext == null)
                    throw new System.ArgumentNullException("apiContext");
                if (whereClause == null)
                    throw new System.ArgumentNullException("whereClause");
    
    				 // Verify user is authorized to perform action, otherwise throw exception.
                    Security.SecurityHandler.SetApiContext(apiContext);
                try
                {
                   /* Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
                    entityKeys = context.Users
    									.Where(whereClause)
    									.Select(e => new { e.Id, e.ModifiedOn })
    									.ToList()									
    									.ConvertAll(e => Helpers.EntityKey.Factory(e.Id, e.ModifiedOn));
    
                 
    				*/
    				entityKeys = null;
    				   return (entityKeys.Count > 0);
                }
                catch (System.Exception ex)
                {      
    				object forDebugging = ex;
                    throw;// Helpers.Exceptions.ExistsException.Factory(ex);
                }
            }
    		
    		/// <summary>
            /// No Metadata Documentation available.
            /// </summary>
            /// <param name="apiContext"></param>
            /// <param name="whereClause"></param>
    		/// <param name="entityKey"></param>
            /// <returns></returns>
            public static bool IsExists(Helpers.ApiContext apiContext, System.Linq.Expressions.Expression<System.Func<Entities.User, bool>> whereClause, out Helpers.EntityKey entityKey)
            {
                // API doesn't allow null parameters. This method requires at least 1 item in the collection.
                if (apiContext == null)
                    throw new System.ArgumentNullException("apiContext");
                if (whereClause == null)
                    throw new System.ArgumentNullException("whereClause");
    			
                try
                {
    			/*
    				Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
                    var query = context.Users.Where(whereClause).Select(e => new { e.Id, e.ModifiedOn }).FirstOrDefault();
    					*/
    				entityKey = null;
    				/*
    				if (query != null)
    					entityKey = Helpers.EntityKey.Factory(query.Id, query.ModifiedOn);
    				*/
                    return (entityKey != null);
                }
                catch (System.Exception ex)
                {      
    				object forDebugging = ex;
                    throw;// Helpers.Exceptions.ExistsException.Factory(ex);
                }
            }
    
    		/// <summary>
            /// No Metadata Documentation available.
            /// </summary>
            /// <param name="apiContext"></param>
            /// <param name="whereClause"></param>
    		/// <param name="entity"></param>
            /// <returns></returns>
            public static bool IsExists(Helpers.ApiContext apiContext, System.Linq.Expressions.Expression<System.Func<Entities.User, bool>> whereClause, out Entities.User entity)
            {
                // API doesn't allow null parameters. This method requires at least 1 item in the collection.
                if (apiContext == null)
                    throw new System.ArgumentNullException("apiContext");
                if (whereClause == null)
                    throw new System.ArgumentNullException("whereClause");
    			
    			 // Verify user is authorized to perform action, otherwise throw exception.
                    Security.SecurityHandler.SetApiContext(apiContext);
                try
                {
    
                    Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
                    var query = context.Users.Where(whereClause).FirstOrDefault();
    
    				if (query != null)
    				{
    					entity = query;                	
                    	DetachObject(apiContext, entity); // must detach the object before return
    				}
    				else
    				{
    				    entity = null;
    				}
    				
                    return (query != null);
                }
                catch (System.Exception ex)
                {       
    				object forDebugging = ex;
                    throw;// Helpers.Exceptions.ExistsException.Factory(ex);
                }
            }
    
    		/// <summary>
            /// No Metadata Documentation available.
            /// </summary>
            /// <param name="apiContext"></param>
            /// <param name="whereClause"></param>
    		/// <param name="entities"></param>
            /// <returns></returns>
            public static bool IsExists(Helpers.ApiContext apiContext, System.Linq.Expressions.Expression<System.Func<Entities.User, bool>> whereClause, out System.Collections.Generic.List<Entities.User> entities)
            {
                // API doesn't allow null parameters. This method requires at least 1 item in the collection.
                if (apiContext == null)
                    throw new System.ArgumentNullException("apiContext");
                if (whereClause == null)
                    throw new System.ArgumentNullException("whereClause");
    			
    			 // Verify user is authorized to perform action, otherwise throw exception.
                    Security.SecurityHandler.SetApiContext(apiContext);
    
                try
                {
                    Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
                    var query = context.Users;
    				query.MergeOption = System.Data.Objects.MergeOption.NoTracking;
    
    				entities = query.Where(whereClause).ToList();
    				
                    return (entities.Count > 0);
                }
                catch (System.Exception ex)
                {       
    				object forDebugging = ex;
                    throw;// Helpers.Exceptions.ExistsException.Factory(ex);
                }
            }
    		
    		#endregion
    
    		#region Validation Methods
    		
    		/// <summary>
            /// No Metadata Documentation available.
            /// </summary>
            /// <param name="apiContext"></param>
            /// <param name="user"></param>
            /// <param name="result"></param>
    		public static void ValidateData(Helpers.ApiContext apiContext, Entities.User user, ref Helpers.ActionResult result)
            {
    			OnValidating(apiContext, user, ref result);
    			
                if (user.Id == null)
                {
                    result.Messages.Add(Helpers.ActionResultMessage.Factory(user, "Id is required.", Helpers.ActionResultMessageType.Error));
                    result.WasSuccessful = false;
                }
    			
    									if (!System.String.IsNullOrWhiteSpace(user.FirstName) && user.FirstName.Length > 50)
    			{						
    				result.Messages.Add(Helpers.ActionResultMessage.Factory(user, "FirstName must be 50 characters or less.", Helpers.ActionResultMessageType.Error));
    				result.WasSuccessful = false;
    			}
    						if (!System.String.IsNullOrWhiteSpace(user.FirstName) && !System.Text.RegularExpressions.Regex.IsMatch(user.FirstName, alphaNumeric))
    			{						
    				result.Messages.Add(Helpers.ActionResultMessage.Factory(user, "FirstName contains invalid characters.", Helpers.ActionResultMessageType.Error));
    				result.WasSuccessful = false;
    			}
    									if (!System.String.IsNullOrWhiteSpace(user.LastName) && user.LastName.Length > 50)
    			{						
    				result.Messages.Add(Helpers.ActionResultMessage.Factory(user, "LastName must be 50 characters or less.", Helpers.ActionResultMessageType.Error));
    				result.WasSuccessful = false;
    			}
    						if (!System.String.IsNullOrWhiteSpace(user.LastName) && !System.Text.RegularExpressions.Regex.IsMatch(user.LastName, alphaNumeric))
    			{						
    				result.Messages.Add(Helpers.ActionResultMessage.Factory(user, "LastName contains invalid characters.", Helpers.ActionResultMessageType.Error));
    				result.WasSuccessful = false;
    			}
    									if (System.String.IsNullOrWhiteSpace(user.Email))
    			{
    				result.Messages.Add(Helpers.ActionResultMessage.Factory(user, "Email is required.", Helpers.ActionResultMessageType.Error));
    				result.WasSuccessful = false;
    			}
    				
    			if (!System.String.IsNullOrWhiteSpace(user.Email) && user.Email.Length > 50)
    			{
    				result.Messages.Add(Helpers.ActionResultMessage.Factory(user, "Email must be 50 characters or less.", Helpers.ActionResultMessageType.Error));
    				result.WasSuccessful = false;
    			}			if (!System.String.IsNullOrWhiteSpace(user.Email) && !System.Text.RegularExpressions.Regex.IsMatch(user.Email, alphaNumeric))
    			{						
    				result.Messages.Add(Helpers.ActionResultMessage.Factory(user, "Email contains invalid characters.", Helpers.ActionResultMessageType.Error));
    				result.WasSuccessful = false;
    			}
    									if (System.String.IsNullOrWhiteSpace(user.Password))
    			{
    				result.Messages.Add(Helpers.ActionResultMessage.Factory(user, "Password is required.", Helpers.ActionResultMessageType.Error));
    				result.WasSuccessful = false;
    			}
    				
    			if (!System.String.IsNullOrWhiteSpace(user.Password) && user.Password.Length > 50)
    			{
    				result.Messages.Add(Helpers.ActionResultMessage.Factory(user, "Password must be 50 characters or less.", Helpers.ActionResultMessageType.Error));
    				result.WasSuccessful = false;
    			}			if (!System.String.IsNullOrWhiteSpace(user.Password) && !System.Text.RegularExpressions.Regex.IsMatch(user.Password, alphaNumeric))
    			{						
    				result.Messages.Add(Helpers.ActionResultMessage.Factory(user, "Password contains invalid characters.", Helpers.ActionResultMessageType.Error));
    				result.WasSuccessful = false;
    			}
    															
    			OnValidated(apiContext, user, ref result);
            }
    		
    		/// <summary>
            /// HandleOptimisticConcurrencyException
    		/// </summary>
    		/// <param name="apiContext"></param>
    		/// <param name="users"></param>
    		/// <param name="exception"></param>
    		/// <param name="result"></param>
            public static void HandleOptimisticConcurrencyException(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.User> users, System.Exception exception, ref Helpers.ActionResult result)
            { 		
    			result.Messages.Add(Helpers.ActionResultMessage.Factory(null, Helpers.ActionResultMessageCode.VLD_013, Helpers.ActionResultMessageType.Error));
                result.WasSuccessful = false;
            }
    		
    		#endregion
    	
    		#region UpdateStatus Methods
    		
    		/// <summary>
            /// No Metadata Documentation available.
    		/// </summary>
    		/// <param name="apiContext"></param>
    		/// <param name="users"></param>
    		/// <param name="columnExpression"></param>
    		/// <returns></returns>
            public static Helpers.ActionResult PartialUpdate(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.User> users,params System.Linq.Expressions.Expression<System.Func<Entities.User, object>>[] columnExpression)
            {
                // API doesn't allow null parameters. This method requires at least 1 item in the collection.
                if (apiContext == null)
                    throw new System.ArgumentNullException("apiContext");
                if (users == null)
                    throw new System.ArgumentNullException("users");
                if (users.Count() == 0)
                    throw new System.ArgumentOutOfRangeException("users");
    			if (columnExpression == null)
    				throw new System.ArgumentNullException("columnExpression");
    			if (columnExpression.Count() == 0)
    				throw new System.ArgumentOutOfRangeException("columnExpression");
    
    			ValidateColumnExpression<Entities.User>(columnExpression);
    
    			Helpers.ActionResult result = Helpers.ActionResult.Factory(true);
                try
                {
                    Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
    
    				foreach (Entities.User user in users)
                    {                    
    					// ATTACH object					
    					AttachObject(apiContext, "Users", user);
    						
    					// SET system level properties
                	    SetSystemProperties(apiContext, user);
    					SetSystemPropertiesModified(apiContext, user);
    					
    					// SET IsActive property modified
    					System.Data.Objects.ObjectStateEntry ose = apiContext.CurrentContext.ObjectStateManager.GetObjectStateEntry(user);
    					
    					foreach (var item in columnExpression)
    					{
    						ose.SetModifiedProperty(item.GetPropertyName());    
    					}
                    }
    
    				context.SaveChanges(); // Save Changes
    				DetachObjects(apiContext, users); // Clean ObjectState cache
                }
    			catch (System.Data.OptimisticConcurrencyException ex)
                {
    				object forDebugging = ex;
    				HandleOptimisticConcurrencyException(apiContext, users, ex, ref result);                
                }
                catch (System.Exception ex)
                {     
    				object forDebugging = ex;
                    throw;// Helpers.Exceptions.UpdateEntityException.Factory(ex);
                }
    
                return result;
            }
    		
    		#endregion
    
    	
    	
    	#endregion
    }
}
