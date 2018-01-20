using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fading : MonoBehaviour 
{
    // -- Singleton Structure
    protected static Fading mInstance;
    public static Fading Instance
    {
        get
        {
            if (mInstance == null)
            {
                GameObject tempObj = new GameObject();
                mInstance = tempObj.AddComponent<Fading>();
                Destroy(tempObj);
            }
            return mInstance;
        }
    }

	//Control de la pantalla de carga
	public bool b_loadingScreen = true;

	// -- Loading Screen Canvas
	public GameObject loadingScreen;

    // -- Scene to be loaded
    int SceneIndex = 0;

    // -- Whether to do Fade
    bool b_DoFade = false;

    // -- Fade Canvas
    public Canvas FadePrefab;
    Canvas FadeSprite;

    // -- Variables
    float f_Alpha = 1.0f, f_Speed = 1.0f;

    // -- Fade's Type
    public enum E_FadeType
    {
        FADE_IN,
        FADE_OUT
    } E_FadeType Type;

    // -- Instantiate
    void InstantiateFade()
    {
        if (FadePrefab != null) 
            FadeSprite = Instantiate(FadePrefab, FadePrefab.transform.position, Quaternion.identity) as Canvas;
    }

    // -- Initialisation
    void Start()
    {
		// -- Set Instance
        mInstance = this;
        
        // -- Start Fading In
        StartFade(0, true);
    }

    // -- Fading Process
    void DoFade(bool Mode)
    {
        // -- Fade-In
        if (Mode)
        {
            if (FadeSprite.GetComponentInChildren<Image>().color.a > 0.0f)
                f_Alpha -= Time.deltaTime * f_Speed;
            else
                b_DoFade = false;
        }

        // -- Fade-Out
        else
        {
			//carga el loading screen si hay una
			if (b_loadingScreen) {
				Instantiate (loadingScreen, loadingScreen.transform.position, loadingScreen.transform.localRotation);
				b_loadingScreen = false;
			}
			if (FadeSprite.GetComponentInChildren<Image>().color.a < 1.0f)
                f_Alpha += Time.deltaTime * f_Speed;
            else
            {
                b_DoFade = false;
                //Application.LoadLevel(SceneName);
				StartCoroutine(DisplayLoadingScreen(SceneIndex));
            }
        }
    }

	IEnumerator DisplayLoadingScreen (int SceneIndex){
		
		AsyncOperation async = SceneManager.LoadSceneAsync (SceneIndex);
		while(!async.isDone)
			yield return null;
	}

    // -- Start Fading [THIS IS THE FUNCTION U CALL TO TOGGLE FADING]
	public void StartFade(int index, bool Mode)
    {
        // -- Do not constantly reset fade
        if (b_DoFade) return;

        // -- Set Scene to be loaded
        this.SceneIndex = index;

        // -- Tells Program to do fading
        b_DoFade = true;

        // -- Instantiate if Canvas doesn't exist
        if (FadeSprite == null)
            InstantiateFade();

        // -- Set Default Color
        Color DefaultColor = FadeSprite.GetComponentInChildren<Image>().color;

        // -- Fade-In
        if (Mode)
        {
            this.Type = E_FadeType.FADE_IN;
            FadeSprite.GetComponentInChildren<Image>().color = new Color(DefaultColor.r, DefaultColor.g, DefaultColor.b, 1.0f);
        }

        // -- Fade Out
        else
        {
            this.Type = E_FadeType.FADE_OUT;
            FadeSprite.GetComponentInChildren<Image>().color = new Color(DefaultColor.r, DefaultColor.g, DefaultColor.b, 0.0f);
        }
    }

	// -- Update Func
	void Update () 
    {
        // -- Do Fading Now
        if (b_DoFade)
        {
            // -- Fade's Type
            switch (Type)
            {
                case E_FadeType.FADE_IN:
                    DoFade(true);
                    break;
                case E_FadeType.FADE_OUT:
                    DoFade(false);
                    break;
            }

            // -- Set Default Color
            Color DefaultColor = FadeSprite.GetComponentInChildren<Image>().color;

            // -- Toggle Alpha
            FadeSprite.GetComponentInChildren<Image>().color = new Color(DefaultColor.r, DefaultColor.g, DefaultColor.b, f_Alpha);
        }
	}
}
