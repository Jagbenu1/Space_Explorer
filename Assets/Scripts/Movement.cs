using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

  //PARAMETERS - for tuning, typically set in the editor (SerializedField Variables)
  //CACHE - e.g. references for readability or speed (like Rigidbody or AudioSource)
  //STATE -  private instance (member) variables

  [SerializeField] float mainThrust = 100f;
  [SerializeField] float rotationThrust = 11f;
  [SerializeField] AudioClip mainEngine;

  Rigidbody rb;
  AudioSource my_audiosource;

  //Example of state 
  //bool isAlive;

  // Start is called before the first frame update
  void Start()
  {
    rb = GetComponent<Rigidbody>();
    my_audiosource = GetComponent<AudioSource>();
  }

  // Update is called once per frame
  void Update()
  {
    ProcessThrust();
    ProcessRotation();
  }

  void ProcessThrust()
  {
    if (Input.GetKey(KeyCode.Space))
    {
      rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
      if (!my_audiosource.isPlaying)
      {
        my_audiosource.PlayOneShot(mainEngine);
      }
    }
    else
    {
      my_audiosource.Stop();
    }
  }
  void ProcessRotation()
  {
    if (Input.GetKey(KeyCode.A))
    {
      ApplyRotation(rotationThrust);
    }
    else if (Input.GetKey(KeyCode.D))
    {
      ApplyRotation(-rotationThrust);
    }
  }

  void ApplyRotation(float rotationThisFrame)
  {
    rb.freezeRotation = true; // freezing rotations so we can manually rotate
    transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
    rb.freezeRotation = false; //unfreezing rotation so the physics system takes over
  }
}
