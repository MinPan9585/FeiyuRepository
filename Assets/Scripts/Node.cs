using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private Player player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        player.SelectNode(this);
    }

    public void OnMouseUp()
    {
        player.DeselectNode();
    }
}
