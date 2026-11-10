using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    /*public float speed;

    void Start()
    {
        Destroy(gameObject, 2f);
    }

    void Update()
    {
        transform.position += new Vector3(0f, 0f, 0f) * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Enemy")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

    private void OnDisable()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        player.fireCheck = true;
    }*/

    public float speed = 15f;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    //Start 함수와의 차이? Start = 오브젝트 생성 후 최초 실행(단 씬 전환) / OnEnable = 오브젝트가 활성화가 될때마다 발동
    private void OnEnable()
    {
        rb.linearVelocity = transform.forward * speed;
        Invoke("DisableBullet", 2f);
    }

    void DisableBullet()
    {
        PoolManager.instance.ReturnBullet(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            CancelInvoke("DisableBullet");
            DisableBullet();
        }
    }
}
