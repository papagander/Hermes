using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data;

    [Table("Reports")]
    public class Report
    { 
        // Core
        public int ReportId;
        public string Name;
        public Customer Customer;
        public int CustomerId;
        // Template
        public Template ReportType;
        public int ReportTypeId;
        // Criteria
        public Statement Statement;
        public int StatementId;
        // Transmission
        public TransmissionType TransmissionType;
        public int TransmissionTypeId;
        // Media
        public MediaType MediaType;
        public int MediaTypeId;

    }
    public class Customer
    {
        public int CustomerId;
        public string Name;

    }


    public class MediaType
    {
        public int MediaTypeId;
        public string Name;
    }

    public class TransmissionType
    {
        public int TransmissionTypeId;
        public string Name;
    }

