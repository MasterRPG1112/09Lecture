using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    //어디서든 잘 불러올 수 있도록
    public static PoolManager instance;

    public GameObject bulletPrefab;
    //총알의 갯수
    public int poolSize = 20;

    //비활성화된 총알을 담아두는 창고
    Queue<GameObject> bulletPool = new Queue<GameObject>();

    private void Awake()
    {

        instance = this;
        InitPool();
    }

    void InitPool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(bulletPrefab, transform);
            obj.SetActive(false);
            bulletPool.Enqueue(obj);
        }
    }

    //창고에서 꺼내씀
    public GameObject GetBullet()
    {
        GameObject obj;
        
        if (bulletPool.Count > 0)
        {
            obj = bulletPool.Dequeue();
        }
        else
        {
            obj = Instantiate (bulletPrefab, transform);
        }

        obj.SetActive (true);
        return obj;
    }

    //창고에 반납함
    public void ReturnBullet(GameObject obj)
    {
        obj.SetActive(false);
        bulletPool.Enqueue(obj);
    }
}
