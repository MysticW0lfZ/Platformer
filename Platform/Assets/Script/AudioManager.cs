using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource musicSource;
    public AudioSource sfxSource;

    public AudioClip coinSound;
    public AudioClip jumpSound;
    public AudioClip damageSound;
    public AudioClip backgroundMusic;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        PlayMusic(backgroundMusic);
    }

    void OnEnable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.onScoreChanged += PlayCoin;
            GameManager.Instance.onHealthChanged += PlayDamage;
        }
    }

    void OnDisable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.onScoreChanged -= PlayCoin;
            GameManager.Instance.onHealthChanged -= PlayDamage;
        }
    }

    //  MUSIC
    public void PlayMusic(AudioClip clip)
    {
        if (musicSource == null) return;

        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    //  SFX
    public void PlaySFX(AudioClip clip)
    {
        if (sfxSource == null || clip == null) return;

        sfxSource.PlayOneShot(clip);
    }

    void PlayCoin(int score)
    {
        // Prevent restart sound
        if (score > 0)
        {
            PlaySFX(coinSound);
        }
    }

    void PlayDamage(int health)
    {
        PlaySFX(damageSound);
    }
}