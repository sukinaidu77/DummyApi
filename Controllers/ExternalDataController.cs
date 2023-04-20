using Microsoft.AspNetCore.Mvc;

namespace DummyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExternalDataController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ExternalDataController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("api/Technology/technologies")]
        public async Task<IActionResult> GetTechnologiesData()
        {
            string url = "https://auditapi-test.skillcheck.skillassure.com/api/Technology/technologies";
            try
            {
                HttpClient httpClient = _httpClientFactory.CreateClient();
                HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    return Ok(responseData);
                }
                else
                {
                    throw new Exception("Failed to retrieve data.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving data. Error message: {ex.Message}");
            }
        }
        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync("https://auditapi-test.skillcheck.skillassure.com/api/UserAuditcheck/userAuditCheck");
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                return Ok(responseBody);
            }
            catch (HttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
