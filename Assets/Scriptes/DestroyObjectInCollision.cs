using UnityEngine;

public class DestroyObjectInCollision : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !gameObject.CompareTag("Ground"))
            Destroy(gameObject, 1f);
    }
}
