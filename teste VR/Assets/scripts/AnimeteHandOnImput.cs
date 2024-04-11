using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimeteHandOnImput : MonoBehaviour
{
    public InputActionProperty pinchAnimantionAction;
    public InputActionProperty GripAnimantionAction;

    public Animator handAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float triggerValue = pinchAnimantionAction.action.ReadValue<float>();
        float GripValue = GripAnimantionAction.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerValue);
        handAnimator.SetFloat("Grip", GripValue);
    }
}
