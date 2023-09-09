using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : MonoBehaviour
{
    const int CountIdle = 0;
    const int CountWalk = 1;
    const int CountLastAnimation = 4;
   
    [SerializeField] private Animator _animator;

    private int _speed = 0;
    private int _leftDirection = -1;
    private int _rightDirection = 1;
    private int _horizontalDirection = 1;
    private int _animationNumber;
    private int _leftBorder = -13;
    private int _rightBorder = 13;

    private void Start()
    {
        Coroutine startAnimations = StartCoroutine(StartAnimations()); 

        _animationNumber = 0;

        if (startAnimations != null)
        {
            StopCoroutine(startAnimations);
        }
       
        StartCoroutine(StartAnimations());  
    }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * _horizontalDirection, 0, 0);

        if (transform.position.x < _leftBorder && _horizontalDirection == _leftDirection)
        {
            Flip();
        }
        else if (transform.position.x > _rightBorder && _horizontalDirection == _rightDirection)
        {
            Flip();
        }
    }

    private IEnumerator StartAnimations()
    {
        int durationAnimation = 3;

        while (true)
        {
            _animationNumber = CountIdle;
            RunAnimation();

            yield return new WaitForSeconds(durationAnimation);

            GenerateAnimationNumber();
            RunAnimation();

            yield return new WaitForSeconds(durationAnimation);
        }
    }

    private void GenerateAnimationNumber()
    {
        int countLastAnimation = CountLastAnimation + 1;

        _animationNumber = Random.Range(CountWalk, countLastAnimation);
    }

    private void RunAnimation()
    {
        int movementSpeed = 4;
        int staySpeed = 0;

        _animator.SetInteger(HashAnimationsNames.AnimatoinNumber, _animationNumber);
 
        if (_animationNumber == CountWalk)
        {
            _speed = movementSpeed;
        }
        else
        {
            _speed = staySpeed;
        }
    }

    private void Flip()
    {
        int countForRotate = -1;

        _horizontalDirection = _horizontalDirection * countForRotate;
        Vector3 theScale = transform.localScale;
        theScale.x *= countForRotate;
        transform.localScale = theScale;
    }
}
