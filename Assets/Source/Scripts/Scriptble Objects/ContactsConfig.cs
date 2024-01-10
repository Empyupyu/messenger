using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Contacts Config", menuName = "Configs/Contacts Config")]
public sealed class ContactsConfig : ScriptableObject
{
    [field: SerializeField] public List<ContactConfig> ContactConfigs { get; private set; }
}
