using UnityEngine;
using UnityEngine.UI;
public class ContactView : MonoBehaviour
{
    [field: SerializeField] public Button Button { get; private set; }
    [field: SerializeField] public Image Icon { get; private set; }
    public CharacterID ContactID { get; private set; }

    public void Initialize(CharacterID id)
    {
        ContactID = id;
    }
}
