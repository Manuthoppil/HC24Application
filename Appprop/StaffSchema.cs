using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appprop
{
    public class StaffSchema
    {

        public string FirstName { get; set; }
        public string lastname { get; set; }
        public string EmailId { get; set; }
        public string PhoneNumber { get; set; }
        public string Nationality { get; set; }
        public string DateofBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string street { get; set; }
        public string county { get; set; }
        public string PostCode { get; set; }
        public int Isdelete { get; set; }
        public string NiNumber { get; set; }

        public string image { get; set; }
        public int Age { get; set; }
        public string ApplicationNo { get; set; }
        public string DBS { get; set; }
        public string DBSType { get; set; }
        public string DBSIssueDate { get; set; }
        public string DBSExpirydate { get; set; }
        public string Driving { get; set; }
        public string ProofofAddress { get; set; }
        public string ProofDoc { get; set; }
        public string Training { get; set; }

        public string Issuedate { get; set; }

        public string ExpiryDate { get; set; }

        public string TrainingDoc { get; set; }
        public byte Data { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public string ProofType { get; set; }
        public string Position { get; set; }
        public string NmcPin { get; set; }
        public string RenewlDate { get; set; }
        public int Matching { get; set; }
        public int Staffid { get; set; }
    }
}
