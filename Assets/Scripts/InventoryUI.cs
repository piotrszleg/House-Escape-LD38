using UnityEngine.UI;
using UnityEngine;

public class InventoryUI : MonoBehaviour {

    Inventory inventory;
    public ItemUI itempPrefab;
    ItemUI[] itemUIs;

    // Use this for initialization
    void Start () {
        inventory = FindObjectOfType<Inventory>();
        itemUIs = new ItemUI[inventory.items.Length];
        RectTransform rectTransform = GetComponent<RectTransform>();
        for (int i = 0; i < inventory.items.Length; i++)
        {
            itemUIs[i]= Instantiate<ItemUI>(itempPrefab, rectTransform);
            itemUIs[i].locked = inventory.items[i].locked;
            itemUIs[i].sprite = inventory.items[i].sprite;
        }
    }

    void Update()
    {
        for (int i = 0; i < inventory.items.Length; i++)
        {
            itemUIs[i].locked = inventory.items[i].locked;
        }
    }
}
