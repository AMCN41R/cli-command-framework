using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EPR.CLI.Core.Common
{
    internal class RequestBuilder : IRequestBuilder, IRequestBuilderMethod, IRequestBuilderHeadersBodySend
    {
        public RequestBuilder()
        {
            this.Client = new HttpClient();
        }

        private RequestBuilder(HttpClient client, HttpRequestMessage request)
        {
            this.Client = client;
            this.Request = request;
        }

        // ReSharper disable once MemberInitializerValueIgnored
        protected HttpClient Client { get; }

        protected HttpRequestMessage Request { get; }

        public IRequestBuilderMethod WithUrl(string url)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(url)
            };

            return new RequestBuilder(this.Client, request);
        }

        async Task<TResult> IRequestBuilderHeadersBodySend.SendAsync<TResult>()
        {
            var response = await this.Client.SendAsync(this.Request);
            var result = await response.Content.ReadAsAsync<TResult>();
            return result;
        }

        IRequestBuilderHeadersBodySend IRequestBuilderHeadersBodySend.WithBody<T>(T body)
        {
            var json = JsonConvert.SerializeObject(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            this.Request.Content = content;
            return this;
        }

        IRequestBuilderHeadersBodySend IRequestBuilderHeadersBodySend.WithHeader(string header, string value)
        {
            this.Request.Headers.Add(header, value);
            return this;
        }

        IRequestBuilderHeadersBodySend IRequestBuilderHeadersBodySend.WithHeader(params KeyValuePair<string, string>[] headers)
        {

            foreach (var kvp in headers)
            {
                this.Request.Headers.Add(kvp.Key, kvp.Value);
            }

            return this;
        }

        Task<HttpResponseMessage> IRequestBuilderHeadersBodySend.SendAsync() => this.Client.SendAsync(this.Request);

        public IRequestBuilderHeadersBodySend WithMethod(HttpMethod method)
        {
            this.Request.Method = method;
            return this;
        }
    }

    public interface IRequestBuilder
    {
        IRequestBuilderMethod WithUrl(string url);
    }

    public interface IRequestBuilderMethod
    {
        IRequestBuilderHeadersBodySend WithMethod(HttpMethod method);
    }

    public interface IRequestBuilderHeadersBodySend
    {
        IRequestBuilderHeadersBodySend WithHeader(string header, string value);

        IRequestBuilderHeadersBodySend WithHeader(params KeyValuePair<string, string>[] headers);

        IRequestBuilderHeadersBodySend WithBody<T>(T body) where T : class;

        Task<TResult> SendAsync<TResult>();

        Task<HttpResponseMessage> SendAsync();
    }
}