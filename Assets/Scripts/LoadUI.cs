using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Services;
using UnityEngine.Networking;
using UnityEngine.Video;

public class LoadUI : MonoBehaviour
{

    public TextMesh messageText;
    public VideoPlayer videoPlayer;
    public bool alreadyPlay = false;


    private MessageService messageService = new MessageService();
    private IEnumerator coroutine;
    // Use this for initialization
    void Start()
    {

        videoPlayer = videoPlayer.GetComponent<VideoPlayer>();
        videoPlayer.targetCameraAlpha = 0;
        messageText = messageText.GetComponent<TextMesh>();
        coroutine = WaitAndPrint(2.0f);
        StartCoroutine(coroutine);
        messageText.text = "Hola tu!";

        //  yield return messageService.GetMessage();
    }

    // Update is called once per frame
    void Update()
    {


    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            yield return messageService.GetMessage((success, data, showVideo, message) => {
                if (success)
                {
                   // Debug.developerConsoleVisible = true;
                   // Debug.LogError(data.id);
                    messageText.text = "latitud:" + data.latitude + " longitud:" + data.longitude;
                    if (showVideo && !alreadyPlay)
                    {
                        if (!videoPlayer.isPlaying)
                        {
                            videoPlayer.targetCameraAlpha = 1;
                            videoPlayer.Play();
                        }
                    }

                }


            });
            yield return new WaitForSeconds(2);
            print("WaitAndPrint " + Time.time);
        }
    }
}
