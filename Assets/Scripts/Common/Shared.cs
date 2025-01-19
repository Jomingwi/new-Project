using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Shared
{
    public static SceneMgr SceneMgr; //singleton
    public static TableMgr TableMgr;
    public static SoundMgr SoundMgr;
    public static MainCamera MainCamera;
    public static BattleMgr BattleMgr;

    public static Transform Zone;

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
//UIâ stack ���� �����