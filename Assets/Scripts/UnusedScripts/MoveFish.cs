using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoveFish : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speedX = 1f;
    [SerializeField] private int sliderStrength = 1;
    [SerializeField] private int fishWeight = 50;
    [SerializeField] private int scoreValue = 1;
    [SerializeField] private bool isCaught = false;
    //[SerializeField] private GameObject fishSlider;

    private GameObject bob;
    private GameObject score;
    private GameObject canvas;
    private GameObject slider;
    private GameObject bucket;
    public CollectionCount collectionCount;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collectionCount = FindObjectOfType<CollectionCount>();

        int speedMod = Random.Range(0, 2);
        if (speedMod == 0)
        {
            speedX *= -1;
        }
        rb.velocity = new Vector3(speedX, 0f, 0f);

        bob = GameObject.Find("Bob");
        score = GameObject.Find("Score");
        canvas = GameObject.Find("Canvas");
        slider = canvas.transform.Find("Slider").gameObject;
        bucket = GameObject.Find("Bucket");
    }

    // Update is called once per frame
    void Update()
    {
        if (isCaught)
        {
            transform.position = new Vector3(bob.transform.position.x, bob.transform.position.y - 0.5f, bob.transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            //print("wall");
            WallFunction();
        }

        if (other.gameObject.tag == "Bob")
        {
            //print("bob");
            BobFunction();
            bob.GetComponent<MoveBob>().UpdateWeight(fishWeight);
        }

        if (other.gameObject.tag == "Surface")
        {
            //print("surface");
            SurfaceFunction();
        }
    }

    private void WallFunction()
    {
        speedX = speedX * -1.0f;
        rb.velocity = new Vector3(speedX, 0f, 0f);
    }

    private void BobFunction()
    {
        isCaught = true;
        rb.velocity = new Vector3(0f, 0f, 0f);
        slider.GetComponent<Slider>().maxValue = sliderStrength;

        slider.SetActive(true);
        slider.GetComponent<SliderScript>().currentFish = this.gameObject;
    }

    private void SurfaceFunction()
    {
        score.GetComponent<ScoreScript>().score += scoreValue;
        slider.GetComponent<SliderScript>().RemoveFish();

        //get num from fish name
        string fishName = transform.name;
        char c = fishName[4];
        int i = c - '0';

        //Add too fish collection
        collectionCount.AddFish(i);

        print(i);
        bucket.GetComponent<BucketScript>().SpawnBucketFish(i);
        //Destroy(gameObject);
    }
}
