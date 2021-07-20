using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager
{
    //µ±Ç°×´Ì¬
    public enum STATE { 
        IDLE,
        RUN,
        FINISHED
    }

    public STATE state;

    public float duration = 1.0f;

    public float elapsedTime = 0;

    public void getTimerState() {
        switch (state) {
            case STATE.IDLE:
                break;
            case STATE.RUN:
                elapsedTime += Time.deltaTime;
                if (elapsedTime >= duration) {
                    state = STATE.FINISHED;
                }
                break;
            case STATE.FINISHED:
                break;
            default:
                Debug.Log("Timer Error!!");
                break;
        }        
    }

    public void init() {
        elapsedTime = 0;
        state = STATE.RUN;
    }


}
