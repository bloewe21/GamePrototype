using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCollection : MonoBehaviour
{
    public GameObject Collection;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Camera1;
    public GameObject Camera2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Collection.active)
        {
            Close();
        }
    }

    public void Close()
    {
        Collection.GetComponent<CollectionSpawnFish>().Close();
        Collection.SetActive(false);
        Camera1.SetActive(true);
        Camera2.SetActive(false);
        Button1.SetActive(true);
        //Button2.SetActive(true);
        //Button3.SetActive(true);
    }
}
