using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Devices.Sensors;
using Microsoft.Maui.Maps;

namespace Mapa_Celular
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Define las coordenadas de la ubicación en la que quieres centrar el mapa
            var centerPosition = new Location(25.67609159748798, -100.32119338807044); // Coordenadas de Monterrey

            // Define la región del mapa, centrada en la posición anterior y con un radio de visualización de 5 km
            map.MoveToRegion(MapSpan.FromCenterAndRadius(centerPosition, Distance.FromKilometers(5)));

            // Crear el pin
            var pinAlameda = new Pin
            {
                Label = "Alameda Monterrey",
                Address = "Parque de MTY",
                Type = PinType.Place,
                Location = new Location(25.67609159748798, -100.32119338807044)
            };

            var pinCafe = new Pin
            {
                Label = "Café Nuevo León",
                Address = "Av. Constitución, Monterrey",
                Type = PinType.Place,
                Location = new Location(25.686269204977087, -100.31651165006096)
            };

            var pinFundidora = new Pin
            {
                Label = "Parque Fundidora",
                Address = "Fundidora, Monterrey",
                Type = PinType.Place,
                Location = new Location(25.6782215, -100.2888646)
            };

            // Suscribir el evento PinClicked
            pinAlameda.MarkerClicked += OnPinClicked;
            pinCafe.MarkerClicked += OnPinClicked;
            pinFundidora.MarkerClicked += OnPinClicked;

            // Agregar el pin al mapa
            map.Pins.Add(pinAlameda);
            map.Pins.Add(pinCafe);
            map.Pins.Add(pinFundidora);

        }
        // Método que maneja el evento PinClicked
   
        private async void OnPinClicked(object sender, PinClickedEventArgs e)
        {
            var clickedPin = sender as Pin;

            // Verificar cuál pin fue clicado y abrir la página correspondiente
            if (clickedPin.Label == "Alameda Monterrey")
            {
                await Navigation.PushModalAsync(new ImagenPage()); // Abrir página de Alameda
            }
            else if (clickedPin.Label == "Café Nuevo León")
            {
                await Navigation.PushModalAsync(new ImagenCafe()); // Abrir página del Café Nuevo León
            }
            else if (clickedPin.Label == "Parque Fundidora")
            {
                await Navigation.PushModalAsync(new ImagenFundidora()); // Abrir página del Café Nuevo León
            }

            // Evita mostrar la ventana de información predeterminada
            e.HideInfoWindow = true;
        }



    }
}