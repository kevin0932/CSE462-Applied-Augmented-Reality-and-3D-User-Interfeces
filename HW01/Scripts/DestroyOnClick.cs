using UnityEngine;
using System.Collections;

public class DestroyOnClick : MonoBehaviour {

	public static int score = 0;
	public MouseUtils.Button respondToMouseButton = MouseUtils.Button.Left;
	public TextMesh tm;

	//public void OnMouseDown()
	// Only responds to left click!


	public void OnMouseOver() {
		if (Input.GetMouseButtonDown ((int)respondToMouseButton)) {
						Destroy (this.gameObject);
					tm = GameObject.Find("ScoreText").GetComponent<TextMesh>();
					score += 10;
					tm.text = "Score: " + score;
				}
	}
}
