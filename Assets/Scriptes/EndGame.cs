using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private string target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(target))
        {
            Debug.Log("End Game");
        }
    }
}
