using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    private Vector2 startPos;
    private Camera cam;

    private float targetPos;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        targetPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            startPos = cam.ScreenToWorldPoint(Input.mousePosition);
        else if (Input.GetMouseButton(0))
        {

            float position = cam.ScreenToWorldPoint(Input.mousePosition).x - startPos.x;
            targetPos = Mathf.Clamp(transform.position.x - position,-7.6f,7.2f);
        }
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, targetPos, speed * Time.deltaTime), transform.position.y, transform.position.z);
    }
}
