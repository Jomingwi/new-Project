using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    
    public void OnBtnTitle()
    {
        Shared.SceneMgr.ChangeScene(eSCENE.eSCENE_LOGIN);
    }
}
