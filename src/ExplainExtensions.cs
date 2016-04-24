using EPiServer.Find;

namespace BVNetwork.Explain
{
    public static class ExplainExtensions
    {
        public static ExplainResult Explain(this IClient client, ISearch search, string type, string id)
        {
            return client.NewCommand(context => new ExplainCommand(context, client.DefaultIndex)).Explain(search, type, id);
        }
    }
}
