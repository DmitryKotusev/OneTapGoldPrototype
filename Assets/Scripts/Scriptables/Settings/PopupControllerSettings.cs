using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableSettings/PopupControllerSettings", fileName = "PopupControllerSettings")]
public class PopupControllerSettings : ScriptableObject
{
    [SerializeField]
    private GameObject finishGamePopupPrefab;

    public GameObject FinishGamePopupPrefab => finishGamePopupPrefab;
}
