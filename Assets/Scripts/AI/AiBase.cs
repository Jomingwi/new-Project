using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBase : MonoBehaviour
{
    protected Character Character;

    protected eAI AiState = eAI.eAI_CREATE;

    public virtual void Type()
    {

    }

    public void Init(Character _Charecter)
    {
        Character = _Charecter;
    }

    public void State()
    {
        switch(AiState)
        {
            case eAI.eAI_CREATE:
                Create();
                break;
            case eAI.eAI_SEARCH:
                Search();
                break;
            case eAI.eAI_MOVE:
                Move();
                break;
            case eAI.eAI_RESET:
                Reset();
                break;
        }
    }

    protected virtual void Create()
    {
        AiState = eAI.eAI_SEARCH;
    }

    protected virtual void Search()
    {
        AiState = eAI.eAI_MOVE;
    }
    protected virtual void Move()
    {
        AiState = eAI.eAI_SEARCH;
    }

    protected virtual void Reset()
    {
        AiState = eAI.eAI_SEARCH;
    }
    


}
