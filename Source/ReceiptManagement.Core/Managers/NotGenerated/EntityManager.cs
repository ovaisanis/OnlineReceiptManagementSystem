using System;
using System.Linq;

using Collections = System.Collections.Generic;
using Edm         = System.Data.Metadata.Edm;
using Entities = ReceiptManagement.Common.Entities;
using Helpers = ReceiptManagement.Common.Helpers;
using System.Collections.Generic;
using System.Linq.Dynamic;

namespace ReceiptManagement.Core.Managers
{
	/// <summary>
	///		The common supertype for all generated object managers.
    /// </summary><remarks>Add shared methods and properties here as needed.</remarks>
	public class EntityManager
    {
        #region Properties

        /// <summary>
        /// Regular Expression for valid character set allowed for text fields
        /// </summary>
        protected const string alphaNumeric = "^\\s*[a-zA-Z0-9-.()\\\\#_//`'\"@/,/&,\\s]+\\s*$";

        /// <summary>
        /// Regular Expression for valid character (including '[' and ']') set allowed for text fields
        /// </summary>
        protected const string alphanumericSquareBrackets = "^\\s*[a-zA-Z0-9\\[\\]\\-.()\\\\#_//`'\"@/,/&,\\s]+\\s*$";

        #endregion

        #region GetMethodInfo Method

        /// <summary>
        /// Get MethodInfo to Invoke through Reflection
        /// </summary>
        /// <param name="entityType"></param>
        /// <param name="methodName"></param>
        /// <param name="columnType"></param>
        /// <returns></returns>
        protected static System.Reflection.MethodInfo GetMethodInfo(System.Type entityType, System.String methodName, System.Type columnType)
        {
            System.Reflection.MethodInfo[] methods = entityType.GetMethods();
            System.Reflection.MethodInfo method = methods.Where(m => m.Name == methodName && m.IsGenericMethod).FirstOrDefault();

            return method.MakeGenericMethod(new System.Type[] { columnType });
        } 

        #endregion

        #region ApplyOriginalValues Method

        /// <summary>
        /// ApplyOriginalValues for Concurrency check in Update and Delete
        /// </summary>
        /// <param name="apiContext"></param>
        /// <param name="entity"></param>
        protected static void ApplyOriginalValues(Helpers.ApiContext apiContext, Entities.EntityObject entity)
        {
            Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
            System.Data.Objects.ObjectStateEntry ose = context.ObjectStateManager.GetObjectStateEntry(entity);
            ose.ApplyOriginalValues(entity);
        }

        #endregion

        #region SoftDelete Method

        /// <summary>
        /// SoftDelete entity from entity set
        /// </summary>
        /// <param name="apiContext"></param>
        /// <param name="entitySet"></param>        
        /// <param name="entity"></param>        
        [System.Obsolete]
        protected static void SoftDelete(Helpers.ApiContext apiContext, System.String entitySet, Entities.EntityObject entity)
        {
            SoftDelete(apiContext, entitySet, new System.Collections.Generic.List<Entities.EntityObject> { entity });
        }

