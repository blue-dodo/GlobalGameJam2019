///----------------------------------------------------------------------------------------------------------------------------------
///
///     Autor:          dariovfsantos@gmail.com
///     Descrição:      Movimento do dodó
///     Criação:        25/01/2019
///     Última edição   25/01/2019   
/// 
///----------------------------------------------------------------------------------------------------------------------------------
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement", order = 0)]
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float jumpSpeed = 5f;
    [SerializeField] private bool canJump = true;

    private Rigidbody2D rigidBody;
    private BoxCollider2D feet;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        feet = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        HandheldMovement();
    }

    private void HandheldMovement()
    {
        float h = Run();
        float v = Jump();
        //WallJump();

        rigidBody.velocity = new Vector2(h, v);
        FlipSprite();
    }

    private float Run() => Input.GetAxis("Horizontal") * runSpeed;

    private float Jump()
    {
        if (!feet.IsTouchingLayers(LayerMask.GetMask("Ground")) )//&& !canJump)
            return rigidBody.velocity.y;

        if(Input.GetAxis("Vertical") > Mathf.Epsilon)
        {
         //   canJump = false;
            return jumpSpeed;
        }
        return rigidBody.velocity.y;
    }

    private void WallJump()
    {
        RaycastHit2D ray = Physics2D.Linecast(transform.localPosition, new Vector2(transform.localPosition.x + Mathf.Sign(transform.localScale.x), transform.localPosition.y), LayerMask.GetMask("Wall"));

        if (ray.collider != null)
            if (ray.collider.tag == "Wall")
                canJump = true;

        Debug.DrawLine(transform.localPosition, new Vector2(transform.localPosition.x + Mathf.Sign(transform.localScale.x), transform.localPosition.y));
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f;
        if(playerHasHorizontalSpeed)
            transform.localScale = new Vector2(Mathf.Sign(Input.GetAxis("Horizontal")) * Mathf.Abs(transform.localScale.x), transform.localScale.y);
    }
}
