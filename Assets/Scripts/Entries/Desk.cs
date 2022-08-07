using UnityEngine;

public class Desk : MonoBehaviour
{
    [SerializeField] private GenerateTrigger _generateTrigger;
    public GenerateTrigger GenerateTrigger => _generateTrigger;
}
