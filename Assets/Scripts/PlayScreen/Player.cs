using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame updat
    [SerializeField]
    GameObject rope;
    [SerializeField]
    GameObject hooks;
    [SerializeField]
    Animator playerAnimator;
    List<Vector2> rectTransforms = new List<Vector2>();
    Transform a;
    GameObject target;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseButtonDown();
        }
        if (Input.GetMouseButtonUp(0))
        {
            OnMouseButtonUp();
        }
        if (target != null)
        {
            Extensions.LookAt2D(transform,target);
        }
    }
    private void Start()
    {
        for (int a = 0; a < hooks.transform.childCount; a++)
        {
            rectTransforms.Add(hooks.transform.GetChild(a).GetComponent<RectTransform>().anchoredPosition);
        }
    }

    public void OnMouseButtonUp()
    {
        playerAnimator.SetBool("IsHoocked", false);
        var joint = GetComponent<SpringJoint2D>();
        joint.connectedBody = null;
        joint.enabled = false;
        rope.GetComponent<RectTransform>().sizeDelta = new Vector2(10, 0);
        
    }

    public void OnMouseButtonDown()
    {
        playerAnimator.SetBool("IsHoocked",true);
        playerAnimator.SetBool("endStartAnimation", true);
        target = GetNearestHook();
        var joint = GetComponent<SpringJoint2D>();
        joint.enabled = true;
        joint.autoConfigureDistance = true;
        joint.connectedBody = target.GetComponent<Rigidbody2D>();
        joint.autoConfigureDistance = false;
        joint.distance -= 0.5f;



        var position = GetComponent<RectTransform>().anchoredPosition;
        Vector3 moveDirection = target.GetComponent<RectTransform>().anchoredPosition - position;
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(-moveDirection.x, moveDirection.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        rope.GetComponent<RectTransform>().sizeDelta = new Vector2(rope.GetComponent<RectTransform>().sizeDelta.x, moveDirection.magnitude-100);
        

    }
    private GameObject GetNearestHook()
    {
        var position = GetComponent<RectTransform>().anchoredPosition;
        var target = rectTransforms[0];
        int number = 0;

        for (int i = 0; i < rectTransforms.Count; i++)
        {
            if (Vector2.Distance(position, target) > Vector2.Distance(position, rectTransforms[i]))
            {
                target = rectTransforms[i];
                number = i;
            }

        }
        return hooks.transform.GetChild(number).gameObject ;
    }

}
