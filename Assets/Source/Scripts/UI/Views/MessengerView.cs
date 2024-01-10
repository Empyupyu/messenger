using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessengerView : MonoBehaviour
{
    [field: SerializeField] public TextMeshProUGUI Title { get; private set; }
    [field: SerializeField] public Button ContactHideButton { get; private set; }
    [field: SerializeField] public RectTransform MessangeHolder { get; private set; }
    [field: SerializeField] public List<MessageView> MessageViews { get; private set; }
    [field: SerializeField] public VerticalLayoutGroup VerticalLayoutGroup { get; private set; }
    [field: SerializeField] public ContactsView ContactsView { get; private set; }
}
