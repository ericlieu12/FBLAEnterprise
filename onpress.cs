﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onpress : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Jump"))
        {
            Application.LoadLevel("Main Menu");
        }
    }

}
