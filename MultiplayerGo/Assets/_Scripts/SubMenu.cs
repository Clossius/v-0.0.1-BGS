using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class SubMenu : MonoBehaviour {

	public GameObject title;
	public GameObject pOneUsername;
	public GameObject pTwoUsername;
	public GameObject pOneTimeText;
	public GameObject pTwoTimeText;
	public GameObject subMenu;

	// When a player joins a room
	// this function gets called.
	// Open the submenu and initialize text.
	public void JoinRoom (string roomID)
	{
		subMenu.SetActive (true);

		title = GameObject.FindGameObjectWithTag ("SubMenuTitle");
		TextMeshProUGUI text = title.GetComponent<TextMeshProUGUI> ();

		text.text = "Room: " + roomID;
	}

	// Update the player information in a room.
	public void UpdatePlayers (string playerOne, string playerTwo)
	{
		TextMeshProUGUI pOneUser = pOneUsername.GetComponent<TextMeshProUGUI> ();
		TextMeshProUGUI pTwoUser = pTwoUsername.GetComponent<TextMeshProUGUI> ();

		pOneUser.text = playerOne;
		pTwoUser.text = playerTwo;

	}

	// When the game starts, setup room and start
	// the room settings.
	public void StartGameSetup ()
	{
		GameObject info = GameObject.FindGameObjectWithTag ("SubMenuInfo");
		if (info){
			TextMeshProUGUI text = info.GetComponent<TextMeshProUGUI> ();
			text.text = "Game active.";
		}
		subMenu.SetActive (false);
	}
}