        /// <summary>
        /// SoftDelete entity from entity set
        /// </summary>
        /// <param name="apiContext"></param>
        /// <param name="entitySet"></param>        
        /// <param name="entities"></param>        
        [System.Obsolete]
        protected static void SoftDelete(Helpers.ApiContext apiContext, System.String entitySet, System.Collections.Generic.IEnumerable<Entities.EntityObject> entities)
        {
            Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;

            foreach (var entity in entities)
            {
                System.Data.Objects.ObjectStateEntry ose = context.ObjectStateManager.GetObjectStateEntry(entity);
                System.Guid id                 = (System.Guid)ose.CurrentValues["Id"];
                System.Guid modifiedBy         = (System.Guid)ose.CurrentValues["ModifiedBy"];
                System.DateTime modifiedOn     = (System.DateTime)ose.CurrentValues["ModifiedOn"];
                System.DateTime origModifiedOn = (System.DateTime)ose.OriginalValues["ModifiedOn"];

                string sqlQuery = string.Format(@"UPDATE [{0}] 
                                                  SET    
                                                         [IsDeleted]  = 1, 
                                                         [ModifiedBy] = '{1}',
                                                         [ModifiedOn] = '{2}'
                                                  WHERE  
                                                         [Id]         = @p0
                                                     AND [ModifiedOn] = @p1", entitySet, modifiedBy, modifiedOn);

                int recordCount = apiContext.CurrentContext.ExecuteStoreCommand(sqlQuery, id, origModifiedOn);
                if (recordCount == 0)
                    throw new System.Data.OptimisticConcurrencyException();
            }
        }

        #endregion        

        #region SoftDeleteObjectMappings Method

        /// <summary>
        /// SoftDeleteObjectMappings entity from entity set
        /// </summary>
        /// <param name="apiContext"></param>        
        /// <param name="entity"></param>  
        /// <returns></returns>
        [System.Obsolete]
        protected static int SoftDeleteObjectMappings(Helpers.ApiContext apiContext, Entities.EntityObject entity)
        {
            Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;

            System.Guid id = (System.Guid)entity.GetType().GetProperty("Id").GetValue(entity, null);
            System.Guid modifiedBy = (System.Guid)entity.GetType().GetProperty("ModifiedBy").GetValue(entity, null);
            System.DateTime modifiedOn = (System.DateTime)entity.GetType().GetProperty("ModifiedOn").GetValue(entity, null);

            string sqlQuery = string.Format(@"UPDATE    [ObjectMappings] 
                                                SET    
                                                        [IsDeleted]  = 1, 
                                                        [ModifiedBy] = '{0}',
                                                        [ModifiedOn] = '{1}'
                                                WHERE  
                                                        [ParentId]   = @p0", modifiedBy, modifiedOn);

            int recordCount = apiContext.CurrentContext.ExecuteStoreCommand(sqlQuery, id);
            return recordCount;
        } 

        #endregion        

        #region AttachObject Method

        /// <summary>
        /// Attach Object
        /// </summary>
        /// <param name="apiContext"></param>
        /// <param name="entitySet"></param>
        /// <param name="entity"></param>        
        protected static void AttachObject(Helpers.ApiContext apiContext, System.String entitySet, Entities.EntityObject entity)
        {
            Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;

            // ATTACH to context
            context.AttachTo(entitySet, entity);

            // APPLY original values
            ApplyOriginalValues(apiContext, entity);
        }

        #endregion

        #region DetachObjects Method

        /// <summary>
        /// Purge object state cache and detach all objects added/updated/deleted from the system in current context.SaveChanges() call
        /// </summary>
        /// <param name="apiContext"></param>
        /// <param name="entity"></param>
        protected static void DetachObject(Helpers.ApiContext apiContext, Entities.EntityObject entity)
        {
            Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
            try
            {
                context.Detach(entity);
            }
            catch (System.InvalidOperationException) { } // NOTE : we do intentionally suppressing this exception
        }

        /// <summary>
        /// Purge object state cache and detach all objects added/updated/deleted from the system in current context.SaveChanges() call
        /// </summary>
        /// <param name="apiContext"></param>
        /// <param name="entities"></param>
        protected static void DetachObjects(Helpers.ApiContext apiContext, System.Collections.Generic.IEnumerable<Entities.EntityObject> entities)
        {
            Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
            foreach (var entity in entities)
            {
                context.Detach(entity);
            }
        }

        #endregion

        #region SetSystemProperties Method

        /// <summary>
        /// Set System Properties (CreadBy, CreatedOn, ModifiedBy, ModifiedOn, and CustomerId)
        /// </summary>
        /// <param name="apiContext"></param>
        /// <param name="entity"></param>
        protected static void SetSystemProperties(Helpers.ApiContext apiContext, Entities.EntityObject entity)
        { 
            SetSystemProperties(apiContext, entity, true);
        }

        /// <summary>
        /// Set System Properties (CreadBy, CreatedOn, ModifiedBy, ModifiedOn, and CustomerId)
        /// </summary>
        /// <param name="apiContext"></param>
        /// <param name="entity"></param>
        /// <param name="ignoreCreated"></param>
        protected static void SetSystemProperties(Helpers.ApiContext apiContext, Entities.EntityObject entity, bool ignoreCreated)
        {
            // SET system level properties
           /* if (!ignoreCreated) {
                entity.GetType().GetProperty("CreatedBy").SetValue(entity,  apiContext.User.Id,     null);
                entity.GetType().GetProperty("CreatedOn").SetValue(entity,  System.DateTime.UtcNow, null);
            }

            
            entity.GetType().GetProperty("ModifiedBy").SetValue(entity, apiContext.User.Id,     null);
            entity.GetType().GetProperty("ModifiedOn").SetValue(entity, System.DateTime.UtcNow, null);
            entity.GetType().GetProperty("CustomerId").SetValue(entity, apiContext.Customer.Id, null);           
            * */
        }

        #endregion

        #region SetSystemPropertiesModified Method

        /// <summary>
        /// Set CustomerId, ModifiedBy and ModifiedOn properties modified for update/delete
        /// </summary>
        /// <param name="apiContext"></param>
        /// <param name="entity"></param>
        protected static void SetSystemPropertiesModified(Helpers.ApiContext apiContext, Entities.EntityObject entity)
        {
            Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
            System.Data.Objects.ObjectStateEntry ose = context.ObjectStateManager.GetObjectStateEntry(entity);
            ose.SetModifiedProperty("ModifiedBy");
            ose.SetModifiedProperty("ModifiedOn");
            ose.SetModifiedProperty("CustomerId");
        }

        #endregion

        #region SetModified Method

        /// <summary>
        /// SetModified for Update
        /// </summary>
        /// <param name="apiContext"></param>
        /// <param name="entity"></param>
        protected static void SetModified(Helpers.ApiContext apiContext, Entities.EntityObject entity)
        {
            Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;
            System.Data.Objects.ObjectStateEntry ose = context.ObjectStateManager.GetObjectStateEntry(entity);

            System.Data.Metadata.Edm.ItemCollection colleciton = null;
            if (context.MetadataWorkspace.TryGetItemCollection(System.Data.Metadata.Edm.DataSpace.CSpace, out colleciton))
            {
                System.String typeFullName = entity.GetType().ToString();
                Edm.EntityType entiyType =
                    colleciton.GetItems<Edm.EntityType>()
                              .Where(e => e.FullName.Equals(typeFullName, System.StringComparison.InvariantCultureIgnoreCase))
                              .First();

                // SET all properties modified except those who are in ignore list
                foreach (Edm.EdmProperty property in entiyType.Properties)
                {
                    if (!IsInIgnoreList(property.Name))
                    {
                        ose.SetModifiedProperty(property.Name);
                    }
                }
            }
        }

        // Ignored columns list for Full Update
        private static bool IsInIgnoreList(string propertyName)
        {
            switch (propertyName)
            {
                case "CreatedOn": return true;
                case "CreatedBy": return true;
                case "IsDeleted": return true;
                default:
                    return false;
            }
        }

        #endregion

        #region SetDeleted Method

        /// <summary>
        /// SetDeleted for SoftDelete
        /// </summary>
        /// <param name="apiContext"></param>
        /// <param name="entity"></param>
        protected static void SetDeleted(Helpers.ApiContext apiContext, Entities.EntityObject entity)
        {
            Model.OrmsContext context = (Model.OrmsContext)apiContext.CurrentContext;

            // SET IsDeleted = true
            entity.GetType().GetProperty("IsDeleted").SetValue(entity, true, null);

            // SET IsDeleted modified
            System.Data.Objects.ObjectStateEntry ose = context.ObjectStateManager.GetObjectStateEntry(entity);
            ose.SetModifiedProperty("IsDeleted");            
        }

        #endregion

        #region Translate Method
                
        private static void Translate<TEntity>(System.Data.Common.DbDataReader reader, out Collections.List<TEntity> entities) where TEntity : class
        {
            // Initilize list
            entities = new Collections.List<TEntity>();

            System.Type type = typeof(TEntity);
            System.Reflection.MethodInfo methodInfo = type.GetMethod("Factory", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);

            while (reader.Read())
            {
                // Create Object
                TEntity entity = (TEntity)methodInfo.Invoke(null, new object[0]);

                foreach (System.Reflection.PropertyInfo property in type.GetProperties())
                {
                    if (IsComplexType(property))        // Complex Type
                    {
                        Entities.EntityObject complexEntity = null;
                        if (TryGetValue(property, reader, out complexEntity))
                        {
                            property.SetValue(entity, complexEntity, null);
                        }
                    }
                    else if (IsPrimitiveType(property)) // Primitive Type
                    {
                        object value = null;
                        if (TryGetValue(property.Name, reader, out value))
                        {
                            property.SetValue(entity, value, null);
                        }
                    }
                }

                entities.Add(entity);
            }
        }

        private static bool IsPrimitiveType(System.Reflection.PropertyInfo property)
        {
            System.Type propertyType = property.PropertyType;
            if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition().Equals(typeof(System.Nullable<>)))
            {
                propertyType = System.Nullable.GetUnderlyingType(propertyType);
            }

            switch (propertyType.FullName)
            {
                case "System.String":
                case "System.DateTime":
                case "System.Guid":
                case "System.Int32":
                case "System.Int64":
                case "System.Double":
                case "System.Decimal":
                case "System.Boolean":
                    return true;
                default:
                    return false;
            }
        }

        private static bool IsComplexType(System.Reflection.PropertyInfo property)
        {
            System.String propertyName = property.PropertyType.Name;
            switch (propertyName)
            {
                case "Address":
                case "CropQuantity":
                case "GpsCoordinate":
                case "ItemQuantity":
                case "Length":
                case "TierHigh":
                case "Weight":
                    return true;
                default:
                    return false;
            }
        }

        private static bool TryGetValue(System.String propertyName, System.Data.Common.DbDataReader reader, out object value)
        {
            try
            {
                if (reader[propertyName] != System.DBNull.Value)
                {
                    value = reader[propertyName];
                    return true;
                }
                else
                {
                    value = null;
                    return false;
                }
            }
            catch
            {
                value = null;
                return false;
            }
        }

        private static bool TryGetValue(System.Reflection.PropertyInfo propertyInfo, System.Data.Common.DbDataReader reader, out Entities.EntityObject complexEntity)
        {
            complexEntity = null;
            System.String prefix = propertyInfo.Name + "_";

            System.Type type = propertyInfo.PropertyType;
            System.Reflection.MethodInfo methodInfo = propertyInfo.PropertyType.GetMethod("Factory", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);

            foreach (System.Reflection.PropertyInfo property in type.GetProperties())
            {
                if (IsPrimitiveType(property))
                {
                    object value = null;
                    if (TryGetValue(prefix + property.Name, reader, out value))
                    {
                        if (complexEntity == null)
                        {
                            complexEntity = (Entities.EntityObject)methodInfo.Invoke(null, new object[0]);
                        }

                        property.SetValue(complexEntity, value, null);
                    }
                }
            }

            return (complexEntity != null);
        }

        #endregion

        #region ExecuteStoreQuery Method

        /// <summary>
        /// ExecuteStoreQuery
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="apiContext"></param>
        /// <param name="sqlQuery"></param>
        /// <param name="entities"></param>
        [System.Obsolete]
        protected static void ExecuteStoreQuery<TEntity>(Helpers.ApiContext apiContext, System.String sqlQuery, out Collections.List<TEntity> entities) where TEntity : class
        {
            ExecuteStoreQuery<TEntity>(apiContext, sqlQuery, new object[0], out entities);
        }

        /// <summary>
        /// ExecuteStoreQuery
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="apiContext"></param>
        /// <param name="sqlQuery"></param>
        /// <param name="parameters">parameters must be named @p0, @p1, ...</param>
        /// <param name="entities"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security",
                 "CA2100",
                 Justification = "Already mark obsolete")]
        [System.Obsolete]
        protected static void ExecuteStoreQuery<TEntity>(Helpers.ApiContext apiContext, System.String sqlQuery, object[] parameters, out Collections.List<TEntity> entities) where TEntity : class
        {
            System.Data.IDbConnection connection = 
                (apiContext.CurrentContext.Connection as System.Data.EntityClient.EntityConnection).StoreConnection;

            connection.Open();
            using (System.Data.IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = sqlQuery;

                int index = 0;
                foreach (object value in parameters)
                {
                    command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@p" + index++, value));
                }

                using (System.Data.Common.DbDataReader reader = (System.Data.Common.DbDataReader)command.ExecuteReader())
                {
                    Translate<TEntity>(reader, out entities);
                }
            }
        }

