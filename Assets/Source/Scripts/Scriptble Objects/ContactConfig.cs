using UnityEngine;
[CreateAssetMenu(fileName = "Contact Config", menuName = "Configs/Contact Config")]
public sealed class ContactConfig : ScriptableObject
{
    [field: SerializeField] public int ID { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
}
