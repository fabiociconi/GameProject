using UnityEngine;
using System.Collections;

public class CameraHandler : MonoBehaviour
{
    private Transform player;
    public Vector2 smoothing = new Vector2(3, 3);
    
    void Awake()
    {
        player = GameObject.Find("Snake").transform;
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }

    void Update()
    {
        var x = transform.position.x;
        var y = transform.position.y;
        
        x = Mathf.Lerp(x, player.position.x, smoothing.x * Time.deltaTime);
        y = Mathf.Lerp(y, player.position.y, smoothing.y * Time.deltaTime);

        transform.position = new Vector3(x, y, transform.position.z);
    }
}
