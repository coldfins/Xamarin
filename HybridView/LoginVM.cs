using System;

namespace HybridView
{
    public class LoginVM
    {
        private string _password = string.Empty;
        private string _username = string.Empty;

        public string UserName
        {
            get { return _username; }
            set
            {
                if (_username.Equals(value, StringComparison.Ordinal))
                    return;
                _username = value ?? string.Empty;
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (_password.Equals(value, StringComparison.Ordinal))
                    return;
                _password = value ?? string.Empty;
            }
        }
    }
}