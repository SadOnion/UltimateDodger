using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemy : BaseEnemy
{
    public LineRenderer line;
    protected override IEnumerator StartMovingTowardsPlayer()
    {
        Vector2 dir = GetDirection();
        MakeLine(dir);
        yield return new WaitForSeconds(1);
        body.velocity = dir*speed;
    }
    private void MakeLine(Vector2 dir)
    {
        line.SetPosition(1,dir*25);
    }
}
