using System.Linq;
using System.Linq.Dynamic;
using Entities = ReceiptManagement.Common.Entities;
using Helpers  = ReceiptManagement.Common.Helpers;

namespace ReceiptManagement.Core.Managers
{
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public sealed partial class MyProductsServicesManager : EntityManager
    {	
    	#region Methods
    	
    			#region Partial Methods
    
            //	This partial method gives us a way to update an object before it is added to the system.
            static partial void OnAdding(Helpers.ApiContext apiContext, Entities.My_Products_Services my_Products_Services);
    
            //	This partial method gives us a way to access an object after it has been added to the system.
            static partial void OnAdded(Helpers.ApiContext apiContext, Entities.My_Products_Services my_Products_Services);
    
            //	This partial method gives us a way to update an object before it is updated in the system.        
            static partial void OnUpdating(Helpers.ApiContext apiContext, Entities.My_Products_Services my_Products_Services, bool isBulkUpdate);
    
            //	This partial method gives us a way to access an object after it has been updated in the system.        
            static partial void OnUpdated(Helpers.ApiContext apiContext, Entities.My_Products_Services my_Products_Services, bool isBulkUpdate);
    
            //	This partial method gives us a way to update an object before it is deleted from the system.
            static partial void OnDeleting(Helpers.ApiContext apiContext, Entities.My_Products_Services my_Products_Services);
    
            //	This partial method gives us a way to access an object after it has been deleted from the system.
            static partial void OnDeleted(Helpers.ApiContext apiContext, Entities.My_Products_Services my_Products_Services);
    
            //	This partial method gives us a way to update an object before it is imported into the system.
            static partial void OnImporting(Helpers.ApiContext apiContext, Entities.My_Products_Services my_Products_Services);
    
            //	This partial method gives us a way to access an object after it has been imported into the system.
            static partial void OnImported(Helpers.ApiContext apiContext, Entities.My_Products_Services my_Products_Services);
    
            //	This partial method gives us a way to bulk update an object before it is bulk updated in the system.
            static partial void OnBulkUpdating(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.My_Products_Services> my_Products_ServicesList);
    
            //	This partial method gives us a way to access an object after it has been bulk updated in the system.
            static partial void OnBulkUpdated(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.My_Products_Services> my_Products_ServicesList);
    
            //	This partial method gives us a way to access an object during it is bulk updated in the system.
            static partial void OnPartialUpdate(Helpers.ApiContext apiContext, Entities.My_Products_Services my_Products_Services);
    		
    		//	This partial method gives us a way to access an object before it is validated in the system.
            static partial void OnValidating(Helpers.ApiContext apiContext, Entities.My_Products_Services my_Products_Services, ref Helpers.ActionResult result);
    		
            //	This partial method gives us a way to access an object after it has been validated in the system.
    		static partial void OnValidated(Helpers.ApiContext apiContext, Entities.My_Products_Services my_Products_Services, ref Helpers.ActionResult result);
    
            //	This partial method gives us a way to update an object before it is purged from the system.
            static partial void OnPurging(Helpers.ApiContext apiContext, Entities.My_Products_Services my_Products_Services);
    
            //	This partial method gives us a way to access an object after it has been purged from the system.
            static partial void OnPurged(Helpers.ApiContext apiContext, Entities.My_Products_Services my_Products_Services);
    
    		#endregion
    
    		#region Add Methods
    	
    
    		public static Helpers.ActionResult Add(Helpers.ApiContext apiContext, Entities.My_Products_Services my_Products_Services,out long id)
        	{
        		// API doesn't allow null parameters. This method requires at least 1 item in the collection.
                if (apiContext == null)
                    throw new System.ArgumentNullException("apiContext");
                if (my_Products_Services == null)
                    throw new System.ArgumentNullException("image");              
        				
        		// Verify user is authorized to perform action, otherwise throw exception.
                Security.SecurityHandler.SetApiContext(apiContext);
        
        		Helpers.ActionResult result = Helpers.ActionResult.Factory(true);
        
        		try
        		{
        			Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
        				
        			// ADD to context
        			OnAdding(apiContext, my_Products_Services);
    
        			context.AddObject("Images", my_Products_Services);
        				    
        			context.SaveChanges(); // Save Changes	
    			
                    id = my_Products_Services.Id;
    
        			DetachObjects(apiContext, new System.Collections.Generic.List<Entities.My_Products_Services> {my_Products_Services }); // Clean ObjectState cache
        				
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
    		/// <param name="my_Products_ServicesList"></param>
    		/// <returns></returns>
    		public static Helpers.ActionResult Add(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.My_Products_Services> my_Products_ServicesList)
    		{
    			return Add(apiContext, my_Products_ServicesList, false);
    		}
    		
    		/// <summary>
    		///	No Metadata Documentation available.
    		/// </summary>
    		/// <param name="apiContext"></param>
    		/// <param name="my_Products_ServicesList"></param>
    		/// <param name="clientWins">if true system properties will not be overwritten by Api</param>
    		/// <returns></returns>
    		public static Helpers.ActionResult Add(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.My_Products_Services> my_Products_ServicesList, System.Boolean clientWins)
    		{
    			// API doesn't allow null parameters. This method requires at least 1 item in the collection.
                if (apiContext == null)
                    throw new System.ArgumentNullException("apiContext");
                if (my_Products_ServicesList == null)
                    throw new System.ArgumentNullException("my_Products_ServicesList");
                if (my_Products_ServicesList.Count() == 0)
                    throw new System.ArgumentOutOfRangeException("my_Products_ServicesList");
    				
    			 // Verify user is authorized to perform action, otherwise throw exception.
                    Security.SecurityHandler.SetApiContext(apiContext);
    
    			Helpers.ActionResult result = Helpers.ActionResult.Factory(true);
    
    			try
    			{
    				Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
    				foreach (Entities.My_Products_Services my_Products_Services in my_Products_ServicesList)
    				{
    					if (!clientWins)
    					{
    						// SET system level properties
    				    	SetSystemProperties(apiContext, my_Products_Services, false);
    					}
    
    					// ADD to context
    					OnAdding(apiContext, my_Products_Services);
    					context.AddObject("My_Products_Services", my_Products_Services);
    				}
    
    				context.SaveChanges(); // Save Changes				
    				DetachObjects(apiContext, my_Products_ServicesList); // Clean ObjectState cache
    				
    				foreach (Entities.My_Products_Services my_Products_Services in my_Products_ServicesList)
    					OnAdded(apiContext, my_Products_Services);
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
    		/// <param name="my_Products_ServicesList"></param>
    		/// <returns></returns>
    		public static Helpers.ActionResult Update(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.My_Products_Services> my_Products_ServicesList)
    		{
    			return Update(apiContext, my_Products_ServicesList, false);
    		}
    		
    		/// <summary>
    		///		No Metadata Documentation available.
    		/// </summary>
    		/// <param name="apiContext"></param>
    		/// <param name="my_Products_ServicesList"></param>
    		/// <param name="clientWins">if true system properties will not be overwritten by Api</param>
    		/// <returns></returns>
    		public static Helpers.ActionResult Update(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.My_Products_Services> my_Products_ServicesList, System.Boolean clientWins)
    		{
    			// API doesn't allow null parameters. This method requires at least 1 item in the collection.
                if (apiContext == null)
                    throw new System.ArgumentNullException("apiContext");
                if (my_Products_ServicesList == null)
                    throw new System.ArgumentNullException("my_Products_ServicesList");
                if (my_Products_ServicesList.Count() == 0)
                    throw new System.ArgumentOutOfRangeException("my_Products_ServicesList");
    
    				 // Verify user is authorized to perform action, otherwise throw exception.
                    Security.SecurityHandler.SetApiContext(apiContext);
    			Helpers.ActionResult result = Helpers.ActionResult.Factory(true);
    
                try
                {
                    Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
                    foreach (Entities.My_Products_Services my_Products_Services in my_Products_ServicesList)
                    {
    					OnUpdating(apiContext, my_Products_Services, false);
    					
    					// ATTACH object					
    					AttachObject(apiContext, "My_Products_Services", my_Products_Services);
    
    					if (!clientWins)
    					{
    						// SET system level properties
                	    	SetSystemProperties(apiContext, my_Products_Services);
    					}
    					
    					// SET modified										
                        SetModified(apiContext, my_Products_Services);
                    }
    
    				if (clientWins) {
    					context.Refresh(System.Data.Objects.RefreshMode.ClientWins, my_Products_ServicesList);
    				}
    				
    				context.SaveChanges(); // Save Changes
    				DetachObjects(apiContext, my_Products_ServicesList); // Clean ObjectState cache
    
                    foreach (Entities.My_Products_Services my_Products_Services in my_Products_ServicesList)
                        OnUpdated(apiContext, my_Products_Services, false);
                }
    			catch (System.Data.OptimisticConcurrencyException ex)
                {
    				object forDebugging = ex;
    				HandleOptimisticConcurrencyException(apiContext, my_Products_ServicesList, ex, ref result);
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
    		/// <param name="my_Products_ServicesList"></param>
    		/// <returns></returns>
            public static Helpers.ActionResult Delete(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.My_Products_Services> my_Products_ServicesList)
            {
    			// API doesn't allow null parameters. This method requires at least 1 item in the collection.
                if (apiContext == null)
                    throw new System.ArgumentNullException("apiContext");
                if (my_Products_ServicesList == null)
                    throw new System.ArgumentNullException("my_Products_ServicesList");
                if (my_Products_ServicesList.Count() == 0)
                    throw new System.ArgumentOutOfRangeException("my_Products_ServicesList");
    
    				 // Verify user is authorized to perform action, otherwise throw exception.
                    Security.SecurityHandler.SetApiContext(apiContext);
    			Helpers.ActionResult result = Helpers.ActionResult.Factory(true);
                try
                {				
                    Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
                    foreach (Entities.My_Products_Services my_Products_Services in my_Products_ServicesList)
                    {
    					OnDeleting(apiContext, my_Products_Services);
    					
    					// ATTACH object					
    					AttachObject(apiContext, "My_Products_Services", my_Products_Services);
    					
    					// SET system level properties
                	    SetSystemProperties(apiContext, my_Products_Services);
    					SetSystemPropertiesModified(apiContext, my_Products_Services);
    					
    					// SET SoftDeleted
    					SetDeleted(apiContext, my_Products_Services);
                    }
    
    				context.SaveChanges(); // Save Changes
    				DetachObjects(apiContext, my_Products_ServicesList); // Clean ObjectState cache
    				
                    foreach (Entities.My_Products_Services my_Products_Services in my_Products_ServicesList)
                        OnDeleted(apiContext, my_Products_Services);
                }
    			catch (System.Data.OptimisticConcurrencyException ex)
                {
    				object forDebugging = ex;
                    HandleOptimisticConcurrencyException(apiContext, my_Products_ServicesList, ex, ref result);
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
    		/// <param name="my_Products_ServicesList"></param>
    		/// <returns></returns>
            public static Helpers.ActionResult Purge(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.My_Products_Services> my_Products_ServicesList)
            {
    			// API doesn't allow null parameters. This method requires at least 1 item in the collection.
                if (apiContext == null)
                    throw new System.ArgumentNullException("apiContext");
                if (my_Products_ServicesList == null)
                    throw new System.ArgumentNullException("my_Products_ServicesList");
                if (my_Products_ServicesList.Count() == 0)
                    throw new System.ArgumentOutOfRangeException("my_Products_ServicesList");
    
    				 // Verify user is authorized to perform action, otherwise throw exception.
                    Security.SecurityHandler.SetApiContext(apiContext);
    			Helpers.ActionResult result = Helpers.ActionResult.Factory(true);
                try
                {				
                    Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
                    foreach (Entities.My_Products_Services my_Products_Services in my_Products_ServicesList)
                    {
    					OnPurging(apiContext, my_Products_Services);
    					
    					// ATTACH object					
    					AttachObject(apiContext, "My_Products_Services", my_Products_Services);
    					
    					// DELETE object
    					context.DeleteObject(my_Products_Services);
                    }
    
    				context.SaveChanges(); // Save Changes
    								
                    foreach (Entities.My_Products_Services my_Products_Services in my_Products_ServicesList)
                        OnPurged(apiContext, my_Products_Services);
                }
    			catch (System.Data.OptimisticConcurrencyException ex)
                {
    				object forDebugging = ex;
                    HandleOptimisticConcurrencyException(apiContext, my_Products_ServicesList, ex, ref result);
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
    		/// <param name="my_Products_Services"></param>
    		/// <returns></returns>
            public static Helpers.ActionResult Get(Helpers.ApiContext apiContext, int id, out Entities.My_Products_Services my_Products_Services)
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
                    var qry = context.My_Products_Services.Where(r => r.Id.Equals(id)).FirstOrDefault();
    
    				// See what would be default value in this case
                    // Also to see if no value found what shall be put into Action Result                
    				if (qry != null)
    				{
    					my_Products_Services = qry;
    					
                    	// must detach the object before return
                    	DetachObject(apiContext, my_Products_Services);
    				}
    				else
    				{
                		my_Products_Services = new Entities.My_Products_Services();
    					my_Products_Services.Id = id;
    
    					result.WasSuccessful = false;
    					result.Messages.Add(Helpers.ActionResultMessage.Factory(my_Products_Services, "Object not Found", Helpers.ActionResultMessageType.Warning));
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
    		/// <param name="my_Products_ServicesList"></param>
    		/// <returns></returns>
    		public static Helpers.ActionResult Get(Helpers.ApiContext apiContext, Helpers.QuerySettings<Entities.My_Products_Services> querySettings, out System.Collections.Generic.List<Entities.My_Products_Services> my_Products_ServicesList)
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
                    System.Data.Objects.ObjectQuery<Entities.My_Products_Services> query = context.My_Products_Services;
                    query.MergeOption = System.Data.Objects.MergeOption.NoTracking;
    				
    				// include entities
    				foreach (System.String include in querySettings.IncludedEntities) { query = query.Include(include); }
    
                    // execute the query with query settings applied
    				my_Products_ServicesList = query
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
    		public static Helpers.ActionResult Count(Helpers.ApiContext apiContext, Helpers.QuerySettings<Entities.My_Products_Services> querySettings, out int count)
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
    				count = context.My_Products_Services.Where(querySettings.GetWhereExpression()).Count();
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
    		/// <param name="my_Products_ServicesList"></param>
            /// <returns></returns>
            public static Helpers.ActionResult BulkUpdate(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.My_Products_Services> my_Products_ServicesList)
            {
                // API doesn't allow null parameters. This method requires at least 1 item in the collection.
                if (apiContext == null)
                    throw new System.ArgumentNullException("apiContext");
                if (my_Products_ServicesList == null)
                    throw new System.ArgumentNullException("my_Products_ServicesList");
                if (my_Products_ServicesList.Count() == 0)
                    throw new System.ArgumentOutOfRangeException("my_Products_ServicesList");
    
    				 // Verify user is authorized to perform action, otherwise throw exception.
                    Security.SecurityHandler.SetApiContext(apiContext);
    			Helpers.ActionResult result = Helpers.ActionResult.Factory(true);
                try
                {
                    Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
    				
    				OnBulkUpdating(apiContext, my_Products_ServicesList);
    
    				foreach (Entities.My_Products_Services my_Products_Services in my_Products_ServicesList)
                    {
    					OnUpdating(apiContext, my_Products_Services, true);					
    
    					// ATTACH object					
    					AttachObject(apiContext, "My_Products_Services", my_Products_Services);
    					
    					// SET system level properties
                	    SetSystemProperties(apiContext, my_Products_Services);
    					SetSystemPropertiesModified(apiContext, my_Products_Services);
    					
    					// PARTIAL update					
                        OnPartialUpdate(apiContext, my_Products_Services);
                    }
    
    				context.SaveChanges(); // Save Changes
    				DetachObjects(apiContext, my_Products_ServicesList); // Clean ObjectState cache
    
                    foreach (Entities.My_Products_Services my_Products_Services in my_Products_ServicesList)
                        OnUpdated(apiContext, my_Products_Services, true);
    					
    				OnBulkUpdated(apiContext, my_Products_ServicesList);
                }
    			catch (System.Data.OptimisticConcurrencyException ex)
                {
    				object forDebugging = ex;
                    HandleOptimisticConcurrencyException(apiContext, my_Products_ServicesList, ex, ref result);
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
            /// <param name="my_Products_ServicesList"></param>
            /// <returns></returns>
            public static Helpers.ActionResult Import(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.My_Products_Services> my_Products_ServicesList)
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
            public static bool IsExists(Helpers.ApiContext apiContext, System.Linq.Expressions.Expression<System.Func<Entities.My_Products_Services, bool>> whereClause)
            {
                // API doesn't allow null parameters. This method requires at least 1 item in the collection.
                if (apiContext == null)
                    throw new System.ArgumentNullException("apiContext");
                if (whereClause == null)
                    throw new System.ArgumentNullException("whereClause");
    			
                try
                {
                    Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
                    return context.My_Products_Services.Any(whereClause);
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
            public static bool IsExists(Helpers.ApiContext apiContext, System.Linq.Expressions.Expression<System.Func<Entities.My_Products_Services, bool>> whereClause, long id)
            {
                // API doesn't allow null parameters. This method requires at least 1 item in the collection.
                if (apiContext == null)
                    throw new System.ArgumentNullException("apiContext");
                if (whereClause == null)
                    throw new System.ArgumentNullException("whereClause");
    			
                try
                {
                    Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
                    id = context.My_Products_Services.Where(whereClause).Select(e => e.Id).FirstOrDefault();                 
    
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
           /* public static bool IsExists(Helpers.ApiContext apiContext, System.Linq.Expressions.Expression<System.Func<Entities.My_Products_Services, bool>> whereClause, out System.Collections.Generic.List<int> iDs)
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
                    iDs = context.My_Products_Services.Where(whereClause).Select(e => e.Id).ToList();
    
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
            public static bool IsExists(Helpers.ApiContext apiContext, System.Linq.Expressions.Expression<System.Func<Entities.My_Products_Services, bool>> whereClause, System.Linq.Expressions.Expression<System.Func<Entities.My_Products_Services, long>> selectClause, out System.Collections.Generic.List<long> iDs)
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
                    iDs = context.My_Products_Services.Where(whereClause).Select(selectClause).ToList();
    
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
            public static bool IsExists(Helpers.ApiContext apiContext, System.Linq.Expressions.Expression<System.Func<Entities.My_Products_Services, bool>> whereClause, out System.Collections.Generic.List<Helpers.EntityKey> entityKeys)
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
                    entityKeys = context.My_Products_Services
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
            public static bool IsExists(Helpers.ApiContext apiContext, System.Linq.Expressions.Expression<System.Func<Entities.My_Products_Services, bool>> whereClause, out Helpers.EntityKey entityKey)
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
                    var query = context.My_Products_Services.Where(whereClause).Select(e => new { e.Id, e.ModifiedOn }).FirstOrDefault();
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
            public static bool IsExists(Helpers.ApiContext apiContext, System.Linq.Expressions.Expression<System.Func<Entities.My_Products_Services, bool>> whereClause, out Entities.My_Products_Services entity)
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
                    var query = context.My_Products_Services.Where(whereClause).FirstOrDefault();
    
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
            public static bool IsExists(Helpers.ApiContext apiContext, System.Linq.Expressions.Expression<System.Func<Entities.My_Products_Services, bool>> whereClause, out System.Collections.Generic.List<Entities.My_Products_Services> entities)
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
                    var query = context.My_Products_Services;
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
            /// <param name="my_Products_Services"></param>
            /// <param name="result"></param>
    		public static void ValidateData(Helpers.ApiContext apiContext, Entities.My_Products_Services my_Products_Services, ref Helpers.ActionResult result)
            {
    			OnValidating(apiContext, my_Products_Services, ref result);
    			
                if (my_Products_Services.Id == null)
                {
                    result.Messages.Add(Helpers.ActionResultMessage.Factory(my_Products_Services, "Id is required.", Helpers.ActionResultMessageType.Error));
                    result.WasSuccessful = false;
                }
    			
    																								
    			OnValidated(apiContext, my_Products_Services, ref result);
            }
    		
    		/// <summary>
            /// HandleOptimisticConcurrencyException
    		/// </summary>
    		/// <param name="apiContext"></param>
    		/// <param name="my_Products_ServicesList"></param>
    		/// <param name="exception"></param>
    		/// <param name="result"></param>
            public static void HandleOptimisticConcurrencyException(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.My_Products_Services> my_Products_ServicesList, System.Exception exception, ref Helpers.ActionResult result)
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
    		/// <param name="my_Products_ServicesList"></param>
    		/// <param name="columnExpression"></param>
    		/// <returns></returns>
            public static Helpers.ActionResult PartialUpdate(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.My_Products_Services> my_Products_ServicesList,params System.Linq.Expressions.Expression<System.Func<Entities.My_Products_Services, object>>[] columnExpression)
            {
                // API doesn't allow null parameters. This method requires at least 1 item in the collection.
                if (apiContext == null)
                    throw new System.ArgumentNullException("apiContext");
                if (my_Products_ServicesList == null)
                    throw new System.ArgumentNullException("my_Products_ServicesList");
                if (my_Products_ServicesList.Count() == 0)
                    throw new System.ArgumentOutOfRangeException("my_Products_ServicesList");
    			if (columnExpression == null)
    				throw new System.ArgumentNullException("columnExpression");
    			if (columnExpression.Count() == 0)
    				throw new System.ArgumentOutOfRangeException("columnExpression");
    
    			ValidateColumnExpression<Entities.My_Products_Services>(columnExpression);
    
    			Helpers.ActionResult result = Helpers.ActionResult.Factory(true);
                try
                {
                    Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
    
    				foreach (Entities.My_Products_Services my_Products_Services in my_Products_ServicesList)
                    {                    
    					// ATTACH object					
    					AttachObject(apiContext, "My_Products_Services", my_Products_Services);
    						
    					// SET system level properties
                	    SetSystemProperties(apiContext, my_Products_Services);
    					SetSystemPropertiesModified(apiContext, my_Products_Services);
    					
    					// SET IsActive property modified
    					System.Data.Objects.ObjectStateEntry ose = apiContext.CurrentContext.ObjectStateManager.GetObjectStateEntry(my_Products_Services);
    					
    					foreach (var item in columnExpression)
    					{
    						ose.SetModifiedProperty(item.GetPropertyName());    
    					}
                    }
    
    				context.SaveChanges(); // Save Changes
    				DetachObjects(apiContext, my_Products_ServicesList); // Clean ObjectState cache
                }
    			catch (System.Data.OptimisticConcurrencyException ex)
                {
    				object forDebugging = ex;
    				HandleOptimisticConcurrencyException(apiContext, my_Products_ServicesList, ex, ref result);                
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
