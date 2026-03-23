using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class Gestures_DoubleTap : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float maxTapDelay = 0.3f; // seconds between taps

    float lastTapTime = 0f;

    public bool hasShield = false;

    void Awake()
    {
        EnhancedTouchSupport.Enable();
    }

    void Update()
    {
        if (touch.activeTouches.Count < 1)
            return;

        var touch1 = touch.activeTouches[0];

        if (touch1.phase == UnityEngine.InputSystem.TouchPhase.Began)
        {
            float timeSinceLastTap = Time.time - lastTapTime;

            if (timeSinceLastTap <= maxTapDelay)
            {
                // Double tap detected!
                StartCoroutine(ShieldTimer());
                lastTapTime = 0f; // reset
            }
            else
            {
                lastTapTime = Time.time;
            }
        }
    }
    IEnumerator ShieldTimer()
    {
        hasShield = true;
        player.GetComponent<SpriteRenderer>().color = Color.blueViolet;
        yield return new WaitForSeconds(1f);
        hasShield = false;
        player.GetComponent <SpriteRenderer>().color = Color.white;
    }

}