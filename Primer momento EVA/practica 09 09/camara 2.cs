using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara2 : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public Vector3 offset = new Vector3(2.44f, 2.12f, 3.13f);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position+offset;
    }
}
