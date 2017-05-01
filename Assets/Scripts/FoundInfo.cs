using UnityEngine;
using UnityEngine.UI;

public class FoundInfo : MonoBehaviour {

    public Image image;
    Animator anim;
    static FoundInfo instance;

    void Start()
    {
        anim = GetComponent<Animator>();
        instance = this;
    }

	public static void Show(Sprite sprite)
    {
        Debug.Log("Show");
        instance.image.sprite = sprite;
        instance.anim.Play("SlideInandOut");
    }
}
