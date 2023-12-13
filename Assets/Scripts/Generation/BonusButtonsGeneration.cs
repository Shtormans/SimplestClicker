using System;
using System.Collections;
using UnityEngine;

public class BonusButtonsGeneration : MonoBehaviour
{
    [SerializeField] private BonusButton _bonusButton;
    [SerializeField] private RectTransform _panelTransform;

    public event Action<Clickable> OnButtonInstanceCreated; 

    private void OnEnable()
    {
        StartCoroutine(GenerationCoroutine());
    }

    private void OnDisable()
    {
        StopCoroutine(GenerationCoroutine());
    }

    private IEnumerator GenerationCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);

            var instance = CreateNewButton();
        }
    }

    private GameObject CreateNewButton()
    {
        var button = _bonusButton.gameObject;
        var position = GetRandomPosition();
        var rotation = Quaternion.identity;

        var instance = Instantiate(button, position, rotation);
        instance.transform.SetParent(_panelTransform, false);

        var bonusButton = instance.GetComponent<BonusButton>();
        
        OnButtonInstanceCreated?.Invoke(bonusButton);

        return instance;

    }

    private Vector2 GetRandomPosition()
    {
        float x = UnityEngine.Random.Range(0, _panelTransform.rect.width) - _panelTransform.rect.width / 2;
        float y = UnityEngine.Random.Range(0, _panelTransform.rect.height) - _panelTransform.rect.height / 2;

        return new Vector2(x, y);
    }
}
