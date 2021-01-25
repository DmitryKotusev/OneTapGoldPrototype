using UnityEngine;

[CreateAssetMenu(menuName = "SharedRuntimeVariables/IntSharedVariable", fileName = "IntSharedVariable")]
public class IntSharedVariable : ScriptableObject
{
    public int Variable { get; set; }
}
