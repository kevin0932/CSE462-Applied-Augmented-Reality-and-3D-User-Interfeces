using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public GameObject object1;
	public GameObject object2;


	// Update is called once per frame
	void Update () {
		if (AttackCenter.isDone == true)
		{
			object1.renderer.enabled = true;
			object2.renderer.enabled = true;
		}
	}
}
