using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Text.RegularExpressions;


namespace ReceiptManagement.Common.Helpers
{


    /// <summary>
    ///		Specify settings about the query to be performed.
    /// </summary>
    public sealed class QuerySettings<TEntity>
    {
        /*
         * == TODO ==
         * TODO: Deal with Time truncation in DateTime search
         * TODO: Remove Obsolete properties once done with Upgrades
         * TODO: Deal with Navigational Properties (.Any) search
         */

        #region Public Properties

        #region Result batch size

        /// <summary>
        /// MaxResultsSizeConstant
        /// </summary>
        public const System.Int32 MaxResultsSizeConstant = 100000;

        /// <summary>
        ///	The starting number in the results to return.
        /// </summary>
        public System.Int32 ResultsStartIndex
        {
            get { return _resultsStartIndex; }
            set
            {
                if (value < 0)
                    throw new System.IndexOutOfRangeException("_resultStartIndex");
                _resultsStartIndex = value;
            }
        }
        private System.Int32 _resultsStartIndex = 0;

        /// <summary>
        ///	The number of results to return.
        /// </summary>
        public System.Int32 MaxResultsSize
        {
            get { return _maxResultsSize; }
            set
            {
                if (value < 0 || value > MaxResultsSizeConstant)
                    throw new System.IndexOutOfRangeException("_maxResultsSize");
                _maxResultsSize = value;
            }
        }
        private System.Int32 _maxResultsSize = MaxResultsSizeConstant;

        #endregion

        #region Ignore SoftDeleted Records

        /// <summary>
        /// Ignore soft deleted records if set to True
        /// </summary>        
        public bool IgnoreSoftDeleteRecords
        {
            get { return _ignoreSoftDeleteRecords; }
            set { _ignoreSoftDeleteRecords = value; }
        }
        private bool _ignoreSoftDeleteRecords = true;

        #endregion

        #region Sort Expression

        /// <summary>
        /// Sort Column Name
        /// </summary>
        [Obsolete("Use SortExpression instead of SortColumn and SortDirection")]
        public System.String SortColumn { get; set; }

        /// <summary>
        /// Sort Direction
        /// </summary>
        [Obsolete("Use SortExpression instead of SortColumn and SortDirection")]
        public ColumnSortDirection SortDirection
        {
            get { return _sortDirection; }
            set { _sortDirection = value; }
        }
        private ColumnSortDirection _sortDirection = ColumnSortDirection.Ascending;

        /// <summary>
        /// Sort Expression
        /// </summary>
        /// <remarks>SortExpression if SET directly will have higher precedence than SortColumn/SortDirection</remarks>
        public System.String SortExpression
        {
            get
            {
                /*
                 * This IF block is kept for backward compatibility 
                 */
#pragma warning disable 612, 618
                if (!String.IsNullOrEmpty(SortColumn))
                {
                    ValidateSortExpression(SortColumn);

                    if (_sortDirection == ColumnSortDirection.Ascending)
                        return SortColumn + " asc";
                    else
                        return SortColumn + " desc";
                }
#pragma warning restore 612, 618
                return _sortExpression;
            }
            set
            {
                _sortExpression = value;

                if (String.IsNullOrEmpty(_sortExpression))
                    _sortExpression = "ID";

                ValidateSortExpression(_sortExpression);
            }
        }
        private System.String _sortExpression = "ID";

        #endregion

        #region Include Entities

        /// <summary>
        ///	A list of relationships to a returned entity to return as well.
        /// </summary>
        public List<System.String> IncludedEntities { get; set; }

        #endregion

        #region Where Expression

        #region Where Predicate

        /// <summary>
        /// Where Expression
        /// ability to filter the results based on criteria
        /// </summary>
        public Expression<Func<TEntity, bool>> WhereExpression
        {
            get { return _whereExpression; }
            set { _whereExpression = value; }
        }
        private Expression<Func<TEntity, bool>> _whereExpression = (x => true);

        #endregion

        #region Column Filters

