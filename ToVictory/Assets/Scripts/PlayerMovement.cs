using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponenet<Rigidbody2D>();
    }

    private void Update()
    {
        body.velocity = new Vector3(Input)
    }
}
