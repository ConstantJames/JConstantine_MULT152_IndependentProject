using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private BoxCollider playerCollider;
    private float playerClearance;

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = GetComponent<BoxCollider>();
        playerClearance = playerCollider.size.y * 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
