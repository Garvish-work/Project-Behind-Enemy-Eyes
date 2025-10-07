using UnityEngine;

public class DetectionBaseState 
{
    public enum DetectionState
    {
        DETECTED, NOT_DETECTED
    };
    public enum StateEvents
    {
        ENTER, UPDATE, EXIT
    };

    protected DetectionState detectionState;
    protected StateEvents stateEvent;
}
