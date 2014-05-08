using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Linq.Dynamic
{
    /// <summary>
    /// ExpressionExtension
    /// </summary>
    public static class ExpressionExtension
    {
        #region Public Static Methods
        
        public static System.Linq.Expressions.Expression<T> Compose<T>(this System.Linq.Expressions.Expression<T> first, System.Linq.Expressions.Expression<T> second, Func<System.Linq.Expressions.Expression, System.Linq.Expressions.Expression, System.Linq.Expressions.Expression> merge)
        {
            // build parameter map (from parameters of second to parameters of first)
            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);

            // replace parameters in the second lambda expression with parameters from the first
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

            // apply composition of lambda expression bodies to parameters from the first expression 
            return System.Linq.Expressions.Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        public static System.Linq.Expressions.Expression<Func<T, bool>> And<T>(this System.Linq.Expressions.Expression<Func<T, bool>> first, System.Linq.Expressions.Expression<Func<T, bool>> second)
        {
            return first.Compose(second, System.Linq.Expressions.Expression.AndAlso);
        }

        public static System.Linq.Expressions.Expression<Func<T, bool>> Or<T>(this System.Linq.Expressions.Expression<Func<T, bool>> first, System.Linq.Expressions.Expression<Func<T, bool>> second)
        {
            return first.Compose(second, System.Linq.Expressions.Expression.OrElse);
        }

        /// <summary>
        /// Gets the property name on which this expression has been applied.
        /// </summary>
        /// <typeparam name="T">Entity</typeparam>
        /// <param name="expression">expression</param>
        /// <returns>Name of property in string on which expression was applied.</returns>
        public static string GetPropertyName<T>(this System.Linq.Expressions.Expression<Func<T, object>> expression)
        {
            return expression.Body.ToString().Split('.')[1].TrimEnd(')');
        }
        #endregion
    }
}
