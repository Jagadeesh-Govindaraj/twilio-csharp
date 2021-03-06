using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Api.V2010.Account 
{

    /// <summary>
    /// ConnectAppResource
    /// </summary>
    public class ConnectAppResource : Resource 
    {
        public sealed class PermissionEnum : StringEnum 
        {
            private PermissionEnum(string value) : base(value) {}
            public PermissionEnum() {}

            public static readonly PermissionEnum GetAll = new PermissionEnum("get-all");
            public static readonly PermissionEnum PostAll = new PermissionEnum("post-all");
        }

        private static Request BuildFetchRequest(FetchConnectAppOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.PathAccountSid ?? client.AccountSid) + "/ConnectApps/" + options.PathSid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// Fetch an instance of a connect-app
        /// </summary>
        ///
        /// <param name="options"> Fetch ConnectApp parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ConnectApp </returns> 
        public static ConnectAppResource Fetch(FetchConnectAppOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Fetch an instance of a connect-app
        /// </summary>
        ///
        /// <param name="options"> Fetch ConnectApp parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ConnectApp </returns> 
        public static async System.Threading.Tasks.Task<ConnectAppResource> FetchAsync(FetchConnectAppOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Fetch an instance of a connect-app
        /// </summary>
        ///
        /// <param name="pathSid"> Fetch by unique connect-app Sid </param>
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ConnectApp </returns> 
        public static ConnectAppResource Fetch(string pathSid, string pathAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchConnectAppOptions(pathSid){PathAccountSid = pathAccountSid};
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary>
        /// Fetch an instance of a connect-app
        /// </summary>
        ///
        /// <param name="pathSid"> Fetch by unique connect-app Sid </param>
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ConnectApp </returns> 
        public static async System.Threading.Tasks.Task<ConnectAppResource> FetchAsync(string pathSid, string pathAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchConnectAppOptions(pathSid){PathAccountSid = pathAccountSid};
            return await FetchAsync(options, client);
        }
        #endif

        private static Request BuildUpdateRequest(UpdateConnectAppOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.PathAccountSid ?? client.AccountSid) + "/ConnectApps/" + options.PathSid + ".json",
                client.Region,
                postParams: options.GetParams()
            );
        }

        /// <summary>
        /// Update a connect-app with the specified parameters
        /// </summary>
        ///
        /// <param name="options"> Update ConnectApp parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ConnectApp </returns> 
        public static ConnectAppResource Update(UpdateConnectAppOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Update a connect-app with the specified parameters
        /// </summary>
        ///
        /// <param name="options"> Update ConnectApp parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ConnectApp </returns> 
        public static async System.Threading.Tasks.Task<ConnectAppResource> UpdateAsync(UpdateConnectAppOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Update a connect-app with the specified parameters
        /// </summary>
        ///
        /// <param name="pathSid"> The sid </param>
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="authorizeRedirectUrl"> URIL Twilio sends requests when users authorize </param>
        /// <param name="companyName"> The company name set for this Connect App. </param>
        /// <param name="deauthorizeCallbackMethod"> HTTP method Twilio WIll use making requests to the url </param>
        /// <param name="deauthorizeCallbackUrl"> URL Twilio will send a request when a user de-authorizes this app </param>
        /// <param name="description"> A more detailed human readable description </param>
        /// <param name="friendlyName"> A human readable name for the Connect App. </param>
        /// <param name="homepageUrl"> The URL users can obtain more information </param>
        /// <param name="permissions"> The set of permissions that your ConnectApp requests. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ConnectApp </returns> 
        public static ConnectAppResource Update(string pathSid, string pathAccountSid = null, Uri authorizeRedirectUrl = null, string companyName = null, Twilio.Http.HttpMethod deauthorizeCallbackMethod = null, Uri deauthorizeCallbackUrl = null, string description = null, string friendlyName = null, Uri homepageUrl = null, List<ConnectAppResource.PermissionEnum> permissions = null, ITwilioRestClient client = null)
        {
            var options = new UpdateConnectAppOptions(pathSid){PathAccountSid = pathAccountSid, AuthorizeRedirectUrl = authorizeRedirectUrl, CompanyName = companyName, DeauthorizeCallbackMethod = deauthorizeCallbackMethod, DeauthorizeCallbackUrl = deauthorizeCallbackUrl, Description = description, FriendlyName = friendlyName, HomepageUrl = homepageUrl, Permissions = permissions};
            return Update(options, client);
        }

        #if !NET35
        /// <summary>
        /// Update a connect-app with the specified parameters
        /// </summary>
        ///
        /// <param name="pathSid"> The sid </param>
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="authorizeRedirectUrl"> URIL Twilio sends requests when users authorize </param>
        /// <param name="companyName"> The company name set for this Connect App. </param>
        /// <param name="deauthorizeCallbackMethod"> HTTP method Twilio WIll use making requests to the url </param>
        /// <param name="deauthorizeCallbackUrl"> URL Twilio will send a request when a user de-authorizes this app </param>
        /// <param name="description"> A more detailed human readable description </param>
        /// <param name="friendlyName"> A human readable name for the Connect App. </param>
        /// <param name="homepageUrl"> The URL users can obtain more information </param>
        /// <param name="permissions"> The set of permissions that your ConnectApp requests. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ConnectApp </returns> 
        public static async System.Threading.Tasks.Task<ConnectAppResource> UpdateAsync(string pathSid, string pathAccountSid = null, Uri authorizeRedirectUrl = null, string companyName = null, Twilio.Http.HttpMethod deauthorizeCallbackMethod = null, Uri deauthorizeCallbackUrl = null, string description = null, string friendlyName = null, Uri homepageUrl = null, List<ConnectAppResource.PermissionEnum> permissions = null, ITwilioRestClient client = null)
        {
            var options = new UpdateConnectAppOptions(pathSid){PathAccountSid = pathAccountSid, AuthorizeRedirectUrl = authorizeRedirectUrl, CompanyName = companyName, DeauthorizeCallbackMethod = deauthorizeCallbackMethod, DeauthorizeCallbackUrl = deauthorizeCallbackUrl, Description = description, FriendlyName = friendlyName, HomepageUrl = homepageUrl, Permissions = permissions};
            return await UpdateAsync(options, client);
        }
        #endif

        private static Request BuildReadRequest(ReadConnectAppOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.PathAccountSid ?? client.AccountSid) + "/ConnectApps.json",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// Retrieve a list of connect-apps belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="options"> Read ConnectApp parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ConnectApp </returns> 
        public static ResourceSet<ConnectAppResource> Read(ReadConnectAppOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));

            var page = Page<ConnectAppResource>.FromJson("connect_apps", response.Content);
            return new ResourceSet<ConnectAppResource>(page, options, client);
        }

        #if !NET35
        /// <summary>
        /// Retrieve a list of connect-apps belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="options"> Read ConnectApp parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ConnectApp </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<ConnectAppResource>> ReadAsync(ReadConnectAppOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<ConnectAppResource>.FromJson("connect_apps", response.Content);
            return new ResourceSet<ConnectAppResource>(page, options, client);
        }
        #endif

        /// <summary>
        /// Retrieve a list of connect-apps belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ConnectApp </returns> 
        public static ResourceSet<ConnectAppResource> Read(string pathAccountSid = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadConnectAppOptions{PathAccountSid = pathAccountSid, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary>
        /// Retrieve a list of connect-apps belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ConnectApp </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<ConnectAppResource>> ReadAsync(string pathAccountSid = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadConnectAppOptions{PathAccountSid = pathAccountSid, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        /// <summary>
        /// Fetch the next page of records
        /// </summary>
        ///
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns> 
        public static Page<ConnectAppResource> NextPage(Page<ConnectAppResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Api,
                    client.Region
                )
            );

            var response = client.Request(request);
            return Page<ConnectAppResource>.FromJson("connect_apps", response.Content);
        }

        /// <summary>
        /// Converts a JSON string into a ConnectAppResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ConnectAppResource object represented by the provided JSON </returns> 
        public static ConnectAppResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<ConnectAppResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

        /// <summary>
        /// The unique sid that identifies this account
        /// </summary>
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        /// <summary>
        /// URIL Twilio sends requests when users authorize
        /// </summary>
        [JsonProperty("authorize_redirect_url")]
        public Uri AuthorizeRedirectUrl { get; private set; }
        /// <summary>
        /// The company name set for this Connect App.
        /// </summary>
        [JsonProperty("company_name")]
        public string CompanyName { get; private set; }
        /// <summary>
        /// HTTP method Twilio WIll use making requests to the url
        /// </summary>
        [JsonProperty("deauthorize_callback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod DeauthorizeCallbackMethod { get; private set; }
        /// <summary>
        /// URL Twilio will send a request when a user de-authorizes this app
        /// </summary>
        [JsonProperty("deauthorize_callback_url")]
        public Uri DeauthorizeCallbackUrl { get; private set; }
        /// <summary>
        /// A more detailed human readable description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; private set; }
        /// <summary>
        /// A human readable name for the Connect App.
        /// </summary>
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        /// <summary>
        /// The URL users can obtain more information
        /// </summary>
        [JsonProperty("homepage_url")]
        public Uri HomepageUrl { get; private set; }
        /// <summary>
        /// The set of permissions that your ConnectApp requests.
        /// </summary>
        [JsonProperty("permissions")]
        [JsonConverter(typeof(StringEnumConverter))]
        public List<ConnectAppResource.PermissionEnum> Permissions { get; private set; }
        /// <summary>
        /// A string that uniquely identifies this connect-apps
        /// </summary>
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        /// <summary>
        /// The URI for this resource
        /// </summary>
        [JsonProperty("uri")]
        public string Uri { get; private set; }

        private ConnectAppResource()
        {

        }
    }

}