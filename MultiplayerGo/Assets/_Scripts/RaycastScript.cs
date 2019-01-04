using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class RaycastScript : MonoBehaviour {

    public Camera cam;
    public GameObject stoneManager;
	public GameObject gameMenu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // If left mouse button is clicked.
		if (Input.GetMouseButtonDown(0))
        {
			if(gameMenu.activeSelf)
			{
	            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
	            RaycastHit hit;

	            if (Physics.Raycast(ray, out hit))
	            {
	                Vector3 pos = hit.point;
					string coordinate = GameObject.Find ("_GobanManager").GetComponent<CoordinateManager> ().ClickToCoordinate (pos);
					if(coordinate != "")
					{ 
						//GameObject.Find ("_StoneManager").GetComponent<StoneManager> ().CreateStone (coordinate, 0);
						//PGC getPlayer = new PGC();
						//GameObject player = getPlayer.GetPlayerData();

						//player.GetComponent<PlayerDataNetworkingScript>().PlayerClick(coordinate);
					}
	            }
			}
        }
	}
}
