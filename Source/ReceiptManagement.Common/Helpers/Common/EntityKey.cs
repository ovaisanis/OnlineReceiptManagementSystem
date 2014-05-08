
namespace ReceiptManagement.Common.Helpers
{
    /// <summary>
    /// EntityKey used to store entity id and modified date
    /// </summary>
    public class EntityKey : IEntityKey
    {
        #region Constructors & Factory Methods

        // Constructor
        private EntityKey() { }

        /// <summary>
        /// Factory
        /// </summary>
        /// <param name="id"></param>
        /// <param name="modifiedOn"></param>
        public static EntityKey Factory(System.Guid id, System.DateTime modifiedOn)
        {
            return new EntityKey { Id = id, ModifiedOn = modifiedOn };
        }

        #endregion

        #region Properties

        /// <summary>
        /// Id
        /// </summary>
        public System.Guid     Id         { get; private set; }

        /// <summary>
        /// ModifiedDate
        /// </summary>
        public System.DateTime ModifiedOn { get; private set; }

        #endregion
    }
}
