using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Ocelot.Configuration;
using Ocelot.Middleware;
using Ocelot.Multiplexer;
using System.Net;
using System.Net.Http.Headers;

namespace OcelotApiGateway;

public class FakeDefinedAggregator : IDefinedAggregator
{
    public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
    {

        var postsByUserName = new JObject();

        foreach (var response in responses)
        {
            var downStreamRouteKey = ((DownstreamRoute)response.Items["DownstreamRoute"]).Key;
            var downstreamResponse = (DownstreamResponse)response.Items["DownstreamResponse"];

            var downstreamResponseContent = await downstreamResponse.Content.ReadAsByteArrayAsync();

            var downstreamResponseContentString = System.Text.Encoding.Default.GetString(downstreamResponseContent);

            postsByUserName.Add(new JProperty(downStreamRouteKey, downstreamResponseContentString));
        }

        var postsByUsernameString = JsonConvert.SerializeObject(postsByUserName);

        var stringContent = new StringContent(postsByUsernameString)
        {
            Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
        };

        return new DownstreamResponse(stringContent, HttpStatusCode.OK, new List<KeyValuePair<string, IEnumerable<string>>>(), "OK");
    }
}
