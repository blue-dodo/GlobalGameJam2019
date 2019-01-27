///----------------------------------------------------------------------------------------------------------------------------------
///
///     Autor:          dariovfsantos@gmail.com
///     Descrição:      Movimento dos objetos
///     Criação:        25/01/2019
///     Última edição   25/01/2019   
/// 
///----------------------------------------------------------------------------------------------------------------------------------
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [Header("Movement", order = 0)]
    [SerializeField] private float moveSpeed = 5f;
    public GameObject randomObject;

    private Rigidbody2D rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        rig.MovePosition(new Vector2(transform.localPosition.x + Input.GetAxis("Horizontal") * moveSpeed, transform.localPosition.y + Input.GetAxis("Vertical") * moveSpeed));
        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(randomObject, new Vector2(transform.localPosition.x, transform.localPosition.y), Quaternion.Euler(GetRandomRotation()));
            Destroy(gameObject);
        }
    }

    private Vector3 GetRandomRotation()
    {
        Vector3 rotation = new Vector3(0f, 0f, 0f);

        rotation.z = Random.Range(0, 360);
        return rotation;
    }

}
