using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class MoveFishCollection : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private int fishNum = 1;
    [SerializeField] private float speedZ = 1f;
    public GameObject water;
    public Vector3 destination;
    private bool turning = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //spawn with random velocity direction
        int speedMod = Random.Range(0, 2);
        if (speedMod == 0)
        {
            speedZ *= -1;
        }
        rb.velocity = new Vector3(0f, 0f, speedZ);


    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(destination, transform.position);
        if(dist < 0.1f && !turning)
        {
            float slowSpeed = Random.Range(0.1f, 0.3f);
            rb.velocity = transform.up * slowSpeed;
            turning = true;
            float wait = Random.Range(0.1f, 1.0f);
            Invoke("SetSwim", wait);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            //WallFunction();
            SetSwim();
        }
        if (other.gameObject.tag == "Side")
        {
            SideFunction();
        }
    }

    private void WallFunction()
    {
        //reverse direction if hit wall
        speedZ = speedZ * -1.0f;

        float rotTest = Random.Range(60.0f, 120.0f);

        Quaternion fishTurn = Quaternion.Euler(0, rotTest, 90.0f);

        transform.rotation = fishTurn;

        rb.velocity = transform.up * speedZ;

    }

    private void SideFunction()
    {
        //reverse direction if hit wall
        speedZ = speedZ * -1.0f;

        float rotTest = Random.Range(60.0f, 120.0f);
        //Vector3 turnVect = new Vector3(0.0f, rotTest, 0.0f);
        Quaternion fishTurn = Quaternion.Euler(rotTest, 0f, 90f);
        //rb.MoveRotation(fishTurn);
        transform.rotation = fishTurn;

        //rb.velocity = new Vector3((speedZ - (speedZ * (rotTest/90f))), 0f, speedZ - (speedZ * (90f/rotTest)));
        //rb.velocity = new Vector3(0f, 0f, speedZ);
        rb.velocity = transform.up * speedZ;
    }


    private void SetSwim()
    {
        turning = false;
        speedZ = 1.0f;
        //Collider mesh = water.GetComponent<Collider>();
        //Mesh mesh = water.GetComponent<Mesh>();
        //destination = new Vector3(
            //Random.Range(mesh.bounds.min.x, mesh.bounds.max.x),
            //Random.Range(mesh.bounds.min.y, mesh.bounds.max.y),
            //Random.Range(mesh.bounds.min.z, mesh.bounds.max.z));
        destination = new Vector3(
            Random.Range(-16, 0),
            Random.Range(-16, -1),
            Random.Range(-3, 3));

        transform.LookAt(destination);
        //Quaternion fishTurn = Quaternion.Euler(transform.rotation.x + 90, transform.rotation.y, transform.rotation.z);
        //transform.rotation = fishTurn;
        transform.Rotate(90f, 0f, 0f);
        rb.velocity = transform.up * speedZ;

    }


}
