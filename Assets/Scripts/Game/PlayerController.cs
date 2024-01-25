using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerUI _playerUI;

    private Player _currentPlayer;
    private PlayerUI _currentPlayerUI;

    private void Awake()
    {
        _currentPlayer = Instantiate(_player, Vector3.zero, Quaternion.identity);
        _currentPlayerUI = Instantiate(_playerUI, Vector3.zero, Quaternion.identity);

        _currentPlayerUI.Construct(_currentPlayer);
    }
}