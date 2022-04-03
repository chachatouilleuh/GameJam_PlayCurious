using System;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    //private SceneManager sceneManager;

    [SerializeField, Tooltip("les canvas à assigner")] private GameObject Accueil, MainMenu, Options, Tuto, Selection, LoadScreen;

    private bool m_accueilOpen;
    private bool m_mainMenuOpen, m_optionsOpen, m_loadScreenOpen, m_tutoOpen, m_selectionOpen;


    [SerializeField, Tooltip("le menu de slection de letage")]
    private GameObject KeyboardU, GamepadU, KeyboardM, GamepadM, KeyboardD, GamepadD, PlayButton, KupButton, KdownButton, GupButton, GdownButton;

    public bool Kready= false;
    
    public bool Gready= false;

    private float playerWhere =0;


    // INITIALISE LES VALEURS
    private void Awake()
    {
        OpenAccueil();
        playerWhere = PlayerPrefs.GetFloat("choix");
    }
    // MENU SLECTION ETAGE

    private void Update()
    {
        if (Kready == true && Gready == true)
        {
            PlayButton.SetActive(true);
        }
    }

    public void Kup()
    {
        KeyboardM.SetActive(false);
        KupButton.SetActive(false);
        KdownButton.SetActive(false);
        KeyboardU.SetActive(true);
        GupButton.SetActive(false);
        PlayerPrefs.SetFloat("choix",1);
        Kready = true;
    }
    public void Kdown()
    {
        KeyboardM.SetActive(false);
        KupButton.SetActive(false);
        KdownButton.SetActive(false);
        KeyboardD.SetActive(true);
        GdownButton.SetActive(false);
        PlayerPrefs.SetFloat("choix",2);
        Kready = true;
    }
    public void Gup()
    {
        GamepadM.SetActive(false);
        GupButton.SetActive(false);
        GdownButton.SetActive(false);
        GamepadU.SetActive(true);
        KupButton.SetActive(false);
        PlayerPrefs.SetFloat("choix",2);
        Gready = true;
    }
    public void Gdown()
    {
        GamepadM.SetActive(false);
        GupButton.SetActive(false);
        GdownButton.SetActive(false);
        GamepadD.SetActive(true);
        KdownButton.SetActive(false);
        PlayerPrefs.SetFloat("choix",1);
        Gready = true;
    }

    

    // OPEN/CLOSE CANVAS
    
    public void OpenAccueil()
    {
        if (!m_accueilOpen)
        {
            Accueil.SetActive(true);
            m_accueilOpen = true;
        }
        else
        {
            Accueil.SetActive(false);
            m_accueilOpen = false;
        }
    }
    
    public void OpenMainMenu()
    {
        if (!m_mainMenuOpen)
        {
            MainMenu.SetActive(true);
            m_mainMenuOpen = true;
        }
        else
        {
            MainMenu.SetActive(false);
            m_mainMenuOpen = false;
        }
    }
    
    public void OpenOptions()
    {
        if (!m_optionsOpen)
        {
            Options.SetActive(true);
            m_optionsOpen = true;
        }
        else
        {
            Options.SetActive(false);
            m_optionsOpen = false;
        }
    }
    
    public void OpenTuto()
    {
        if (!m_tutoOpen)
        {
            Tuto.SetActive(true);
            m_tutoOpen = true;
        }
        else
        {
            Tuto.SetActive(false);
            m_tutoOpen = false;
        }
    }
    
    public void OpenLoadScreen()
    {
        if (!m_loadScreenOpen)
        {
            LoadScreen.SetActive(true);
            m_loadScreenOpen = true;
        }
        else
        {
            LoadScreen.SetActive(false);
            m_loadScreenOpen = false;
        }
    }
    
    public void OpenSelection()
    {
        if (!m_selectionOpen)
        {
            Selection.SetActive(true);
            m_selectionOpen = true;
            
            
        }
        else
        {
            Selection.SetActive(false);
            m_selectionOpen = false;
        }
    }
}

