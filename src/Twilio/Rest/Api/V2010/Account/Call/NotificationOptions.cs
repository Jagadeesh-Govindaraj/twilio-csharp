using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account.Call 
{

    /// <summary>
    /// FetchNotificationOptions
    /// </summary>
    public class FetchNotificationOptions : IOptions<NotificationResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string PathAccountSid { get; set; }
        /// <summary>
        /// The call_sid
        /// </summary>
        public string PathCallSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new FetchNotificationOptions
        /// </summary>
        ///
        /// <param name="pathCallSid"> The call_sid </param>
        /// <param name="pathSid"> The sid </param>
        public FetchNotificationOptions(string pathCallSid, string pathSid)
        {
            PathCallSid = pathCallSid;
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
    /// DeleteNotificationOptions
    /// </summary>
    public class DeleteNotificationOptions : IOptions<NotificationResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string PathAccountSid { get; set; }
        /// <summary>
        /// The call_sid
        /// </summary>
        public string PathCallSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new DeleteNotificationOptions
        /// </summary>
        ///
        /// <param name="pathCallSid"> The call_sid </param>
        /// <param name="pathSid"> The sid </param>
        public DeleteNotificationOptions(string pathCallSid, string pathSid)
        {
            PathCallSid = pathCallSid;
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
    /// ReadNotificationOptions
    /// </summary>
    public class ReadNotificationOptions : ReadOptions<NotificationResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string PathAccountSid { get; set; }
        /// <summary>
        /// The call_sid
        /// </summary>
        public string PathCallSid { get; }
        /// <summary>
        /// The log
        /// </summary>
        public int? Log { get; set; }
        /// <summary>
        /// The message_date
        /// </summary>
        public DateTime? MessageDateBefore { get; set; }
        /// <summary>
        /// The message_date
        /// </summary>
        public DateTime? MessageDate { get; set; }
        /// <summary>
        /// The message_date
        /// </summary>
        public DateTime? MessageDateAfter { get; set; }

        /// <summary>
        /// Construct a new ReadNotificationOptions
        /// </summary>
        ///
        /// <param name="pathCallSid"> The call_sid </param>
        public ReadNotificationOptions(string pathCallSid)
        {
            PathCallSid = pathCallSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Log != null)
            {
                p.Add(new KeyValuePair<string, string>("Log", Log.Value.ToString()));
            }

            if (MessageDate != null)
            {
                p.Add(new KeyValuePair<string, string>("MessageDate", MessageDate.Value.ToString("yyyy-MM-dd")));
            }
            else
            {
                if (MessageDateBefore != null)
                {
                    p.Add(new KeyValuePair<string, string>("MessageDate<", MessageDateBefore.Value.ToString("yyyy-MM-dd")));
                }

                if (MessageDateAfter != null)
                {
                    p.Add(new KeyValuePair<string, string>("MessageDate>", MessageDateAfter.Value.ToString("yyyy-MM-dd")));
                }
            }

            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }

            return p;
        }
    }

}