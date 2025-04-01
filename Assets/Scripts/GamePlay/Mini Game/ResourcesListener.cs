using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

[AddComponentMenu("Custom/ResourcesListener(���������� ����������� ��������)")]
public class ResourcesListener : MonoBehaviour 
{
    [Header("��������� ���� � ����������� � ��������:")]
    [SerializeField] Text timeBenderTxt;
    [SerializeField] Text coinsTxt;
    [SerializeField] Text depositOverrideTxt;
    

    [Serializable]
    public class Pair
    {
        public MyResources key;
        public int value;
    }

    [Header("��������� ��������:")]
    [SerializeField] private List<Pair> myEnumList = new List<Pair>();

    private void Awake()
    {
        ValidateTextFields();
    }

    /// <summary>
    /// ����� ��� ���������� ������
    /// </summary>
    /// <param name="resourceKey">����� ������� ���������</param>
    /// <param name="amount">����������</param>
    public void AddCurrency(MyResources resourceKey, int amount)
    {
        // ����, ���� �� ��� ����� ���� � ������
        Pair existingPair = myEnumList.Find(pair => pair.key == resourceKey);

        if (existingPair != null)
        {
            // ���� ������ ������, ����������� ��� ��������
            existingPair.value += amount;
        }
        else
        {
            // ���� ������ �� ������, ��������� ����� ������� � ������
            myEnumList.Add(new Pair { key = resourceKey, value = amount });
        }

        ValidateTextFields();
    }

    /// <summary>
    /// ��������� ��������� ���� ��������.
    /// </summary>
    public void ValidateTextFields()
    {
        // ���� �������� ��� ������� ������� � ��������� ��������� ����
        Pair timeBenderPair = myEnumList.Find(pair => pair.key == MyResources.TimeBender);
        timeBenderTxt.text = timeBenderPair.value.ToString();
        

        Pair coinsPair = myEnumList.Find(pair => pair.key == MyResources.Coins);
        coinsTxt.text = coinsPair.value.ToString();
        

        Pair depositOverridePair = myEnumList.Find(pair => pair.key == MyResources.DepositOverride);
        depositOverrideTxt.text = depositOverridePair.value.ToString();
        
    }

}
