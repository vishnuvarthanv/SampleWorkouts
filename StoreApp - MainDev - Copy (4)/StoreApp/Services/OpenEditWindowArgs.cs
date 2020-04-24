using StoreApp.Model;

namespace StoreApp.Services
{
    /// <summary>
    /// Action Type
    /// </summary>
    public enum ActionType
    {
        /// <summary>
        /// Add a friend
        /// </summary>
        Add,

        /// <summary>
        /// Edit a friend
        /// </summary>
        Edit
    }

    /// <summary>
    /// Open EditWindow arguments
    /// </summary>
    public class OpenEditWindowArgs
    {
        /// <summary>
        /// If <see cref="ActionType"/> is Edit, then the value for this property need to be provided
        /// </summary>
        public UserProfile UserProfile { get; set; }

        public ActionType Type { get; set; }
    }
}