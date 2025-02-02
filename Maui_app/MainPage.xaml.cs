namespace Maui_app
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            facturaEntrada.TextChanged += (s, e) => calcularPropina(false, false);
            abajo.Clicked += (s, e) => calcularPropina(false, true);
            arriba.Clicked += (s, e) => calcularPropina(true, false);

            sliderPorcentaje.ValueChanged += (s, e) =>
            {
                double pct = Math.Round(e.NewValue);
                propinaPorcentaje.Text = pct + "%";
                calcularPropina(false, false);
            };
        }

        void calcularPropina(bool arriba, bool abajo)
        {
            double t;
            if (Double.TryParse(facturaEntrada.Text, out t) && t > 0)
            {
                double pct = Math.Round(sliderPorcentaje.Value);
                double tip = Math.Round(t * (pct / 100.0), 2);

                double final = t + tip;

                if (arriba)
                {
                    final = Math.Ceiling(final);
                    tip = final - t;
                }
                else if (abajo)
                {
                    final = Math.Floor(final);
                    tip = final - t;
                }

                propinaOutput.Text = tip.ToString("C");
                totalOutput.Text = final.ToString("C");
            }
        }
        void propinaNormal(object sender, EventArgs e) { sliderPorcentaje.Value = 15; }
        void propinaGenerosa(object sender, EventArgs e) { sliderPorcentaje.Value = 20; }
    }

}
