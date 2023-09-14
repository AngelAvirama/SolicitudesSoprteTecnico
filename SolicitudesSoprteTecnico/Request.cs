using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestsQueue
{
    public class Request
    {   
        public int requestNumber { get; set; }
        public string customerName { get; set; }

   
        public string problemDescription {  get; set; }

        public int urgencyLevel { get; set; }

        public Request(int requestN, string name, string problem,int urgency) 
        {
            requestNumber = requestN;
            customerName = name;
            problemDescription = problem;
            urgencyLevel = urgency;
        
        
        }
    }
}