        #endregion

        #region GetEntityPropertyUsageAttributes Method

        /// <summary>
        /// Get PropertyUsageAttributes for all properties in entity
        /// </summary>
        /// <param name="apiContext"></param>
        /// <param name="entityType"></param>
        /// <param name="propertiesUsageAttributes"></param>
        /// <returns></returns>
        public static Helpers.ActionResult GetPropertiesUsageAttributes(Helpers.ApiContext apiContext, Type entityType, out Collections.IEnumerable<Helpers.PropertyUsageAttributes> propertiesUsageAttributes)
        {
            // API doesn't allow null parameters. This method requires at least 1 item in the collection.
            if (apiContext == null)
                throw new System.ArgumentNullException("apiContext");
            if (entityType == null)
                throw new System.ArgumentNullException("entityType");

            Helpers.ActionResult result = Helpers.ActionResult.Factory(true);

            try
            {
                using (Model.OrmsContext contexte = (Model.OrmsContext)apiContext.CurrentContext)
                {
                    System.Data.Metadata.Edm.EntityType edmEntityType
                        = (from item in contexte.MetadataWorkspace.GetItems(System.Data.Metadata.Edm.DataSpace.CSpace)
                           where item.BuiltInTypeKind == System.Data.Metadata.Edm.BuiltInTypeKind.EntityType
                           && (item as System.Data.Metadata.Edm.EntityType).Name == entityType.Name
                           select item as System.Data.Metadata.Edm.EntityType).First();

                    propertiesUsageAttributes = from p in edmEntityType.Properties
                                                //where p.Name.ToLower() == fieldName
                                                select SetPropertyUsageAttributes(p);
                                                //select new Helpers.PropertyUsageAttributes
                                                //{
                                                //    Name = p.Name,
                                                //    MaxLength = p.TypeUsage.EdmType.Name.ToLower() == "string" ? System.Convert.ToInt32(p.TypeUsage.Facets["MaxLength"].Value) : (-1),
                                                //    Required = !System.Convert.ToBoolean(p.TypeUsage.Facets["Nullable"].Value),
                                                //    Type = p.TypeUsage.EdmType.Name
                                                //};
                    if (propertiesUsageAttributes == null)
                        propertiesUsageAttributes = new Collections.List<Helpers.PropertyUsageAttributes>();

                }
            }
            catch (System.Exception ex)
            {
                object forDebugging = ex;
                throw;
            }

            return result;
        }


