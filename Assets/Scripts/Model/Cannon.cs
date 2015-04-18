using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {

    public LineRenderer laser;
    GameObject spark;
    public float laserRange = 8;

    void Start()
    {
        spark = Instantiate(GamePrefabs.instance.spark);
        spark.SetActive(false);
    }

    void Shoot()
    {
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
                spark.SetActive(true);
                spark.transform.position = hitInfo.point;
            }
        }
    }

    void StopShooting()
    {
        laser.SetVertexCount(1);
        spark.SetActive(false);
    }

	void Update () {
        if (GameLogic.instance.InputLocked()) return;

        Rotate();
        if (Input.GetMouseButton(0) || GameLogic.instance.alwaysShoot) {
            Shoot();
        }
        else
        {
            StopShooting();
        }
	}

    void Rotate()
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

	void Rotate(Vector3 direction, float power)
	{
		float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
		Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.up);
		transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, power);
	}
}
