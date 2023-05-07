using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpForce;
    public bool isGrounded = false;
    public GameObject bulletPrefab;
    private LineRenderer lineRend;
    private DistanceJoint2D distJoint;
    private Node selectedNode;

    private void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        distJoint = GetComponent<DistanceJoint2D>();
        selectedNode = null;
        lineRend.enabled = false;
        distJoint.enabled = false;
    }

    public void SelectNode(Node node)
    {
        selectedNode = node;
    }

    public void DeselectNode()
    {
        selectedNode = null;
    }

    private void NodeBehaviour()
    {
        if (selectedNode == null)
        {
            lineRend.enabled = false;
            distJoint.enabled = false;
            return;
        }

        lineRend.enabled = true;
        distJoint.enabled = true;
        distJoint.connectedBody = selectedNode.GetComponent<Rigidbody2D>();

        if(selectedNode != null)
        {
            lineRend.SetPosition(0, transform.position);
            lineRend.SetPosition(1, selectedNode.transform.position);
        }
    }

    void Update()
    {
        NodeBehaviour();
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector2(-1, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector2(1, 0));
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) 
        {
            rb.AddForce(new Vector2(0, jumpForce));
        }
        //if (Input.GetMouseButtonDown(0))
        //{
        //    GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        //    Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    Vector3 dir = mouseWorldPos - transform.position;
        //    bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(dir.x, dir.y).normalized *1000);
        //}
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    public void Die()
    {
        transform.position = Vector3.zero;
        rb.velocity = Vector2.zero;
    }
}
