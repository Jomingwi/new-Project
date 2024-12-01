using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

public partial class Title : MonoBehaviour
{
    public JoyStick JOYSTICK;
    

    //private void Start()
    //{
    //    SetVideo();
    //}

    //public void OnBtnTitle()
    //{
    //    Shared.SceneMgr.ChangeScene(eSCENE.eSCENE_LOGIN);
    //}

    public void OnPointerDown(BaseEventData eventData)
    {
        JOYSTICK.gameObject.SetActive(true);



#if UNITY_EDITOR_WIN
#if UNITY_EDITOR
        JOYSTICK.transform.position = Input.mousePosition;
        
    
#else
        Touch touch = Input.GetTouch(0);

        JOYSTICK.transform.position = touch.position;
#endif
#endif
        JOYSTICK.OnDown((PointerEventData)eventData);
    }

    public void OnPointerUp(BaseEventData eventData)
    {
        JOYSTICK.gameObject.SetActive(false);
        JOYSTICK.OnUp((PointerEventData)eventData);
    }

    public void OnDrag(BaseEventData eventData)
    {
        JOYSTICK.OnDrag((PointerEventData)eventData);
    }
}


