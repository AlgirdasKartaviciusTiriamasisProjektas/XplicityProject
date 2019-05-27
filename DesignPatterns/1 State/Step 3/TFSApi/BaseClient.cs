using Microsoft.TeamFoundation.Build.WebApi;
using Microsoft.TeamFoundation.SourceControl.WebApi;
using Microsoft.VisualStudio.Services.Common;
using System;
using System.Net;

namespace TFSApi
{
    public class BaseClient
    {
        private readonly string _collectionUrl;
        private readonly string _username;
        private readonly string _password;

        public BaseClient(string collectionUrl, string username, string password)
        {
            _collectionUrl = collectionUrl;
            _username = username;
            _password = password;
        }

        private VssCredentials GetCredentials()
        {
            return new VssCredentials(new WindowsCredential(new NetworkCredential(_username, _password)));
        }
        private Uri GetUri()
        {
            return new Uri(_collectionUrl, UriKind.Absolute);
        }

        protected GitHttpClient GitHttpClientFactory() => new GitHttpClient(GetUri(), GetCredentials());

        protected BuildHttpClient BuildHttpClientFactory() => new BuildHttpClient(GetUri(), GetCredentials());
    }

}