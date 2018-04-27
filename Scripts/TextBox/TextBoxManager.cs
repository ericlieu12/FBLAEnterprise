using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityStandardAssets.Characters.ThirdPerson;

public class TextBoxManager : MonoBehaviour
{
    public GameObject TextBox;

    public TMP_Text theText;

    public int currentLine;
    public int endLine;

    public TextAsset textFile;
    public string[] textLines;

    public bool isActive;

    public bool stopPlayer;

    private bool isTyping = false;
    private bool cancelType = false;

    public float typeSpeed;
    public AudioSource sound;

    public int charPerSound;
    int charPerSoundCounter;

    public bool pressedButton;

    CharacterController character;
    public ThirdPersonUserControl controller;
    public ThirdPersonCharacter controller2;

    //use this for initialization
    void Start()
    {
        character = FindObjectOfType<CharacterController>();

        pressedButton = false;

        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));

        }


        if (endLine == 0)
        {
            endLine = textLines.Length - 1;
        }

        if (isActive)
        {
            enableTextBox();
        }
        else
        {
            DisableTextBox();
        }
    }

    void Update()
    {
        if (!isActive)
        {
            return;
        }
        //theText.text = textLines[currentline];

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isTyping)
            {
                currentLine++;

                if (currentLine > endLine)
                {
                    DisableTextBox();
                }
                else
                {
                    StartCoroutine(TextScroll(textLines[currentLine]));
                }
            }
            else if (isTyping && !cancelType)
            {
                cancelType = true;
            }
        }
    }

    private IEnumerator TextScroll(string lineOfText)
    {
        int letter = 0;
        theText.text = "";
        isTyping = true;
        cancelType = false;
        while (isTyping && !cancelType && (letter < lineOfText.Length - 1))
        {
            theText.text += lineOfText[letter];
            letter += 1;
            if (charPerSoundCounter == charPerSound)
            {
                sound.Play();
                charPerSoundCounter = 0;
            }
            charPerSoundCounter++;
            yield return new WaitForSeconds(typeSpeed);
        }

        theText.text = lineOfText;
        isTyping = false;
        cancelType = false;
    }

    public void enableTextBox()
    {
        character.moveSetting.forwardVel = 0;
        character.moveSetting.jumpVel = 0;
        character.moveSetting.rotateVel = 0;

        TextBox.SetActive(true);
        isActive = true;
        controller.enabled = false;
        controller2.m_MoveSpeedMultiplier = (0f);
        controller2.m_Animator.SetFloat("Forward", 0);
        StartCoroutine(TextScroll(textLines[currentLine]));

    }

    public void DisableTextBox()
    {
        character.moveSetting.forwardVel = 7;
        character.moveSetting.jumpVel = 5;
        character.moveSetting.rotateVel = 100;
        TextBox.SetActive(false);
        isActive = false;
        controller.enabled = true;
        controller2.m_MoveSpeedMultiplier = (2f);
    }

    public void ReloadScript(TextAsset theText)
    {
        if (theText != null)
        {
            textLines = new string[1];
            textLines = (theText.text.Split('\n'));
        }

    }
}
