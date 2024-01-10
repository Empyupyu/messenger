using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Messages Config", menuName = "Configs/Messages Config")]
public sealed class MessagesConfig : ScriptableObject
{
    [field: SerializeField] public List<MessageConfig> MessageConfigs { get; private set; }
    [field: SerializeField] public MessageView MessageView { get; private set; }
}
