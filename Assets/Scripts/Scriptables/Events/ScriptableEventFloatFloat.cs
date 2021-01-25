using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableEvents/EventFloatFloat", fileName = "EventFloatFloat")]
public class ScriptableEventFloatFloat : ScriptableObject
{
    public event Action<float, float> ScriptableSignal;

    public void RaiseEvent(float parameter1, float parameter2)
    {
        ScriptableSignal?.Invoke(parameter1, parameter2);
    }
}
