using UnityEngine;
using System.Collections;

public class Cannon : HeatExplosive {

    public LineRenderer laser;
    GameObject spark;
    float laserRange = 200;

    void Start()
    {
        spark = Instantiate(GamePrefabs.instance.spark, transform.position, Quaternion.identity) as GameObject;
    }

    protected void Shoot()
    {
        SoundManager.instance.Laser();
        spark.transform.position = transform.position;
        laser.SetPosition(0, transform.position);
        Shoot(transform.position, transform.rotation * Vector3.forward, laserRange, 1);
    }

    void Shoot(Vector3 current, Vector3 direction, float distance, int index)
    {
        RaycastHit hitInfo;
        Physics.Raycast(current, direction, out hitInfo, distance);
        laser.SetVertexCount(index + 1);
        if (hitInfo.point == Vector3.zero)
        {
            laser.SetPosition(index, current + direction * distance);
        }
        else
        {
            laser.SetPosition(index, hitInfo.point);
            hitInfo.collider.SendMessage("OnLaserHit", SendMessageOptions.DontRequireReceiver);
            if (hitInfo.collider.tag == "Reflectable")
            {
                Shoot(hitInfo.point, Vector3.Reflect(direction, hitInfo.normal), distance - hitInfo.distance, index + 1);
            }
            else
            {
                //spark
                spark.transform.position = hitInfo.point;
            }
        }
    }

    protected void StopShooting()
    {
        SoundManager.instance.StopLaser();
        laser.SetVertexCount(1);
        spark.transform.position = transform.position;
    }	

    protected void Rotate()
    {
        Vector3 pointer;
        if (Input.touchCount > 0)
        {
            pointer = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        }
        else
        {
            pointer = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        pointer.y = 0;

        Rotate(pointer - transform.position, 1);
    }

	protected void Rotate(Vector3 direction, float power)
	{
		float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
		Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.up);
		transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, power);
	}

    public override void OnHeated()
    {
        base.OnHeated();
        Destroy(spark);
    }
}
