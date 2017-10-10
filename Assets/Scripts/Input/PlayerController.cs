using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [Tooltip("Avatar model.")]
    public GameObject avatar;
    [Tooltip("Movement's speed for the avatar.")]
    public float speed = 7;
    // rotation for the avatar
    private Vector3 lookPoint;
    // movement velocity
	private Vector3 velocity;
    // rigidbody to move the player's position
	private Rigidbody rb;
	
	void Start() 
	{
		rb = GetComponent<Rigidbody>();
	}
	
	public void Move(Vector3 velocity)
	{
		this.velocity = velocity * speed;
	}
	
	public void LookAt(Vector3 point)
    {
        lookPoint = point;
        var heightCorrectedPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        avatar.transform.LookAt(heightCorrectedPoint);
    }
	
	public void MoveUpdate()
	{
		rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
	}
}
