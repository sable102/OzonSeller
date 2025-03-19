
namespace OzonSeller.Core.ApiClient
{
	public interface IOzonApiClient
	{
		Task<T> PostAsync<T>(string endpoint, object requestData);
		Task Test();
	}
}