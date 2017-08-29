using UnityEngine;
using System.Collections;

/**
 * Respawn
 * 
 * Handles player death and respawn mechanics
 * 
 * This script is given to any playable character and is triggered when the player dies, so that it reads the checkpoint value and positions the player where he last saved.
 **/
public class Respawn : MonoBehaviour {

    public AudioClip[] deathByEnemy;
    public AudioClip[] deathByFalling;
    public AudioSource audio;

    /**
     * Sets the contents of the two sound arrays with the files inside the resource folder
     **/
    void Start()
    {
        deathByEnemy = new AudioClip[] {(AudioClip) Resources.Load("Sounds/Death/Scream1"), (AudioClip) Resources.Load("Sounds/Death/Scream3") , (AudioClip) Resources.Load("Sounds/Death/Scream4") , (AudioClip) Resources.Load("Sounds/Death/Scream5") };
        deathByFalling = new AudioClip[] { (AudioClip) Resources.Load("Sounds/Death/Falling/Scream2"), (AudioClip) Resources.Load("Sounds/Death/Falling/Scream6") };

        
    }

    /**
     * Waits for the set amount of time to play the death sound and then positions the player back at the last checkpoint. 
     **/
    IEnumerator PlayerDeath()
    {
        yield return new WaitForSeconds(1);
        
        transform.position = Checkpoint.checkPosition;
        
        transform.rotation = Checkpoint.checkRotation;

       
    }

    /**
     * Plays different sounds if the player hits a falling deathzone or the enemy, then triggers Playerdeath coroutine
     **/

    void OnTriggerEnter(Collider hit)
    {
        
        if (hit.gameObject.tag == "Falling")
        {
            audio.PlayOneShot(deathByFalling[Random.Range(0, deathByFalling.Length-1)]); //Plays a random sound from the deathByFalling array
            
            StartCoroutine(PlayerDeath());
        }

        if(hit.gameObject.tag == "Enemy")
        {
            audio.PlayOneShot(deathByEnemy[Random.Range(0, deathByEnemy.Length-1)]); //Plays a random sound from the deathByEnemy array
            StartCoroutine(PlayerDeath());
        }
    }

    /**
     * Plays the sound when hit by the enemy, then triggers Playerdeath coroutine.
     **/
    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {
            audio.PlayOneShot(deathByEnemy[Random.Range(0, deathByEnemy.Length)]);
            StartCoroutine(PlayerDeath());
        }
    }

    
}
