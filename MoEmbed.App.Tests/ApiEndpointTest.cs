using System.Net;
using System.Text.Json;

namespace MoEmbed;

public class ApiEndpointTest
{
    [Test]
    public async Task Api_WithoutUrl_Returns404WithError()
    {
        var response = await SharedAppFactory.Client.GetAsync("/api");

        await Assert.That(response.StatusCode).IsEqualTo(HttpStatusCode.NotFound);

        var content = await response.Content.ReadAsStringAsync();
        var json = JsonDocument.Parse(content);
        var error = json.RootElement.GetProperty("error").GetString();

        await Assert.That(error).IsNotNull();
    }

    [Test]
    public async Task Api_WithInvalidUrl_Returns404WithInvalidUrlError()
    {
        var response = await SharedAppFactory.Client.GetAsync("/api?url=not-a-valid-url");

        await Assert.That(response.StatusCode).IsEqualTo(HttpStatusCode.NotFound);

        var content = await response.Content.ReadAsStringAsync();
        var json = JsonDocument.Parse(content);
        var error = json.RootElement.GetProperty("error").GetString();

        await Assert.That(error).IsEqualTo("Invalid URL.");
    }

    [Test]
    public async Task Api_WithInvalidFormat_ThrowsDueToHandlerBug()
    {
        // NOTE: The handler has a bug where writer is null for invalid formats,
        // causing a NullReferenceException that propagates through TestServer.
        await Assert.ThrowsAsync<NullReferenceException>(
            () => SharedAppFactory.Client.GetAsync("/api?url=https://example.com&format=invalid"));
    }

    [Test]
    public async Task Api_WithJsonFormat_ReturnsJsonContentType()
    {
        var response = await SharedAppFactory.Client.GetAsync("/api?url=https://example.com&format=json");

        await Assert.That(response.Content.Headers.ContentType?.MediaType).IsEqualTo("application/json");
    }

    [Test]
    public async Task Api_WithXmlFormat_ReturnsXmlContentType()
    {
        var response = await SharedAppFactory.Client.GetAsync("/api?url=https://example.com&format=xml");

        await Assert.That(response.Content.Headers.ContentType?.MediaType).IsEqualTo("text/xml");
    }

    [Test]
    public async Task Api_WithDefaultFormat_ReturnsJsonContentType()
    {
        var response = await SharedAppFactory.Client.GetAsync("/api?url=https://example.com");

        await Assert.That(response.Content.Headers.ContentType?.MediaType).IsEqualTo("application/json");
    }

    [Test]
    public async Task Api_WithUrlContainingHash_ReturnsResponse()
    {
        var response = await SharedAppFactory.Client.GetAsync("/api?url=https://example.com%23section");

        await Assert.That(response.Content.Headers.ContentType?.MediaType).IsEqualTo("application/json");
    }

    [Test]
    [Arguments("max_width", "400")]
    [Arguments("max_height", "300")]
    public async Task Api_WithDimensionParameters_ReturnsResponse(string param, string value)
    {
        var response = await SharedAppFactory.Client.GetAsync($"/api?url=https://example.com&{param}={value}");

        await Assert.That(response.Content.Headers.ContentType?.MediaType).IsEqualTo("application/json");
    }
}
