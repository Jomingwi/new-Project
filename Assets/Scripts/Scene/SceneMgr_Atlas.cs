using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.U2D;

public partial class SceneMgr : MonoBehaviour
{
    [NonReorderable]
    Dictionary<string , SpriteAtlas> SpriteAtlas = new Dictionary<string, SpriteAtlas> ();


    public Sprite GetSpriteAtlas(string _Atlas , string _Name)
    {
        if (SpriteAtlas.ContainsKey(_Atlas))
        {
            return SpriteAtlas[_Atlas].GetSprite(_Name);
        }

        UnityEngine.Object obj = null;

        obj = Resources.Load("Atlas/" + _Atlas);
        if (obj == null) {

            Debug.Log("load fail" + _Atlas);

            return null;
        }
        
        SpriteAtlas sa = obj as SpriteAtlas;

        if (sa != null) 
        {
            SpriteAtlas.Add(_Atlas, sa);
            return sa.GetSprite(_Name);
        }

        return null;
    }

}
