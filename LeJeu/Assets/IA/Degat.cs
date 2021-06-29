using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Degat : MonoBehaviour
{
    public SphereCollider sphereCollider;
    public bool hit;
    // Start is called before the first frame update
    void Start()
    {
        hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider others)
    {
        hit = true;
    }
}
