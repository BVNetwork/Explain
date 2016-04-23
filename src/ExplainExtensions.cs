using EPiServer.Find;

namespace BVNetwork.Explain
{
    public static class ExplainExtensions
    {
        //public static object Explain(this IClient client, ISearch search, IContent content)
        //{
        //    var type = content.GetOriginalType().FullName.Replace('.', '_');
        //    var indexId = content.GetIndexId();
        //    return client.NewCommand(context => new ExplainCommand(context, client.DefaultIndex)).Explain(search, type, indexId);
        //}

        public static object Explain(this IClient client, ISearch search, string type, string id)
        {
            return client.NewCommand(context => new ExplainCommand(context, client.DefaultIndex)).Explain(search, type, id);
        }
    }
}
