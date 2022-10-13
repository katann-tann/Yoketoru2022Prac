using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMChanger : MonoBehaviour
{
    [Tooltip("–Â‚ç‚µ‚½‚¢BGM"), SerializeField]
    TinyAudio.BGM bgm = TinyAudio.BGM.Gameover;

    void Start()
    {
        TinyAudio.PlayBGM(bgm);
    }
}
