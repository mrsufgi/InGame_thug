using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DiabledButtonText : MonoBehaviour {

    public Color EnabledTextColor;
    public Color DisabledTextColor;
  

    void Start () {
        Button parent = GetComponentInParent<Button>();
        if (parent.enabled)
        {
            gameObject.GetComponent<Text>().color = EnabledTextColor;
        } else
        {
            gameObject.GetComponent<Text>().color = DisabledTextColor;
        }
	}
}
