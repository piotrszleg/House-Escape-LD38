using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveItem : MonoBehaviour {

    public bool selected;
    public UnityEvent action;

    public void OnTriggerStay2D()
    {
        if (selected)
        {
            Interact();
        }
    }

    public virtual void Start()
    {

    }


    public virtual void Interact()
    {
        action.Invoke();
        selected = false;
    }
}
