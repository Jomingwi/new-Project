using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Shared
{
    public static SceneMgr SceneMgr; //singleton
    public static TableMgr TableMgr;
    public static SoundMgr SoundMgr;
    public static MainCamera MainCamera;

    public static TableMgr InitTableMgr()
    {
        if (TableMgr == null)
        {
            TableMgr = new TableMgr();
            TableMgr.Init();
        }

        return TableMgr;
    }


}
//UI창 stack 으로 만들기