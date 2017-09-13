using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [Tooltip("Avatar model.")]
    public GameObject avatar;
    public Vector3 lookPoint;
	Vector3 velocity;
	Rigidbody rb;
	
	void Start() 
	{
		rb = GetComponent<Rigidbody>();
	}
	
	public void Move(Vector3 velocity)
	{
		this.velocity = velocity * 5;
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
