using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("0");
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().Die();
        }
    }
}
