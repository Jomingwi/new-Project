using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SceneMgr : MonoBehaviour
{
    public void SetPlayerPrefsIntKey(string _key , int _value)
    {
        PlayerPrefs.SetInt( _key, _value );
       
        PlayerPrefs.Save();
    }

    public int GetPlayerPrefsIntKey(string _key)
    {
        return PlayerPrefs.GetInt(_key);
    }

    public void SetPlayerPrefsFloatKey(string _key, float _value)
    {
        PlayerPrefs.SetFloat(_key, _value);

        PlayerPrefs.Save();
    }

    public float GetPlayerPrefsFloatKey(string _key)
    {
        return PlayerPrefs.GetFloat(_key);
    }

    public void SetPlayerPrefsStringKey(string _key, string _value)
    {
        PlayerPrefs.SetString(_key, _value);

        PlayerPrefs.Save();
    }

    public string GetPlayerPrefsStringKey(string _key)
    {
        return PlayerPrefs.GetString(_key);
    }

    //Title - Login - Loading - Lobby(Battle)
    //계정이 있으면 바로 로비
    //없으면 Login에서 계정생성





}
