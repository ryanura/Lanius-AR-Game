using UnityEngine;

public class LookAtCamera : MonoBehaviour {
	GameObject camGO;
	Camera cam;
	public bool allAxis;

	// Use this for initialization
	void Start () {
		cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (allAxis)
		{
			transform.LookAt(cam.transform.position);
		}else{
			transform.LookAt(new Vector3 (cam.gameObject.transform.position.x, transform.position.y, cam.gameObject.transform.position.z));
		}
	}
}