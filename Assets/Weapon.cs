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
            Debug.Log("The Left Click Happened!");
            Debug.LogFormat ("Mouse Position is: {0}, {1}", Input.mousePosition.x, Input.mousePosition.y);
            Debug.LogFormat("Worldpoint: {0}, {1}", worldPoint.x, worldPoint.y);
            Debug.LogFormat ("direction", direction);
            Debug.LogFormat ("Transform position is: {0}, {1}", transform.position.x, transform.position.y);
            Debug.Log(direction);
            if (shotTime >= 0.1){
                Debug.Log("Raining Hell Down Upon My Enemies...");
                // Instantiate(projectile, shotPoint.position, transform.rotation);
                var newProjectile = Instantiate(projectile);
                // newProjectile.transform.position = new Vector3(-1.583f, -2.873f + 5, 0);
                newProjectile.transform.position = shotPoint.transform.position;
                newProjectile.transform.rotation = transform.rotation;
                shotTime = 0;
            }
        }
         shotTime += Time.deltaTime;
    }
}
