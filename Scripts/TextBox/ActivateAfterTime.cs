using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAfterTime : MonoBehaviour
{

    public TextAsset theText;

    public int startLine;
    public int endLine;

    public TextBoxManager theTextBox;

    public bool DestroyWhenActivated;

    public bool requireButtonPress;
    bool waitForPress;

    public float TimeUntilText;

    // Use this for initialization
    void Start()
    {
        theTextBox = FindObjectOfType<TextBoxManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (TimeUntilText <= 0)
        {
            if (waitForPress && Input.GetKeyDown(KeyCode.E))
            {
                theTextBox.ReloadScript(theText);
                theTextBox.currentLine = startLine;
                theTextBox.endLine = endLine;
                theTextBox.enableTextBox();
            }
        }

        TimeUntilText -= Time.deltaTime;

    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (requireButtonPress)
            {
                waitForPress = true;
                return;
            }

            theTextBox.ReloadScript(theText);
            theTextBox.currentLine = startLine;
            theTextBox.endLine = endLine;
            theTextBox.enableTextBox();
        }

        if (DestroyWhenActivated)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            waitForPress = false;
        }
    }
}
