using UnityEngine;

public class IncrementValue : MonoBehaviour
{
    [SerializeField] private IntVariable variable;

    public void OnRaise(int increment)
    {
        variable.value += increment;
    }
}
