using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApplication.Models
{
    public class Log
    {
        private int _Id;
        public int Id { 
            get 
            { 
                return _Id; 
            } 
            set 
            {
               
                _Id = value;
            } 
        }
        public string classofDevice { get; set; }
        public string IsRead { get; set; }
        public DateTime TimeofLog { get; set; }
        public string  LogReport { get; set; }
        public string UserInChargeofReading { get; set; }
    }
}
