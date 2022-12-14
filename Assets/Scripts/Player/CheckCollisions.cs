using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckCollisions : MonoBehaviour
{
   //
	public PlayerController playerController;
	public GameObject RestartPanel;
	Vector3 StartPos;
	public GameObject Buster;
	public RankManager rankManager;
	public Animator PlayerAnim;
	public static CheckCollisions Instance;
	[HideInInspector]
	public int RunnerWinAmount;
	public int count;
    private void Awake()
    {
        
    }
    private void Start()
    {
		StartPos = new Vector3(transform.position.x,transform.position.y,transform.position.z);
		Instance = this;
		RunnerWinAmount = (rankManager.txtRanks.Length / 2);
		count = PlayerPrefs.GetInt("Count");
    }

    public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	private void OnTriggerEnter(Collider other)
	{
	/*
		if (other.CompareTag("coin"))
		{
            collectCoin.AddCoin();
            Destroy(other.gameObject);
		*/
		if (other.tag==Tags.Finish_tag)
		{

			PlayerFinish(other.gameObject);
			/*
			if (collectCoin.score >= 54)
			{
				//Debug.Log("You Win!..");
				playerController.runningSpeed = 0f;
				playerController.PlayerAnim.SetBool("win", true);
				transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self);
				RestartPanel.SetActive(true);
			}
			else
			{
				//Debug.Log("You Lose!..");
				playerController.runningSpeed = 0f;
				playerController.PlayerAnim.SetBool("lose", true);
				transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self);
				RestartPanel.SetActive(true);
			}
			*/
		
		}
        if (other.tag == Tags.Speed_tag)
        {
			playerController.runningSpeed = playerController.runningSpeed + 3;
			StartCoroutine(IslowAfterCorutine());
			Buster.SetActive(true);
        }
	
	}
	void PlayerFinish(GameObject gameObject)
    {
		FinishScript finishScript = gameObject.gameObject.GetComponent<FinishScript>();
		playerController.runningSpeed = 0f;
		//	playerController.PlayerAnim.SetBool("win", true);
		transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self);
		RestartPanel.SetActive(true);
		GameManager.Instance.isGameEnding = true;
		if (GameManager.Instance.isGameEnding)
		{
			if (GameManager.Instance.Timer < GameManager.Instance.HighScore || GameManager.Instance.HighScore == 0)
			{
				GameManager.Instance.HighScore = GameManager.Instance.Timer;
				PlayerPrefs.SetFloat("HighScore", GameManager.Instance.HighScore);
				
				ActionReplay.Instiance.SetHighScore();
                if (GameManager.Instance.highScoreIsTrue >=1)
                {
					GameManager.Instance.highScoreIsTrue = 2;
                }
                else
                {
					GameManager.Instance.highScoreIsTrue = 1;
				}
				
				// high score un act??f olup olmad??g??n?? kontrol etmek i??in 1 v 0 binary say??lar?? kulland??k
				PlayerPrefs.SetInt("HighScoreTrue",GameManager.Instance.highScoreIsTrue);
				if(ActionReplay.Instiance.actionReplayRecordsSave.Capacity< ActionReplay.Instiance.actionReplayRecords.Count)
                {
					ActionReplay.Instiance.actionReplayRecordsSave.Capacity = ActionReplay.Instiance.actionReplayRecords.Count;
				}
				// ActionReplay.Instiance.isInReplayMode = true;
				count = ActionReplay.Instiance.actionReplayRecords.Count;
				PlayerPrefs.SetInt("Count", count);
			}
		}
		if (finishScript.RunnerValue <= RunnerWinAmount)
		{
			PlayerAnim.SetBool("Win", true);
			PlayerAnim.SetBool("Run", false);
		}
		else
		{

			PlayerAnim.SetBool("Lose", true);
			PlayerAnim.SetBool("Run", false);
		}
		
     
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag==Tags.Obstacle_tag)
		{
			//	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			transform.position = StartPos;

		}
	}
	private  IEnumerator IslowAfterCorutine()
    {
		yield return new WaitForSeconds(2f);
		playerController.runningSpeed = playerController.runningSpeed - 3;
		Buster.SetActive(false);
    }

}
