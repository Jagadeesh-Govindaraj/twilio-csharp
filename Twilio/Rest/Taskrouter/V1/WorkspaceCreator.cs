using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Taskrouter.V1 {

    public class WorkspaceCreator : Creator<WorkspaceResource> {
        public string friendlyName { get; }
        public Uri eventCallbackUrl { get; set; }
        public string eventsFilter { get; set; }
        public bool? multiTaskEnabled { get; set; }
        public string template { get; set; }
    
        /// <summary>
        /// Construct a new WorkspaceCreator
        /// </summary>
        ///
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="eventCallbackUrl"> The event_callback_url </param>
        /// <param name="eventsFilter"> The events_filter </param>
        /// <param name="multiTaskEnabled"> The multi_task_enabled </param>
        /// <param name="template"> The template </param>
        public WorkspaceCreator(string friendlyName, Uri eventCallbackUrl=null, string eventsFilter=null, bool? multiTaskEnabled=null, string template=null) {
            this.friendlyName = friendlyName;
            this.eventCallbackUrl = eventCallbackUrl;
            this.multiTaskEnabled = multiTaskEnabled;
            this.template = template;
            this.eventsFilter = eventsFilter;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created WorkspaceResource </returns> 
        public override async Task<WorkspaceResource> CreateAsync(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.POST,
                Domains.TASKROUTER,
                "/v1/Workspaces"
            );
            
            AddPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("WorkspaceResource creation failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to create record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return WorkspaceResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created WorkspaceResource </returns> 
        public override WorkspaceResource Create(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.POST,
                Domains.TASKROUTER,
                "/v1/Workspaces"
            );
            
            AddPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("WorkspaceResource creation failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to create record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return WorkspaceResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request) {
            if (friendlyName != null) {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (eventCallbackUrl != null) {
                request.AddPostParam("EventCallbackUrl", eventCallbackUrl.ToString());
            }
            
            if (eventsFilter != null) {
                request.AddPostParam("EventsFilter", eventsFilter);
            }
            
            if (multiTaskEnabled != null) {
                request.AddPostParam("MultiTaskEnabled", multiTaskEnabled.ToString());
            }
            
            if (template != null) {
                request.AddPostParam("Template", template);
            }
        }
    }
}