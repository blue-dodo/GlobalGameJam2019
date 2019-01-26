using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpModifier : MonoBehaviour
{
    [SerializeField] private float fallMultiplier = 2.5f;
    private Rigidbody2D rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(rigidBody.velocity.y < 0)
            rigidBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
    }
}
