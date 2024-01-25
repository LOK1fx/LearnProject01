using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private ItemInfoUIPanel _itemInfoUIPanel;

    private Player _currentPlayer;

    public void Construct(Player player)
    {
        _currentPlayer = player;

        _currentPlayer.InteractableInfo.OnItemSelected += OnInteractableItemSelected;
        _currentPlayer.InteractableInfo.OnItemDeselected += OnInteractableItemDeselected;
    }

    private void OnInteractableItemDeselected()
    {
        _itemInfoUIPanel.HideInfo();
    }

    private void OnInteractableItemSelected(ItemInfo info)
    {
        _itemInfoUIPanel.ShowInfo(info);
    }
}