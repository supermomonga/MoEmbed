using System.Net;

namespace MoEmbed;

public class RootEndpointTest
{
    [Test]
    public async Task Root_ReturnsHtml()
    {
        var response = await SharedAppFactory.Client.GetAsync("/");

        await Assert.That(response.StatusCode).IsEqualTo(HttpStatusCode.OK);
        await Assert.That(response.Content.Headers.ContentType?.MediaType).IsEqualTo("text/html");
    }

    [Test]
    public async Task Root_ReturnsIndexHtmlContent()
    {
        var response = await SharedAppFactory.Client.GetAsync("/");
        var content = await response.Content.ReadAsStringAsync();

        await Assert.That(content).Contains("<html");
    }
}
