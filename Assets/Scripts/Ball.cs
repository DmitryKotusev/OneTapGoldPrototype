using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private ScriptableEvent BallGotIntoHole;

    [SerializeField]
    private ScriptableEvent BallMissed;

    [SerializeField]
    private Rigidbody2D attachedRigidbody2D;

    public void Launch(Vector2 velocity)
    {
        attachedRigidbody2D.velocity = velocity;

        attachedRigidbody2D.gravityScale = 1;
    }

    public void Reload()
    {
        attachedRigidbody2D.velocity = Vector2.zero;

        attachedRigidbody2D.gravityScale = 0;

        gameObject.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Ball registered collision: {collision.transform.name}");

        gameObject.SetActive(false);

        if (collision.transform.GetComponent<Hole>() != null)
        {
            BallGotIntoHole.RaiseEvent();

            return;
        }

        BallMissed.RaiseEvent();
    }
}
