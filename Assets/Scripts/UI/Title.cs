using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public partial class Title : MonoBehaviour
{

    private void Start()
    {
        SetVideo();
    }

    public void OnBtnTitle()
    {
        Shared.SceneMgr.ChangeScene(eSCENE.eSCENE_LOGIN);
    }
}

