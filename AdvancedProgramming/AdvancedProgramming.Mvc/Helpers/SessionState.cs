using AdvancedProgramming.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdvancedProgramming.Mvc.Helpers
{
    public class SessionState
    {
        private HttpSessionStateBase session;

        public SessionState(HttpSessionStateBase session)
        {
            this.session = session;
        }

        public User CurrentUser
        {
            get => session["User"] as User;
            set => session["User"] = value;
        }

        public void Logout()
        {
            session.Remove("User");
        }
    }

}