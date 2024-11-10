using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public Text TextInput;
    

   

    public void OnbtnLogin()
    {
        if(TextInput.text.Length > 0 || TextInput.text == "")
        {
            Shared.SceneMgr.ChangeScene(eSCENE.eSCENE_LOADING);
        }
    }

}
