using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public enum gameObjectAct
{
    delete, active, disable
}
// A behaviour that is attached to a playable
public class GameObjectBehaviour : PlayableBehaviour
{
    public gameObjectAct g_act;
    public string object_name;

    // Called when the owning graph starts playing
    public override void OnGraphStart(Playable playable)
    {

    }

    // Called when the owning graph stops playing
    public override void OnGraphStop(Playable playable)
    {

    }

    // Called when the state of the playable is set to Play
    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {

    }

    // Called when the state of the playable is set to Paused
    public override void OnBehaviourPause(Playable playable, FrameData info)
    {

    }

    // Called each frame while the state is set to Play
    public override void PrepareFrame(Playable playable, FrameData info)
    {
        if (g_act == gameObjectAct.delete)
        {
            GameObject d = GameObject.Find(object_name);
            if (d)
            { GameObject.Destroy(d); Debug.Log("1"); }
            else
            { Debug.Log(object_name); }
        }
        if (g_act == gameObjectAct.disable)
        {
            GameObject d = GameObject.Find(object_name);
            if (d)
            { d.SetActive(false); Debug.Log("3"); }
        }
    }
}
