using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Declaring variables to refer to later in code
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;

    //Declaring animating and rigidbody components to refer to later on
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //Horzintal Variable
        float horizontalInput = Input.GetAxis("Horizontal");
        //Left and right velocity
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        //flip the character
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        //Make player jump
        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();

        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }

    //Making jump mechanic
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("jump");
        grounded = false;
    }

    //Collision detection for when player touches ground enabling jump
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }
}
