using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject GroundPrefab;
    public int X, Y;

    void Start()
    {
        for (float i = -X / 2; i < (X / 2); i += 0.2f)
        {
            for (float j = -Y/2; j < (Y/2); j += 0.2f)
            {
                Instantiate(GroundPrefab, new Vector3(i, j, 0), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
