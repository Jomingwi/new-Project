using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Strategy : MonoBehaviour
{
    abstract public void SkillPlay(int index);
}
//전략패턴 