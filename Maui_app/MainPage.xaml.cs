namespace Maui_app
{
    public partial class MainPage : ContentPage
    {
        string nombreArchivo = Path.Combine(FileSystem.AppDataDirectory, "notas.txt");
        String notaIntroducida;

        public MainPage()
        {
            InitializeComponent();
            if (File.Exists(nombreArchivo))
            {
                editor.Text = File.ReadAllText(nombreArchivo);
            }
        }

        public void guardar(Object sender, EventArgs e)
        {
            String notaIntroducida = editor.Text;

            if (!string.IsNullOrEmpty(notaIntroducida))
            {
                this.DisplayAlert("Quieres guardar la nota ?", "", "Si");
            }
            else
            {
                this.DisplayAlert("No has introducido nada", "", "Continuar");
            }
        }

        public void borrar(object sender, EventArgs e)
        {
            editor.Text = "";
        }
    }

}
