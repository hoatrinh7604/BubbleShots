using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndShoot : MonoBehaviour
{
    private Vector3 target;
    [SerializeField] GameObject crosshairs;
    [SerializeField] GameObject playerGun;
    [SerializeField] Transform pointShot;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Camera camera;

    [SerializeField] float speedBullet = 60f;

    [SerializeField] float timeDelay;
    private float time;
    // Update is called once per frame
    void Update()
    {
        target = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshairs.transform.position = new Vector2(target.x, target.y);

        Vector3 difference = target - playerGun.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        playerGun.transform.rotation = Quaternion.Euler(0, 0, rotationZ);


        time += Time.deltaTime;
        if(time > timeDelay)
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();

            Fire(direction, rotationZ);
            time = 0;
        }
    }

    void Fire(Vector2 direction, float rotationZ)
    {
        SoundController.Instance.PlayAudio(SoundController.Instance.firing, 0.05f, false);
        GameObject bullet = Instantiate(bulletPrefab) as GameObject;
        bullet.transform.position = pointShot.position;
        bullet.transform.rotation = Quaternion.Euler(0, 0, rotationZ);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * speedBullet;

        Destroy(bullet, 3);
    }
}
