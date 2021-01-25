using UnityEngine;

public class LaunchBallInputController : MonoBehaviour
{
    [SerializeField]
    private ScriptableEvent buttonDown;

    [SerializeField]
    private ScriptableEvent buttonUp;

    public void OnPointerDown()
    {
        buttonDown.RaiseEvent();
    }

    public void OnPointerUp()
    {
        buttonUp.RaiseEvent();
    }
}
