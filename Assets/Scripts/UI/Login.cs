using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField TextInput;
    public Sprite sprite;
    public Image img;

    private void Awake()
    { 
        //이미지 스프라이트에 붙여서 아틀라스 이름과 sprite 이름을 써서 불러옴
        img.sprite= Shared.SceneMgr.GetSpriteAtlas("Common", "Sky");
    }


    private void Start()
    {

        //로그인 계쩡이 있는가
        if (Shared.SceneMgr.GetPlayerPrefsStringKey("User") == null)
        {
            Shared.SceneMgr.SetPlayerPrefsStringKey("User", TextInput.text);
           
            OnbtnLogin();
        }
        else
        {
            Shared.SceneMgr.GetPlayerPrefsStringKey("User");
           
            OnbtnLogin();
        }
        
        //계정을 넣고
        //저장해서 신넘기기

    }



    public void OnbtnLogin()
    {
        if(TextInput.text.Length > 0 || TextInput.text != "")
        {
            Shared.SceneMgr.ChangeScene(eSCENE.eSCENE_LOADING);

            StartCoroutine(DelayLoading(3));

            gameObject.SetActive(false);
        }
    }


    public IEnumerator DelayLoading(float _delay)
    {

        yield return new WaitForSeconds(_delay);

        Shared.SceneMgr.ChangeScene(eSCENE.eSCENE_LOBBY);
    }

}
