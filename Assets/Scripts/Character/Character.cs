using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character
{
    protected int Hp;// int Hp �� ������ ���� ����Ŭ����

    protected abstract void SetHp();

    //protected virtual void SetHp()
    //{

    //}
    
}

public class Player : Character
{
    protected override void SetHp()
    {
        Hp = 100;
    }
}
