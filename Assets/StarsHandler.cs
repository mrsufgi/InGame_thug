using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StarsHandler : MonoBehaviour {

    public Sprite m_ActiveStar;
    public Sprite m_NotActiveStar;


    void Start()
    {
     //   SetActiveStarSprite(false);
    }
    public void SetActiveStarSprite(bool i_flag)
    {
        if (i_flag)
        {
            this.GetComponent<Image>().sprite = m_ActiveStar;
        }
        else
        {
            this.GetComponent<Image>().sprite = m_NotActiveStar;
        }
    }
}
