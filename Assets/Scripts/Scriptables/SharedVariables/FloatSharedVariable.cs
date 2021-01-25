using UnityEngine;

[CreateAssetMenu(menuName = "SharedRuntimeVariables/FloatSharedVariable", fileName = "FloatSharedVariable")]
public class FloatSharedVariable : ScriptableObject
{
    public float Variable { get; set; }
}
