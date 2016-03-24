using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers;
using Twilio.Http;
using Twilio.Resources.Lookups.V1;

namespace Twilio.Fetchers.Lookups.V1 {

    public class PhoneNumberFetcher : Fetcher<PhoneNumberResource> {
        private Twilio.Types.PhoneNumber phoneNumber;
        private string countryCode;
        private string type;
    
        /**
         * Construct a new PhoneNumberFetcher
         * 
         * @param phoneNumber The phone_number
         */
        public PhoneNumberFetcher(Twilio.Types.PhoneNumber phoneNumber) {
            this.phoneNumber = phoneNumber;
        }
    
        /**
         * The country_code
         * 
         * @param countryCode The country_code
         * @return this
         */
        public PhoneNumberFetcher setCountryCode(string countryCode) {
            this.countryCode = countryCode;
            return this;
        }
    
        /**
         * The type
         * 
         * @param type The type
         * @return this
         */
        public PhoneNumberFetcher setType(string type) {
            this.type = type;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Fetched PhoneNumberResource
         */
        public override PhoneNumberResource execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.LOOKUPS,
                "/v1/PhoneNumbers/" + this.phoneNumber + ""
            );
            
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("PhoneNumberResource fetch failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
                RestException restException = RestException.fromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    restException.GetMessage(),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    restException.GetStatus(),
                    null
                );
            }
            
            return PhoneNumberResource.fromJson(response.GetContent());
        }
    }
}