        /// <summary>
        /// Filter Column Name
        /// </summary>
        [Obsolete]
        public System.String FilterColumn { get; set; }

        /// <summary>
        /// Filter Value
        /// </summary>
        [Obsolete]
        public System.Object FilterValue { get; set; }

        /// <summary>
        /// Filters
        /// </summary>
        public List<QueryFilter> Filters
        {
            get
            {
                if (_filters == null)
                    _filters = new List<QueryFilter>();
                return _filters;
            }
            set
            {
                _filters = value;
            }
        }
        private List<QueryFilter> _filters = null;

        private bool isGenericType;

        private bool isNullableType;

        #endregion

        #region GetWhereExpression Method

        /// <summary>
        /// ADD QueryFilter from FilterColumn & FilterValue
        /// </summary>

        private void AddBackwardSupport()
        {
#pragma warning disable 612, 618
            if (!string.IsNullOrWhiteSpace(FilterColumn) || FilterValue != null)
                Filters.Add(QueryFilter.Factory(FilterColumn, FilterValue));
#pragma warning restore 612, 618
        }

        /// <summary>
        /// returns where expression; Filter Column:Value will be given preference over WhereExpression
        /// </summary>
        /// <returns></returns>
        public Expression<Func<TEntity, bool>> GetWhereExpression()
        {

            // ADD QueryFilter from FilterColumn & FilterValue
            AddBackwardSupport();

            /*
             * Expression
             */
            Expression<Func<TEntity, bool>> expression = _whereExpression;

            /*
             * Create Filter Expressions one by one and AND (&&) into expression
             */
            foreach (var filter in Filters)
            {
                if (filter.Value == null || string.IsNullOrWhiteSpace(filter.Value.ToString()))
                    throw new Exceptions.InvalidExpressionException("Must provide a valid Filter Column. It cannot be Null or Empty.");

                string dynamicExpression = string.Empty;

                Expression<Func<TEntity, bool>> filterExpression = null;
                
                if(filter.Column.Contains(","))
                {
                    //Get the expression for a column containing multiple columns 
                    filterExpression = GetMultipleColumnExpression(filter);
                }
                else
                {
                    Type type = GetColumnType(typeof(TEntity), filter.Column);                    

                    bool isValidFilter = ValidateFilter(type.ToString(), filter.Value.ToString());

                    if (!isValidFilter)
                    {
                        filterExpression = (x => false);
                    }
                    else
                    {
                        dynamicExpression = GetDynamicExpression(filter);

                        filterExpression = System.Linq.Dynamic.DynamicExpression.ParseLambda<TEntity, bool>(dynamicExpression);

                        //check if column has null then add the nullable condition
                        if (!isGenericType && (type == typeof(System.String) && filter.Operator == FilterOperator.IsNotEqualTo) || (isNullableType && filter.Operator == FilterOperator.IsNotEqualTo))
                        {
                            filterExpression = filterExpression.Or(GetNullableColumnExpression(filter.Column, type));

                            isNullableType = false;
                        }

                        isGenericType = false;
                    }
                }

                // AND the two expressions
                expression = expression.And(filterExpression);
            }


            /*
             * Append IsDeleted Clause if IgnoreSoftDeletedRecords = True
             * Also make sure IsDeleted Property is available in entity
             */
            if (_ignoreSoftDeleteRecords && typeof(TEntity).GetProperties().Any(p => p.Name == "IsDeleted"))
            {
                // CREATE expression (IsDeleted == False)
                Expression<Func<TEntity, bool>> deleteExpression =
                                System.Linq.Dynamic.DynamicExpression.ParseLambda<TEntity, bool>("!IsDeleted");

                // AND the two expressions
                expression = expression.And(deleteExpression);
            }

            //If System level filtes have been passed, AND them with the original Expression
            if (!string.IsNullOrEmpty(_systemFilter) && expression != null)
            {
                var systemFilterExpression = System.Linq.Dynamic.DynamicExpression.ParseLambda<TEntity, bool>(_systemFilter);

                expression = expression.And(systemFilterExpression);    
            }

            // Return
            return expression;
        }

