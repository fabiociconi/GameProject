using UnityEngine;
using System.Collections;
using System;

public class CameraHandler : MonoBehaviour
{
    private Transform player;

    public Vector2 XLimits = new Vector2(2, 2);
    public Vector2 YLimits = new Vector2(2, 2);
    public Vector2 smoothing = new Vector2(3, 3);

    void Awake()
    {
        player = GameObject.Find("Snake").transform;
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }

    void Update()
    {

        // Mouse wheel zoom in
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (GetComponent<Camera>().orthographicSize > 5)
                 GetComponent<Camera>().orthographicSize--;
        }
        // Mouse wheel zoom out
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (GetComponent<Camera>().orthographicSize <20 )
                GetComponent<Camera>().orthographicSize++;
        }
        //
        var x = transform.position.x;
        var y = transform.position.y;

        x = Mathf.Lerp(x, player.position.x, smoothing.x * Time.deltaTime);
        y = Mathf.Lerp(y, player.position.y, smoothing.y * Time.deltaTime);

        if (x <= XLimits.x)
        {
            x = XLimits.x;
        }
        else if (x >= XLimits.y)
        {
            x = XLimits.y;
        }

        if (y <= YLimits.x)
        {
            y = YLimits.x;
        }
        else if (y >= YLimits.y)
        {
            y = YLimits.y;
        }

        transform.position = new Vector3(x, y, transform.position.z);

    }

}
