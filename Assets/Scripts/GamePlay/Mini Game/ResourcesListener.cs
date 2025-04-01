using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

[AddComponentMenu("Custom/ResourcesListener(Контроллер накопленных ресурсов)")]
public class ResourcesListener : MonoBehaviour 
{
    [Header("Текстовые поля с информацией о ресурсах:")]
    [SerializeField] Text timeBenderTxt;
    [SerializeField] Text coinsTxt;
    [SerializeField] Text depositOverrideTxt;
    

    [Serializable]
    public class Pair
    {
        public MyResources key;
        public int value;
    }

    [Header("Контейнер ресурсов:")]
    [SerializeField] private List<Pair> myEnumList = new List<Pair>();

    private void Awake()
    {
        ValidateTextFields();
    }

    /// <summary>
    /// Метод для начисления валюты
    /// </summary>
    /// <param name="resourceKey">Товар который начисляем</param>
    /// <param name="amount">количество</param>
    public void AddCurrency(MyResources resourceKey, int amount)
    {
        // Ищем, есть ли уже такой ключ в списке
        Pair existingPair = myEnumList.Find(pair => pair.key == resourceKey);

        if (existingPair != null)
        {
            // Если ресурс найден, увеличиваем его значение
            existingPair.value += amount;
        }
        else
        {
            // Если ресурс не найден, добавляем новый элемент в список
            myEnumList.Add(new Pair { key = resourceKey, value = amount });
        }

        ValidateTextFields();
    }

    /// <summary>
    /// Обновляет текстовые поля ресурсов.
    /// </summary>
    public void ValidateTextFields()
    {
        // Ищем значения для каждого ресурса и обновляем текстовые поля
        Pair timeBenderPair = myEnumList.Find(pair => pair.key == MyResources.TimeBender);
        timeBenderTxt.text = timeBenderPair.value.ToString();
        

        Pair coinsPair = myEnumList.Find(pair => pair.key == MyResources.Coins);
        coinsTxt.text = coinsPair.value.ToString();
        

        Pair depositOverridePair = myEnumList.Find(pair => pair.key == MyResources.DepositOverride);
        depositOverrideTxt.text = depositOverridePair.value.ToString();
        
    }

}
