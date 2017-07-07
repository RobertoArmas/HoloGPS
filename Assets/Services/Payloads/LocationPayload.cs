using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Services.Payloads
{
    [System.Serializable]
    public class LocationPayload
    {
        public int id;
        public string latitude;
        public string longitude;
    }
}
