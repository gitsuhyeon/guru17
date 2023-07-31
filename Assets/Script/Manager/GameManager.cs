using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] goGameUI = null;
    [SerializeField] GameObject goTitleUI = null;
    
    public static GameManager instance;

    public bool isStartGame = false;

    ComboManager theCombo;
    ScoreManager theScore;
    TimingManager thetiming;
    StatusManager theStatus;
    PlayerController thePlayer;
    StageManager theStage;
    NoteManager theNote;
    Result theResult;

    [SerializeField] CenterFlame theMusic = null;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        theNote = FindAnyObjectByType<NoteManager>();
        theCombo = FindObjectOfType<ComboManager>();
        theScore = FindObjectOfType<ScoreManager>();
        thetiming = FindObjectOfType<TimingManager>();
        theStatus = FindObjectOfType<StatusManager>();
        thePlayer = FindObjectOfType<PlayerController>();
        theStage = FindObjectOfType<StageManager>();
        theResult = FindObjectOfType<Result>();
    }

    public void GameStart(int p_songNum, int p_bpm)
    {
        for(int i = 0; i < goGameUI.Length; i++)
        {
            goGameUI[i].SetActive(true);
        }

        theMusic.bgmName = "BGM" + p_songNum;
        theNote.bpm = p_bpm;
        theCombo.ResetCombo();
        theScore.Initialized();
        thetiming.Initialized();
        theStatus.Initialized();
        thePlayer.Initialized();
        theStage.RemoveStage();
        theStage.SettingStage(p_songNum);
        theResult.SetcurrentSong(p_songNum);

        AudioManager.instance.StopBGM();

        isStartGame = true;
    }

    public void MainMenu()
    {
        for (int i = 0; i < goGameUI.Length; i++)
        {
            goGameUI[i].SetActive(false);
        }

        goTitleUI.SetActive(true);
    }
}
