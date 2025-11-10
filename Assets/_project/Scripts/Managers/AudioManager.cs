using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bounceAS;
    public AudioSource brickHitAS;    
    public AudioSource failAS;
    public AudioSource victoryAS;

    public void PlayBounceAS()
    {
        bounceAS.Play();
    }
    public void PlayBrickHitAS()
    {
        brickHitAS.Play();
    }
    public void PlayFailAS()
    {
        failAS.Play();
    }
    public void PlayVictoryAS()
    {
        victoryAS.Play();
    }
}
