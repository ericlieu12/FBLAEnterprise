using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestNPC : MonoBehaviour {
    public Material mat;
    public bool Talked;
    public NPCTree quest;
    
    // Use this for initialization
    void Start ()
    {
        quest = FindObjectOfType<NPCTree>();
        Talked = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Talked)
        {
            mat.color = Color.green;
            return;
            
        }
        mat.color = Color.red;
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(Talked ==false)
            {
                gameObject.GetComponent<BoxCollider>().enabled = false;
                quest.Counter++;
                
            }
            Talked = true;
            


        }
    }
}
