using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingController : MonoBehaviour
{
    [SerializeField] float speed = 5;
    private Transform target;

    private ObjectController objController;

    // Start is called before the first frame update
    void Start()
    {
        objController = GetComponent<ObjectController>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!objController.isDeath)
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, target.position) < 0.01f)
        {
            GameController.Instance.GameOver();
        }
    }

    public void Settarget(Transform target)
    {
        this.target = target;
    }

    public void Escape()
    {
        if(GetComponent<ObjectController>().IsEnemy())
            GameController.Instance.UpdateSlider(1);
    }

    public void UpdateSpeed(float value)
    {
        speed = value;
    }
}
