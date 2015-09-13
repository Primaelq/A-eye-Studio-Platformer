using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour {

    public Sprite heartFull;
    public Sprite heartHalf;
    public Sprite heartEmpty;
    public Image heart0;
    public Image heart1;
    public Image heart2;

    private int health;

    void Start()
    {

    }

    void Update()
    {
        health = PlayerController.health;

        switch (health)
        {
            case 0:
                heart0.sprite = heartEmpty;
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                break;

            case 1:
                heart0.sprite = heartHalf;
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                break;

            case 2:
                heart0.sprite = heartFull;
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                break;

            case 3:
                heart0.sprite = heartFull;
                heart1.sprite = heartHalf;
                heart2.sprite = heartEmpty;
                break;

            case 4:
                heart0.sprite = heartFull;
                heart1.sprite = heartFull;
                heart2.sprite = heartEmpty;
                break;

            case 5:
                heart0.sprite = heartFull;
                heart1.sprite = heartFull;
                heart2.sprite = heartHalf;
                break;

            case 6:
                heart0.sprite = heartFull;
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                break;
        }
    }
}
