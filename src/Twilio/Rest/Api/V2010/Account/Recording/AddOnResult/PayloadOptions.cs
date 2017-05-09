using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account.Recording.AddOnResult 
{

    /// <summary>
    /// Fetch an instance of a result payload
    /// </summary>
    public class FetchPayloadOptions : IOptions<PayloadResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string PathAccountSid { get; set; }
        /// <summary>
        /// The reference_sid
        /// </summary>
        public string PathReferenceSid { get; }
        /// <summary>
        /// The add_on_result_sid
        /// </summary>
        public string PathAddOnResultSid { get; }
        /// <summary>
        /// Fetch by unique payload Sid
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new FetchPayloadOptions
        /// </summary>
        ///
        /// <param name="pathReferenceSid"> The reference_sid </param>
        /// <param name="pathAddOnResultSid"> The add_on_result_sid </param>
        /// <param name="pathSid"> Fetch by unique payload Sid </param>
        public FetchPayloadOptions(string pathReferenceSid, string pathAddOnResultSid, string pathSid)
        {
            PathReferenceSid = pathReferenceSid;
            PathAddOnResultSid = pathAddOnResultSid;
            PathSid = pathSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    /// <summary>
    /// Retrieve a list of payloads belonging to the Add-on result
    /// </summary>
    public class ReadPayloadOptions : ReadOptions<PayloadResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string PathAccountSid { get; set; }
        /// <summary>
        /// The reference_sid
        /// </summary>
        public string PathReferenceSid { get; }
        /// <summary>
        /// The add_on_result_sid
        /// </summary>
        public string PathAddOnResultSid { get; }

        /// <summary>
        /// Construct a new ReadPayloadOptions
        /// </summary>
        ///
        /// <param name="pathReferenceSid"> The reference_sid </param>
        /// <param name="pathAddOnResultSid"> The add_on_result_sid </param>
        public ReadPayloadOptions(string pathReferenceSid, string pathAddOnResultSid)
        {
            PathReferenceSid = pathReferenceSid;
            PathAddOnResultSid = pathAddOnResultSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }

            return p;
        }
    }

    /// <summary>
    /// Delete a payload from the result along with all associated Data
    /// </summary>
    public class DeletePayloadOptions : IOptions<PayloadResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string PathAccountSid { get; set; }
        /// <summary>
        /// The reference_sid
        /// </summary>
        public string PathReferenceSid { get; }
        /// <summary>
        /// The add_on_result_sid
        /// </summary>
        public string PathAddOnResultSid { get; }
        /// <summary>
        /// Delete by unique payload Sid
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new DeletePayloadOptions
        /// </summary>
        ///
        /// <param name="pathReferenceSid"> The reference_sid </param>
        /// <param name="pathAddOnResultSid"> The add_on_result_sid </param>
        /// <param name="pathSid"> Delete by unique payload Sid </param>
        public DeletePayloadOptions(string pathReferenceSid, string pathAddOnResultSid, string pathSid)
        {
            PathReferenceSid = pathReferenceSid;
            PathAddOnResultSid = pathAddOnResultSid;
            PathSid = pathSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

}