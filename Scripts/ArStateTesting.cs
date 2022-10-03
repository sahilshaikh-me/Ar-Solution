using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
public class ArStateTesting : MonoBehaviour
{
    public Text debugTEXt;
    private void OnEnable()
    {
        ARSession.stateChanged += OnStateChanged;
    }

    private void OnDisable()
    {
        ARSession.stateChanged -= OnStateChanged;
    }

    private void OnStateChanged(ARSessionStateChangedEventArgs args)
    {
        switch (args.state)
        {
            case ARSessionState.None:
                debugTEXt.text = "None";
                break;
            case ARSessionState.CheckingAvailability:
                debugTEXt.text = "CheckingAvailability";

                break;
            case ARSessionState.Installing:
                debugTEXt.text = "Installing";

                break;
            case ARSessionState.NeedsInstall:
                debugTEXt.text = "NeedsInstall";

                break;
            case ARSessionState.Ready:
                debugTEXt.text = "Ready";

                break;
            case ARSessionState.SessionInitializing:
                debugTEXt.text = "SessionInitializing";

                break;
            case ARSessionState.SessionTracking:
                debugTEXt.text = "SessionTracking";

                break;
            case ARSessionState.Unsupported:
                debugTEXt.text = "Unsupported";

                break;
        }
    }
}
