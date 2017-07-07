using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Services.Payloads
{
    [System.Serializable]
    public class MessageResponsePayload
    {
        public bool success;
    
        public LocationPayload data;

        public bool showVideo;


    }
}
