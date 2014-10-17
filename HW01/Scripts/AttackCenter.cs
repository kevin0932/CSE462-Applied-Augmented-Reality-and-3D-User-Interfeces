using UnityEngine;
using System.Collections;

public class AttackCenter : MonoBehaviour {
	
	public static bool isDone = false;
	private bool firstTime = false;
	public static float time1;
	public static float time2;

	//the speed, in units per second, we want to move towards the target
	float speed = 1;
	// Use this for initialization
	void Start () {
		speed += Random.Range(0f, 2f);
	}


	
	// Update is called once per frame
	void Update () {
		MoveTowardsTarget();
		PulseObject();
	}

	private void MoveTowardsTarget() {

		//move towards the center of the world
		Vector3 targetPosition = new Vector3(0,0,0);

		Vector3 currentPosition = this.transform.position;
		//first, check to see if we're close enough to the target
		//this check prevents us from oscillating back and forth over the target
		//if we're farther than 1 unit away, do the movement, otherwise do nothing
		if(Vector3.Distance(currentPosition, targetPosition) > 1) { 
			
			//get the direction we need to go by subtracting the current position from the target position
			Vector3 directionOfTravel = targetPosition - currentPosition;
			//now normalize the direction, since we only want the direction information
			directionOfTravel.Normalize();
			
			//now move at the specified speed in the direction of travel
			//scale the movement on each axis by the directionOfTravel vector components
			
			this.transform.Translate(
				(directionOfTravel.x * speed * Time.deltaTime),
				(directionOfTravel.y * speed * Time.deltaTime),
				(directionOfTravel.z * speed * Time.deltaTime),
				Space.World);
		} else {
			//We made it.
			Debug.Log("Failure to protect your base, all belong to us.");

			//Compiler statements below, the lines beginning with #
			//These are compile time conditionals. Like choosing which code to write when compiling the app.
			//In this case, we're selecting the appropriate way to stop play.
			//When in the Unity Editor, Application.Quit doesn't work
			//When building a release, UnityEditor class isn't available.
			//So we have to choose between them with the compile time conditionals.
			isDone = true;
			if(firstTime == false)
				time1 = Time.realtimeSinceStartup;
			firstTime = true;
			time2 = Time.realtimeSinceStartup;

			Debug.Log("Time1: "+time1 + "\tTime2: "+ time2);

			if( (time2 - time1) > 1)
			{
				#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
				#else
				Application.Quit();
				#endif
			}

		}
	}


	private void PulseObject() {
		//the number of pulses per second
		float rate = .5f;
		float maxScale = 1.2f;
		float minScale = .8f;

		//first we'll make sure the frequency matches the rate specified
		//then get the amplitude to be between 0 and 1
		//Time.time is the number of seconds since the game started.
		//since sine wraps around, we can still use this ever increasing value to get pulses
		float scale = (Mathf.Sin(Time.time * (rate * 2 * Mathf.PI)) + 1f)/2f;

		//then interpolate that value between our min and max
		//Lerp is shorthand for linear interpolation
		scale = Mathf.Lerp (minScale, maxScale, scale);

		transform.localScale = new Vector3(scale,scale,scale);
	}
}
