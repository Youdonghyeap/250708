using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1f;

    private bool IsPinned = false;
    private bool IsLaunchered = false;

    public GameObject pinHitEffectPrefab;

    private void FixedUpdate()
    {
        if (IsPinned == false && IsLaunchered == true && GameManager.instance.isGameOver == false)
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsPinned = true;
        if (collision.gameObject.tag == "TargetCircle")
        {
            GameObject childObject = transform.Find("Square").gameObject;
            childObject.GetComponent<SpriteRenderer>().enabled = true;
            transform.SetParent(collision.gameObject.transform);
            GameManager.instance.DecreaseGoal();
        }
        else if (collision.gameObject.tag == "Pin")
        {
            if (pinHitEffectPrefab != null)
            {
                Instantiate(pinHitEffectPrefab, transform.position, Quaternion.identity);
            }
            Destroy(collision.gameObject);
            GameManager.instance.SetGameOver(false);
        }
    }

    public void Launch()
    {
        IsLaunchered = true;
        if (GameManager.instance != null && GameManager.instance.isGameOver)
            return;
    }
}
