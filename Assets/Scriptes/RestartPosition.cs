using UnityEngine;

public class RestartPosition : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion startRotation;
    private Vector3 startScale;

    private void Start()
    {
        startPosition = GetComponent<Transform>().localPosition;
        startRotation = GetComponent<Transform>().localRotation;
        startScale = GetComponent<Transform>().localScale;
    }

    public void OnRaise()
    {
        GetComponent<Transform>().localPosition = startPosition;
        GetComponent<Transform>().localRotation = startRotation;
        GetComponent<Transform>().localScale = startScale;
    }
}
