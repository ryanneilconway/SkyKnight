using UnityEngine;
using System.Collections;

public class CameraUpdater : MonoBehaviour
{

    private Transform player;
    public float zoomLevel;
    public float horizontalOffset;
    public float verticalOffset;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        transform.position = new Vector3(player.position.x + horizontalOffset, player.position.y + verticalOffset, player.position.z - zoomLevel);
    }
}