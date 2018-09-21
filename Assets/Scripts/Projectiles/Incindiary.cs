using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incindiary : Projectile
{
    public float burnDelay = 2f;
    public float burnDam = 10f;
    public int burnAmount = 5;

    private int burnCount = 0;
  
    public override void Fire(Vector3 dir)
    {
        projectile.AddForce(dir * projSpeed, ForceMode.Impulse);
    }

    public IEnumerator Burn(Enemy enemy)
    {
        burnCount++; // Count up burn count
        enemy.DealDamage(burnDam);
        Debug.Log("ON FIRE");
        yield return new WaitForSecondsRealtime(burnDelay);
        if (burnCount < burnAmount)
        {
            StartCoroutine(Burn(enemy));
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public override void OnCollisionEnter(Collision col)
    {
        Enemy enemy = col.gameObject.GetComponent<Enemy>();
        // Turn off collision (CollideR)
        // Turn off effects (MeshRenderer, ParticleSystem, etc)
        if (enemy)
        {
            StartCoroutine(Burn(enemy));

        }
    }
}
