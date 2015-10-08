using UnityEngine;
using System.Collections;

public class Caracter_Controler : MonoBehaviour{

	private RaycastHit theHit;
	public float 		forwardDis = 1;
	public float 		moveSpeed;
	public float 		jumpBoost;
	public float 		rayDis = 1;
	private Rigidbody 	rb;
	public float 		maxJump;
	private float 		jumpCount;

	public void Start (){
		rb = gameObject.GetComponent<RigidBody>();
	}

	public void Update (){
		

		Movement();
	}

	public void Movement(){

		if(Input.GetAxis("Vertical")> 0){
			//Debug.DrawRay(transform.position, transform.forward, Color.green);
			if(Physics.Raycast(transform.position , transform.forward , forwardDis)){	
				Debug.Log("Hit Front");
			}
				else{
					transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

				}

		}
		if(Input.GetAxis("Vertical")< 0){
			if(Physics.Raycast(transform.position , -transform.forward , forwardDis)){
				Debug.Log("Hit Back");
			}
				else{
					transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);

				}

		}
		if(Input.GetAxis("Horizontal")> 0){
			if(Physics.Raycast(transform.position , transform.right , forwardDis)){
				Debug.Log("Hit Right");
			}
				else{
					transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

				}

		}
		if(Input.GetAxis("Horizontal")< 0){
			if(Physics.Raycast(transform.position , -transform.right , forwardDis)){
				Debug.Log("Hit Left");
			}
				else{
					transform.Translate(-Vector3.right * moveSpeed * Time.deltaTime);

				}
		}
		if(Input.GetButtonDown("Jump")){
			if(jumpCount >= maxJump){
					rb.Velocity = new Vector3(0,jumpBoost,0);
			}
		}
	}
}