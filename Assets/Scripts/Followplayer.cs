using UnityEngine;

public class Followplayer : MonoBehaviour
{
    public Transform player; //Player Position


    Vector3 move,start,end;

    //Playermoves between:  vvv

    [Range(-6.3f, 6.6f)]
    public float left = -2.2f;
    [Range(-6.3f, 6.6f)]
    public float right = 2.5f;

    //Playermoves between   ^^^


    void Update()
    {


        if (player.position.x > left && player.position.x < right) //Spieler Zwischen linkem und rechtem Kamera - Rand
        {
            move = new Vector3(player.position.x, transform.position.y, transform.position.z);

            transform.position = move;    //Kammera x Position = Spieler x Position
        }
        else if(player.position.x <= left) //Spieler weiter links als linker Rand
        {
            start = new Vector3(left, transform.position.y, transform.position.z);
            transform.position = start;     //Kamera gleich linker Rand (ANFANG VOM BILD)
        }
        else if(player.position.x > right) //Spieler weiter rechts als rechter Rand
        {
            end = new Vector3(right, transform.position.y, transform.position.z);
            transform.position = end;       //Kamera gleich rechter Rand (ENDE VOM BILD)
        }
    }
}
