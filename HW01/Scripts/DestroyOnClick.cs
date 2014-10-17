using UnityEngine;
using System.Collections;

public class DestroyOnClick : MonoBehaviour {

	public MouseUtils.Button respondToMouseButton = MouseUtils.Button.Left;

	//public void OnMouseDown()
	// Only responds to left click!


	public void OnMouseOver() {
		if(Input.GetMouseButtonDown((int)respondToMouseButton))
			Destroy(this.gameObject);
	}
}
