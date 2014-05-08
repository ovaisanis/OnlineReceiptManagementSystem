
namespace ReceiptManagement.Common.Helpers
{
    /// <summary>
    ///     Sort Directions
    /// </summary>
    public enum ColumnSortDirection
    {
        /// <summary>
        ///     Ascending Order
        /// </summary>
        Ascending,

        /// <summary>
        ///     Descending Order
        /// </summary>
        Descending
    }

    /// <summary>
    /// SortDirection : Constans for Column sorting
    /// </summary>
    public struct GridSortDirection
    {
        /// <summary>
        /// Ascending : Constants for Sort Column
        /// </summary>
        public const string Ascending  = "ASC";

        /// <summary>
        /// Descending : Constants for Sort Column
        /// </summary>
        public const string Descending = "DESC";
    }
}
