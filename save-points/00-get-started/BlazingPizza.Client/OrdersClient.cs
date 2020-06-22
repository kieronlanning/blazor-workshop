using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BlazingPizza.Client
{
	public class OrdersClient
	{
		readonly HttpClient _httpClient;

		public OrdersClient(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public Task<IEnumerable<OrderWithStatus>> GetOrdersAsync(CancellationToken cancellationToken = default) =>
			_httpClient.GetFromJsonAsync<IEnumerable<OrderWithStatus>>("orders", cancellationToken);

		public Task<OrderWithStatus> GetOrderAsync(int orderId, CancellationToken cancellationToken = default) =>
			_httpClient.GetFromJsonAsync<OrderWithStatus>($"orders/{orderId}", cancellationToken);

		async public Task<int> PlaceOrderAsync(Order order, CancellationToken cancellationToken = default)
		{
			var response = await _httpClient.PostAsJsonAsync("orders", order, cancellationToken);
			response.EnsureSuccessStatusCode();

			var orderId = await response.Content.ReadFromJsonAsync<int>();

			return orderId;
		}
	}
}
