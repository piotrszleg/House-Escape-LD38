using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCutscene : InteractiveItem
{

    Inventory inventory;
    TextDrawer textDrawer;
    Player player;
    public int itemIndex;
    public int itemInsideIndex;
    /*messages*/
    public string cantOpen = "I can't open this without a key.";
    public string open = "The key worked.";
    public Vector2 playerStandPosition;
    public Rigidbody2D ball;
    public Rigidbody2D key;
    public SpriteRenderer door;
    public AudioClip hitSound;
    public AudioClip finishSound;
    public GameObject finalText;

    public override void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        player = FindObjectOfType<Player>();
        textDrawer = FindObjectOfType<TextDrawer>();
        base.Start();
    }

    public override void Interact()
    {
        if (inventory.UseItem(itemIndex))
        {
            StartCoroutine(Cutscene());
        }
        else
        {
            textDrawer.Write(cantOpen);
            selected = false;
        }
        base.Interact();
    }

    IEnumerator Cutscene()
    {
        
        player.MoveTo((Vector2)transform.position + playerStandPosition);
        yield return new WaitForEndOfFrame();
        yield return new WaitUntil(() => player.atTarget);
        player.Flip(-1);
        Rigidbody2D ballClone= Instantiate<Rigidbody2D>(ball, player.transform.position, Quaternion.identity);
        ballClone.AddForce(new Vector2(-10, 10), ForceMode2D.Impulse);
        yield return new WaitUntil(()=>Vector2.Distance(transform.position, ballClone.transform.position)<1);
        Destroy(ballClone.gameObject);
        GetComponent<SpriteRenderer>().enabled = false;
        Rigidbody2D keyClone = Instantiate<Rigidbody2D>(key, transform.position, Quaternion.identity);
        Camera.main.GetComponent<CameraMovement>().Shake(0.5f, 0.5f);
        FindObjectOfType<AudioSource>().PlayOneShot(hitSound);
        yield return new WaitForSeconds(0.5f);
        player.MoveTo(keyClone.transform.position);
        yield return new WaitForEndOfFrame();
        yield return new WaitUntil(() => player.atTarget);
        Destroy(keyClone.gameObject);
        player.MoveTo(door.transform.position);
        yield return new WaitForEndOfFrame();
        yield return new WaitUntil(() => player.atTarget);
        door.color = Color.black;
        yield return new WaitForSeconds(1);
        player.gameObject.SetActive(false);
        FindObjectOfType<AudioSource>().PlayOneShot(finishSound);
        finalText.SetActive(true);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, playerStandPosition);
    }
}
