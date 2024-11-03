using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SceneMgr : MonoBehaviour
{

    private void Awake()
    {
        Shared.SceneMgr = this;
    }

    void Start()
    {
        
    }


    void Update()
    {

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
