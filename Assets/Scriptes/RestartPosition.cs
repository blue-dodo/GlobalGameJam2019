using UnityEngine;

public class RestartPosition : MonoBehaviour
{
    private Transform startTransform;

    private void Start()
    {
        startTransform = transform;
    }

    public void OnRaise()
    {
        GetComponent<Transform>().localPosition = startTransform.localPosition;
        GetComponent<Transform>().localScale = startTransform.localScale;
        GetComponent<Transform>().localRotation = startTransform.localRotation;
    }
}
