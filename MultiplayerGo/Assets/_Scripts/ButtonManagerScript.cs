using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;


public class ButtonManagerScript : MonoBehaviour {
	
	//**********************************************************************
	// This script is for managing the actions of buttons when pressed.
	//**********************************************************************

	public GameObject errorMessage;

	// Guest Button.
	// Logs the user in as a guest.
	// Changes the menu to Lobby Menu
	public void GuestButton ()
	{
		errorMessage.SetActive (false);
		int num = Random.Range (1000, 10000);
		PhotonNetwork.NickName = "Guest#" + num.ToString();
		Debug.Log ("Username: " + PhotonNetwork.NickName);
		GameObject.Find ("_Scripts").GetComponent<MenuManager>().ChangeMenu (1);
		GameObject.Find ("_Network").GetComponent<NetworkManager>().JoinLobby();
	}

	// Login Button
	public void LoginButton (GameObject go)
	{
		TextMeshProUGUI text = go.GetComponent<TextMeshProUGUI> ();

		if (text.text.Length > 4 && text.text.Length < 10) {
			PhotonNetwork.NickName = text.text;
			Debug.Log ("Username: " + PhotonNetwork.NickName);
			errorMessage.SetActive (false);
			GameObject.Find ("_Scripts").GetComponent<MenuManager>().ChangeMenu (1);
			GameObject.Find ("_Network").GetComponent<NetworkManager>().JoinLobby();

		} else {
			errorMessage.SetActive (true);
		}
	}

	// Opens the Game menu and board.
	// Sets up room with given conditions.
	public void PlayButton (GameObject title)
	{
		// ****
		// Make sure room settings are set before running this function.
		// ****
		this.GetComponent<MenuManager> ().ChangeMenu (2);

		GameObject.Find ("_GobanManager").GetComponent<DrawLineScript> ()
			.MakeGoban ();
		GameObject.Find ("_StoneManager").GetComponent<StoneManagerScript> ()
			.LoadStoneSettings ();

		GameObject.Find ("_Network").GetComponent<NetworkManager> ().JoinRandomRoom();
	}

	// Leaves the game room and returns to the game menu.
	public void LeaveRoomButton ()
	{
		GameObject.Find ("_StoneManager").GetComponent<StoneManagerScript> ().DestroyStones ();
		GameObject.Find ("_GobanManager").GetComponent<DrawLineScript> ().DestroyLines ();
		GameObject.FindGameObjectWithTag ("RoomManager").GetComponent<RoomManager> ().LeaveRoom ();

	}
}
