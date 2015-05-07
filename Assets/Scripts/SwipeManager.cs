using UnityEngine;

// This script will push a rigidbody around when you swipe
[RequireComponent(typeof(Rigidbody2D))]
public class SwipeManager : MonoBehaviour
{
    public float ForceMultiplier;
    public float SwipeSpeed;
    private LevelManager gameController;

    public void Start()
    {

        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<LevelManager>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }
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
        //     Ray ray = Camera.main.ScreenPointToRay(finger.StartScreenPosition);
        //   RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        ////Check if the ray hits any collider
        //if (hit.collider.gameObject != null)
        //{

        //    if (hit.collider.gameObject == gameObject)
        //    {
        // Get the rigidbody component
        //Rigidbody2D rigidbody = GetComponent<Rigidbody2D> ();


        // TODO: you can initiate swipes of object there are not visible (but are already running)
        // you should prevent swipe to effect them if there are no visible item in queue...

        Debug.Log("Swiping");
        Rigidbody2D rigidbody;
        if (gameController.q.Count != 0)
        {
            Creature dequeuedCreature = gameController.q.Dequeue();
            dequeuedCreature.swiped = true;
            rigidbody = dequeuedCreature.GetComponent<Rigidbody2D>();

        }
        else
        {
            return;
        }


        // Add force to the rigidbody based on the FIXED SPEED 
        // WORK ONLY FOR LEFT OR RIGHT ! ! !  TOP AND BOT WONT DO SHIT!
        // Store the swipe delta in a temp variable
        var swipe = finger.SwipeDelta;

        if (swipe.x < -Mathf.Abs(swipe.y))
        {
            rigidbody.velocity = new Vector2(0, 0);
            rigidbody.AddForce(new Vector2(transform.position.x - SwipeSpeed, 0));

        }
        else if (swipe.x > Mathf.Abs(swipe.y))
        {
            rigidbody.velocity = new Vector2(0, 0);
            rigidbody.AddForce(new Vector2(transform.position.x + SwipeSpeed, 0));
        }

        // saved for other gestures
        else
        {
            // do nothing.
        }

        //Debug.Log(finger.ScaledSwipeDelta);
        //	}
        //}
    }
}