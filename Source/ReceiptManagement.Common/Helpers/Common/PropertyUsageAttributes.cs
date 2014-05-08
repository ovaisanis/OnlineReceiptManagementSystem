using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReceiptManagement.Common.Helpers
{
    /// <summary>
    /// PropertyUsageAttributes
    /// </summary>
    public class PropertyUsageAttributes
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// MaxLength
        /// </summary>
        public int    MaxLength { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        public bool   Required  { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        public string Type      { get; set; }

        /// <summary>
        /// IsComplexType
        /// </summary>
        public bool IsComplexType { get; set; }

        /// <summary>
        /// SubPropertyUsageAttributes
        /// </summary>
        public ICollection<PropertyUsageAttributes> SubPropertyUsageAttributes 
        {
            get
            {
                if (_SubPropertyUsageAttributes == null)
                    _SubPropertyUsageAttributes = new List<PropertyUsageAttributes>();
                return _SubPropertyUsageAttributes;
            }
            set { _SubPropertyUsageAttributes = value; }
        }
        private ICollection<PropertyUsageAttributes>  _SubPropertyUsageAttributes;
    }
}
