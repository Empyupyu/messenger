using System.Collections.Generic;
using UnityEngine;

public sealed class ActivitiesView : MonoBehaviour
{
    [field: SerializeField] public List<ActivitieView> OpenViewButtons { get; private set; }
    [field: SerializeField] public List<GameObject> Views { get; private set; }

    private int _currentID; 

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        foreach (var button in OpenViewButtons) button.Button.onClick.AddListener(() => 
            ShowViewByID(OpenViewButtons.IndexOf(button)));

        ShowViewByID(0);
    }

    private void ShowViewByID(int id)
    {
        EnableButton(_currentID, false);

        _currentID = id;

        EnableButton(_currentID, true);
    }

    private void EnableButton(int id, bool isActive)
    {
        Views[id].gameObject.SetActive(isActive);

        var view = OpenViewButtons[id];
        view.Icon.color = isActive ? view.SelectColor : view.DeSelectColor;
    }
}
