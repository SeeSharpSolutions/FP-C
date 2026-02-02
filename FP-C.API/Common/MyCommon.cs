using AstuteServiceReference;
using FP_C.API.Models;

namespace FP_C.API.Common
{
    public class MyCommon
    {
        private static Dictionary<string, string> _ResultCodes;
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

                // UAT - Only unit test
                //new ProviderDetail() {ProviderCode="ABSA Life"},
                //new ProviderDetail() {ProviderCode="Assupol"},
                //new ProviderDetail() {ProviderCode="Bidvest Life"},
                //new ProviderDetail() {ProviderCode="Discovery Life"},
                //new ProviderDetail() {ProviderCode="FNB"},
                //new ProviderDetail() {ProviderCode="Hollard Life"},
                //new ProviderDetail() {ProviderCode="Liberty Group Limited"},
                //new ProviderDetail() {ProviderCode="Metropolitan"},
                //new ProviderDetail() {ProviderCode="Momentum"},
                //new ProviderDetail() {ProviderCode="Nedbank Insurance"},
                //new ProviderDetail() {ProviderCode="Old Mutual South Africa"},
                //new ProviderDetail() {ProviderCode="PPS"},
                //new ProviderDetail() {ProviderCode="Sanlam"},
                //new ProviderDetail() {ProviderCode="Unit Test -Assupol"},
                //new ProviderDetail() {ProviderCode="UnitTest - Assupol Investment"},
                //new ProviderDetail() {ProviderCode="UnitTest- ABSA Life"},
                //new ProviderDetail() {ProviderCode="UnitTest- Discovery Life"},
                //new ProviderDetail() {ProviderCode=" UnitTest- Hollard Life"},
                //new ProviderDetail() {ProviderCode=" UnitTest- Metropolitan"},
                //new ProviderDetail() {ProviderCode=" UnitTest- Momentum"},
                //new ProviderDetail() {ProviderCode="UnitTest- Nedbank Insurance"},
                //new ProviderDetail() {ProviderCode=" UnitTest- Old Mutual"},
                //new ProviderDetail() {ProviderCode=" UnitTest- PPS"},
                //new ProviderDetail() {ProviderCode="UnitTest- Sanlam"},
                //new ProviderDetail() {ProviderCode="UnitTest- Sanlam Namibia"},
                //new ProviderDetail() {ProviderCode=" UnitTest-Bidvest Life"},
                //new ProviderDetail() {ProviderCode=" UnitTest-Liberty Group LTD"},
                //new ProviderDetail() {ProviderCode="Allan Gray (Manco & LISP)"},
                //new ProviderDetail() {ProviderCode="Assupol Investment"},
                //new ProviderDetail() {ProviderCode="Discovery Invest"},
                //new ProviderDetail() {ProviderCode="INN8"},
                //new ProviderDetail() {ProviderCode="Momentum Wealth"},
                //new ProviderDetail() {ProviderCode=" Old Mutual Wealth and Unit Trusts"},
                //new ProviderDetail() {ProviderCode="STANLIB"},
                //new ProviderDetail() {ProviderCode=" UnitTest - Discovery Invest"},
                //new ProviderDetail() {ProviderCode=" UnitTest- Allan Gray"},
                //new ProviderDetail() {ProviderCode=" UnitTest- Momentum Wealth"},
                //new ProviderDetail() {ProviderCode=" UnitTest- STANLIB"},
                //new ProviderDetail() {ProviderCode=" UnitTest-Old Mutual Wealth and Unit Trusts"},
                //new ProviderDetail() {ProviderCode=" Sanlam Collective Investments"},
                //new ProviderDetail() {ProviderCode=" UnitTest- Sanlam Collective Unit Trusts"}
                new ProviderDetail() {ProviderCode="METL"},
                new ProviderDetail() {ProviderCode="MOML"},
                new ProviderDetail() {ProviderCode="LIBL"},
                new ProviderDetail() {ProviderCode="STLBL"},
                new ProviderDetail() {ProviderCode="SETL"},

                new ProviderDetail() {ProviderCode="DSIL"},
                new ProviderDetail() {ProviderCode="PPSL"},
                new ProviderDetail() {ProviderCode="SLML"},
                new ProviderDetail() {ProviderCode="MOMWL"},
                new ProviderDetail() {ProviderCode="FMIL"},
                
                //new ProviderDetail() {ProviderCode="Old Mutual"},
                //new ProviderDetail() {ProviderCode="Liberty Group Limited"},
                //new ProviderDetail() {ProviderCode="Momentum"},
                //new ProviderDetail() {ProviderCode="Metropolitan"},
                //new ProviderDetail() {ProviderCode="Discovery Life"},
                
                //new ProviderDetail() {ProviderCode="Sanlam Collective Investments"},
                //new ProviderDetail() {ProviderCode="Old Mutual Wealth and Unit Trusts"},
                //new ProviderDetail() {ProviderCode="Professional Provident Society"},
                //new ProviderDetail() {ProviderCode="Hollard Life"},
                //new ProviderDetail() {ProviderCode="Momentum Wealth"},
                
                //new ProviderDetail() {ProviderCode="STANLIB"},
                //new ProviderDetail() {ProviderCode="Allan Gray (Manco & LISP)"},
                //new ProviderDetail() {ProviderCode="ABSA Life"},
                //new ProviderDetail() {ProviderCode="Sanlam"},
                //new ProviderDetail() {ProviderCode="Discovery Invest"},
                
                //new ProviderDetail() {ProviderCode="Nedbank Insurance"},
                new ProviderDetail() {ProviderCode="ALTL"},
                new ProviderDetail() {ProviderCode="NGLL"},
                new ProviderDetail() {ProviderCode="OMUL"},
                new ProviderDetail() {ProviderCode="OMGPL"},
                new ProviderDetail() {ProviderCode="AGL"},
                new ProviderDetail() {ProviderCode="ABSAL"},
                new ProviderDetail() {ProviderCode="SLMNL"},
                //new ProviderDetail() {ProviderCode="Bidvest Life"},
                //new ProviderDetail() {ProviderCode="Assupol"},
                
                //new ProviderDetail() {ProviderCode="Assupol Investment"},
                new ProviderDetail() {ProviderCode="ASPIL"},
                //new ProviderDetail() {ProviderCode="INN8"},
                //new ProviderDetail() {ProviderCode="First National Bank"},
                new ProviderDetail() {ProviderCode="DSLL"}
            ];
        }


    }
}