        #endregion

        #region Validate Filters

        private bool ValidateFilter(string type, string value)
        {
            bool isSuccess = true;            
            string msg = "Please provide valid numeric value";
            string numericRegularExpression = "^[1-9]+[0-9]*$";
            string decimalRegularExpression = @"^\d*(\.\d{1,9})?$";

            switch (type)
            {
                case "System.Int32":

                    int resultInt;                   

                    if (Regex.Match(value, numericRegularExpression).Success)
                    {
                       isSuccess = int.TryParse(value, out resultInt);

                       if (!isSuccess)
                            return false;
                    }
                    else
                    {
                        return false;
                    }                   
                                      
                    break;

                case "System.Int16":

                    short resultShort;                                                   

                    if (Regex.Match(value, numericRegularExpression).Success)
                    {
                        isSuccess = short.TryParse(value, out resultShort);

                        if (!isSuccess)
                            return false;
                    }
                    else
                    {
                        isSuccess = false;
                    }

                    break;

                case "System.Int64":

                    long resultLong;

                    if (Regex.Match(value, numericRegularExpression).Success)
                    {
                        isSuccess = long.TryParse(value, out resultLong);
                        
                        if (!isSuccess)
                            return false;
                    }
                    else
                    {
                        isSuccess = false;
                    }
                    break;

                case "System.Decimal":

                    decimal resultDecimal;
                
                    if (Regex.Match(value, decimalRegularExpression).Success)
                    {
                        isSuccess = decimal.TryParse(value, out resultDecimal);
                        
                        if (!isSuccess)
                            return false;
                    }
                    else
                    {
                        isSuccess = false;
                    }
                    break;               

                case "System.Boolean":
                    bool resultBoolean;
                    isSuccess = bool.TryParse(value, out resultBoolean);

                    if (isSuccess)
                    {
                        value = "0";
                        if (resultBoolean)
                            value = "1";
                    }
                    break;

                case "System.String":
                    break;

                default:
                    break;
            }

           
            if (!isSuccess)
            {
                throw Exceptions.QuerySettingException.Factory(msg);
            }
            
            return isSuccess;
            
        }

        #endregion

        #region DynamicExpression

        /// <summary>
        /// GetDynamicExpression : Get the expression against the operator
        /// </summary>
        /// <param name="type"></param>
        /// <param name="filter"></param>
        /// <param name="filterColumn"></param>
        /// <param name="op"></param>
        /// <returns></returns>
        private string GetDynamicExpression(QueryFilter filter,string filterColumn = "")
        {
            string dynamicExpression = string.Empty;

            if (string.IsNullOrEmpty(filterColumn))
            {
                filterColumn = filter.Column;
            }

            Type type = GetColumnType(typeof(TEntity), filterColumn);

            String op = GetOperator(filter.Operator, type);
          
            var filterValue = filter.Value;

            if (filterValue.ToString().Contains("\""))
            {
                filterValue = filterValue.ToString().Replace("\"", "\"\"");
            }

            // HANDLE System.String type
            if (type == typeof(System.String))
            {
                if (filter.Operator == FilterOperator.Contains ||
                    filter.Operator == FilterOperator.Default ||
                    filter.Operator == FilterOperator.EndsWith ||
                    filter.Operator == FilterOperator.IsContainedIn ||
                    filter.Operator == FilterOperator.StartsWith)
                {
                   
                    dynamicExpression = string.Format("{0} != NULL && {0}.ToLower().{1}(\"{2}\")", filterColumn, op, filterValue.ToString().ToLower());                    
                }
                else
                {
                    dynamicExpression = string.Format("{0} != NULL && {0}.ToLower() {1} \"{2}\"", filterColumn, op, filterValue.ToString().ToLower());
                   
                }
            }
            // HANDLE System.DateTime type
            else if (type == typeof(System.DateTime))
            {
                // NOTE : Yet to deal with the case of Time part truncation

                DateTime dt = DateTime.Parse(filterValue.ToString());
                dynamicExpression = string.Format("{0}  {1} DateTime({2},{3},{4})", filterColumn, op, dt.Year, dt.Month, dt.Day);

            }
            // HANDLE Other types
            else
            {
                /*
                 * NOTE: REMOVE this portion after upgrade
                 * SOME old code to deal
                 */
                if (type == typeof(System.Boolean))
                {
                    if (filterValue.ToString() == "1")
                        filterValue = true;
                    else if (filterValue.ToString() == "0")
                        filterValue = false;
                }

                dynamicExpression = string.Format("{0} {1} {2}", filterColumn, op, filterValue);
            }

            //If collection of entities exists
            if (isGenericType)
            {
                string[] arrNavigationEntities = filter.Column.Split(new char[] { '.' }, 2);

                dynamicExpression = string.Format("{0}.Any({1})", arrNavigationEntities[0], dynamicExpression.Replace(filter.Column, arrNavigationEntities[1]));               
            }

            return dynamicExpression;
        }

