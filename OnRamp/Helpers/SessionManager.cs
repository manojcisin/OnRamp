using OnRamp.Model.Models;
using OnRamp.Models;
using System.Web;


namespace OnRamp.Helpers {
	/// <summary>
	/// this is for session management
	/// </summary>
	public class SessionManager
    {
        private const string SESSION_MANAGER = "SESSION_MANAGER";

        /// <summary>
        ///   Private constructor for SessionManager
        /// </summary>
        private SessionManager()
        {
        }

        #region Method
        /// <summary>
        ///   Singleton-style access point
        /// </summary>
        public static SessionManager Instance
        {
            get
            {
                var manager = HttpContext.Current.Session[SESSION_MANAGER] as SessionManager;
                // Only use ImpersonateUserName if it is set to a Username in the Config.
                if (manager == null)
                {
                    manager = new SessionManager();
                    HttpContext.Current.Session[SESSION_MANAGER] = manager;
                }
                return manager;
            }
        }
        #endregion

        public User CurrentUser { get; set; }
    }
}