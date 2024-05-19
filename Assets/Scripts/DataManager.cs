using System;
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
    public Dictionary<string,bool> chosen_cat = new Dictionary<string, bool>(){{"Синнабон",false},{"Люцикот", false },{"Кошкодевочка", false}, { "Нян-Кэт", false }};

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

    public void UnlockCats()
    {
        cat_collection = new Dictionary<string, bool>()
    {{"Буханка", true },{"Синнабон",true},
     {"Рыжик", true },{ "Печенька", true },
     {"Снежок", true }, { "Фантомка", true },
     {"Люцикот", true }, { "НекоАрк", true },
     {"Снежинка", true}, { "Уголек", true },
     {"Кошкодевочка", true}, { "Нян-Кэт", true }};
    }

    public void EquipCat(string cat_name)
    {
        chosen_cat[cat_name] = true;
    }

    public void UnequipCat(string cat_name)
    {
        chosen_cat[cat_name] = false;
    }
}
