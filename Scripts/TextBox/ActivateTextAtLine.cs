using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActivateTextAtLine : MonoBehaviour {

    public TextAsset theText;

    public int startLine;
    public int endLine;

    public TextBoxManager theTextBox;

    public bool DestroyWhenActivated;

    public bool requireButtonPress;

    bool waitForPress;

	// Use this for initialization
	void Start ()
    {
        theTextBox = FindObjectOfType<TextBoxManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(theTextBox.pressedButton)
        {
            return;
        }
		if(waitForPress && Input.GetKeyDown(KeyCode.E))
        {
            theTextBox.ReloadScript(theText);
            theTextBox.currentLine = startLine;
            theTextBox.endLine = endLine;
            theTextBox.enableTextBox();
            theTextBox.pressedButton = true;
        }
    }

	

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(requireButtonPress)
            {
                waitForPress = true;
                return;
            }

            theTextBox.ReloadScript(theText);
            theTextBox.currentLine = startLine;
            theTextBox.endLine = endLine;
            theTextBox.enableTextBox();
        }

        if(DestroyWhenActivated)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            waitForPress = false;
        }
    }
}
