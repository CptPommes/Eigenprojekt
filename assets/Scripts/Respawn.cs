using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

    public AudioClip[] deathByEnemy;
    public AudioClip[] deathByFalling;
    public AudioSource audio;

    void Start()
    {
        deathByEnemy = new AudioClip[] {(AudioClip) Resources.Load("Sounds/Death/Scream1"), (AudioClip) Resources.Load("Sounds/Death/Scream3") , (AudioClip) Resources.Load("Sounds/Death/Scream4") , (AudioClip) Resources.Load("Sounds/Death/Scream5") };
        deathByFalling = new AudioClip[] { (AudioClip) Resources.Load("Sounds/Death/Falling/Scream2"), (AudioClip) Resources.Load("Sounds/Death/Falling/Scream6") };

        
    }

     IEnumerator PlayerDeath()
    {
        yield return new WaitForSeconds(1);
        
        transform.position = Checkpoint.checkPosition;
        
        transform.rotation = Checkpoint.checkRotation;

       
    }



    void OnTriggerEnter(Collider hit)
    {
        
        if (hit.gameObject.tag == "Falling")
        {
            audio.PlayOneShot(deathByFalling[Random.Range(0, deathByFalling.Length-1)]);
            
            StartCoroutine(PlayerDeath());
        }

        if(hit.gameObject.tag == "Enemy")
        {
            audio.PlayOneShot(deathByEnemy[Random.Range(0, deathByEnemy.Length-1)]);
            StartCoroutine(PlayerDeath());
        }
    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {
            audio.PlayOneShot(deathByEnemy[Random.Range(0, deathByEnemy.Length)]);
            StartCoroutine(PlayerDeath());
        }
    }

    
}
