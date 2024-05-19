using System;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public int level_num = 0;
    public int player_health = 5;
    public int player_money = 200;
    public Dictionary<string, bool> cat_collection = new Dictionary<string, bool>()
    {{"�������", false },{"��������",false}, 
     {"�����", false },{ "��������", false }, 
     {"������", false }, { "��������", false }, 
     {"�������", false }, { "�������", false }, 
     {"��������", false}, { "������", false },
     {"������������", false}, { "���-���", false }};
    public AudioClip intro;
    public AudioClip menu;
    public AudioClip lvl;
    public AudioClip boss;
    public AudioSource music_controller;
    public Dictionary<string,bool> chosen_cat = new Dictionary<string, bool>(){{"��������",false},{"�������", false },{"������������", false}, { "���-���", false }};

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
    {{"�������", true },{"��������",true},
     {"�����", true },{ "��������", true },
     {"������", true }, { "��������", true },
     {"�������", true }, { "�������", true },
     {"��������", true}, { "������", true },
     {"������������", true}, { "���-���", true }};
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
