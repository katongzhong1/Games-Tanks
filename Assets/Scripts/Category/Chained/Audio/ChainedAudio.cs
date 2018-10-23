using System;
using UnityEngine;

/// <summary>
/// Audio 链式编程.
/// </summary>
public static class ChainedAudio {
    //==========================================================================
    // Public Functions
    //==========================================================================
    /// <summary>
    /// Gets the audio.
    /// 获取一个音乐播放器
    /// </summary>
    /// <returns>The audio.</returns>
    /// <param name="gameObject">Game object.</param>
    /// <param name="add">If set to <c>true</c> add.</param>
    public static AudioSource GetAudio(this GameObject gameObject, bool add = false) {
        AudioSource audio = null;
        if (!add) {
            audio = gameObject.GetComponent<AudioSource>();
            if (audio) {
                audio = gameObject.AddComponent<AudioSource>();
            }
        } else {
            audio = gameObject.AddComponent<AudioSource>();
        }
        return audio;
    }

    /// <summary>
    /// Sets the clip.
    /// 设置 clip
    /// </summary>
    /// <returns>The clip.</returns>
    /// <param name="audioSource">Audio source.</param>
    /// <param name="clip">Clip.</param>
    public static AudioSource SetClip(this AudioSource audioSource, AudioClip clip) {
        if (clip) {
            audioSource.clip = clip;
        }
        return audioSource;
    }

    /// <summary>
    /// Ons the update.
    /// 音乐播放中的回调
    /// </summary>
    /// <returns>The update.</returns>
    /// <param name="audioSource">Audio source.</param>
    /// <param name="onUpdateHandler">On update handler.</param>
    public static AudioSource OnUpdate(this AudioSource audioSource, AudioEventDriver.OnUpdateEventHandler onUpdateHandler) {
        GetEventDriver(audioSource).OnUpdate(audioSource, onUpdateHandler);
        return audioSource;
    }

    /// <summary>
    /// Ons the complete.
    /// 音乐播放完成回调
    /// </summary>
    /// <returns>The complete.</returns>
    /// <param name="audioSource">Audio source.</param>
    /// <param name="onCompleteHandler">On complete handler.</param>
    public static AudioSource OnComplete(this AudioSource audioSource, AudioEventDriver.OnCompleteEventHandler onCompleteHandler) {
        GetEventDriver(audioSource).OnComplete(audioSource, onCompleteHandler);
        return audioSource;
    }

    //==========================================================================
    // Private Functions
    //==========================================================================
    private static AudioEventDriver GetEventDriver(this AudioSource audioSource) {
        AudioEventDriver driver = audioSource.gameObject.GetComponent<AudioEventDriver>();
        if (driver == null) {
            driver = audioSource.gameObject.AddComponent<AudioEventDriver>();
        }
        return driver;
    }
}

