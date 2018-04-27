using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest3 : MonoBehaviour
{
    public Material mat;
    public bool Talked;
    // Use this for initialization
    void Start()
    {
        Talked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Talked)
        {
            mat.color = Color.green;
            return;
        }
        mat.color = Color.red;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Talked = true;
        }
    }
}
