using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerController : MonoBehaviour {

	public Camera cam;

	public NavMeshAgent agent;

	public ThirdPersonCharacter character;

	void Start()
	{
		agent.updateRotation = false; //tells agent to not update rotation
	}


	// Update is called once per frame
	void Update ()
	{
		if(Input.GetMouseButtonDown(0)) //left mouse button
		{
			Ray ray = cam.ScreenPointToRay(Input.mousePosition); //converts mouse position to ray when button clicked
			RaycastHit hit; //stores what ray hits

			if (Physics.Raycast(ray, out hit)) //shoots ray and continues if it hits
			{
				//move our agent
				agent.SetDestination(hit.point);
			}
		}

		if(agent.remainingDistance > agent.stoppingDistance) //moves if not at destination
		{
			character.Move(agent.desiredVelocity, false, false); //moves agent, not crouching, not jumping
		}
		else //stops character from moving
		{
			character.Move(Vector3.zero, false, false);
		}
	}
}
