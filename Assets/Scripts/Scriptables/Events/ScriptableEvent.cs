using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableEvents/Event", fileName = "Event")]
public class ScriptableEvent : ScriptableObject
{
    public event Action ScriptableSignal;

    public void RaiseEvent()
    {
        ScriptableSignal?.Invoke();
    }
}
