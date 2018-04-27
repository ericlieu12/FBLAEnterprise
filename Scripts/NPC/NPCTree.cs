using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCTree : MonoBehaviour
{
    public TMP_Text text;

    public int Counter;
	// Use this for initialization
	void Start ()
    {
        Counter = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        text.text = "Members recruited " + Counter + "/10";
	}
}
