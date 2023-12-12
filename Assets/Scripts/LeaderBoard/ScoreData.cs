using System;

[Serializable]
public class ScoreData
{
    public string playerInitials;
    public string playerTime;

    public ScoreData(string initials, string time)
    {
        this.playerInitials = initials;
        this.playerTime = time;
    }
}
