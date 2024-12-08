using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SceneMgr : MonoBehaviour
{

    private void Awake()
    {
        Shared.SceneMgr = this;

        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        Shared.InitTableMgr();
        Table_Character.Info info = Shared.TableMgr.Character.Get(1);
    }



    /*
    winmain
    {
        init()

        while(1)

        {
             if()
              awake()
             if()
              start()

             update()
             render()
        }
    }
     */
}
