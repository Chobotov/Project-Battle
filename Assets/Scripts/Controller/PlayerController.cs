using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Vector2 startPos;
    private Camera cam;

    private float verticalHotLine = -2;
    private float targetPos;


    [SerializeField]
    private float leftHotline, rightHotline;

    void Start()
    {
        cam = GetComponent<Camera>();
        targetPos = transform.position.x;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            startPos = cam.ScreenToWorldPoint(Input.mousePosition);
        else if (Input.GetMouseButton(0))
        {
            float y = cam.ScreenToWorldPoint(Input.mousePosition).y;
            //Debug.Log(y);
            if (y >= verticalHotLine)
            {
                float position = cam.ScreenToWorldPoint(Input.mousePosition).x - startPos.x;
                targetPos = Mathf.Clamp(transform.position.x - position, leftHotline, rightHotline);
            }
        }
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, targetPos, speed * Time.deltaTime), transform.position.y, transform.position.z);
    }
}
