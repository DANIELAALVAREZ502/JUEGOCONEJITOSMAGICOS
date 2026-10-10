namespace JUEGOCONEJITOSMAGICOS;

public partial class ReflexionPage : ContentPage
{
    public ReflexionPage()
    {
        InitializeComponent();
    }

    // Musica de fondo de la seccion de reflexion
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await App.AudioService.PlayBackgroundMusicAsync("musica_reflexion.mp3");
    }

    // Voz del mensaje del Sabio Buho
    private async void OnNarrarClicked(object? sender, EventArgs e)
    {
        await App.NarrationService.PlayNarrationAsync(
            "narracion_reflexion.mp3",
            "Practicar buenos valores nos convierte en mejores personas cada dia. " +
            "Se amable, agradece, respeta y comparte.");
    }

    private void OnStopClicked(object? sender, EventArgs e)
        => App.NarrationService.StopNarrationAsync();

    private async void OnAprenderClicked(object? sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(AprendizajePage));
}
