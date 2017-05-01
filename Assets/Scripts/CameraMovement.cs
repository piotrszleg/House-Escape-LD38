using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform player;
    public float speed = 1;
    public Vector3 normalPosition;
    public Vector3 shakePosition;
    public Vector3 offset = new Vector3(0, 0, -10);

    // Use this for initialization
    void Start()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
            Vector3 newPosition = player.position + offset;
            normalPosition = Vector3.Lerp(normalPosition, newPosition, Time.deltaTime * speed);
        }
        transform.position = normalPosition + shakePosition;
    }

    public void Shake(float magnitude, float duration)
    {
        StartCoroutine(_Shake(magnitude, duration));
    }

    IEnumerator _Shake(float magnitude, float duration)
    {
        float elapsed = 0.0f;

        //Vector3 originalCamPos = transform.position;

        while (elapsed < duration)
        {

            elapsed += Time.deltaTime;

            float percentComplete = elapsed / duration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // map value to [-1, 1]
            float x = Random.value * 2.0f - 1.0f;
            float y = Random.value * 2.0f - 1.0f;
            x *= magnitude * damper;
            y *= magnitude * damper;

            shakePosition = new Vector3(x, y, 0);

            yield return null;
        }

        //transform.position = originalCamPos;
    }
}
