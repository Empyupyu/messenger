using Supyrb;

public sealed class ContactSystem : GameSystem
{
    private SelectContactSignal _selectContactSignal = Signals.Get<SelectContactSignal>();

    private CharacterID _currentContactID;
    private bool _isSelected;

    public void SelectContact(CharacterID id)
    {
        _isSelected = _currentContactID == id ? _isSelected = !_isSelected : true;
        _currentContactID = id;

        _selectContactSignal.Dispatch(new MessageFilterByContact(id, _game.AllMessages), _isSelected);
    }
}
