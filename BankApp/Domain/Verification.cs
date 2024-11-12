using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Domain
{
    public enum VerificationResult
    {
        Unknown,
        Verified,
        Denied,
        FurtherVerificationNeeded
    }
    class Verification
    {
        public string Verifier;
        public DateTime DateTime;
        public VerificationResult verificationResult;
        private string futherInfo;
        public string FurtherInfo
        {
            get
            {
                return futherInfo;
            }
            set
            {
                if(verificationResult == VerificationResult.Denied/* || verificationResult == VerificationResult.FurtherVerificationNeeded*/)
                {
                    Console.WriteLine("FurtherInfo musí být vyplněno pokud je VerificationResult Denied nebo FutherVerificationNeeded");
                }
                futherInfo = value;
            }
        }

        public Verification(string verifier, VerificationResult verificationResult, string futherInfo)
        {
            Verifier = verifier;
            DateTime = DateTime.Now;
            this.verificationResult = verificationResult;
            FurtherInfo = futherInfo;
        }
    }
}
