using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Button的管理类：1.isPressing 2.OnPressed 3.OnReleased 4.DoubleTrigger 5.Long Pressing
/// </summary>
public class ButtonManager
{
    public bool IsPressing = false;
    public bool OnPressed = false;
    public bool OnReleased = false;
    public bool IsExtending = false;
    public bool IsDelaying = false;

    public float ExtendingDuration = 0.15f;
    public float DelayingDuration = 0.15f;

    private bool curState = false;
    private bool lastState = false;

    private TimerManager extendTimer = new TimerManager();
    private TimerManager delayTimer = new TimerManager();

    public void getPressState(bool input) {

        extendTimer.getTimerState();
        delayTimer.getTimerState();

        curState = input;

        IsPressing = curState;

        OnPressed = false;
        OnReleased = false;
        if (curState != lastState) {
            if (curState)
            {
                OnPressed = true;
                StartTimer(delayTimer, DelayingDuration);
            }
            else {
                OnReleased = true;
                StartTimer(extendTimer, ExtendingDuration);
            }
        }
        lastState = curState;

        IsExtending = (extendTimer.state == TimerManager.STATE.RUN);
        IsDelaying = (delayTimer.state == TimerManager.STATE.RUN);
    }

    private void StartTimer(TimerManager timer, float duration) {
        timer.duration = duration;
        timer.init();
    }
}
