namespace JUEGOCONEJITOSMAGICOS;

public partial class PersonajesPage : ContentPage
{
    public PersonajesPage()
    {
        InitializeComponent();
    }

    // Musica de fondo de la seccion "Personajes"
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await App.AudioService.PlayBackgroundMusicAsync("musica_bosque.mp3");
    }

    private async void OnAprendizajeClicked(object? sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(AprendizajePage));
}
