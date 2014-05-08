
namespace ReceiptManagement.Common.Helpers
{
    /// <summary>
    /// IEntityKey
    /// </summary>
    public interface IEntityKey
    {
        System.Guid     Id         { get; }
        System.DateTime ModifiedOn { get; }
    }
}
