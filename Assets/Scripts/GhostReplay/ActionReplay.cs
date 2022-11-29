using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActionReplay : MonoBehaviour
{
    // Start is called before the first frame update
    public List<ActionReplayRecord> actionReplayRecords = new List<ActionReplayRecord>();
    public List<ActionReplayRecord> actionReplayRecordsSave = new List<ActionReplayRecord>();
    private bool isInReplayMode;
    private Rigidbody rigidbody;
    private int currentReplayIndex;
    public int indexChangeRate = 0;
    public int nextIndex;
    private float position_X;
    private float position_Y;
    private float position_Z;
    private float rotation_X;
    private float rotation_Y;
    private float rotation_Z;
    private int indexİ= 0;
    public static ActionReplay Instiance;
    public float WaitForNexIndex = 0.2f;
    public float waitForSecondIndex;
    private float decimalRate = 0;
    public GameObject GhostPlayer;
    public GameObject GhostPlayerPrefab;
    private void Awake()
    {
      
    }
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Instiance = this;
       if (GameManager.Instance.highScoreIsTrue == 0)
        {
            //GhostPlayer.SetActive(false);
            // GhostPlayer.transform.position = transform.position;
            GhostPlayerPrefab.SetActive(false);
            GhostPlayer.GetComponent<TextMeshPro>().text = "";
        }
        else
        {
            //GhostPlayer.SetActive(true);
            GetHighScore();

        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.highScoreIsTrue == 0)
        {
            //GhostPlayer.SetActive(false);
            GhostPlayer.transform.position = transform.position;
        }
        if (GameManager.Instance.highScoreIsTrue >= 1)
        {
            isInReplayMode = !isInReplayMode;
            if (isInReplayMode)
            {

                /*
                WaitForNexIndex -= Time.deltaTime;
                if (WaitForNexIndex <=0 || waitIndex<=0)
                {
                    indexChangeRate += 1;
                    WaitForNexIndex = WaitNextIndex;
                    waitIndex += 1;
                }
                */

                if(GameManager.Instance.highScoreIsTrue > 1)
                {
                    decimalRate += waitForSecondIndex * Time.deltaTime;
                }
                else
                {
                    decimalRate += WaitForNexIndex * Time.deltaTime;
                }
                
                indexChangeRate =(1+ Mathf.RoundToInt(decimalRate));



                SetTransform(indexChangeRate);
                // rigidbody.isKinematic = true;
            }
            else
            {
                // SetTransform(actionReplayRecords.Count - 1);
                // rigidbody.isKinematic = false;
            }
        }
        position_X = transform.position.x;
        position_Y = transform.position.y;
        position_Z = transform.position.z;
        rotation_X = transform.rotation.x;
        rotation_Y = transform.rotation.y;
        rotation_Z = transform.rotation.z;
        if (isInReplayMode == false)

        {
            if (!GameManager.Instance.isGameEnding)
            {
                actionReplayRecords.Add(new ActionReplayRecord { position =transform.position, rotation =transform.rotation });
                // SetHighScore();
            }
        }
        else
        {
            nextIndex = nextIndex + indexChangeRate;

        }



        /*
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            indexChangeRate = -1;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            indexChangeRate *= 0.5f;
        }
        */


    }
    private void FixedUpdate()
    {
       
     
    }
    public void SetHighScore()
    {
        for (int i=0;i<actionReplayRecords.Count;i++)
        {
            PlayerPrefs.SetFloat("Position_X"+i, actionReplayRecords[i].position.x);
            PlayerPrefs.SetFloat("Position_Y"+i, actionReplayRecords[i].position.y);
            PlayerPrefs.SetFloat("Position_Z"+i, actionReplayRecords[i].position.z);
            PlayerPrefs.SetFloat("Rotation_X"+i, actionReplayRecords[i].rotation.x);
            PlayerPrefs.SetFloat("Rotation_Y"+i, actionReplayRecords[i].rotation.y);
            PlayerPrefs.SetFloat("Rotation_Z"+i, actionReplayRecords[i].rotation.z);
            Debug.Log("Set compliate");
           
          //  indexİ += 1;
        }
        
       
        
    }
    public void GetHighScore()
    {
       
        for (int i = 0; i <CheckCollisions.Instance.count; i++)
        {
            Vector3 newPosition = new Vector3(PlayerPrefs.GetFloat("Position_X"+i),
               PlayerPrefs.GetFloat("Position_Y"+i), PlayerPrefs.GetFloat("Position_Z"+i));
            Quaternion quaternion = new Quaternion(PlayerPrefs.GetFloat("Rotation_X"+i), PlayerPrefs.GetFloat("Rotation_Y"+i), PlayerPrefs.GetFloat("Rotation_Z"+i)
                ,0);
            Debug.Log(PlayerPrefs.GetFloat("Position_Z"+0));
            Debug.Log(PlayerPrefs.GetFloat("Position_Z"+1));
            Debug.Log(PlayerPrefs.GetFloat("Position_Z"+311));
            Debug.Log("getScore");

            /*
            actionReplayRecordsSave[i].position.x = PlayerPrefs.GetFloat("Position_X"+i);
            actionReplayRecordsSave[i].position.y = PlayerPrefs.GetFloat("Position_Y"+i);
            actionReplayRecordsSave[i].position.z = PlayerPrefs.GetFloat("Position_Z"+i);
            actionReplayRecordsSave[i].rotation.x = PlayerPrefs.GetFloat("Rotation_X"+i);
            actionReplayRecordsSave[i].rotation.y = PlayerPrefs.GetFloat("Rotation_Y"+i);
            actionReplayRecordsSave[i].rotation.z = PlayerPrefs.GetFloat("Rotation_Z"+i);
            */
            actionReplayRecordsSave.Add(new ActionReplayRecord { position = newPosition,
                rotation = quaternion});


        }
    }
    private void OnEnable()
    {
        
    }
    private void SetTransform(int index)
    {
        if (index < actionReplayRecordsSave.Count)
        {
           // currentReplayIndex = index;
            ActionReplayRecord actionReplayRecord = actionReplayRecordsSave[(int)index];
            GhostPlayer.transform.position = actionReplayRecordsSave[index].position;
            GhostPlayer.transform.rotation = actionReplayRecordsSave[index].rotation;
        }
     
    }
  
}
