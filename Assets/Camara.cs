using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject player;        

    private Vector3 offset;            

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        Vector3 posicion= player.transform.position + offset;
        posicion.z = -1.4f;
        transform.position = posicion;

    }
}
