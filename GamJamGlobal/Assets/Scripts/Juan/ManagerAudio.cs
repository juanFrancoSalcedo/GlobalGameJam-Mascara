using B_Extensions;
using UnityEngine;

public class ManagerAudio : Singleton<ManagerAudio>
{
    public AudioSource coin;
    public AudioSource enemy;
    public AudioSource enemyDeath;
    public AudioSource mask;
    public AudioSource hit;
    public AudioSource menu;
    public AudioSource shot;

    public void PlayCoin()=>coin.Play();
    public void PlayEnemy() => enemy.Play();
    public void PlayEnemyDeath() => enemyDeath.Play();
    public void PlayMask() => mask.Play();
    public void PlayHit() => hit.Play();
    public void PlayMenu() => menu.Play();
    public void PlayShot() => shot.Play();

}


