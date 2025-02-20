using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    protected MiniUIManager4 miniUIManager4;

    public virtual void Init(MiniUIManager4 miniUIManager4)
    {
        this.miniUIManager4 = miniUIManager4;
    }

    protected abstract UIState GetUIState();

    public void SetActive(UIState state)
    {
        this.gameObject.SetActive(GetUIState() == state);
    }
}
