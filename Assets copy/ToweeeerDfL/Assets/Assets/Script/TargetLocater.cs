
using UnityEngine;

public class TargetLocater : MonoBehaviour
{
    [SerializeField] private Transform head;
    [SerializeField] private float radius = 15f;
    [SerializeField] private ParticleSystem projectileParicle;
    private Transform _target;
    private void Start()
    {
        _target = FindObjectOfType<EnemyMover>().transform;
    }
    private void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    private void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance =Mathf.Infinity;

        foreach (var enemy in enemies)
        {
            var targetdistance = Vector3.Distance(head.position,enemy.transform.position);
            if (!(targetdistance < maxDistance))
                continue;
            closestTarget = enemy.transform;
            maxDistance = targetdistance;

            _target = closestTarget;
        }
    }

    private void AimWeapon()
    {
        var targetDistance = Vector3.Distance(_target.position,transform.position);
        head.LookAt(_target);
        Attack(targetDistance < radius);
    }
    private void Attack(bool isActive)
    {
        var emission = projectileParicle.emission;
        emission.enabled = isActive;
    }
}
