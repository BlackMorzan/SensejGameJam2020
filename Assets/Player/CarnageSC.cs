using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarnageSC : MonoBehaviour
{
    [SerializeField]
    Animator m_Animator;
    [SerializeField]
    AudioSource BGSound;
    [SerializeField]
    AudioClip Song;
    [SerializeField]
    ParticleSystem Blood;
    [SerializeField]
    Transform Parent;

    public List<Transform> BodyParts = new List<Transform>();

    private float ending = 0;
    private bool TheEnd = false;

    private void Update()
    {

        if (ending < Time.time && TheEnd)
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);



        Debug.Log(ending + "/" + Time.time);

    }
    private void Start()
    {
        //BGsound need to have normal song on start
        BGSound.Play();
    }
    public void Spooky()
    {
        //no going back
        // sound for testing in BGsound and Song
        BGSound.clip = Song;

        BGSound.Play();
    }

    public void Carnage()
    {
        //Animation Particle
        // animation - separate heat and make is ragdoll??
        Blood.transform.parent = null;

        m_Animator.enabled = false;
        foreach(var body in BodyParts)
        {
            body.gameObject.SetActive(true);
            body.transform.parent = null;
            body.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 10);
        }
        Parent.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;   ////gameObject.GetComponent<BoxCollider2D>;

        //m_Animator.SetBool("pain", true);
        ending = Time.time + 30f;
        Debug.Log(ending + "/" + Time.time);
        TheEnd = true;
        Blood.Play();

        //foreach (Transform child in Parent.transform) if (child.CompareTag("Body")) 
        //{
        //    
        //}

    }
}
