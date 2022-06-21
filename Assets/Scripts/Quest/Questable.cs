using UnityEngine;

//每个【可以派发任务】的NPC都会添加这个脚本，路标等单方面功能性的游戏对象除外，不添加这个脚本，他们只需要添加talkable脚本
public class Questable : MonoBehaviour
{
    public Quest quest;//可委派的具体任务

    public bool isFinished;//防止任务重复派发

    public QuestTarget questTarget;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        //LoadData();
    }
    //当可委派任务NPC对话完成后，调用这个方法
    public void DelegateQuest()
    {
        if(isFinished == false)
        {
            if (quest.questStatus == Quest.QuestStatus.Waitting)
            {
                quest.questStatus = Quest.QuestStatus.Accepted;//初次委托时将任务更改为【接收】状态
                Player.instance.questList.Add(quest);

                //看看收集类是否已经完成了
                if (quest.questType == Quest.QuestType.Gathering)
                {
                    questTarget.CheckQuestIsComplete();

                    #region
                    if(DialogueManager.instance.GetQuestResult() == true)
                    {
                        DialogueManager.instance.ShowDialogue(DialogueManager.instance.talkable.congratsLines, DialogueManager.instance.talkable.hasName);
                        isFinished = true;
                        OfferRewards();
                    }
                    #endregion
                }
            }
            else
            {
                Debug.Log(string.Format("QUEST: {0} has accepted already!", quest.questName));
              //  Debug.Log("QUEST : " + quest.questName + "has has accepted already!");
            }
        }
        else
        {
            Debug.Log("You have Finished THIS QUEST BRO!");
        }

        QuestManager.instance.UpdateQuestList();
    }

    public void OfferRewards()
    {
        Player.instance.exp += quest.expReward;
        Player.instance.gold += quest.goldReward;
        QuestManager.instance.UpdateUIText();
        Debug.Log("$*$*$*****Bonus*****$*$*$");
    }


}
