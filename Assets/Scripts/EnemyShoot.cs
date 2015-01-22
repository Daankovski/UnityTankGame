using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {
	private float reloadTime;
	public float timeToReload;
	public GameObject bulletPrefab;
	public float fireDistance;

	private Transform turret;
	private Transform nozzle;

	// Use this for initialization
	void Start () {
		reloadTime = 0;


		Transform[] transforms = this.gameObject.GetComponentsInChildren<Transform> ();
		foreach (Transform t in transform) 
		{
			if(t.gameObject.name == "turret")
			{
				turret = t;
			}
			if(t.gameObject.name == "nozzle")
			{
				nozzle = t;
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		reloadTime += Time.deltaTime;
		if (reloadTime >= timeToReload)
		{
			CheckForPlayer();

		}


	}

	private void CheckForPlayer()
	{
		Ray myRay = new Ray ();
		myRay.origin = turret.position;
		myRay.direction = turret.forward;


		RaycastHit hitMarker;
		//checkt m.b.v. een raycast of de player in zicht is en if true dan schieten en reloadtime op 0

		if(Physics.Raycast(myRay, out hitMarker, fireDistance))
		{
			print(hitMarker.collider.gameObject.name);
			string hitObjectName = hitMarker.collider.gameObject.name;

			if(hitObjectName == "Tank")
			{
				Instantiate(bulletPrefab, nozzle.position, nozzle.rotation);

				reloadTime = 0;
			}
			
		}
	}
}
