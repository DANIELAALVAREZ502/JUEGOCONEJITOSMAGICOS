namespace JUEGOCONEJITOSMAGICOS;

public partial class LogrosPage : ContentPage
{
    public LogrosPage()
    {
        InitializeComponent();
    }

    // Muestra los logros y los puntos totales
    protected override void OnAppearing()
    {
        base.OnAppearing();
        LblPuntosTotales.Text = $"Puntos totales: {App.Progreso.PuntosTotales}";

        StackLogros.Children.Clear();

        if (App.Progreso.Logros.Count == 0)
        {
            StackLogros.Children.Add(new Label
            {
                Text = "Aun no tienes logros... Juega para desbloquearlos!",
                TextColor = Colors.White,
                HorizontalTextAlignment = TextAlignment.Center
            });
            return;
        }

        foreach (var logro in App.Progreso.Logros)
        {
            StackLogros.Children.Add(new Label
            {
                Text = $"{logro}",
                TextColor = Colors.White,
                FontSize = 16,
                Padding = new Thickness(4)
            });
        }
    }
}
