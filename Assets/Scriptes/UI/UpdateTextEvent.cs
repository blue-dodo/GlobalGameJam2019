using UnityEngine;
using TMPro;

public class UpdateTextEvent : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI deathCounter;

    public void OnRaise(IntVariable variable)
    {
        deathCounter.SetText("" + variable.value);
    }
}
