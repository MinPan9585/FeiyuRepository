using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0, 1.5f, -10f);
    }
}
