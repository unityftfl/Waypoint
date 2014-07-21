using UnityEngine;
using System.Collections;

public class WayPoint : MonoBehaviour {


	public float speed = 20;
	private int currentWaypoint;
	private Vector3 velocity;
	private GameObject closestWaypoint;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		GameObject newWaypoint = FindClosestObject ();
		print (newWaypoint);

		Vector3 target = newWaypoint.transform.position;
		Vector3 moveDirection = target - transform.position;

		transform.position += velocity * Time.deltaTime;

		Vector3 targetPoint = newWaypoint.transform.position;
		var targetRotation = Quaternion.LookRotation(targetPoint - transform.position, new Vector3(0, 1, 0));
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);

		if(moveDirection.magnitude <1){
			newWaypoint.SetActive(false);
		}else{
			velocity = moveDirection.normalized * speed;
		}
	}


	GameObject FindClosestObject(){
		GameObject[] waypoints = GameObject.FindGameObjectsWithTag("waypoint");
		float closestDist = Mathf.Infinity;
		print (closestDist);

		foreach(GameObject waypoint in waypoints){
			float dist = (transform.position - waypoint.transform.position).sqrMagnitude;
			print(dist);

			if(dist < closestDist){
				closestDist = dist;
				closestWaypoint = waypoint;
			}
		}
		return closestWaypoint;
	}
}
