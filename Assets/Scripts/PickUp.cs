using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : Note {

    Inventory inventory;
    public int itemIndex;
    public AudioClip sound;

    public override void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        base.Start();
    }

    public override void Interact()
    {
        if (!inventory.HasItem(itemIndex)) {
            FindObjectOfType<AudioSource>().PlayOneShot(sound);
            inventory.EquipItem(itemIndex);
            base.Interact();
            StartCoroutine(Say());
        }
        selected=false;
    }

    IEnumerator Say()
    {
        yield return new WaitUntil(()=>!textDrawer.drawing);
        FoundInfo.Show(inventory.items[itemIndex].sprite);

    }
}
