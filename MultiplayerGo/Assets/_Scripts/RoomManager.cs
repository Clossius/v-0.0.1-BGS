using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

public class RoomPropertyKeys 
{
	public string boardSize = "bs";
	public string numPlayers = "np";
	public string currentTurn = "ct";
	public string ruleSet = "rs";
	public string timeSet = "ts";
	public string activeGame = "ag";
	public string playerOneName = "pon";
	public string playerTwoName = "ptn";
	public string playerOneTime = "pot";
	public string playerTwoTime = "ptt";
}

public class RoomManager : MonoBehaviourPunCallbacks {

	/// <summary>
	/// Called when the local user/client left a room, so the game's logic can clean up it's internal state.
	/// </summary>
	/// <remarks>When leaving a room, the LoadBalancingClient will disconnect the Game Server and connect to the Master Server.
	/// This wraps up multiple internal actions.
	/// 
	/// Wait for the callback OnConnectedToMaster, before you use lobbies and join or create rooms.</remarks>

	public override void OnLeftRoom ()
	{
		Debug.Log ("Left room.");
		GameObject.Find ("_Scripts").GetComponent<MenuManager> ().ChangeMenu (1);
	}

	public void LeaveRoom ()
	{
		PhotonNetwork.LeaveRoom ();
	}

	// Initialize the room settings.
	public void InitializeRoomSettings ()
	{
		if(!PhotonNetwork.IsMasterClient || !PhotonNetwork.IsConnected)
		{
			Debug.Log ("Not the master client or not connected to network.");
			return;
		}
			
		ExitGames.Client.Photon.Hashtable hash = new ExitGames.Client.Photon.Hashtable ();
		RoomPropertyKeys rpk = new RoomPropertyKeys();

		hash.Add (rpk.boardSize, 9);
		hash.Add (rpk.currentTurn, 0);
		hash.Add (rpk.numPlayers, 2);
		hash.Add (rpk.ruleSet, 0);
		hash.Add (rpk.timeSet, 0);
		hash.Add (rpk.activeGame, false);
		hash.Add (rpk.playerOneName, "");
		hash.Add (rpk.playerTwoName, "");


		string username = PhotonNetwork.NickName;
		hash [rpk.playerOneName] = username;

		PhotonNetwork.CurrentRoom.SetCustomProperties (hash, null, null);

		GameObject.Find ("GameMenu").GetComponent<SubMenu> ()
			.UpdatePlayers ((string)PhotonNetwork.CurrentRoom.CustomProperties[rpk.playerOneName]
				, (string)PhotonNetwork.CurrentRoom.CustomProperties[rpk.playerTwoName]);

		GameObject.Find ("GameMenu").GetComponent<SubMenu> ().JoinRoom (PhotonNetwork.CurrentRoom.Name);
	}

	// Player joined
	public void OnPlayerJoined (string username)
	{
		Debug.Log ("Player Joined: " + username);
	}

	// Debug the properties of the room that changed.
	public override void OnRoomPropertiesUpdate (ExitGames.Client.Photon.Hashtable propertiesThatChanged)
	{
		base.OnRoomPropertiesUpdate (propertiesThatChanged);
		Debug.Log (propertiesThatChanged);
	}
}
