using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : InteractiveItem {

    Inventory inventory;
    TextDrawer textDrawer;
    public int itemIndex;
    public int itemInsideIndex;
    /*messages*/
    public string cantOpen = "I can't open this without a key.";
    public string open = "The key worked.";
    public bool destroyAfterOpening = false;
    public AudioClip sound;

    public override void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        textDrawer = FindObjectOfType<TextDrawer>();
        base.Start();
    }

    public override void Interact()
    {
        if (inventory.UseItem(itemIndex))
        {
            textDrawer.Write(open);
            if (!inventory.HasItem(itemIndex))
                inventory.EquipItem(itemInsideIndex);
            base.Interact();
            StartCoroutine(Say());
            if (destroyAfterOpening)
            {
                GetComponent<SpriteRenderer>().enabled = false;
            }
        }else
        {
            textDrawer.Write(cantOpen);
            selected = false;
        }
    }

    IEnumerator Say()
    {
        yield return new WaitUntil(() => !textDrawer.drawing);
        Debug.Log(0);
        FoundInfo.Show(inventory.items[itemInsideIndex].sprite);

    }
}