        #endregion

        #region MultipleColumnExpression

        /// <summary>
        /// GetMultipleColumnExpression : Parse the expression for multiple columns
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        private Expression<Func<TEntity, bool>> GetMultipleColumnExpression(QueryFilter filter)
        {
            Expression<Func<TEntity, bool>> multipleColumnExpression = null;

            string[] filterTokens = filter.Column.Split(',');
      
            Type type = GetColumnType(typeof(TEntity), filterTokens[0]);

            String op = GetOperator(filter.Operator, type);

            string filterValue = filter.Value.ToString();

            if (ValidateFilter(type.ToString(), filterValue))
            {
                if (filter.Operator == FilterOperator.IsEqualTo || filter.Operator == FilterOperator.IsNotEqualTo)
                {
                    multipleColumnExpression = System.Linq.Dynamic.DynamicExpression.ParseLambda<TEntity, bool>(
                                                      string.Format("string.Concat({0},\" \",{1}) {2} \"{3}\"", filterTokens[0], filterTokens[1], op, filterValue));
                }
                else
                {
                    multipleColumnExpression = System.Linq.Dynamic.DynamicExpression.ParseLambda<TEntity, bool>(
                                                      string.Format("string.Concat({0},\" \",{1}).{2}(\"{3}\")", filterTokens[0], filterTokens[1], op, filterValue));
                }
            }
            else
            {
                multipleColumnExpression = (x => false);                
            }

            return multipleColumnExpression;
        }

        #endregion

        #region NullableColumnExpression

        /// <summary>
        /// GetNullableColumnExpression : Get the expression for null column
        /// </summary>
        /// <param name="filterColumn"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private Expression<Func<TEntity, bool>> GetNullableColumnExpression(string filterColumn,Type type)
        {
            string equalToOperator = GetOperator(FilterOperator.IsEqualTo, type);

            string nullExpression = filterColumn + equalToOperator + " NULL";           

            return System.Linq.Dynamic.DynamicExpression.ParseLambda<TEntity, bool>(nullExpression);            
        }

        #endregion

        #endregion

        #region default system level filter

        string _systemFilter;

        /// <summary>
        /// System level filters defined for an entity.
        /// </summary>
        public string SystemFilter
        {
            get { return _systemFilter; }
            set { _systemFilter = value; }
        }

        #endregion

        #endregion

        #region Private Methods

        #region Helper Methods

