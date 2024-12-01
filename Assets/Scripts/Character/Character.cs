using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character
{
    protected int Hp;// int Hp 가 없으면 순수 가상클래스

    protected abstract void SetHp();

    public Strategy Strategy;

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

public class Monster : Character
{
    protected override void SetHp()
    {
        Hp = 100;
    }
}
