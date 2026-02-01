using B_Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerAudio : Singleton<ManagerAudio>
{
    public AudioSource coin;
    public AudioSource enemy;
    public AudioSource enemyDeath;
    public AudioSource mask;
    public AudioSource hit;
    public AudioSource menu;
    public AudioSource shot;
    public AudioSource musicaInicio;
    public AudioSource musicaGameplay;
    public AudioSource musicaCreditos;
    public void PlayCoin()=>coin.Play();
    public void PlayEnemy() => enemy.Play();
    public void PlayEnemyDeath() => enemyDeath.Play();
    public void PlayMask() => mask.Play();
    public void PlayHit() => hit.Play();
    public void PlayMenu() => menu.Play();
    public void PlayShot() => shot.Play();
    public void PlayMusicGameplay() => musicaGameplay.Play();
    public void PlayMusicCreditos() => musicaCreditos.Play();



    private void Start()
    {
        if (SceneManager.GetActiveScene().name.Contains("GamScene"))
            PlayMusicGameplay();
        
    }

}


