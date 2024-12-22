using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : MonoBehaviour
{

    [SerializeField] AudioSource Bgm;
    [SerializeField] AudioSource Effect;

    void Awake()
    {
        Shared.SoundMgr = this;
        DontDestroyOnLoad(gameObject);
        Bgm.loop = true;
    }
   
    public void PlayBgm(string _Bgm)
    {
        Object obj = Resources.Load(_Bgm);

        if (null == obj) return;

        AudioClip clip = obj as AudioClip;

        if(null == clip) return;

        Bgm.clip = clip;
        Bgm.Play();
    }

    public void PlayEffect(string _Effect)
    {
        Object obj = Resources.Load(_Effect);

        if(null == obj) return;

        AudioClip clip = obj as AudioClip;

        if(null == clip) return;

        Effect.PlayOneShot(clip);
    }
}
