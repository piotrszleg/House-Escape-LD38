using UnityEngine.UI;
using UnityEngine;

public class ItemUI : MonoBehaviour {

	public bool locked
    {
        set
        {
            GetComponent<Image>().color = value ? Color.black : Color.white;//new Color(1, 1, 1, value ? 0 : 1);
        }
    }

    public Sprite sprite{
        set
        {
            GetComponent<Image>().sprite = value;
        }
    }
}
