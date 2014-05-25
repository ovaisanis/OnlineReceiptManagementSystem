using System.Linq;
using System.Linq.Dynamic;
using Entities = ReceiptManagement.Common.Entities;
using Helpers  = ReceiptManagement.Common.Helpers;

namespace ReceiptManagement.Core.Managers
{
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public sealed partial class SystemSocialUsersassociationManager : EntityManager
    {	
    	#region Methods
    	
    			#region Partial Methods
    
            //	This partial method gives us a way to update an object before it is added to the system.
            static partial void OnAdding(Helpers.ApiContext apiContext, Entities.System_Social_UsersAssociation system_Social_UsersAssociation);
    
            //	This partial method gives us a way to access an object after it has been added to the system.
            static partial void OnAdded(Helpers.ApiContext apiContext, Entities.System_Social_UsersAssociation system_Social_UsersAssociation);
    
            //	This partial method gives us a way to update an object before it is updated in the system.        
            static partial void OnUpdating(Helpers.ApiContext apiContext, Entities.System_Social_UsersAssociation system_Social_UsersAssociation, bool isBulkUpdate);
    
            //	This partial method gives us a way to access an object after it has been updated in the system.        
            static partial void OnUpdated(Helpers.ApiContext apiContext, Entities.System_Social_UsersAssociation system_Social_UsersAssociation, bool isBulkUpdate);
    
            //	This partial method gives us a way to update an object before it is deleted from the system.
            static partial void OnDeleting(Helpers.ApiContext apiContext, Entities.System_Social_UsersAssociation system_Social_UsersAssociation);
    
            //	This partial method gives us a way to access an object after it has been deleted from the system.
            static partial void OnDeleted(Helpers.ApiContext apiContext, Entities.System_Social_UsersAssociation system_Social_UsersAssociation);
    
            //	This partial method gives us a way to update an object before it is imported into the system.
            static partial void OnImporting(Helpers.ApiContext apiContext, Entities.System_Social_UsersAssociation system_Social_UsersAssociation);
    
            //	This partial method gives us a way to access an object after it has been imported into the system.
            static partial void OnImported(Helpers.ApiContext apiContext, Entities.System_Social_UsersAssociation system_Social_UsersAssociation);
    
            //	This partial method gives us a way to bulk update an object before it is bulk updated in the system.
            static partial void OnBulkUpdating(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.System_Social_UsersAssociation> system_Social_UsersAssociationList);
    
            //	This partial method gives us a way to access an object after it has been bulk updated in the system.
            static partial void OnBulkUpdated(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.System_Social_UsersAssociation> system_Social_UsersAssociationList);
    
            //	This partial method gives us a way to access an object during it is bulk updated in the system.
            static partial void OnPartialUpdate(Helpers.ApiContext apiContext, Entities.System_Social_UsersAssociation system_Social_UsersAssociation);
    		
    		//	This partial method gives us a way to access an object before it is validated in the system.
            static partial void OnValidating(Helpers.ApiContext apiContext, Entities.System_Social_UsersAssociation system_Social_UsersAssociation, ref Helpers.ActionResult result);
    		
            //	This partial method gives us a way to access an object after it has been validated in the system.
    		static partial void OnValidated(Helpers.ApiContext apiContext, Entities.System_Social_UsersAssociation system_Social_UsersAssociation, ref Helpers.ActionResult result);
    
            //	This partial method gives us a way to update an object before it is purged from the system.
            static partial void OnPurging(Helpers.ApiContext apiContext, Entities.System_Social_UsersAssociation system_Social_UsersAssociation);
    
            //	This partial method gives us a way to access an object after it has been purged from the system.
            static partial void OnPurged(Helpers.ApiContext apiContext, Entities.System_Social_UsersAssociation system_Social_UsersAssociation);
    
    		#endregion
    
    		#region Add Methods
    	
    
    		public static Helpers.ActionResult Add(Helpers.ApiContext apiContext, Entities.System_Social_UsersAssociation system_Social_UsersAssociation,out long id)
        	{
        		// API doesn't allow null parameters. This method requires at least 1 item in the collection.
                if (apiContext == null)
                    throw new System.ArgumentNullException("apiContext");
                if (system_Social_UsersAssociation == null)
                    throw new System.ArgumentNullException("image");              
        				
        		// Verify user is authorized to perform action, otherwise throw exception.
                Security.SecurityHandler.SetApiContext(apiContext);
        
        		Helpers.ActionResult result = Helpers.ActionResult.Factory(true);
        
        		try
        		{
        			Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
        				
        			// ADD to context
        			OnAdding(apiContext, system_Social_UsersAssociation);
    
        			context.AddObject("System_Social_UsersAssociation", system_Social_UsersAssociation);
        				    
        			context.SaveChanges(); // Save Changes	
    			
                    id = system_Social_UsersAssociation.Id;
    
        			DetachObjects(apiContext, new System.Collections.Generic.List<Entities.System_Social_UsersAssociation> {system_Social_UsersAssociation }); // Clean ObjectState cache
        				
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
    		/// <param name="system_Social_UsersAssociationList"></param>
    		/// <returns></returns>
    		public static Helpers.ActionResult Add(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.System_Social_UsersAssociation> system_Social_UsersAssociationList)
    		{
    			return Add(apiContext, system_Social_UsersAssociationList, false);
    		}
    		
    		/// <summary>
    		///	No Metadata Documentation available.
    		/// </summary>
    		/// <param name="apiContext"></param>
    		/// <param name="system_Social_UsersAssociationList"></param>
    		/// <param name="clientWins">if true system properties will not be overwritten by Api</param>
    		/// <returns></returns>
    		public static Helpers.ActionResult Add(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.System_Social_UsersAssociation> system_Social_UsersAssociationList, System.Boolean clientWins)
    		{
    			// API doesn't allow null parameters. This method requires at least 1 item in the collection.
                if (apiContext == null)
                    throw new System.ArgumentNullException("apiContext");
                if (system_Social_UsersAssociationList == null)
                    throw new System.ArgumentNullException("system_Social_UsersAssociationList");
                if (system_Social_UsersAssociationList.Count() == 0)
                    throw new System.ArgumentOutOfRangeException("system_Social_UsersAssociationList");
    				
    			 // Verify user is authorized to perform action, otherwise throw exception.
                    Security.SecurityHandler.SetApiContext(apiContext);
    
    			Helpers.ActionResult result = Helpers.ActionResult.Factory(true);
    
    			try
    			{
    				Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
    				foreach (Entities.System_Social_UsersAssociation system_Social_UsersAssociation in system_Social_UsersAssociationList)
    				{
    					if (!clientWins)
    					{
    						// SET system level properties
    				    	SetSystemProperties(apiContext, system_Social_UsersAssociation, false);
    					}
    
    					// ADD to context
    					OnAdding(apiContext, system_Social_UsersAssociation);
    					context.AddObject("System_Social_UsersAssociation", system_Social_UsersAssociation);
    				}
    
    				context.SaveChanges(); // Save Changes				
    				DetachObjects(apiContext, system_Social_UsersAssociationList); // Clean ObjectState cache
    				
    				foreach (Entities.System_Social_UsersAssociation system_Social_UsersAssociation in system_Social_UsersAssociationList)
    					OnAdded(apiContext, system_Social_UsersAssociation);
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
    		/// <param name="system_Social_UsersAssociationList"></param>
    		/// <returns></returns>
    		public static Helpers.ActionResult Update(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.System_Social_UsersAssociation> system_Social_UsersAssociationList)
    		{
    			return Update(apiContext, system_Social_UsersAssociationList, false);
    		}
    		
    		/// <summary>
    		///		No Metadata Documentation available.
    		/// </summary>
    		/// <param name="apiContext"></param>
    		/// <param name="system_Social_UsersAssociationList"></param>
    		/// <param name="clientWins">if true system properties will not be overwritten by Api</param>
    		/// <returns></returns>
    		public static Helpers.ActionResult Update(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.System_Social_UsersAssociation> system_Social_UsersAssociationList, System.Boolean clientWins)
    		{
    			// API doesn't allow null parameters. This method requires at least 1 item in the collection.
                if (apiContext == null)
                    throw new System.ArgumentNullException("apiContext");
                if (system_Social_UsersAssociationList == null)
                    throw new System.ArgumentNullException("system_Social_UsersAssociationList");
                if (system_Social_UsersAssociationList.Count() == 0)
                    throw new System.ArgumentOutOfRangeException("system_Social_UsersAssociationList");
    
    				 // Verify user is authorized to perform action, otherwise throw exception.
                    Security.SecurityHandler.SetApiContext(apiContext);
    			Helpers.ActionResult result = Helpers.ActionResult.Factory(true);
    
                try
                {
                    Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
                    foreach (Entities.System_Social_UsersAssociation system_Social_UsersAssociation in system_Social_UsersAssociationList)
                    {
    					OnUpdating(apiContext, system_Social_UsersAssociation, false);
    					
    					// ATTACH object					
    					AttachObject(apiContext, "System_Social_UsersAssociation", system_Social_UsersAssociation);
    
    					if (!clientWins)
    					{
    						// SET system level properties
                	    	SetSystemProperties(apiContext, system_Social_UsersAssociation);
    					}
    					
    					// SET modified										
                        SetModified(apiContext, system_Social_UsersAssociation);
                    }
    
    				if (clientWins) {
    					context.Refresh(System.Data.Objects.RefreshMode.ClientWins, system_Social_UsersAssociationList);
    				}
    				
    				context.SaveChanges(); // Save Changes
    				DetachObjects(apiContext, system_Social_UsersAssociationList); // Clean ObjectState cache
    
                    foreach (Entities.System_Social_UsersAssociation system_Social_UsersAssociation in system_Social_UsersAssociationList)
                        OnUpdated(apiContext, system_Social_UsersAssociation, false);
                }
    			catch (System.Data.OptimisticConcurrencyException ex)
                {
    				object forDebugging = ex;
    				HandleOptimisticConcurrencyException(apiContext, system_Social_UsersAssociationList, ex, ref result);
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
    		/// <param name="system_Social_UsersAssociationList"></param>
    		/// <returns></returns>
            public static Helpers.ActionResult Delete(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.System_Social_UsersAssociation> system_Social_UsersAssociationList)
            {
    			// API doesn't allow null parameters. This method requires at least 1 item in the collection.
                if (apiContext == null)
                    throw new System.ArgumentNullException("apiContext");
                if (system_Social_UsersAssociationList == null)
                    throw new System.ArgumentNullException("system_Social_UsersAssociationList");
                if (system_Social_UsersAssociationList.Count() == 0)
                    throw new System.ArgumentOutOfRangeException("system_Social_UsersAssociationList");
    
    				 // Verify user is authorized to perform action, otherwise throw exception.
                    Security.SecurityHandler.SetApiContext(apiContext);
    			Helpers.ActionResult result = Helpers.ActionResult.Factory(true);
                try
                {				
                    Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
                    foreach (Entities.System_Social_UsersAssociation system_Social_UsersAssociation in system_Social_UsersAssociationList)
                    {
    					OnDeleting(apiContext, system_Social_UsersAssociation);
    					
    					// ATTACH object					
    					AttachObject(apiContext, "System_Social_UsersAssociation", system_Social_UsersAssociation);
    					
    					// SET system level properties
                	    SetSystemProperties(apiContext, system_Social_UsersAssociation);
    					SetSystemPropertiesModified(apiContext, system_Social_UsersAssociation);
    					
    					// SET SoftDeleted
    					SetDeleted(apiContext, system_Social_UsersAssociation);
                    }
    
    				context.SaveChanges(); // Save Changes
    				DetachObjects(apiContext, system_Social_UsersAssociationList); // Clean ObjectState cache
    				
                    foreach (Entities.System_Social_UsersAssociation system_Social_UsersAssociation in system_Social_UsersAssociationList)
                        OnDeleted(apiContext, system_Social_UsersAssociation);
                }
    			catch (System.Data.OptimisticConcurrencyException ex)
                {
    				object forDebugging = ex;
                    HandleOptimisticConcurrencyException(apiContext, system_Social_UsersAssociationList, ex, ref result);
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
    		/// <param name="system_Social_UsersAssociationList"></param>
    		/// <returns></returns>
            public static Helpers.ActionResult Purge(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.System_Social_UsersAssociation> system_Social_UsersAssociationList)
            {
    			// API doesn't allow null parameters. This method requires at least 1 item in the collection.
                if (apiContext == null)
                    throw new System.ArgumentNullException("apiContext");
                if (system_Social_UsersAssociationList == null)
                    throw new System.ArgumentNullException("system_Social_UsersAssociationList");
                if (system_Social_UsersAssociationList.Count() == 0)
                    throw new System.ArgumentOutOfRangeException("system_Social_UsersAssociationList");
    
    				 // Verify user is authorized to perform action, otherwise throw exception.
                    Security.SecurityHandler.SetApiContext(apiContext);
    			Helpers.ActionResult result = Helpers.ActionResult.Factory(true);
                try
                {				
                    Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
                    foreach (Entities.System_Social_UsersAssociation system_Social_UsersAssociation in system_Social_UsersAssociationList)
                    {
    					OnPurging(apiContext, system_Social_UsersAssociation);
    					
    					// ATTACH object					
    					AttachObject(apiContext, "System_Social_UsersAssociation", system_Social_UsersAssociation);
    					
    					// DELETE object
    					context.DeleteObject(system_Social_UsersAssociation);
                    }
    
    				context.SaveChanges(); // Save Changes
    								
                    foreach (Entities.System_Social_UsersAssociation system_Social_UsersAssociation in system_Social_UsersAssociationList)
                        OnPurged(apiContext, system_Social_UsersAssociation);
                }
    			catch (System.Data.OptimisticConcurrencyException ex)
                {
    				object forDebugging = ex;
                    HandleOptimisticConcurrencyException(apiContext, system_Social_UsersAssociationList, ex, ref result);
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
    		/// <param name="system_Social_UsersAssociation"></param>
    		/// <returns></returns>
            public static Helpers.ActionResult Get(Helpers.ApiContext apiContext, int id, out Entities.System_Social_UsersAssociation system_Social_UsersAssociation)
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
                    var qry = context.System_Social_UsersAssociation.Where(r => r.Id.Equals(id)).FirstOrDefault();
    
    				// See what would be default value in this case
                    // Also to see if no value found what shall be put into Action Result                
    				if (qry != null)
    				{
    					system_Social_UsersAssociation = qry;
    					
                    	// must detach the object before return
                    	DetachObject(apiContext, system_Social_UsersAssociation);
    				}
    				else
    				{
                		system_Social_UsersAssociation = new Entities.System_Social_UsersAssociation();
    					system_Social_UsersAssociation.Id = id;
    
    					result.WasSuccessful = false;
    					result.Messages.Add(Helpers.ActionResultMessage.Factory(system_Social_UsersAssociation, "Object not Found", Helpers.ActionResultMessageType.Warning));
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
    		/// <param name="system_Social_UsersAssociationList"></param>
    		/// <returns></returns>
    		public static Helpers.ActionResult Get(Helpers.ApiContext apiContext, Helpers.QuerySettings<Entities.System_Social_UsersAssociation> querySettings, out System.Collections.Generic.List<Entities.System_Social_UsersAssociation> system_Social_UsersAssociationList)
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
                    System.Data.Objects.ObjectQuery<Entities.System_Social_UsersAssociation> query = context.System_Social_UsersAssociation;
                    query.MergeOption = System.Data.Objects.MergeOption.NoTracking;
    				
    				// include entities
    				foreach (System.String include in querySettings.IncludedEntities) { query = query.Include(include); }
    
                    // execute the query with query settings applied
    				system_Social_UsersAssociationList = query
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
    		public static Helpers.ActionResult Count(Helpers.ApiContext apiContext, Helpers.QuerySettings<Entities.System_Social_UsersAssociation> querySettings, out int count)
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
    				count = context.System_Social_UsersAssociation.Where(querySettings.GetWhereExpression()).Count();
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
    		/// <param name="system_Social_UsersAssociationList"></param>
            /// <returns></returns>
            public static Helpers.ActionResult BulkUpdate(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.System_Social_UsersAssociation> system_Social_UsersAssociationList)
            {
                // API doesn't allow null parameters. This method requires at least 1 item in the collection.
                if (apiContext == null)
                    throw new System.ArgumentNullException("apiContext");
                if (system_Social_UsersAssociationList == null)
                    throw new System.ArgumentNullException("system_Social_UsersAssociationList");
                if (system_Social_UsersAssociationList.Count() == 0)
                    throw new System.ArgumentOutOfRangeException("system_Social_UsersAssociationList");
    
    				 // Verify user is authorized to perform action, otherwise throw exception.
                    Security.SecurityHandler.SetApiContext(apiContext);
    			Helpers.ActionResult result = Helpers.ActionResult.Factory(true);
                try
                {
                    Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
    				
    				OnBulkUpdating(apiContext, system_Social_UsersAssociationList);
    
    				foreach (Entities.System_Social_UsersAssociation system_Social_UsersAssociation in system_Social_UsersAssociationList)
                    {
    					OnUpdating(apiContext, system_Social_UsersAssociation, true);					
    
    					// ATTACH object					
    					AttachObject(apiContext, "System_Social_UsersAssociation", system_Social_UsersAssociation);
    					
    					// SET system level properties
                	    SetSystemProperties(apiContext, system_Social_UsersAssociation);
    					SetSystemPropertiesModified(apiContext, system_Social_UsersAssociation);
    					
    					// PARTIAL update					
                        OnPartialUpdate(apiContext, system_Social_UsersAssociation);
                    }
    
    				context.SaveChanges(); // Save Changes
    				DetachObjects(apiContext, system_Social_UsersAssociationList); // Clean ObjectState cache
    
                    foreach (Entities.System_Social_UsersAssociation system_Social_UsersAssociation in system_Social_UsersAssociationList)
                        OnUpdated(apiContext, system_Social_UsersAssociation, true);
    					
    				OnBulkUpdated(apiContext, system_Social_UsersAssociationList);
                }
    			catch (System.Data.OptimisticConcurrencyException ex)
                {
    				object forDebugging = ex;
                    HandleOptimisticConcurrencyException(apiContext, system_Social_UsersAssociationList, ex, ref result);
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
    
    		#region Import Methods
    		
    		/// <summary>
            ///		No Metadata Documentation available.
            /// </summary>
            /// <param name="apiContext"></param>
            /// <param name="system_Social_UsersAssociationList"></param>
            /// <returns></returns>
            public static Helpers.ActionResult Import(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.System_Social_UsersAssociation> system_Social_UsersAssociationList)
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
            public static bool IsExists(Helpers.ApiContext apiContext, System.Linq.Expressions.Expression<System.Func<Entities.System_Social_UsersAssociation, bool>> whereClause)
            {
                // API doesn't allow null parameters. This method requires at least 1 item in the collection.
                if (apiContext == null)
                    throw new System.ArgumentNullException("apiContext");
                if (whereClause == null)
                    throw new System.ArgumentNullException("whereClause");
    			
                try
                {
                    Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
                    return context.System_Social_UsersAssociation.Any(whereClause);
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
            public static bool IsExists(Helpers.ApiContext apiContext, System.Linq.Expressions.Expression<System.Func<Entities.System_Social_UsersAssociation, bool>> whereClause, long id)
            {
                // API doesn't allow null parameters. This method requires at least 1 item in the collection.
                if (apiContext == null)
                    throw new System.ArgumentNullException("apiContext");
                if (whereClause == null)
                    throw new System.ArgumentNullException("whereClause");
    			
                try
                {
                    Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
                    id = context.System_Social_UsersAssociation.Where(whereClause).Select(e => e.Id).FirstOrDefault();                 
    
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
           /* public static bool IsExists(Helpers.ApiContext apiContext, System.Linq.Expressions.Expression<System.Func<Entities.System_Social_UsersAssociation, bool>> whereClause, out System.Collections.Generic.List<int> iDs)
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
                    iDs = context.System_Social_UsersAssociation.Where(whereClause).Select(e => e.Id).ToList();
    
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
            public static bool IsExists(Helpers.ApiContext apiContext, System.Linq.Expressions.Expression<System.Func<Entities.System_Social_UsersAssociation, bool>> whereClause, System.Linq.Expressions.Expression<System.Func<Entities.System_Social_UsersAssociation, long>> selectClause, out System.Collections.Generic.List<long> iDs)
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
                    iDs = context.System_Social_UsersAssociation.Where(whereClause).Select(selectClause).ToList();
    
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
            public static bool IsExists(Helpers.ApiContext apiContext, System.Linq.Expressions.Expression<System.Func<Entities.System_Social_UsersAssociation, bool>> whereClause, out System.Collections.Generic.List<Helpers.EntityKey> entityKeys)
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
                    entityKeys = context.System_Social_UsersAssociation
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
            public static bool IsExists(Helpers.ApiContext apiContext, System.Linq.Expressions.Expression<System.Func<Entities.System_Social_UsersAssociation, bool>> whereClause, out Helpers.EntityKey entityKey)
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
                    var query = context.System_Social_UsersAssociation.Where(whereClause).Select(e => new { e.Id, e.ModifiedOn }).FirstOrDefault();
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
            public static bool IsExists(Helpers.ApiContext apiContext, System.Linq.Expressions.Expression<System.Func<Entities.System_Social_UsersAssociation, bool>> whereClause, out Entities.System_Social_UsersAssociation entity)
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
                    var query = context.System_Social_UsersAssociation.Where(whereClause).FirstOrDefault();
    
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
            public static bool IsExists(Helpers.ApiContext apiContext, System.Linq.Expressions.Expression<System.Func<Entities.System_Social_UsersAssociation, bool>> whereClause, out System.Collections.Generic.List<Entities.System_Social_UsersAssociation> entities)
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
                    var query = context.System_Social_UsersAssociation;
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
            /// <param name="system_Social_UsersAssociation"></param>
            /// <param name="result"></param>
    		public static void ValidateData(Helpers.ApiContext apiContext, Entities.System_Social_UsersAssociation system_Social_UsersAssociation, ref Helpers.ActionResult result)
            {
    			OnValidating(apiContext, system_Social_UsersAssociation, ref result);
    			
                if (system_Social_UsersAssociation.Id == null)
                {
                    result.Messages.Add(Helpers.ActionResultMessage.Factory(system_Social_UsersAssociation, "Id is required.", Helpers.ActionResultMessageType.Error));
                    result.WasSuccessful = false;
                }
    			
    												
    			OnValidated(apiContext, system_Social_UsersAssociation, ref result);
            }
    		
    		/// <summary>
            /// HandleOptimisticConcurrencyException
    		/// </summary>
    		/// <param name="apiContext"></param>
    		/// <param name="system_Social_UsersAssociationList"></param>
    		/// <param name="exception"></param>
    		/// <param name="result"></param>
            public static void HandleOptimisticConcurrencyException(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.System_Social_UsersAssociation> system_Social_UsersAssociationList, System.Exception exception, ref Helpers.ActionResult result)
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
    		/// <param name="system_Social_UsersAssociationList"></param>
    		/// <param name="columnExpression"></param>
    		/// <returns></returns>
            public static Helpers.ActionResult PartialUpdate(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.System_Social_UsersAssociation> system_Social_UsersAssociationList,params System.Linq.Expressions.Expression<System.Func<Entities.System_Social_UsersAssociation, object>>[] columnExpression)
            {
                // API doesn't allow null parameters. This method requires at least 1 item in the collection.
                if (apiContext == null)
                    throw new System.ArgumentNullException("apiContext");
                if (system_Social_UsersAssociationList == null)
                    throw new System.ArgumentNullException("system_Social_UsersAssociationList");
                if (system_Social_UsersAssociationList.Count() == 0)
                    throw new System.ArgumentOutOfRangeException("system_Social_UsersAssociationList");
    			if (columnExpression == null)
    				throw new System.ArgumentNullException("columnExpression");
    			if (columnExpression.Count() == 0)
    				throw new System.ArgumentOutOfRangeException("columnExpression");
    
    			ValidateColumnExpression<Entities.System_Social_UsersAssociation>(columnExpression);
    
    			Helpers.ActionResult result = Helpers.ActionResult.Factory(true);
                try
                {
                    Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
    
    				foreach (Entities.System_Social_UsersAssociation system_Social_UsersAssociation in system_Social_UsersAssociationList)
                    {                    
    					// ATTACH object					
    					AttachObject(apiContext, "System_Social_UsersAssociation", system_Social_UsersAssociation);
    						
    					// SET system level properties
                	    SetSystemProperties(apiContext, system_Social_UsersAssociation);
    					SetSystemPropertiesModified(apiContext, system_Social_UsersAssociation);
    					
    					// SET IsActive property modified
    					System.Data.Objects.ObjectStateEntry ose = apiContext.CurrentContext.ObjectStateManager.GetObjectStateEntry(system_Social_UsersAssociation);
    					
    					foreach (var item in columnExpression)
    					{
    						ose.SetModifiedProperty(item.GetPropertyName());    
    					}
                    }
    
    				context.SaveChanges(); // Save Changes
    				DetachObjects(apiContext, system_Social_UsersAssociationList); // Clean ObjectState cache
                }
    			catch (System.Data.OptimisticConcurrencyException ex)
                {
    				object forDebugging = ex;
    				HandleOptimisticConcurrencyException(apiContext, system_Social_UsersAssociationList, ex, ref result);                
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
