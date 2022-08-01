using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawController : MonoBehaviour
{
    [SerializeField] GameObject[] objects;

    [SerializeField] Transform target;
    [SerializeField] float delayTime = 2f;
    [SerializeField] float delayMinTime = 2f;
    [SerializeField] float delayMaxTime = 2f;
    [SerializeField] float speedObj = 5f;
    private float time;

    [SerializeField] bool isRight;

    [SerializeField] Transform spawPointMin;
    [SerializeField] Transform spawPointMax;
    [SerializeField] bool isHorizontal;

    [SerializeField] bool flipX;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > delayTime)
        {
            SpawObject();
            time = 0;
            delayTime = Random.Range(delayMinTime, delayMaxTime);
        }
    }

    void SpawObject()
    {
        int index = Random.Range(0, objects.Length);
        GameObject obj = Instantiate(objects[index]);
        if(isRight)
        {
            obj.GetComponent<SpriteRenderer>().flipX = true;
        }    
        obj.GetComponent<MovingController>().Settarget(target);
        obj.GetComponent<MovingController>().UpdateSpeed(speedObj);
        //obj.GetComponent<SpriteRenderer>().flipX = flipX;

        if(isHorizontal)
        {
            float y = Random.Range(spawPointMin.position.y, spawPointMax.position.y);
            obj.transform.position = new Vector2(spawPointMin.position.x, y);
        }
        else
        {
            float x = Random.Range(spawPointMin.position.x, spawPointMax.position.x);
            obj.transform.position = new Vector2(x, spawPointMin.position.y);
        }
        
    }

    public void UpdateSpeed()
    {
        speedObj += 1;
    }

    public void ReduceDelayTime()
    {
        delayMaxTime -= 1;
        delayMinTime -= 1;

        if(delayMinTime < 1) delayMinTime = 1;
        if(delayMaxTime < 1) delayMaxTime = 1;
    }
}
