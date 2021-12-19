using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoesInsuranceEmporium.DataClasses
{
    public class Property
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }        
        public int Size { get; set; }
        public LineType PropertyType { get; set; }
        public Decimal AppraisedValue { get; set; }
    }

    public enum LineType
    {
        Commercial, Personal
    }
}
