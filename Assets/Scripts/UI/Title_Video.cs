using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public partial class Title : MonoBehaviour
{

    public VideoPlayer VIDEOPLAYER;
    public RawImage RAWIMAGE;

    VideoClip Clip = null;


    private void SetVideo()
    {
        string file = "Prefabs/Video/" + "EF_Normal";
        Clip = Resources.Load(file) as VideoClip;

        VIDEOPLAYER.gameObject.SetActive(true);


        RAWIMAGE.texture = VIDEOPLAYER.texture;

        VIDEOPLAYER.clip = Clip;

        VIDEOPLAYER.Prepare(); //���� �ε� �غ�
        //VIDEOPLAYER.Play();//���� ����
        //VIDEOPLAYER.Stop();//���� ����

        StartCoroutine(IUpdateVideo());
    }

    IEnumerator IUpdateVideo()
    {
        VIDEOPLAYER.Play();

        yield return new WaitForSeconds(0.1f);

        while (true)
        {
            yield return new WaitForSeconds(0.1f);

            if (true == VIDEOPLAYER.isPlaying)
            {
                RAWIMAGE.texture = VIDEOPLAYER.texture;

                continue;
            }

            break;
        }

        VIDEOPLAYER.transform.gameObject.SetActive(false);
    }

}
