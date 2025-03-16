using UnityEngine;
using UnityEngine.UI;

public class SettingPopup : MonoBehaviour
{
    public Image music;
    public Image sound;
    public Sprite musicOn;
    public Sprite musicOff;
    public Sprite soundOn;
    public Sprite soundOff;

    private void OnEnable()
    {
        LoadSprite();
    }

    private void LoadSprite()
    {
        var data = GameManager.Instance.gameData;
        
        if (data.isMusic)
        {
            music.sprite = musicOn;
        }
        else
        {
            music.sprite = musicOff;
        }
        
        if (data.isSound)
        {
            sound.sprite = soundOn;
        }
        else
        {
            sound.sprite = soundOff;
        }
        
        AudioManager.Instance.ToggleMusic(!data.isMusic);
        AudioManager.Instance.ToggleSFX(!data.isSound);
    }
    
    public void ToggleMusic()
    {
        var data = GameManager.Instance.gameData;
        
        if (data.isMusic)
        {
            data.isMusic = false;
            music.sprite = musicOff;
            AudioManager.Instance.ToggleMusic(true);
        }
        else
        {
            data.isMusic = true;
            music.sprite = musicOn;
            AudioManager.Instance.ToggleMusic(false);
        }
    }
    
    public void ToggleSound()
    {
        var data = GameManager.Instance.gameData;
        
        if (data.isSound)
        {
            data.isSound = false;
            sound.sprite = soundOff;
            AudioManager.Instance.ToggleSFX(true);
        }
        else
        {
            data.isSound = true;
            sound.sprite = soundOn;
            AudioManager.Instance.ToggleSFX(false);
        }
    }

    public void ClosePopup()
    {
        gameObject.SetActive(false);
    }
}
