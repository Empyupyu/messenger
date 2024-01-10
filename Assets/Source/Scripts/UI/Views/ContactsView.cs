using System.Collections.Generic;
using UnityEngine;
public class ContactsView : MonoBehaviour
{
    [field: SerializeField] public Transform ContactsHolder { get; private set; }
    [field: SerializeField] public List<ContactView> Contacts { get; private set; }
}
