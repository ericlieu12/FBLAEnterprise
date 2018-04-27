using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BroadcastJournalism : MonoBehaviour
{
    public AudioSource ding;
    public TMP_Text text;
    public int Counter1;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Interview 5 People About the Bike Thefts!\n" + Counter1 + "/5 \n " ;
        
    }
}
  