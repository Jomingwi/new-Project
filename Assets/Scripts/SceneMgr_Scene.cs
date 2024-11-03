using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public partial class SceneMgr : MonoBehaviour
{
    eSCENE Scene = eSCENE.eSCENE_TITLE;

    public void ChangeScene(eSCENE e , bool _Loading = false)
    {
        if (Scene == e)
            return;

        Scene = e;

        switch(e)
        {
            case eSCENE.eSCENE_TITLE:
                SceneManager.LoadScene("Title");
                break;
            case eSCENE.eSCENE_LOGIN:
                SceneManager.LoadScene("Login");
                break;
            case eSCENE.eSCENE_LOBBY:
                SceneManager.LoadScene("Lobby");
                break;
            case eSCENE.eSCENE_BATTLE:
                SceneManager.LoadScene("Battle");
                break;

        }
    }
    
    

}
