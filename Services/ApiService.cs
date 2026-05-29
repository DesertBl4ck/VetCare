using System.Net.Http.Json;
using VetCare.Models;

namespace VetCare.Services;

public class ApiService
{
    private readonly HttpClient _http;
    private const string BASE = "https://api-udec-pweb-aedec9hxbugye0am.westus3-01.azurewebsites.net";

    public ApiService(HttpClient http)
    {
        _http = http;
        _http.BaseAddress = new Uri(BASE);
    }

    public async Task<List<ServicioApi>?> GetServiciosAsync()
    {
        try
        {
            return await _http.GetFromJsonAsync<List<ServicioApi>>("/api/salud/servicios");
        }
        catch
        {
            return null;
        }
    }

    public async Task<List<ServicioApi>?> GetServiciosPorEspecialidadAsync(int especialidadId)
    {
        try
        {
            return await _http.GetFromJsonAsync<List<ServicioApi>>(
                $"/api/salud/servicios/especialidad/{especialidadId}");
        }
        catch
        {
            return null;
        }
    }

    public async Task<List<EspecialidadApi>?> GetEspecialidadesAsync()
    {
        try
        {
            return await _http.GetFromJsonAsync<List<EspecialidadApi>>("/api/salud/especialidades");
        }
        catch
        {
            return null;
        }
    }
}