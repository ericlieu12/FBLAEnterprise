using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CalenderManager : MonoBehaviour {
    public PauseMenu menu;

    public TMP_Text display;
    public TMP_Text objectivediplay;

    public static string[] Dates = new string[12] {"September","October","October","November","December", "February","February","March","March","April","June", "Enjoy the world!"};
    public static string Objective;
    public static int index = 0;

    public int globalIndex;

    public static bool DoNotChangeDate = false;

	// Use this for initialization
	void Start ()
    {
        globalIndex = index;
        Time.timeScale = 1;
        menu.TurnOffMenu();
        display.text = Dates[index];

        if(index == 0)
        {
            objectivediplay.text = "Membership Madness! \nHelp recruit members!\nGo to the auditorium (Second floor) To take on this quest!";
        }
        if (index == 1)
        {
            objectivediplay.text = "Choose which competitive event you are participating in!";
        }

        if (index == 2)
        {
            objectivediplay.text = "State Fall Leadership Conference! If you wish to attend please meet outside of the school building near the Main Entrance!";
        }
        if(index == 3)
        {
            objectivediplay.text = "American Enterprise Day!\nGo to the gym to try to guess the Mystery Word!";
        }
        if (index == 4)
        {
            objectivediplay.text = "FBLA Glowstick Sale for the football game! Go to the Gym for more information to participate!";
        }
        if (index == 5)
        {
            objectivediplay.text = "FBLA WEEK: Go to the Auditorium to hear about the stories of real FBLA Students!";
        }
        if(index == 6)
        {
            objectivediplay.text = "FBLA WEEK: Each One Reach One! Go to the auditorium to begin to recruit members!";
        }
        if (index == 7)
        {
            objectivediplay.text = "Day 2/3 out of States, Event Day!";
        }
        if (index == 8)
        {
            objectivediplay.text = "States Award Ceremony! Congrats to everyone who won an award!";
        }
        if (index == 9)
        {
            objectivediplay.text = "Earth Day!!";
        }
        if (index == 10)
        {
            objectivediplay.text = "THIS IS IT THE NATIONAL LEADERSHIP CONFERENCE!";
        }
        if(index == 11)
        {
            objectivediplay.text = "Thank you!";
        }
        if (DoNotChangeDate)
        {
            DoNotChangeDate = false;
            return;
        }
        index++;
    }
	
    public void KeepDate()
    {
        DoNotChangeDate = true;
    }
	// Update is called once per frame
	void Update ()
    {
		
	}
}
