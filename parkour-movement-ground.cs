using UnityEngine;

public class PlayerMovement: MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float _moveSpeed = 30f;
    [SerializeField] private float _turnSpeed = 90f;
    [SerializeField] private float _jumpForce = 300f;
    [SerializeField] private Vector3 _direction;
    private bool isGrounded = false;

    void Awake()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        // Ruota il player con A e D usando _turnSpeed
        float turn = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            turn = -_turnSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            turn = _turnSpeed * Time.deltaTime;
        }
        if (turn != 0f)
        {
            transform.Rotate(0f, turn, 0f);
        }

        // Muovi il player avanti/indietro seguendo la direzione della camera con W/S e _moveSpeed
        Vector3 moveDir = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            moveDir += Camera.main.transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDir -= Camera.main.transform.forward;
        }
        moveDir.y = 0f;
        moveDir.Normalize();

        if (moveDir != Vector3.zero)
        {
            _rigidbody.MovePosition(transform.position + moveDir * _moveSpeed * Time.deltaTime);
        }

        // Salta con Space usando _jumpForce e controlla isGrounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Imposta isGrounded a true quando tocchi il terreno
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
