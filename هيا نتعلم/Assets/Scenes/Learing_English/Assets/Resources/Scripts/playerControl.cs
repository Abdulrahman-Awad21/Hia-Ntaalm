using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerControl : MonoBehaviour
{
    string currentPlayerName;
    string currentPlayerRightAnswers;
    string currentPlayerWrongAnswers;
    GameObject[] playersScore;
    GameObject[] playersName;

    public void start()
    {
        //currentPlayerName = GameObject.Find("currentPlayerName").GetComponent<Text>().text;
        //currentPlayerRightAnswers = GameObject.Find("currentPlayerRightAnswers").GetComponent<Text>().text;
        //currentPlayerWrongAnswers = GameObject.Find("currentPlayerWrongAnswers").GetComponent<Text>().text;
        playersScore = GameObject.FindGameObjectsWithTag("playersScore");
        playersName = GameObject.FindGameObjectsWithTag("playersName");
        Debug.Log(playersName);

        GameObject mainCanvas = GameObject.FindGameObjectWithTag("mainCanvas");
        mainCanvas.SetActive(false);
    }

    public List<Player> addPlayers()
    {
        List<Player> players = new List<Player>();

        GameObject[] joinedPlayersName = GameObject.FindGameObjectsWithTag("joinedPlayerName");
        for (int i = 0; i < 4; i++)
        {
            string playerName = joinedPlayersName[i].GetComponent<Text>().text;
            if (playerName != "")
            {
                players.Add(new Player(playerName));
            }
            else
            {
                break;
            }
        }


        return players;
    }

    public void displayPlayers(List<Player> players)
    {
        for (int i = 0; i < players.Count; i++)
        {
            playersName[i].GetComponent<Text>().text = players[i].playerName;
            playersScore[i].GetComponent<Text>().text = players[i].playerScore.ToString();
        }
    }

    public void updatePlayerScore(Player player)
    {
        int id = player.id;
        GameObject.FindGameObjectsWithTag("playersScore")[id].GetComponent<Text>().text = player.playerScore.ToString();
    }

    public void displayCurrentPlayerInfo(Player player)
    {
        GameObject.Find("currentPlayerName").GetComponent<Text>().text = player.playerName;
        GameObject.Find("currentPlayerRightAnswers").GetComponent<Text>().text = player.playerRightAnswers.ToString();
        GameObject.Find("currentPlayerWrongAnswers").GetComponent<Text>().text = player.playerWrongAnswers.ToString();
    }
}

