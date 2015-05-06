using UnityEngine;

// This script will push a rigidbody around when you swipe
[RequireComponent(typeof(Rigidbody2D))]
public class SwipeManager : MonoBehaviour
{
    public CreatureQueue q;
    public float ForceMultiplier;
    public float SwipeSpeed;
   
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
        //Create a Ray on the tapped / clicked position
        Ray ray = Camera.main.ScreenPointToRay(finger.StartScreenPosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        //Check if the ray hits any collider
		if (hit.collider.gameObject != null) {

			if (hit.collider.gameObject == gameObject) {

				Debug.Log ("Swiping");
                // Get the rigidbody component
                //Rigidbody2D rigidbody = GetComponent<Rigidbody2D> ();
                Rigidbody2D rigidbody = q.Dequeue().GetComponent<Rigidbody2D>();


                // Add force to the rigidbody based on the swipe force
                // rigidbody.AddForce (finger.ScaledSwipeDelta * ForceMultiplier);


                // Add force to the rigidbody based on the FIXED SPEED 
                // WORK ONLY FOR LEFT OR RIGHT ! ! !  TOP AND BOT WONT DO SHIT!
                // Store the swipe delta in a temp variable
                var swipe = finger.SwipeDelta;
              
                if (swipe.x < -Mathf.Abs(swipe.y))
                {
                    rigidbody.AddForce(new Vector2(transform.position.x - SwipeSpeed, transform.position.y), ForceMode2D.Force);

                } else if (swipe.x > Mathf.Abs(swipe.y))
                {
                    rigidbody.AddForce(new Vector2(transform.position.x + SwipeSpeed, transform.position.y), ForceMode2D.Force);
                } else
                {
                    // do nothing.
                }
                Debug.Log (finger.ScaledSwipeDelta);
			}
		}
    }
}