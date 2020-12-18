using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class ScenePlayableAsset : PlayableAsset
{
    public string movie1;
    public string movie2;
    // Factory method that generates a playable based on this asset
    public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
    {
        ScenePlayableBehaviour playableBehaviour = new ScenePlayableBehaviour();
        return ScriptPlayable<ScenePlayableBehaviour>.Create(graph, playableBehaviour);
    }
}
