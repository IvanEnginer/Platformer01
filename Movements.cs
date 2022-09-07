using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Movements : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForse;

    private Animator _animator;

    private Vector3 _startVector3;
    private Vector3 _currentVector3;

    private int _runToRightAnimatorHash = Animator.StringToHash("IsRunToRight");
    private int _runToLeftAnimatorHash = Animator.StringToHash("IsRunToLeft");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _startVector3.x = transform.position.x;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _animator.SetBool(_runToRightAnimatorHash, true);
            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }
        else
        {
            _animator.SetBool(_runToRightAnimatorHash, false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
            _animator.SetBool(_runToLeftAnimatorHash, true);
        }
        else
        {
            _animator.SetBool(_runToLeftAnimatorHash, false);
        }

        _currentVector3.x = transform.position.x;

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            if (_startVector3.x <= _currentVector3.x)
            {
                transform.Translate(_speed * Time.deltaTime, _jumpForse * Time.deltaTime, 0);
            }
            else
            {
                transform.Translate(_speed * Time.deltaTime * -1, _jumpForse * Time.deltaTime, 0);
            }
        }

        _startVector3.x = _currentVector3.x;
    }
}
