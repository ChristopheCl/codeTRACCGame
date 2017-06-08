using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnAnimation : MonoBehaviour
{
    private Vector3 size;

    private void Awake()
    {
        size = gameObject.transform.localScale;
    }

    public void btnHoverEnter()
    {
        //iTween.ScaleTo(this.gameObject, iTween.Hash("time", 0.25f, "scale", Vector3.one * 1.1f));
        iTween.ScaleTo(this.gameObject, iTween.Hash("time", 0.25f, "scale", gameObject.transform.localScale * 1.1f));
    }

    public void btnHoverExit()
    {
       // iTween.ScaleTo(this.gameObject, iTween.Hash("time", 0.25f, "scale", Vector3.one / 1f));
        iTween.ScaleTo(this.gameObject, iTween.Hash("time", 0.25f, "scale", size));
    }
}
