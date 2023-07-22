using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject lastObject;
    public TMP_Text text;
    [SerializeField] private float money = 0;
    [SerializeField] private float depositMoney = 0;
    public TMP_Text[] texts;

    public void increaseDepositMoney(float value)
    {
        depositMoney += value;
        setDepositText();
    }

    public float getDepositMoney()
    {
        return depositMoney;
    }

    public void increaseMoney(float value)
    {
        money += value;
        changeText();
    }

    public void decreaseMoney(float value)
    {
        money -= value;
        changeText();
    }

    public float getMoney()
    {
        return money;
    }

    public void setLastObject(GameObject obj)
    {
        lastObject = obj;
    }

    public GameObject getLastObject()
    {
        return lastObject;
    }

    public void changeText()
    {
        if(money < 1000f)
        {
            text.text = money.ToString();
        }
        else if(money > 1000f)
        {
            float temp = money / 1000f;
            text.text = temp.ToString() + "K";
        }
        else if(money > 10000f)
        {
            float temp = money / 10000f;
            text.text = temp.ToString() + "K";
        }  
    }

    private void setDepositText()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].text = depositMoney.ToString();
        }
    }

    public void loadLevel()
    {
        SceneManager.LoadScene(0);
    }
    
}
