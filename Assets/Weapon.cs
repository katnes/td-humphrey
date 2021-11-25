using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectile;
    public GameObject shotPoint;
    public float timeBetweenShots;

    private float shotTime;

    private void Update()
    {
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);   
        Vector2 direction = worldPoint - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;

        if(Input.GetMouseButton(0)) {
            if (shotTime >= 0.1){
                var newProjectile = Instantiate(projectile);
                newProjectile.transform.position = shotPoint.transform.position;
                newProjectile.transform.rotation = transform.rotation;
                shotTime = 0;
            }
        }
         shotTime += Time.deltaTime;
    }
}
