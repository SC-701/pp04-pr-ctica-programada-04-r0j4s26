using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Text.Json;


namespace Servicios
{
    public class RevisionServicio : IRevisionServicio
    {
        private readonly IConfiguracion _configuracion;
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<RevisionServicio> _logger;

        public RevisionServicio(IConfiguracion configuracion, IHttpClientFactory httpClient, ILogger<RevisionServicio> logger)
        {
            _configuracion = configuracion;
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<Revision> Obtener(string placa)
        {
            try
            {
                var endpoint = _configuracion.ObtenerMetodo("ApiEndPointsRevision", "ObtenerRevision");
                var servicioRevision = _httpClient.CreateClient("ServicioRevision");
                var respuesta = await servicioRevision.GetAsync(string.Format(endpoint, placa));
                respuesta.EnsureSuccessStatusCode();
                var resultado = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var resultadoDeserializado = JsonSerializer.Deserialize<List<Revision>>(resultado, opciones);
                return resultadoDeserializado.FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar el registro");
                return null;
            }

        }
    }
}
