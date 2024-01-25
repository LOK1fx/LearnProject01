using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Image))]
public class ItemInfoUIPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _itemName;
    [SerializeField] private TextMeshProUGUI _itemDescription;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void ShowInfo(ItemInfo info)
    {
        _itemName.text = info.Name;
        _itemDescription.text = info.Description;
        _image.enabled = true;
    }

    public void HideInfo()
    {
        _itemName.text = "";
        _itemDescription.text = "";
        _image.enabled = false;
    }
}