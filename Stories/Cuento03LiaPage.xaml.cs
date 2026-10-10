namespace JUEGOCONEJITOSMAGICOS.Stories;

public partial class Cuento03LiaPage : ContentPage
{
    public Cuento03LiaPage()
    {
        InitializeComponent();
    }

    // Musica de fondo de los cuentos
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await App.AudioService.PlayBackgroundMusicAsync("musica_bosque.mp3");
    }

    // Voz para el cuento interactivo
    private async void OnNarrarClicked(object? sender, EventArgs e)
    {
        await App.NarrationService.PlayNarrationAsync(
            "narracion_decision.mp3",
            "Lia encontro una fruta muy especial y deliciosa. Bambi esta a su lado y tambien tiene " +
            "hambre. Compartir hace feliz a los amigos. Que deberia hacer Lia?");
    }

    private void OnStopClicked(object? sender, EventArgs e)
        => App.NarrationService.StopNarrationAsync();

    // Opcion correcta: compartir
    private async void OnOpcionA_Clicked(object? sender, EventArgs e)
    {
        App.Progreso.DesbloquearLogro("Solidario con los amigos");
        await DisplayAlertAsync("Excelente decision!",
            "Compartir muestra amabilidad y solidaridad. Bambi esta muy feliz.", "Continuar");
        await Shell.Current.GoToAsync(nameof(ReflexionPage));
    }

    // Opcion incorrecta: guardar la fruta
    private async void OnOpcionB_Clicked(object? sender, EventArgs e)
    {
        await DisplayAlertAsync("Intentalo de nuevo",
            "Guardar todo para uno mismo no hace feliz a nadie. Compartir es un acto de amor.",
            "Reintentar");
    }
}
