using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glowstick : MonoBehaviour {
    Quest4 quest;
	// Use this for initialization
	void Start ()
    {
        quest = FindObjectOfType<Quest4>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            quest.ding.Play();
            quest.Counter++;
            Destroy(gameObject);
        }
    }
}
