using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class BattleMgr : MonoBehaviour
{
    Dictionary<int, string> dicCharacter = new Dictionary<int, string>();

    List<int> list = new List<int>();
    List<string> list2 = new List<string>();


    public bool GameOver;
    //add�� �־���

    //key ���� value������ �̷���� 
    //()
    //[]

    Character Factory(eCHARACTER _e)
    {
        Character character = null;

        switch(_e)
        {
            case eCHARACTER.eCHARACTER_PLAYER:
                character = new Player();
                break;
            case eCHARACTER.eCHARACTER_MONSTER:
                character = new Monster();
                break;
        }
        return character;
    }


}




