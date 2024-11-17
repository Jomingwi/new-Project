using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public partial class SceneMgr : MonoBehaviour
{
    //중요한 정보는 저장하지않고 저장되야하는것만 저장하는 파일저장방법
    string FilePath = "Test.txt";

    public void SaveFile()
    {
        File.Exists(Application.dataPath + FilePath);
       
        StreamWriter sw = File.CreateText(FilePath);

        sw.WriteLine("Test");

        sw.Close();
    }

    public void LoadFile()
    {

        StreamReader sr = File.OpenText(Application.dataPath + FilePath);

        string str1 = sr.ReadLine();

        sr.Close();
    }
}
