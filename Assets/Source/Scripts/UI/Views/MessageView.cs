using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class MessageView : MonoBehaviour
{
    [field: SerializeField] public Image Icon { get; private set; }
    [field: SerializeField] public TextMeshProUGUI Title { get; private set; }
    [field: SerializeField] public TextMeshProUGUI Message { get; private set; }
    [field: SerializeField] public TextMeshProUGUI Date { get; private set; }

    public CharacterID ContactID { get; private set; }

    public void Initialize(CharacterID id)
    {
        ContactID = id;
    }
}
