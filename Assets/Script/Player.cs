using UnityEngine;

public class Player : MonoBehaviour
{
    float moveX;
    float moveZ;
    bool jump;
    bool fire;

    bool isJump;

    public float Speed;
    public float JumpPower;

    float fireTimer = 0f;

    public GameObject bulletPrefab;
    public Transform firePoint;
    //public bool fireCheck = true;

    Vector3 moveVec;

    Rigidbody rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        GetInput();
        Move();
        Jump();
        Shoot();
    }

    void GetInput()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");
        jump = Input.GetButtonDown("Jump");
        fire = Input.GetButton("Fire1");
    }

    void Move()
    {
        moveVec = new Vector3(moveX, 0, moveZ).normalized;
        transform.position += moveVec * Speed * Time.deltaTime;
        transform.LookAt(transform.position + moveVec);
    }

    void Jump()
    {
        if (jump && !isJump)
        {
            rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
            isJump = true;
        }
    }
    void Shoot()
    {
        /*if (fire && fireCheck)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            fireCheck = false;
        }*/

        fireTimer += Time.deltaTime;

        if (fire)
        {
            fireTimer += 0f;

            GameObject bullet = PoolManager.instance.GetBullet();
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;

            //총구 방향(firePoint.forward)으로 총알 속도 다시 맞춰주기
            bullet.GetComponent<Rigidbody>().linearVelocity = firePoint.forward * 15f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJump = false;
        }
    }
}
