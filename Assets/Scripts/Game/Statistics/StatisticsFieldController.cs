using TMPro;
using UnityEngine;

public class StatisticsFieldController : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public TextMeshProUGUI Value;

    void Update()
    {
        Value.fontSize = Text.fontSize;
    }
}
