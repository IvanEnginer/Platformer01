using UnityEngine;

public class CheingDirection : MonoBehaviour
{
    private Animator _animator;

    private Vector3 _startPoint;
    private Vector3 _lastPoint;
    private Vector3 _currentPosition;

    private bool _isDirectionRight = true;
    private bool _isDirectionChange = true;

    private int _runToRightAnimatorHash = Animator.StringToHash("IsRunToRighRobot");

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _startPoint = transform.position;

        _lastPoint = _startPoint;
    }

    private void Update()
    {
        _currentPosition = transform.position;

        _isDirectionRight = _lastPoint.x < _currentPosition.x ? true : false;

        _lastPoint = _currentPosition;

        if(_isDirectionChange != _isDirectionRight)
        {
            if(_isDirectionRight)
            {
                _animator.SetBool(_runToRightAnimatorHash, true);
            }
            else
            {
                _animator.SetBool(_runToRightAnimatorHash, false);
            }

            _isDirectionChange = _isDirectionRight;
        }
    }
}