        private static Helpers.PropertyUsageAttributes SetPropertyUsageAttributes(Edm.EdmProperty p)
        {
            Helpers.PropertyUsageAttributes propertyUsageAttributes = new Helpers.PropertyUsageAttributes();
            propertyUsageAttributes.Name = p.Name;

            if (p.TypeUsage.EdmType.BuiltInTypeKind == Edm.BuiltInTypeKind.ComplexType)
            {
                propertyUsageAttributes.IsComplexType = true;
                foreach (Edm.EdmProperty property in ((Edm.ComplexType)p.TypeUsage.EdmType).Properties)
                {
                    Helpers.PropertyUsageAttributes subPropertyUsageAttributes = SetPropertyUsageAttributes(property);
                    propertyUsageAttributes.SubPropertyUsageAttributes.Add(subPropertyUsageAttributes);
                }
            }
            else
            {
                propertyUsageAttributes.IsComplexType = false;
                propertyUsageAttributes.MaxLength = p.TypeUsage.EdmType.Name.ToLower() == "string" ? System.Convert.ToInt32(p.TypeUsage.Facets["MaxLength"].Value) : (-1);
                propertyUsageAttributes.Required = !System.Convert.ToBoolean(p.TypeUsage.Facets["Nullable"].Value);
                propertyUsageAttributes.Type = p.TypeUsage.EdmType.Name;
            }
            return propertyUsageAttributes;
        }

        #endregion

        #region Validate Columns

        /// <summary>
        /// Validates expression and the properties present in it.
        /// </summary>
        /// <typeparam name="T">Entity</typeparam>
        /// <param name="columnExpression">array of columns</param>
        public static void ValidateColumnExpression<T>(System.Linq.Expressions.Expression<System.Func<T, object>>[] columnExpression)
        {
            foreach (var item in columnExpression)
            {
                var propertyName = item.GetPropertyName();

                var property = typeof(T).GetProperty(propertyName);

                if (property == null)
                {
                    throw new MissingMemberException(typeof(T).Name, propertyName);
                }

                if (!IsPrimitiveType(property))
                {
                    throw new InvalidCastException("Only primitive properties are supported.");
                }
            }
        }


        #endregion
    }
}
