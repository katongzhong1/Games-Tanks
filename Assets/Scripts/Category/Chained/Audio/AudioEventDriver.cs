using System;
using UnityEngine;
using System.Collections;

public class AudioEventDriver: MonoBehaviour {
    //======================================================================
    // Public Properties
    //======================================================================
    /// <summary>
    /// On update event handler.
    /// 委托定义
    /// </summary>
    /// <param name="percent">百分比</param>
    public delegate void OnUpdateEventHandler(float percent);
    /// <summary>
    /// On complete event handler.
    /// </summary>
    public delegate void OnCompleteEventHandler();
    /// <summary>
    /// The on update.
    /// 委托实例
    /// </summary>
    public OnUpdateEventHandler onUpdate = null;
    /// <summary>
    /// The on complete.
    /// 委托实例
    /// </summary>
    public OnCompleteEventHandler onComplete = null;

    //======================================================================
    // Private Properties
    //======================================================================
    /// <summary>
    /// The audio source.
    /// </summary>
    private AudioSource audioSource = null;

    //======================================================================
    // Public Functions
    //======================================================================
    public void OnUpdate(AudioSource audios, OnUpdateEventHandler onUpdateHandler) {
        onUpdate = onUpdateHandler;
        audioSource = audios;
    }

    public void OnComplete(AudioSource audios, OnCompleteEventHandler onCompleteHandler) {
        audioSource = audios;
        onComplete = onCompleteHandler;
    }

    //======================================================================
    // Private Functions
    //======================================================================

    private void Update() {
        // ==> onUpdate 驱动
        if (onUpdate != null && audioSource != null) {
            if (audioSource.isPlaying) {
                onUpdate(audioSource.time / audioSource.clip.length);
            }
        }
        // ==> onComplete 驱动
        if (Mathf.Abs(audioSource.time - audioSource.clip.length) < 0.00001) {
            onComplete();
        }
    }
}
