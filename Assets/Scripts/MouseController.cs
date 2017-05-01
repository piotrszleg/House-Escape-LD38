using UnityEngine.EventSystems;
using UnityEngine;

public class MouseController : MonoBehaviour {

    Camera mainCam;
    Player player;
    InteractiveItem previouslySelected;
    public Transform crosshair;

	// Use this for initialization
	void Start () {
        mainCam = Camera.main;
        player = FindObjectOfType<Player>();
        crosshair.position = new Vector3(int.MaxValue, int.MaxValue, 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Click(mainCam.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    void Click(Vector2 position)
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            //Mouse hovers above UI.
            return;
        }
        bool accepted = false;
        Collider2D[] overlapingColliders=new Collider2D[10];
        Physics2D.OverlapPointNonAlloc(position, overlapingColliders);
        for(int i=0; i<overlapingColliders.Length; i++)
        {
            if (overlapingColliders[i] != null)
            {
                InteractiveItem ii = overlapingColliders[i].GetComponent<InteractiveItem>();//GetComponents?
                if (ii != null)
                {
                    crosshair.position = ii.transform.position;
                    Debug.Log(ii.name+" selected");
                    if (previouslySelected != null)
                    {
                        previouslySelected.selected = false;
                    }
                    ii.selected = true;
                    previouslySelected = ii;
                    player.MoveTo(position);
                    accepted = true;
                    break;
                }
            }
        }
        if (!accepted)
        {
            player.MoveTo(position);
            crosshair.position = new Vector3(int.MaxValue, int.MaxValue, 0);
        }
    }
}
