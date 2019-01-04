using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;



public class StoneManagerScript : MonoBehaviour {

	public class Stone {
		public GameObject stone;
		public string coordinate;
		public int color;

		public Stone (GameObject _stone, string _coordinate, int _color)
		{
			stone = _stone;
			coordinate = _coordinate;
			color = _color;
		}
	}

    public GameObject stone;
    public Material blackMaterial;
    public Material whiteMaterial;

    public float y = 0.025f; // height of all the stones.

	List<Stone> stones;

	// Initalize stone manager settings.
	public void LoadStoneSettings ()
	{
		stones = new List<Stone> ();
	}

	public void LoadListOfStones (List<string> moves, List<int> colors)
	{
		DestroyStones ();

		stones = new List<Stone> ();

		for (int i=0; i< moves.Count; i++)
		{
			CreateStone (moves[i], colors[i]);
		}
	}

	public void DestroyStones ()
	{
		for ( int i=0; i<stones.Count; i++ )
		{
			Destroy (stones[i].stone);
		}

		stones.Clear ();
	}

	// Create stone at given coordinate
	public void CreateStone (string coor, int color)
    {
		Vector3 newPos = GameObject.Find ("_GobanManager").GetComponent<CoordinateManager> ().CoordinateToVector3 (coor);

        GameObject newMove = Instantiate(stone) as GameObject;
		newMove.transform.position = newPos;
		SetStoneColor (newMove, color);

		Stone newStone = new Stone (newMove, coor, color);

		stones.Add (newStone);
    }

	// Return Random color number
	int RandomColorInt (int numPlayers)
	{
		int num = Random.Range (0, numPlayers);
		return num;
	}
	// Set color of the stone.
	void SetStoneColor (GameObject stone, int color)
	{
		stone.GetComponent<Renderer> ().material.color = Color.black;
		if (color == 1) {
			stone.GetComponent<Renderer> ().material.color = Color.white;
		} else if (color == 2) {
			stone.GetComponent<Renderer> ().material.color = Color.blue;
		} else if (color == 3) {
			stone.GetComponent<Renderer> ().material.color = Color.red;
		} else if (color == 4) {
			stone.GetComponent<Renderer> ().material.color = Color.green;
		}
	}
}
