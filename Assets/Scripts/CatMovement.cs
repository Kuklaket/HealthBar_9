using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : MonoBehaviour
{
    const int CountIdle = 0;
    const int CountWalk = 1;
    const int CountWait = 2;
    const int CountWait1 = 3;
    const int CountWait2 = 4;
   
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
        int countLastAnimation = CountWait2 + 1;

        _animationNumber = Random.Range(CountWalk, countLastAnimation);
    }

    private void RunAnimation()
    {
        _animator.SetInteger("AnimationNumber", _animationNumber);

        if (_animationNumber == CountWalk)
        {
            _speed = 4;
        }
        else
        {
            _speed = 0;
        }
    }

    private void Flip()
    {
        int countForRotate = -1;

        _horizontalDirection = _horizontalDirection * countForRotate;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
