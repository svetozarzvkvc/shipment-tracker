using ShipmentTracker.Application.DTO;
using ShipmentTracker.Domain;
using ShipmentTracker.UI.Pages;
using System.Net.Http.Json;

namespace ShipmentTracker.UI.Services
{
    public class ShipmentService(HttpClient httpClient)
    {
        public async Task <IEnumerable<ShipmentDto>> GetAllShiplments(ShipmentSearchDto search)
        {
            return await httpClient.GetFromJsonAsync<List<ShipmentDto>>($"api/shipments?ShipmentName={search.ShipmentName}&Status={search.Status}");
        }
        public async Task<bool> DeleteShipment(Guid id)
        {
            var response = await httpClient.DeleteAsync($"api/shipments/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<ShipmentDto> GetShipmentById(Guid id)
        {
            return await httpClient.GetFromJsonAsync<ShipmentDto>($"api/shipments/{id}");
        }

        public async Task InsertShipment(CreateShipmentDto shipment)
        {
            await httpClient.PostAsJsonAsync("api/shipments", shipment);
        }

        public async Task UpdateShipment(UpdateShipmentDto shipment)
        {
            await httpClient.PutAsJsonAsync($"api/shipments/{shipment.Id}", shipment);
        }
    }
}
