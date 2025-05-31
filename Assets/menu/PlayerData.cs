using System;
using System.Collections.Generic;

[System.Serializable]
public class PlayerModel
{
    public int Id;
    public string Name;
    public string Password;
    public string Level1Time = "00:00";
    public string Level2Time = "00:00";
}

[System.Serializable]
public class PlayerModelList
{
    public List<PlayerModel> users;
}
