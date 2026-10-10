namespace JUEGOCONEJITOSMAGICOS;

public partial class FinalPage : ContentPage
{
    public FinalPage()
    {
        InitializeComponent();
    }

    // Musica de fondo de la seccion de creditos
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await App.AudioService.PlayBackgroundMusicAsync("musica_reflexion.mp3");
    }
}
