using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnRigidbodyOff : MonoBehaviour
{
    [SerializeField] private float time = 1;

    private void Start()
    {
        if (time < 0)
            time = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(TurnOff(time));
    }

    IEnumerator TurnOff(float time)
    {
        yield return new WaitForSeconds(time);
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
