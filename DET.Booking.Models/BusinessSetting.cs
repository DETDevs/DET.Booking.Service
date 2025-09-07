using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DET.Booking.Models
{
    public class BusinessSetting<T>
    {
        public int? SettingID { get; set; }
        public int BusinessID { get; set; }
        public string? Key { get; set; }
        public T? Value { get; set; }
        public string? ValueJson { get; set; }
        public string CreateUser { get; set; }
    }

    public class BusinessSettingResponse
    {
        public int? SettingID { get; set; }
        public int BusinessID { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string CreateUser { get; set; }
        public string ModificationUser { get; set; }
    }
}
