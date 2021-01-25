using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableSettings/LaunchBallSettings", fileName = "LaunchBallSettings")]
public class LaunchBallSettings : ScriptableObject
{
    [SerializeField]
    private Vector2 launchDirection = Vector2.one;

    [SerializeField]
    private float startAcceleration = 0.1f;

    [SerializeField]
    private float maxAcceleration = 10f;

    [SerializeField]
    private float accelerationChangeSpeed = 0.05f;

    public Vector2 LaunchDirection => launchDirection.normalized;

    public float StartAcceleration => startAcceleration;

    public float MaxAcceleration => maxAcceleration;

    public float AccelerationChangeSpeed => accelerationChangeSpeed;
}
