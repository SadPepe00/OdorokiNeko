using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public int level_num = 0;
    public int player_health = 5;
    public int player_money = 200;
    public Dictionary<string, bool> cat_collection = new Dictionary<string, bool>()
    {{"Буханка", false },{"Синнабон",false}, 
     {"Рыжик", false },{ "Печенька", false }, 
     {"Снежок", false }, { "Фантомка", false }, 
     {"Люцикот", false }, { "НекоАрк", false }, 
     {"Снежинка", false}, { "Уголек", false },
     {"Кошкодевочка", false}, { "Нян-Кэт", false }};
    public AudioClip intro;
    public AudioClip menu;
    public AudioClip lvl;
    public AudioClip boss;
    public AudioSource music_controller;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        music_controller = gameObject.GetComponent<AudioSource>();
    }
    public void ChangeMusic(string state)
    {
        if (state == "menu")
        {
            music_controller.clip = menu;
            music_controller.Play();
            music_controller.loop = true;
        }
        if (state == "lvl")
        {
            music_controller.clip = lvl;
            music_controller.Play();
            music_controller.loop = true;
        }
        if (state == "boss")
        {
            music_controller.clip = boss;
            music_controller.Play();
            music_controller.loop = true;
        }
        if (state == "death")
        {
            music_controller.Stop();
        }
    }
    public void SetVolume(float vol)
    {
        music_controller.volume = vol;
    }

    public void SetLoop(bool loop)
    {
        music_controller.loop = loop;
    }
}
