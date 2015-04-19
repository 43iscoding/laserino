using UnityEngine;
using System.Collections;

public class Cannon : HeatExplosive {

    public LineRenderer laser;
    public AudioSource laserSound;
    float laserRange = 1000;

    void Start()
    {
        SetupLaserSound();
    }

    void SetupLaserSound()
    {
        laserSound.clip = SoundManager.instance.laser;
        laserSound.loop = true;
        laserSound.mute = false;
        laserSound.volume = Random.Range(0.1f, 0.13f);
        laserSound.pitch = Random.Range(0.95f, 1.05f);
        laserSound.Play();
    }

    protected void Shoot()
    {
        laserSound.mute = false;
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
        }
    }

    protected void StopShooting()
    {
        laserSound.mute = true;
        laser.SetVertexCount(1);
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
}
