using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Linq.Dynamic
{
    /// <summary>
    /// ParamterRebinder
    /// </summary>
    public class ParameterRebinder : System.Linq.Expressions.ExpressionVisitor
    {
        #region Private Members
        
        private readonly Dictionary<System.Linq.Expressions.ParameterExpression, System.Linq.Expressions.ParameterExpression> map;

        #endregion
        
        #region Constructor
        
        public ParameterRebinder(Dictionary<System.Linq.Expressions.ParameterExpression, System.Linq.Expressions.ParameterExpression> map)
        {
            this.map = map ?? new Dictionary<System.Linq.Expressions.ParameterExpression, System.Linq.Expressions.ParameterExpression>();
        }

        #endregion

        #region Public Methods
        
        public static System.Linq.Expressions.Expression ReplaceParameters(Dictionary<System.Linq.Expressions.ParameterExpression, System.Linq.Expressions.ParameterExpression> map, System.Linq.Expressions.Expression exp)
        {
            return new ParameterRebinder(map).Visit(exp);
        }
        
        #endregion

        #region Protected Override Methods
        
        protected override System.Linq.Expressions.Expression VisitParameter(System.Linq.Expressions.ParameterExpression p)
        {
            System.Linq.Expressions.ParameterExpression replacement;

            if (map.TryGetValue(p, out replacement))
            {
                p = replacement;
            }

            return base.VisitParameter(p);
        } 

        #endregion
    }
}
