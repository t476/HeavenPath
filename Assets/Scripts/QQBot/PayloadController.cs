using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Threading.Tasks;

public class PayloadController
{
    public void SolvePayloadByType(Payload payload)
    {
        switch (payload.t)
        {
            case "MESSAGE_CREATE":
                if (checkBotMentioned(payload.d.mentions))
                {
                    SolveAtPayloadByContent(payload.d);
                }
                break;
            default:
                break;
        }
    }

    private void SolveAtPayloadByContent(PayloadDetail payloadDetail)
    {
        string content = payloadDetail.content.Substring(24);

        string bindQQ = "绑定账号";
        if (String.Compare(bindQQ, content) == 0)
        {
            Config.instance.BotConfig.user_id = payloadDetail.author.id;
            QQBotHttps.instance.AddLog($"已与账号{payloadDetail.author.username}绑定");
            QQBotHttps.instance.SendMessages("已绑定，可以开始游戏");
        }
    }

    private bool checkBotMentioned(List<User> mentions)
    {
        foreach (User user in mentions)
        {
            if (user.id == Config.instance.BotConfig.BotID)
            {
                return true;
            }
        }
        return false;
    }
}