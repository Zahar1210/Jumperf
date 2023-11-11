using System;
using UnityEngine;

public class WallTeleport : MonoBehaviour
{
    [SerializeField] private Transform oppositePoint;
    [SerializeField] private Transform target;

    [SerializeField] private bool leftSide;

    private void Update()
    {
        bool isLeft = leftSide;
        bool isPastTarget = isLeft ? transform.position.x > target.position.x : transform.position.x < target.position.x;

        if (isPastTarget)
        {
            MoveToOppositePoint();
        }
    }

    private void MoveToOppositePoint() => target.position = new Vector2(oppositePoint.position.x, target.position.y);
}