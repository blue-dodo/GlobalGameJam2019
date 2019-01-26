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
    [SerializeField] private float wallRunSpeed = 5f;
    private bool isGrounded = true;
    private bool doubleJump = true;
    private bool canWallJump = false;

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

        if(!CanWallJump())
        {
            float h = Run();
            float v = Jump();

            rigidBody.velocity = new Vector2(h, v);
        }
        else
        {
            float v = Jump();
            if (Input.GetKeyDown(KeyCode.UpArrow))
                rigidBody.velocity = new Vector2( -transform.localScale.x * wallRunSpeed, v);
        }

        FlipSprite();
    }

    private float Run() => Input.GetAxis("Horizontal") * runSpeed;

    private float Jump()
    {
        isGrounded = feet.IsTouchingLayers(LayerMask.GetMask("Ground"));
        if(isGrounded)
            doubleJump = true;

        if(Input.GetKeyDown(KeyCode.UpArrow) && (isGrounded || doubleJump || canWallJump))
        {
            if(!isGrounded)
                doubleJump = false;
            return jumpSpeed;
        }
        return rigidBody.velocity.y;
    }

    private bool CanWallJump()
    {
        RaycastHit2D ray = Physics2D.Linecast(transform.localPosition, new Vector2(transform.localPosition.x + 2.05f * Mathf.Sign(transform.localScale.x), transform.localPosition.y), LayerMask.GetMask("Wall", "Ground"));
        Debug.DrawLine(transform.localPosition, new Vector2(transform.localPosition.x + 2.05f * Mathf.Sign(transform.localScale.x), transform.localPosition.y));

        if (ray.collider != null)
            if (ray.collider.tag == "Wall")
                return true;
        return false;
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f;
        if(playerHasHorizontalSpeed)
            transform.localScale = new Vector2(Mathf.Sign(Input.GetAxis("Horizontal")) * Mathf.Abs(transform.localScale.x), transform.localScale.y);
    }
}
