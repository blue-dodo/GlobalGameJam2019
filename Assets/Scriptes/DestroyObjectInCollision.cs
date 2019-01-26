using UnityEngine;

public class DestroyObjectInCollision : MonoBehaviour
{
    [SerializeField] private string target = "Player";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(target))
            Destroy(gameObject);
    }
}
