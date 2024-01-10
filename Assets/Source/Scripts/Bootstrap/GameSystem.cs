using UnityEngine;
using Zenject;

public class GameSystem : MonoBehaviour
{
    [Inject] protected GameData _game;

    public virtual void OnAwake() { }
    public virtual void OnUpdate() { }
}
