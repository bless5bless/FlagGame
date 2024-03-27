using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 声音管理器
/// </summary>
public class SoundManager 
{
    private AudioSource bgmSource;//播放bgm的音频组件
    private AudioSource effectSource;

    private Dictionary<string, AudioClip> clips;//音频缓存字典

    private bool isStop;//是否静音

    public bool IsStop
    {
        get 
        { 
            return isStop; 
        }
        set
        {
            isStop = value;
            if(isStop == true)
            {
                bgmSource.Pause();
            }
            else
            {
                bgmSource.Play();
            }
        }
    }

    private float bgmVolume;//bgm音量

    public float BgmVolume
    {
        get 
        { 
            return bgmVolume; 
        } 
        set
        {
            bgmVolume = value;
            bgmSource.volume = bgmVolume;
        }
    }

    private float effectVolume;//音效音量

    public float EffectVolume
    {
        get 
        { 
            return effectVolume;
        }
        set 
        { 
            effectVolume = value;
            //effectSource.volume = effectVolume;
        }
    }

    public SoundManager()
    {
        clips = new Dictionary<string, AudioClip>();
        bgmSource = GameObject.Find("game").GetComponent<AudioSource>();
        IsStop = false;
        bgmVolume = 1;
        effectVolume = 1;
    }

    public void PlayBGM(string res)
    {
        if (isStop == true)
        {
            return;
        }
        if (clips.ContainsKey(res) == false)
        {
            //加载
            AudioClip clip = Resources.Load<AudioClip>($"Sounds/{res}");
            clips.Add(res, clip);
        }
        bgmSource.clip = clips[res];
        bgmSource.Play();//播放
    }

    public void PlayEffect(string res)
    {
        if (clips.ContainsKey(res) == false)
        {
            AudioClip clip = Resources.Load<AudioClip>($"Sounds/{res}");
            clips.Add(res, clip);
        }
        effectSource.clip = clips[res];
        effectSource.Play();
    }

    public void PlayEffect(string name,Vector3 pos)
    {
        if(isStop == true)
        {
            return;
        }
        AudioClip clip = null;
        if(clips.ContainsKey(name) == false)
        {
            clip = Resources.Load<AudioClip>($"Sounds/{name}");
            clips.Add(name, clip);
        }
        AudioSource.PlayClipAtPoint(clips[name], pos);
    }
}
