using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusButton : Clickable
{
    [SerializeField, Range(0f, 5f)] private float _mulitplier = 2;
    [SerializeField, Range(0f, 10f)] private float _seconds = 5;

    [SerializeField, Range(0, 200)] private float _speed = 70;

    private void OnEnable()
    {
        StartCoroutine(DeleteCoroutine());
    }

    private void Update()
    {
        transform.position = transform.position + Vector3.up * _speed * Time.deltaTime;
    }

    public void Click()
    {
        var command = new BonusButtonCommand(_mulitplier, _seconds);

        base.Click(command);

        Destroy(gameObject);
    }

    private IEnumerator DeleteCoroutine()
    {
        yield return new WaitForSeconds(2);

        Destroy(gameObject);
    }
}
