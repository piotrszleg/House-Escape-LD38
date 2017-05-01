using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    [System.Serializable]
    public class Item{
        public Sprite sprite;
        public bool locked;
    }
    public Item[] items;

    public bool HasItem(int index)
    {
        return !items[index].locked;
    }
    public bool UseItem(int index)
    {
        if (!items[index].locked)
        {
            items[index].locked = true;
            return true;
        }else
        {
            return false;
        }
    }
    public void EquipItem(int index)
    {
        items[index].locked = false;
    }
}
