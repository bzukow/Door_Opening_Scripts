using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_target_camera : MonoBehaviour
{
    private GameObject player;
    private ZulController playerScript;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Zul");
        playerScript = player.GetComponent<ZulController>();
    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 4f, player.transform.position.z - 12f);
    }
}
