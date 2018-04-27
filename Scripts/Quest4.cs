using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quest4 : MonoBehaviour {
    public AudioSource ding;
    public TMP_Text text;
    public int Counter;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        text.text = "Glowsticks Found\n" + Counter + "/100";
	}
}
