using UnityEngine;

public class RestartPosition : MonoBehaviour
{
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }
    private void OnRaise()
    {
        GetComponent<Transform>().position = startPosition;
    }
}
