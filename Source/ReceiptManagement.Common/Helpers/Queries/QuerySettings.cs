using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ReceiptManagement.Common.Helpers
{
	/// <summary>
	///		Specify settings about the query to be performed.
	/// </summary>
	public sealed class _QuerySettings<TEntity>
    {
        #region Properties

        #region Ignore SoftDeleted Records

        /// <summary>
        /// Flag to ignore soft deleted records into results        
        /// If set to true add another clause IsDeleted == true into where predicate
        /// </summary>        
        public bool IgnoreSoftDeleteRecords
        {
            get { return _ignoreSoftDeleteRecords; }
            set { _ignoreSoftDeleteRecords = value; }
        }
        private bool _ignoreSoftDeleteRecords = true;

        #endregion

        #region Where Expression

        #region Where Predicate

        /// <summary>
        /// Select/Where Expression
        /// ability to filter the results based on criteria; still have to put more thoughts how this will work
        /// </summary>
        public System.Linq.Expressions.Expression<Func<TEntity, bool>> WhereExpression
        {
            get { return _whereExpression; }
            set { _whereExpression = value; }
        }
        private System.Linq.Expressions.Expression<Func<TEntity, bool>> _whereExpression = (x => true); 

        #endregion

        #region Column Filter

        /// <summary>
        /// Filter Column Name
        /// </summary>
        public System.String FilterColumn
        {
            get { return _filterColumn; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new Exceptions.InvalidExpressionException("Must provide a valid Filter Column. It cannot be Null or Empty.");

                _filterColumn = value;                
                _filterColumnType = GetColumnType(typeof(TEntity), _filterColumn);
            }
        }
        private System.String _filterColumn = string.Empty;

        /// <summary>
        /// Filter Value
        /// </summary>
        public System.Object FilterValue
        {
            get { return _filterValue; }
            set { _filterValue = value; }
        }

        private System.Object _filterValue = null;

        // Filter column type
        private System.Type FilterColumnType
        {
            get { return _filterColumnType; }
        }
        private System.Type _filterColumnType = null; 


        public List<KeyValuePair<string, string>> Filters
        {
            set { filters = value; }
            get { return filters;  }
        
        }

        private List<KeyValuePair<string, string>> filters = null;

        #endregion

        #region GetWhereExpression Method

        /// <summary>
        /// returns where expression; Filter Column:Value will be given preference over WhereExpression
        /// </summary>
        /// <returns></returns>
        internal Expression<Func<TEntity, bool>> GetWhereExpression()
        {
            Expression<Func<TEntity, bool>> expression = null;

            if ((String.IsNullOrWhiteSpace(FilterColumn) || FilterValue == null) && (filters == null || filters.Count <= 0))
            {
                expression = _whereExpression;
            }
            else if ((filters == null || filters.Count <= 0) && (!String.IsNullOrWhiteSpace(FilterColumn) || FilterValue != null))
            {
             // NOTE: IF where expression and filter expression are both specified

                expression = GetFilterExpression(_whereExpression.Parameters[0]);
                                
                Expression body = Expression.And(expression.Body, _whereExpression.Body);
                expression = expression.Update(body, expression.Parameters);
            }
            else
            {
                // NOTE: IF where expression and filter expression are both specified
                bool isFirst = true;
                foreach (KeyValuePair<string,string> pair in filters)
                {
                    FilterColumn = pair.Key;
                    FilterValue = pair.Value;
                                        
                    var filterExpression = GetFilterExpression(_whereExpression.Parameters[0]);

                    Expression body = null;
                    if (isFirst)
                    {
                        expression = filterExpression;
                        body = Expression.And(expression.Body, _whereExpression.Body);
                        isFirst = false;
                    }
                    else
                    {
                        body = Expression.And(expression.Body, filterExpression.Body);                        
                    }

                    expression = expression.Update(body, expression.Parameters);
                }                
            }

            /*
             * Append IsDeleted Clause if IgnoreSoftDeletedRecords = True
             * Also make sure IsDeleted Property is available in entity
             */
            if (_ignoreSoftDeleteRecords && typeof(TEntity).GetProperties().Any(p => p.Name == "IsDeleted"))
            {                
                var xParam                      = expression.Parameters[0];                 
                Expression softDeleteExpression = Expression.Equal(Expression.Property(xParam, "IsDeleted"), Expression.Constant(false));
                Expression body                 = Expression.And(expression.Body, softDeleteExpression);
                                
                expression = expression.Update(body, expression.Parameters); 
            }
            
            return expression;
        }
        
        #endregion
        
        #endregion

        #region Sort Expression
        
        /// <summary>
        /// Sort Column Name
        /// </summary>
        public System.String SortColumn 
        {
            get { return _sortColumn;  }
            set 
            {
                _sortColumn = value;
                _sortColumnType = GetColumnType(typeof(TEntity), _sortColumn);
            }
        }
        private System.String _sortColumn = "CreatedOn";
        
        /// <summary>
        /// Sort Direction
        /// </summary>
        public ColumnSortDirection SortDirection
        {
            get { return _sortDirection;  }            
            set { _sortDirection = value; }
        }
        private ColumnSortDirection _sortDirection = ColumnSortDirection.Ascending;

        // Sort Column Type
        internal System.Type SortColumnType
        {
            get { return _sortColumnType;  }            
        }
        private System.Type _sortColumnType = typeof(System.DateTime);

        // returns sort expression
        internal Expression<Func<TEntity, TType>> GetSortExpression<TType>()
        { 
            // Make Expression here using FieldName
            var xParam = Expression.Parameter(typeof(TEntity), "x");
            var body   = GetExpression(xParam, typeof(TEntity), SortColumn);

            var lambda = Expression.Lambda<Func<TEntity, TType>>(body, new ParameterExpression[] { xParam });

            return lambda;
        }

        #endregion        

        #region Result batch size

        /// <summary>
        ///		The starting number in the results to return.
        /// </summary>
        public System.Int32 ResultsStartIndex
        {
            get { return _resultsStartIndex; }
            set
            {
                if (value < 0)// || value > _maxResultsSize)
                    throw new System.IndexOutOfRangeException("_resultStartIndex");
                _resultsStartIndex = value;
            }
        }
        private System.Int32 _resultsStartIndex = 0;

        /// <summary>
        ///		The number of results to return.
        /// </summary>
        public System.Int32 MaxResultsSize
        {
            get { return _maxResultsSize; }
            set
            {
                // Upper limit for batch of records to be returned is 10,000
                if (value < 0 || value > 10000) //|| value < _resultsStartIndex)
                    throw new System.IndexOutOfRangeException("_maxResultsSize");
                _maxResultsSize = value;
            }
        }
        private System.Int32 _maxResultsSize = 10000; 

        #endregion

        #region Include Entities

        /// <summary>
        ///		A list of relationships to a returned entity to return as well.
        /// </summary>
        public System.Collections.Generic.List<System.String> IncludedEntities { get; set; } 

        #endregion

        #endregion

        #region Private Methods

        // extract column type
        private static System.Type GetColumnType(System.Type entityType, System.String propName)
        {
            System.Reflection.PropertyInfo[] props = entityType.GetProperties(System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Instance);

            System.String navEntityName             = string.Empty;
            System.Reflection.PropertyInfo propInfo = null;
            if (propName.Contains('.'))
            {
                navEntityName = propName.Split(new char[] { '.' }, 2)[0];
                propName      = propName.Split(new char[] { '.' }, 2)[1];

                propInfo = props.Where(p => p.Name == navEntityName).FirstOrDefault();
                if (propInfo == null)
                    throw new Exceptions.InvalidExpressionException("Property Not Found");

                return GetColumnType(propInfo.PropertyType, propName);
            }

            propInfo = props.Where(p => p.Name == propName).FirstOrDefault();
            if (propInfo == null)
                throw new Exceptions.InvalidExpressionException("Property Not Found");

            if (!IsPrimitiveType(propInfo.PropertyType))
                throw new Exceptions.InvalidExpressionException("Property is not Primitive");

            return propInfo.PropertyType;
        }

        // return true if it is from allowed primitive types
        private static bool IsPrimitiveType(System.Type propType)
        {
            if (propType.IsGenericType && propType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                propType = Nullable.GetUnderlyingType(propType);
            }

            switch(propType.ToString())
            {
                case "System.String":
                case "System.DateTime":                
                case "System.Guid":
                case "System.Int32":
                case "System.Int64":
                case "System.Double":
                case "System.Decimal":
                case "System.Boolean":
                case "System.Int16":
                    return true;
                default:
                    return false;
            }
        }

        // return true if type is Nullable
        private static bool IsNullable(System.Type propType)
        {
            if (propType.IsGenericType && propType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                return true;
            return false;
        }

        // extract expression tree
        private static Expression GetExpression(Expression expr, System.Type entityType, System.String propName)
        {
            System.Reflection.PropertyInfo[] props = entityType.GetProperties(System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Instance);

            if (propName.Contains('.'))
            {
                System.String navEntityName = string.Empty;

                navEntityName = propName.Split(new char[] { '.' }, 2)[0];
                propName = propName.Split(new char[] { '.' }, 2)[1];

                System.Type propType = props.Where(p => p.Name == navEntityName).First().PropertyType;

                return GetExpression(Expression.Property(expr, navEntityName), propType, propName);
            }

            return Expression.Property(expr, propName);
        }

        // get constant expression for nullable types
        private static Expression GetNullableExpression(object value, System.Type type)
        {
            switch (Nullable.GetUnderlyingType(type).ToString())
            {
                case "System.Int32"    :
                            int intVal = Int32.Parse(value.ToString());
                            return Expression.Convert(Expression.Constant(new Nullable<Int32>(intVal)),    type);
                case "System.DateTime" :
                            DateTime dtVal = DateTime.Parse(value.ToString());
                            return Expression.Convert(Expression.Constant(new Nullable<DateTime>(dtVal)),  type);
                case "System.Int64"    : 
                            Int64 longVal = Int64.Parse(value.ToString());
                            return Expression.Convert(Expression.Constant(new Nullable<Int64>(longVal)),   type);
                case "System.Double"   : 
                            Double dblVal = Double.Parse(value.ToString());
                            return Expression.Convert(Expression.Constant(new Nullable<Double>(dblVal)),   type);
                case "System.Decimal"  :
                            Decimal decVal = Decimal.Parse(value.ToString());
                            return Expression.Convert(Expression.Constant(new Nullable<Decimal>(decVal)),  type);
                case "System.Boolean"  :
                            Boolean boolVal = Boolean.Parse(value.ToString());
                            return Expression.Convert(Expression.Constant(new Nullable<Boolean>(boolVal)), type);

                case "System.Int16":
                            short shortVal = Int16.Parse(value.ToString());
                            return Expression.Convert(Expression.Constant(new Nullable<Int16>(shortVal)), type);

                case "System.String"   : 
                case "System.Guid"     : 
                default                : 
                            throw new System.Exception("Unhandled Nullable Expression");
            }
        }

        // get filter expression
        private Expression<Func<TEntity, bool>> GetFilterExpression()
        {
            return GetFilterExpression(Expression.Parameter(typeof(TEntity), "x"));
        }

        private Expression<Func<TEntity, bool>> GetFilterExpression(ParameterExpression xParam)
        {
            /*
             * Special Handling for Boolean
             */
            if (FilterColumnType == typeof(System.Boolean))
            {
                if (FilterValue.ToString() == "1")
                {
                    FilterValue = true.ToString();
                }
                else if (FilterValue.ToString() == "0")
                {
                    FilterValue = false.ToString();
                }
            }
                        
            /*
             * BUILD EXPRESSION using field name
             */
            Expression body = null;            
            var lExpr  = GetExpression(xParam, typeof(TEntity), FilterColumn);
            var rExpr  = !IsNullable(FilterColumnType) ?
                          Expression.Constant(Convert.ChangeType(FilterValue, FilterColumnType)) : GetNullableExpression(FilterValue, FilterColumnType);

            /*
             * Special handling if filter column type is string
             */
            if (FilterColumnType == typeof(System.String))
            {
                body = Expression.Call(
                    lExpr, typeof(System.String).GetMethod("Contains", new Type[] { typeof(System.String) }), rExpr);
            }

            /*
             * Special handling if filter column type is datetime
             */
            else if (FilterColumnType == typeof(System.DateTime))
            {
                // Make left expression NULLable
                lExpr = Expression.Convert(lExpr, typeof(System.Nullable<DateTime>));

                // Make right expression NULLable                
                rExpr = Expression.Convert(Expression.Constant(new Nullable<DateTime>(DateTime.Parse(FilterValue.ToString()))), 
                                           typeof(System.Nullable<DateTime>));
                
                body = Expression.Equal(
                            Expression.Call(typeof(System.Data.Objects.EntityFunctions).GetMethod("TruncateTime", new Type[] { typeof(System.Nullable<DateTime>) })
                            , new Expression[] { lExpr })
                        , rExpr);
            }

            /*
             * For the rest
             */
            else
            {
                body = Expression.Equal(lExpr, rExpr);
            }


            var lambda = Expression.Lambda<Func<TEntity, bool>>(body, new ParameterExpression[] { xParam });
            return lambda;
        }

        private Expression<Func<TEntity, bool>> GetExpressionForSecureIds(ParameterExpression xParam, string key, List<System.Guid> lstIds)
        {

            Expression<Func<TEntity, bool>> result = default(Expression<Func<TEntity, bool>>);
            result = (x => true);

            try
            {
                ConstantExpression secureIds = Expression.Constant(lstIds, typeof(List<System.Guid>));
                MemberExpression memberExpression = (MemberExpression)GetExpression(xParam, typeof(TEntity), key);
                Expression convertExpression = Expression.Convert(memberExpression, typeof(System.Guid));
                MethodCallExpression containsExpression = Expression.Call(secureIds, "Contains", new Type[] { }, convertExpression);

                result = Expression.Lambda<Func<TEntity, bool>>(containsExpression, new ParameterExpression[] { xParam });

            }
            catch
            {
                throw;
            }

            return result;

        }

        #endregion

        #region Constructors & Factories

        //	Internal constructor since it shouldn't be called outside of the API.
		internal _QuerySettings() 
		{
			IncludedEntities = new System.Collections.Generic.List<string>();
		}

		/// <summary>
		///		Creates a new instance of a QuerySettings object.
		/// </summary>
        public static Helpers._QuerySettings<TEntity> Factory() 
		{
            return new Helpers._QuerySettings<TEntity>();
		}

		#endregion
	}
}
