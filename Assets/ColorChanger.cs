using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlayerColor 
{
    RedPlayer,
    GreenPlayer,
    BluePlayer,
}

public class ColorChanger : MonoBehaviour
{
    public PlayerColor playerColor;
    public GameObject Redobject, Greenobject, Blueobject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (playerColor) 
        { 
            case PlayerColor.RedPlayer:
                Redobject.SetActive(true);
                Greenobject.SetActive(false);
                Blueobject.SetActive(false);
                break; 
            case PlayerColor.GreenPlayer:
                Greenobject.SetActive(true);
                Blueobject.SetActive(false);
                Redobject.SetActive(false);
                break;
                case PlayerColor.BluePlayer:
                Blueobject.SetActive(true);
                Redobject.SetActive(false);
                Greenobject.SetActive(false);
                break;
        }    

    }

    private void OnMouseDown()
    {
        if (playerColor == PlayerColor.RedPlayer) 
        {
            playerColor = PlayerColor.GreenPlayer;
        }

        else if (playerColor == PlayerColor.GreenPlayer)
        {
            playerColor = PlayerColor.BluePlayer;
        }

        else if (playerColor == PlayerColor.BluePlayer)
        {
            playerColor = PlayerColor.RedPlayer;
        }

    }

}
