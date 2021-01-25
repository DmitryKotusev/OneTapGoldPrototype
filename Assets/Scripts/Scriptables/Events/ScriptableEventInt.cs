using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableEvents/EventInt", fileName = "EventInt")]
public class ScriptableEventInt : ScriptableObject
{
    public event Action<int> ScriptableSignal;

    public void RaiseEvent(int parameter)
    {
        ScriptableSignal?.Invoke(parameter);
    }
}
