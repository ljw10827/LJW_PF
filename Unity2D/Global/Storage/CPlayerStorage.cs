using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class CPlayerStorage : CSingleton<CPlayerStorage>
{
    public struct PlayerInfo
    {
        public int nIndex;
        public string oName;
        public int nMoney;
        public int nCash;
        public int nAtk;
        public int nDef;
        public int nSpeed;
        public int nHealthPoint;
    }

    public List<PlayerInfo> playerInfoList { get; set; }
    public Dictionary<string, PlayerInfo> playerDict { get; set; }

    public override void Awake()
    {
        base.Awake();
        playerInfoList = new List<PlayerInfo>();
        string oFileName = Application.persistentDataPath + "/PlayerInfoList.json";

        if (this.LoadListFromFile(oFileName) == null)
        {
            this.LoadOriginListFromFile("Datas/GameData/PlayerInfoList");
            this.SaveListToFile(playerInfoList, oFileName);
        }

        playerInfoList = this.LoadListFromFile(oFileName);
        playerDict.Add("Player", playerInfoList[0]);
    }

    public List<PlayerInfo> LoadListFromFile(string filePath)
    {
        List<PlayerInfo> oPlayerList = null;

        if (!File.Exists(filePath))
        {
            return oPlayerList;
        }

        else
        {
            var oReadStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            var oBinaryFormatter = new BinaryFormatter();

            try
            {
                oPlayerList = (List<PlayerInfo>)oBinaryFormatter.Deserialize(oReadStream);
            }

            finally
            {
                oReadStream.Close();
            }
        }

        return oPlayerList;
    }

    public void LoadOriginListFromFile(string filePath)
    {
        var oTextAsset = Resources.Load<TextAsset>(filePath);
        var oJSONRoot = SimpleJSON.JSON.Parse(oTextAsset.text);

        var oPlayerInfoList = oJSONRoot["PlayerInfoList"];

        for (int i = 0; i < oPlayerInfoList.Count; i++)
        {
            var oInfoList = oPlayerInfoList[i];
            var playerInfo = new PlayerInfo();

            playerInfo.oName = oInfoList["Name"];
            playerInfo.nMoney = int.Parse(oInfoList["Money"]);
            playerInfo.nCash = int.Parse(oInfoList["Cash"]);
            playerInfo.nIndex = int.Parse(oInfoList["ID"]);
            playerInfo.nAtk = int.Parse(oInfoList["ATK"]);
            playerInfo.nDef = int.Parse(oInfoList["DEF"]);
            playerInfo.nSpeed = int.Parse(oInfoList["Speed"]);
            playerInfo.nHealthPoint = int.Parse(oInfoList["HP"]);

            playerInfoList.Add(playerInfo);
        }
    }

    public void MoneyMinus(int price)
    {
        var playerInfo = new PlayerInfo();

        playerInfo.nIndex = playerInfoList[0].nIndex;
        playerInfo.nMoney = playerInfoList[0].nMoney - price;
        playerInfo.nCash = playerInfoList[0].nCash;
        playerInfo.nAtk = playerInfoList[0].nAtk;
        playerInfo.nDef = playerInfoList[0].nDef;
        playerInfo.nSpeed = playerInfoList[0].nSpeed;
        playerInfo.nHealthPoint = playerInfoList[0].nHealthPoint;

        playerInfo.oName = playerInfoList[0].oName;

        playerInfoList[0] = playerInfo;

        this.SavePlayerInfo();
        playerDict["Player"] = playerInfoList[0];
    }

    public void CashMinus(int price)
    {
        var playerInfo = new PlayerInfo();

        playerInfo.nIndex = playerInfoList[0].nIndex;
        playerInfo.nMoney = playerInfoList[0].nMoney;
        playerInfo.nCash = playerInfoList[0].nCash - price;
        playerInfo.nAtk = playerInfoList[0].nAtk;
        playerInfo.nDef = playerInfoList[0].nDef;
        playerInfo.nSpeed = playerInfoList[0].nSpeed;
        playerInfo.nHealthPoint = playerInfoList[0].nHealthPoint;

        playerInfo.oName = playerInfoList[0].oName;

        playerInfoList[0] = playerInfo;

        this.SavePlayerInfo();
        playerDict["Player"] = playerInfoList[0];

    }

    public void UpdateDictFromList(PlayerInfo playerInfo)
    {
        var newPlayerInfo = new PlayerInfo();
        newPlayerInfo.nIndex = playerInfo.nIndex;
        newPlayerInfo.nMoney = playerInfo.nMoney;
        newPlayerInfo.nCash =playerInfo.nCash;
        newPlayerInfo.nAtk = playerInfo.nAtk;
        newPlayerInfo.nDef = playerInfo.nDef;
        newPlayerInfo.nSpeed = playerInfo.nSpeed;
        newPlayerInfo.nHealthPoint = playerInfo.nHealthPoint;
        newPlayerInfo.oName = playerInfo.oName;

        this.SavePlayerInfo();
        playerDict["Player"] = newPlayerInfo;
    }

    private void SaveListToFile(List<PlayerInfo> playerList, string filePath)
    {
        var oWriteStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
        var oBinaryFormatter = new BinaryFormatter();

        try
        {
            oBinaryFormatter.Serialize(oWriteStream, playerList);
        }

        finally
        {
            oWriteStream.Close();
        }
    }

    private void SavePlayerInfo()
    {
        var oFilepath = Application.persistentDataPath + "PlayerInfoList.json";
        var oWriteStream = new FileStream(oFilepath, FileMode.OpenOrCreate, FileAccess.Write);
        var oBinaryFormatter = new BinaryFormatter();

        try
        {
            oBinaryFormatter.Serialize(oWriteStream, playerInfoList);
        }

        finally
        {
            oWriteStream.Close();
        }
    }
}
