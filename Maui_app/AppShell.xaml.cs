namespace Maui_app
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            //comentario
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Application.Current.UserAppTheme = AppTheme.Light;
        }
    }
}
