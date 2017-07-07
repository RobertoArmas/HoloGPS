using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Services.Payloads;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine;

namespace Assets.Services
{
    public class MessageService
    {

        public IEnumerator GetMessage(Action<bool, LocationPayload,bool, string> onComplete)
        {


            UnityWebRequest webRequest = UnityWebRequest.Get(
                "http://192.168.100.188:8000/api/data"
                );

            yield return webRequest.Send();

            if (!webRequest.isError)
            {


                MessageResponsePayload message = JsonUtility.FromJson<MessageResponsePayload>(
                    webRequest.downloadHandler.text
                 );

                if (message.success)
                {
                    onComplete(true, message.data,message.showVideo, "Exitoso");
                }
                else
                {
                    onComplete(false, null,false, "Ha fallado");
                }



            }
            else
            {

                onComplete(false, null,false, webRequest.error);

            }

        }

        public string FixJson(string keyParent, string data)
        {
            return string.Format("{{ \"{0}\": {1}}}", keyParent, data);
        }
    }
}
