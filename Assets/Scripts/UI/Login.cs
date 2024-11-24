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
        //�̹��� ��������Ʈ�� �ٿ��� ��Ʋ�� �̸��� sprite �̸��� �Ἥ �ҷ���
        img.sprite= Shared.SceneMgr.GetSpriteAtlas("Common", "Sky");
    }


    private void Start()
    {

        //�α��� ������ �ִ°�
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
        
        //������ �ְ�
        //�����ؼ� �ųѱ��

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
