using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WaypointGroup
{
    public Transform cover;
    public List<Waypoint> waypoints;

    public void Regrade()
    {
        foreach (Waypoint waypoint in waypoints) {
            Vector3 playerPosition = GameManager.instance.player.position;
            // TODO ���Ͻ����жϷ���
            waypoint.score = Vector3.Distance(waypoint.transform.position, playerPosition) > 
                                      Vector3.Distance(cover.position, playerPosition) ?
                                      100 : 0;
        }
    }
}

[Serializable]
public class Waypoint
{
    public Transform transform;
    public float score;
}
