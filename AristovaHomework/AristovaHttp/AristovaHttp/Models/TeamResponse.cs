using System;
using System.Collections.Generic;
using System.Text;

namespace AristovaHttp.Models
{
    public class TeamResponse
    {
        public IEnumerable<Team> Data { get; set; }
        public int Count { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
