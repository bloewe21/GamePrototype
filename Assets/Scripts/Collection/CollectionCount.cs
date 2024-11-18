using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionCount : MonoBehaviour
{
    public int[] fishCount = new int[5];

    private void Start()
    {
    }


    // Start is called before the first frame update
    public void AddFish(int fish)
    {
        fishCount[fish-1] = fishCount[fish-1] + 1;
    }

    public int GetFish(int fishID)
    {
        return fishCount[fishID];
    }


}
