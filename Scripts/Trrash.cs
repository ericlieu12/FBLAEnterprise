using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trrash : MonoBehaviour
{
    Quest8 quest;
    // Use this for initialization
    void Start()
    {
        quest = FindObjectOfType<Quest8>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            quest.ding.Play();
            quest.Counter++;
            Destroy(gameObject);
        }
    }
}
