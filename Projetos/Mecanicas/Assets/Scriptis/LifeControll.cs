using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class LifeControll : MonoBehaviour
{
    public float maxLife = 130;
    private float life;
    public Scrollbar lifeBar;
    // Use this for initialization
    void Start()
    {
        life = maxLife;
        lifeControl();
    }


    public void Hit(float hit)
    {
        life -= hit;
        if (life < 0)
        {
            life = 0;
        }
        lifeControl();
    }

    public void Healing(float healing)
    {
        life += healing;
        if (life > maxLife)
        {
            life = maxLife;
        }
        lifeControl();
    }

    private void lifeControl()
    {
        lifeBar.size = (life / maxLife);
    }

}
