namespace Maui_app
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        string numeroTraducido;
        private void traducir(Object sender, EventArgs e)
        {
            string numeroIntroducido = NumTelefonoTexto.Text; //OBTENEMOS EL NUMERO RECOGIDO EN EL ENTRY
            numeroTraducido = Maui_app.PhonewordTranslator.ToNumber(numeroIntroducido); //UTILIZAMOS EL METODO DE LA CLASE
                                                                                                  //PHONEWORDTRANSLATOR PASANDOLE EL NUMERO INTRODUCIDO
                                                                                                  //COMPROBAMOS SI EL NUMERO INTRODUCIDO Y TRADUCIDO ESTA VACIO O NO
            if (!string.IsNullOrEmpty(numeroTraducido))
            {
                //SI CONTIENE ALGO, EL BOTON LLAMAR SE ACTIVA Y SU TEXTO CAMBIA A "LLAMAR A ...."
                BotonLlamar.IsEnabled = true;
                BotonLlamar.Text = "Llamar a " + numeroTraducido;
            }
            else
            {
                //SI ESTA VACIO SE DESABILITA EL BOTON LLAMAR Y SE CAMBIA EL TEXTO DEL BOTON
                BotonLlamar.IsEnabled = false;
                BotonLlamar.Text = "Llamar";
            }
        }

        async void llamada(Object sender, EventArgs e)
        {
            //CUANDO PULSAMOS EL BOTON LLAMAR(SI ESTA HABILITADO) NOS SALE UNA ALERTA QUE NOS PREGUNTA SI QUEREMOS LLAMAR AL NUMERO
            if (await this.DisplayAlert("Marque un numero", "Te gustaria llamar a " + numeroTraducido + "?", "Si", "No"))
            {
                try
                {
                    if (PhoneDialer.Default.IsSupported)
                        PhoneDialer.Default.Open(numeroTraducido);
                }
                catch (ArgumentNullException)
                {
                    await DisplayAlert("Imposible de marcar", "Numero de telefono no valido", "Vale");
                }
                catch (Exception)
                {
                    // Other error has occurred.
                    await DisplayAlert("Imposible de marcar", "Marcado fallido", "Vale");
                }
            }
        }

    }

}
