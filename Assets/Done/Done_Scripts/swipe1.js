
private var leftFingerPos : Vector2 = Vector2.zero;
private var leftFingerLastPos : Vector2 = Vector2.zero;
private var leftFingerMovedBy : Vector2 = Vector2.zero;
 
public var slideMagnitudeX : float = 0.0;
public var slideMagnitudeY : float = 0.0;
 
 
function Update()
{
    if (Input.touchCount == 1)
    {
        var touch : Touch = Input.GetTouch(0);
       
        if (touch.phase == TouchPhase.Began)
        {
            leftFingerPos = Vector2.zero;
            leftFingerLastPos = Vector2.zero;
            leftFingerMovedBy = Vector2.zero;
           
            slideMagnitudeX = 0;
            slideMagnitudeY = 0;
           
            // record start position
            leftFingerPos = touch.position;
           
        }
       
        else if (touch.phase == TouchPhase.Moved)
        {
            leftFingerMovedBy = touch.position - leftFingerPos; // or Touch.deltaPosition : Vector2
                                                                // The position delta since last change.
            leftFingerLastPos = leftFingerPos;
            leftFingerPos = touch.position;
           
            // slide horz
            slideMagnitudeX = leftFingerMovedBy.x / Screen.width;
           
            // slide vert
            slideMagnitudeY = leftFingerMovedBy.y / Screen.height;
           
        }
       
        else if (touch.phase == TouchPhase.Stationary)
        {
            leftFingerLastPos = leftFingerPos;
            leftFingerPos = touch.position;
           
            slideMagnitudeX = 0.0;
            slideMagnitudeY = 0.0;
        }
       
        else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
        {
            slideMagnitudeX = 0.0;
            slideMagnitudeY = 0.0;
        }
    }
}
 