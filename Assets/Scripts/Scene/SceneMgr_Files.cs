using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public partial class SceneMgr : MonoBehaviour
{
    //�߿��� ������ ���������ʰ� ����Ǿ��ϴ°͸� �����ϴ� ����������
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
