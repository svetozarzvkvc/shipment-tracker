namespace ShipmentTracker.UI.Services
{
    public class AuthService
    {
        private bool _isAuthenticated = true;

        public bool IsAuthenticated => _isAuthenticated;

        public void LogIn()
        {
            _isAuthenticated = true;
        }

        public void LogOut()
        {
            _isAuthenticated = false;
        }
    }
}
