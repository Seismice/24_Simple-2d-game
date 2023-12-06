using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Швидкість переміщення гравця")]
    [SerializeField] private int _spead = 10;
    [Header("Сила прижка гравця")]
    [SerializeField] private float _jumpForce;
    [SerializeField] private ContactFilter2D _platform;

    private Rigidbody2D _rigidbody2D;
    private bool isOnPlatfom => _rigidbody2D.IsTouching(_platform);

    public bool isRiht = true;


    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Jump();
    }

    /// <summary>
    /// Метод для керування стрілками клавіатури.
    /// </summary>
    private void GetInput()
    {
        if (transform.rotation.eulerAngles.z < 89f || transform.rotation.eulerAngles.z > 271f)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.localPosition += -transform.right * _spead * Time.deltaTime;
                isRiht = false;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.localPosition += transform.right * _spead * Time.deltaTime;
                isRiht = true;
            } 
        }

        if(Input.GetKey(KeyCode.LeftControl))
        {
            //transform.localRotation = transform.Rotate(0f, 0f, 0f);

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0f);
        }
    }

    private void Jump()
    {
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    if (isOnPlatfom == true)
        //    {
        //        _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse); 
        //    }
        //}

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
        //}

        if (transform.rotation.eulerAngles.z < 89f || transform.rotation.eulerAngles.z > 271f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isOnPlatfom == true)
                {
                    _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
                }
            } 
        }

    }

}



