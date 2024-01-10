using UnityEngine;
using UnityEngine.UI;

public class ActivitieView : MonoBehaviour
{
    [field: SerializeField] public Button Button { get; private set; }
    [field: SerializeField] public Image Icon { get; private set; }
    [field: SerializeField] public Color SelectColor { get; private set; }
    [field: SerializeField] public Color DeSelectColor { get; private set; }
}
