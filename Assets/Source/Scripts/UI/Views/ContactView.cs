using UnityEngine;
using UnityEngine.UI;
public class ContactView : MonoBehaviour
{
    [field: SerializeField] public Button Button { get; private set; }
    public int ContactID { get; private set; }

    public void Initialize(int id)
    {
        ContactID = id;
    }
}
