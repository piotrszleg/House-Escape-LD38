using UnityEngine;

public class Note : InteractiveItem
{

    [HideInInspector]
    public TextDrawer textDrawer;
    public string [] message;

    public override void Start () {
        textDrawer = FindObjectOfType<TextDrawer>();
        base.Start();
	}

    public override void Interact()
    {
        WriteMessage();
        base.Interact();
    }

    public void WriteMessage()
    {
        textDrawer.Write(message);
    }
}
