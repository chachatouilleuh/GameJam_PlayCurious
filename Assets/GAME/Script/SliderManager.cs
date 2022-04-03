using UnityEngine;
using UnityEngine.UI;


public class SliderManager : MonoBehaviour
{
    // Les sources musique, sfx et luminosite
    [SerializeField, Tooltip("la musique a mettre")] private AudioSource m_audioSource;

    // les Sliders
    [SerializeField, Tooltip("le slider de la musique")] private Slider m_musicSlider;

    // la valeur maximale par defaut assignee
    private float m_musicVolume = 1f;

    private void Start()
    {
        // Au lancement du jeu je vais recuperer les valeurs de mes sliders
        m_musicVolume = PlayerPrefs.GetFloat("music");

        // la valeur de ma source est egale a celle du volume recupere
        m_audioSource.volume = m_musicVolume;

        // la valeur du slider est egale a celle du volume recupere
        m_musicSlider.value = m_musicVolume;

        // J'initie mes valeurs par defaut
        m_audioSource.volume = 0.5f;
    }

    private void Update()
    {
        // Mes valeurs de volumes sont toujours egales a celles recuperees
        m_audioSource.volume = m_musicVolume;


        // Je remplace les valeurs recuperables
        PlayerPrefs.SetFloat("music", m_musicVolume);
    }

    // Les fonctions a attribuer aux sliders pour mettre a jour les differentes valeurs 

    public void MusicVolumeUpdater(float volume)
    {
        m_musicVolume = volume;
    }


    // Les fonctions pour reset les valeurs

    public void VolumeReset()
    {
        PlayerPrefs.DeleteKey("music");

        m_audioSource.volume = 1;

        m_musicSlider.value = 1;
    }
}