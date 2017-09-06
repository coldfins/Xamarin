using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridView.Models
{

    class ClsLoginResponse
    {
        public int errorCode { get; set; }
        public string message { get; set; }
        public ClsUser data { get; set; }
    }

    class ClsUser
    {
        public int id { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public DateTime date_created { get; set; }
        public DateTime date_modified { get; set; }
    }
}