        /// <summary>
        /// Extract column type
        /// </summary>
        /// <param name="entityType"></param>
        /// <param name="propName"></param>
        /// <returns></returns>
        private System.Type GetColumnType(System.Type entityType, System.String propName)
        {
            System.Reflection.PropertyInfo[] props = null;

            if (entityType.IsGenericType)
            {
                isGenericType = entityType.IsGenericType;
                entityType = entityType.GetGenericArguments().FirstOrDefault();
            }

            props = entityType.GetProperties(System.Reflection.BindingFlags.Public |
                    System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Instance);


            System.String navEntityName = string.Empty;
            System.Reflection.PropertyInfo propInfo = null;
            if (propName.Contains('.'))
            {
                navEntityName = propName.Split(new char[] { '.' }, 2)[0];
                propName = propName.Split(new char[] { '.' }, 2)[1];

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

            if (IsNullable(propInfo.PropertyType))
            {
                isNullableType = true;
                return Nullable.GetUnderlyingType(propInfo.PropertyType);
            }

            return propInfo.PropertyType;
        }

        /// <summary>
        /// Return True if it is from allowed primitive types
        /// </summary>
        /// <param name="propType"></param>
        /// <returns></returns>
        private bool IsPrimitiveType(System.Type propType)
        {
            if (propType.IsGenericType && propType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                propType = Nullable.GetUnderlyingType(propType);
            }

            switch (propType.ToString())
            {
                case "System.String":
                case "System.DateTime":
                case "System.Guid":
                case "System.Int16":
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

        /// <summary>
        /// Return True if type is Nullable
        /// </summary>
        /// <param name="propType"></param>
        /// <returns></returns>
        private bool IsNullable(System.Type propType)
        {
            if (propType.IsGenericType && propType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                return true;
            return false;
        }

        /// <summary>
        /// Get Operator
        /// </summary>
        /// <param name="filterOperator"></param>
        /// <returns></returns>
        private System.String GetOperator(FilterOperator filterOperator, Type type)
        {
            switch (filterOperator)
            {
                case FilterOperator.IsLessThan:
                    return "<";

                case FilterOperator.IsLessThanOrEqualTo:
                    return "<=";

                case FilterOperator.IsEqualTo:
                    return "==";

                case FilterOperator.IsNotEqualTo:
                    return "!=";

                case FilterOperator.IsGreaterThanOrEqualTo:
                    return ">=";

                case FilterOperator.IsGreaterThan:
                    return ">";

                case FilterOperator.StartsWith:
                    return "StartsWith";

                case FilterOperator.EndsWith:
                    return "EndsWith";

                case FilterOperator.Contains:
                    return "Contains";

                case FilterOperator.Default:

                case FilterOperator.IsContainedIn:

                default:
                    if (type == typeof(System.String))
                        return "Contains";
                    return "==";
            }
        }

        #endregion

        #region ValidateSortExpression Method

        private void ValidateSortExpression(System.String sortExpression)
        {
            const string ascendingLongConstant = "ascending";
            const string ascendingShortConstant = "asc";

            const string descendingLongConstant = "descending";
            const string descendingShortConstant = "desc";

            // validate comma separated expressions one by one
            if (!String.IsNullOrEmpty(sortExpression))
            {
                string[] sortExpressions = sortExpression.Trim().Split(',');
                foreach (var expr in sortExpressions)
                {
                    // expression format: [ColumnName] {ascending|descending}
                    string[] tokens = expr.Trim().Split(' ');
                    if (tokens.Count() > 2)
                        throw new System.Exception("Invalid Sort Expression");

                    string columnName = tokens[0];
                    GetColumnType(typeof(TEntity), columnName);

                    // check if sort order is also the part of expression
                    if (tokens.Count() > 1 &&
                        tokens[1].ToLower() != ascendingLongConstant &&
                        tokens[1].ToLower() != ascendingShortConstant &&
                        tokens[1].ToLower() != descendingLongConstant &&
                        tokens[1].ToLower() != descendingShortConstant)
                        throw new System.Exception("Invalid Sort Order in Expression");
                }
            }
        }

        #endregion

        #endregion

        #region Constructors & Factories

        //	Internal constructor since it shouldn't be called outside of the API.
        public QuerySettings()
        {
            IncludedEntities = new List<string>();
        }

        /// <summary>
        ///		Creates a new instance of a QuerySettingsExtended object.
        /// </summary>
        public static QuerySettings<TEntity> Factory()
        {
            return new QuerySettings<TEntity>();
        }

        #endregion
    }
}
