using UnityEngine;

//Classe che gestisce il movimento del giocatore
public class PlayerMovement : MonoBehaviour
{
    //Velocità di movimento tramite Transform (non utilizzata in questo script)
    [SerializeField] private float _speedTransform = 1.5f;
    //Velocità di movimento tramite Rigidbody
    [SerializeField] private float _speedRigidbody = 15f;
    //Riferimento al componente Rigidbody
    [SerializeField] private Rigidbody _rigidbody;
    //Direzione del movimento
    [SerializeField] private Vector3 _direction;

    //Metodo chiamato all'avvio dello script
    void Awake()
    {
        //Ottiene il componente Rigidbody dall'oggetto
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    //Metodo chiamato ad ogni frame
    void Update()
    {
        //Aggiorna la direzione in base all'input
        GetDirection();
    }

    //Metodo chiamato ad ogni frame fisico
    void FixedUpdate()
    {
        //Muove il giocatore
        Move();
    }

    //Metodo per ottenere la direzione in base ai tasti premuti
    private void GetDirection()
    {
        _direction = Vector3.zero;
        //Se viene premuto W, aggiunge avanti
        if (Input.GetKey(KeyCode.W))
        {
            _direction += Vector3.forward;
        }
        //Se viene premuto S, aggiunge indietro
        if (Input.GetKey(KeyCode.S))
        {
            _direction += Vector3.back;
        }
        //Se viene premuto D, aggiunge destra
        if (Input.GetKey(KeyCode.D))
        {
            _direction += Vector3.right;
        }
        //Se viene premuto A, aggiunge sinistra
        if (Input.GetKey(KeyCode.A))
        {
            _direction += Vector3.left;
        }
    }

    //Metodo per muovere il Rigidbody nella direzione desiderata
    private void Move()
    {
        _rigidbody.MovePosition(_rigidbody.position + _direction * _speedRigidbody * Time.fixedDeltaTime);
    }
}