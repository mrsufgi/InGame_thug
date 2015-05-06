using UnityEngine;

// This script will push a rigidbody around when you swipe
[RequireComponent(typeof(Rigidbody))]
public class SimpleSwipe : MonoBehaviour
{
	public float ForceMultiplier = 1.0f;
	
	protected virtual void OnEnable()
	{
		// Hook into the OnSwipe event
		Lean.LeanTouch.OnFingerSwipe += OnFingerSwipe;
	}
	
	protected virtual void OnDisable()
	{
		// Unhook into the OnSwipe event
		Lean.LeanTouch.OnFingerSwipe -= OnFingerSwipe;
	}
	
	public void OnFingerSwipe(Lean.LeanFinger finger)
	{
		// Get the rigidbody component
		var rigidbody = GetComponent<Rigidbody>();
		
		// Add force to the rigidbody based on the swipe force
		rigidbody.AddForce(finger.ScaledSwipeDelta * ForceMultiplier);
	}
}