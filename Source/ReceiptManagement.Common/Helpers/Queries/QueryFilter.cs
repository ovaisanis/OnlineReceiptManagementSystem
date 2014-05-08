using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReceiptManagement.Common.Helpers
{
    /// <summary>
    /// Filter Operators
    /// </summary>
    public enum FilterOperator
    {
        Default                 = -1,
        IsLessThan              =  0,
        IsLessThanOrEqualTo     =  1,
        IsEqualTo               =  2,
        IsNotEqualTo            =  3,
        IsGreaterThanOrEqualTo  =  4,
        IsGreaterThan           =  5,
        StartsWith              =  6,
        EndsWith                =  7,
        Contains                =  8,
        IsContainedIn           =  9,
    }

    /// <summary>
    /// Query Filter
    /// </summary>
    public class QueryFilter
    {
        #region Public Properties

        /// <summary>
        /// Column name to filter on
        /// </summary>
        public System.String  Column   { get; internal set; }

        /// <summary>
        /// Filter Value
        /// </summary>
        public System.Object  Value    { get; internal set; }

        /// <summary>
        /// Filter Operator
        /// </summary>
        public FilterOperator Operator { get; internal set; }

        #endregion

        #region Factory Methods

        private QueryFilter() { }

        /// <summary>
        /// Factory Method
        /// </summary>
        /// <param name="column">Column to Filter on</param>
        /// <param name="value">Filter Value</param>
        /// <returns></returns>
        public static QueryFilter Factory(System.String column, System.Object value)
        {
            return new QueryFilter { Column = column, Value = value, Operator = FilterOperator.Default };
        }

        /// <summary>
        /// Factory Method
        /// </summary>
        /// <param name="column">Column to Filter on</param>
        /// <param name="value">Filter Value</param>
        /// <param name="filterOperator">Filter Operator</param>
        /// <returns></returns>
        public static QueryFilter Factory(System.String column, System.Object value, FilterOperator filterOperator)
        {
            return new QueryFilter{ Column = column, Value = value, Operator = filterOperator };
        }

        /// <summary>
        /// Factory Method
        /// </summary>
        /// <param name="column">Column to Filter on</param>
        /// <param name="value">Filter Value</param>
        /// <param name="operatorIndex">Operator Index is used to cast integer onto Filter Operator</param>
        /// <returns></returns>
        public static QueryFilter Factory(System.String column, System.Object value, System.Int32 operatorIndex)
        {
            return new QueryFilter { Column = column, Value = value, Operator = (FilterOperator)operatorIndex  };
        }

        #endregion
    }
}
