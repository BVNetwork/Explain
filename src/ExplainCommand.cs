using System;
using System.IO;
using System.Net;
using System.Text;
using EPiServer.Find;
using EPiServer.Find.Api;
using EPiServer.Find.Connection;
using EPiServer.Find.Helpers;
using Newtonsoft.Json;
using EPiServer.Find.Json;

namespace BVNetwork.Explain
{
    public class ExplainCommand : Command
    {
        private readonly string _index;

        public ExplainCommand(ICommandContext commandContext, string index) : base(commandContext)
        {
            _index = index;
        }

        public ExplainResult Explain(ISearch search, string type, string id)
        {
            IJsonRequest request = CommandContext.RequestFactory.CreateRequest(GetUrl(type, id), HttpVerbs.Post, ExplicitRequestTimeout);
            try
            {
                var context = new SearchContext();
                search.ApplyActions(context);
                string requestBody = CommandContext.Serializer.Serialize(context.RequestBody);
                request.WriteBody(requestBody);
                using (var stringReader = new StringReader(request.GetResponse()))
                {
                    ExplainResult explain = CommandContext.Serializer.Deserialize<ExplainResult>(new JsonTextReader(stringReader));
                    return explain;
                }
            }
            catch (WebException ex)
            {
                string message = ex.Message;
                if (ex.Response.IsNotNull())
                {
                    string end = new StreamReader(ex.Response.GetResponseStream(), Encoding.UTF8).ReadToEnd();
                    message = message + Environment.NewLine + end;
                }
                throw new WebException(message, ex);
            }
        }

        private string GetUrl(string type, string id)
        {
            return string.Format("{0}{1}/{2}/{3}/_explain", GetServerUrl(), _index, type, id);
        }
    }
}
