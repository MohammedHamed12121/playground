using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class ClientMessage
    {
        public string? ClientName { get; set; }
        public string? Message { get; set; }
        public DateTime SentAt { get; set; }
    }
}
