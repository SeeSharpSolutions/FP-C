using AstuteServiceReference;
using FP_C.API.Models;

namespace FP_C.API.Common
{
    public class MyCommon
    {
        private static Dictionary<string,string> _ResultCodes;
        public static Dictionary<string, string> ResultCodes
        {
            get
            {
                if (_ResultCodes == null)
                {
                    _ResultCodes = new()
                    {
                        { "100",  "Awaiting Content Providers response.   Please do not re-submit this request." },
                        { "200",  "General Data Error." },
                        { "201",  "The response could not be processed as it contained invalid data." },
                        { "202",  "The response cannot be processed due to a data overflow error.Please do not resubmit the request.Please contact the company directly for more information."},
                        { "300",  "The Content Provider Database is currently unavailable.  Please contact Astute Support for escalation."},
                        { "600",  "Unsupported transaction.Invalid transaction number."},
                        { "1003", "User has been blocked by the Compliance Officer."},
                        { "1420", "The selected Content Provider is not valid for your country."},
                        { "2001", "Client record not found."},
                        { "2002", "A duplicate client record exists.Please refine your search by entering the clients full details:  Identity number, Initials, Surname and Date - of - Birth; or search by policy number."},
                        { "2007", "The client information is not available.Please contact the Content Provider."},
                        { "2040", "The Digital Consent for this client has timed out. Please request again."},
                        { "2102", "Unable to match this client with any active policies / products."},
                        { "2105", "The Digital Consent for this client has been declined.Please contact client for consent."},
                        { "2109", "Requester not Broker on record."},
                        { "3032", "Your intermediary license is not active with the Product Provider.Please contact the Product Provider."},
                        { "3034", "User not permitted to perform a new client query for this Provider."},
                        { "3035", "User not permitted to perform an Existing client query for this Provider."},
                        { "4067", "The Digital Consent for this client is still pending. The transaction will only process once the client has provided consent."},
                        { "4070", "Your intermediary code is not accredited with the Product Provider.Please contact the Product Provider."},
                        { "4079", "Client information cannot be provided to the requesting intermediary."},
                        { "9993", "Content Provider did not respond to Product Request in a timely fashion." }
                    };
                }
                return _ResultCodes;
            }
        }

        public static List<ApiKeyModel> GetApiKeys()
        {
            return
            [
                new ApiKeyModel("dev", "1779d06f-6713-47ad-8ab7-c5900f729f58"),
                new ApiKeyModel("dev", "84FB23D7-8B98-4DAD-A2E2-E7F0895000EC")
            ];
        }

        public static DateTime GetDOB(string idNumber)
        {
            if (idNumber.Length > 6)
            {
                string yearString = idNumber.Substring(0, 2);
                string monthString = idNumber.Substring(2, 2);
                string dayString = idNumber.Substring(4, 2);
                int year = int.Parse(yearString);
                int month = int.Parse(monthString);
                int day = int.Parse(dayString);
                int currentYearLastTwoDigits = DateTime.Now.Year % 100;
                int century = (year <= currentYearLastTwoDigits) ? 2000 : 1900;
                year += century;
                return new DateTime(year, month, day);
            }
            else
            {
                throw new ArgumentException("ID number is too short to extract date of birth.");
            }
        }

        public static ProviderDetail[] GetAllProviders()
        {
            return
            [
                new ProviderDetail() { ProviderCode = "AMAS" },
                new ProviderDetail() { ProviderCode = "ABSA" },
                new ProviderDetail() { ProviderCode = "DSL" },
                new ProviderDetail() { ProviderCode = "FMI" },
                new ProviderDetail() { ProviderCode = "ALT" },
                new ProviderDetail() { ProviderCode = "LIB" },
                new ProviderDetail() { ProviderCode = "MOM" },
                new ProviderDetail() { ProviderCode = "NGL" },
                new ProviderDetail() { ProviderCode = "OMU" },
                new ProviderDetail() { ProviderCode = "SLMNA" },
                new ProviderDetail() { ProviderCode = "PPS" },
                new ProviderDetail() { ProviderCode = "SLM" },
                new ProviderDetail() { ProviderCode = "FNB" },
                new ProviderDetail() { ProviderCode = "AG" },
                new ProviderDetail() { ProviderCode = "OMGP" },
                new ProviderDetail() { ProviderCode = "DSI" },
                new ProviderDetail() { ProviderCode = "MOMW" },
                new ProviderDetail() { ProviderCode = "OMGP" },
                new ProviderDetail() { ProviderCode = "STLB" },
                new ProviderDetail() { ProviderCode = "SET" },
                new ProviderDetail() { ProviderCode = "INN8" },
                new ProviderDetail() { ProviderCode = "MOME" },
                new ProviderDetail() { ProviderCode = "SANE" }
            ];
        }


    }
}