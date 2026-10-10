using Microsoft.Maui.Media;
using Plugin.Maui.Audio;

namespace JUEGOCONEJITOSMAGICOS
{
    /// <summary>
    /// Reproduce la narracion de los cuentos.
    /// 1) Si existe el archivo de audio (Resources\Raw) lo reproduce.
    /// 2) Si no existe, usa la voz del dispositivo con TextToSpeech
    ///    (voz IA incluida en el sistema operativo).
    /// De esta forma los cuentos siempre pueden ser "narrados por una voz".
    /// </summary>
    public class NarrationService
    {
        private readonly IAudioManager _audioManager;
        private IAudioPlayer? _player;
        private CancellationTokenSource? _cts;

        public NarrationService(IAudioManager audioManager)
        {
            _audioManager = audioManager;
        }

        /// <summary>
        /// Reproduce la narracion de un cuento.
        /// </summary>
        /// <param name="fileName">Nombre del mp3 en Resources\Raw (opcional).</param>
        /// <param name="textoRespaldo">Texto que se lee con la voz del dispositivo si no hay mp3.</param>
        public async Task PlayNarrationAsync(string fileName, string textoRespaldo)
        {
            await StopNarrationAsync();

            try
            {
                var stream = await FileSystem.OpenAppPackageFileAsync(fileName);
                _player = _audioManager.CreatePlayer(stream);
                _player.Volume = 1.0;
                _player.Play();
            }
            catch
            {
                // No hay mp3 de narracion: usamos la voz IA del dispositivo.
                _cts = new CancellationTokenSource();
                await TextToSpeech.SpeakAsync(
                    textoRespaldo,
                    new SpeechOptions { Volume = 1f, Pitch = 1.05f, Rate = 0.9f },
                    _cts.Token);
            }
        }

        /// <summary>Detiene la narracion en curso.</summary>
        public Task StopNarrationAsync()
        {
            _player?.Stop();
            _cts?.Cancel();
            return Task.CompletedTask;
        }
    }
}
