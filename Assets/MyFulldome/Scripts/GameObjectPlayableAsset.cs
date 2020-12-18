using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class GameObjectPlayableAsset : PlayableAsset
{
    public gameObjectAct g_act;
    public string object_name;
    // Factory method that generates a playable based on this asset
    public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
    {
        GameObjectBehaviour playableBehaviour = new GameObjectBehaviour();
        playableBehaviour.object_name = object_name;
        return ScriptPlayable<GameObjectBehaviour>.Create(graph, playableBehaviour);
    }
}