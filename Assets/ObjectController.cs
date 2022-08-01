using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [SerializeField] bool isEnemy;
    [SerializeField] GameObject effectPrefab;

    public bool isDeath;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            if (!isEnemy)
            {
                GameController.Instance.GameOver();
            }
            else
            {
                SoundController.Instance.PlayAudio(SoundController.Instance.bang, 0.3f, false);
                GameObject obj = Instantiate(effectPrefab);
                obj.transform.position = transform.position;
                Destroy(obj, 0.5f);
                var main = obj.GetComponent<ParticleSystem>().main;
                main.startColor = GameController.Instance.colors[Random.Range(0, GameController.Instance.colors.Length)];
                //obj.GetComponent<Animator>().Play("bang");
                GameController.Instance.UpdateScore(1);

                isDeath = true;
            }
            
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }

    public bool IsEnemy()
    {
        return isEnemy;
    }
}
