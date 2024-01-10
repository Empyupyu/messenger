using UnityEngine;

public class ContactSystem : GameSystem
{
    private CharacterID _currentContactID;

    public override void OnAwake()
    {
        
    }

    public void SelectContact(CharacterID id)
    {
        Debug.Log("Select " + id);
        _currentContactID = id;
    }
}
