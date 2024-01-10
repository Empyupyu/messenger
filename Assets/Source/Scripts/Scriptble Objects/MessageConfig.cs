using UnityEngine;

[CreateAssetMenu(fileName = "Message Config", menuName = "Configs/Message Config")]
public sealed class MessageConfig : ScriptableObject
{
    [field: SerializeField] public CharacterID ID { get; private set; }
    [field: SerializeField] public string Title { get; private set; }
    [field: SerializeField] public string Message { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public string Date { get; private set; }
    [field: SerializeField] public Color TitleColor { get; private set; }
}
