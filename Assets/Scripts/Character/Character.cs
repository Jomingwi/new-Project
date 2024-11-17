using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character
{
    protected int Hp;// int Hp 가 없으면 순수 가상클래스

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
