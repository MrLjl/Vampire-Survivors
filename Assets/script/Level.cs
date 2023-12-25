using System.Collections.Generic;

public class Level
{
    public int curLevel;
    public List<int> takeLevels;

    public Level()
    {
    }

    public Level(int curLevel)
    {
        this.curLevel = curLevel;
        takeLevels = new List<int>();
    }

    public Level(int curLevel, List<int> takeLevels)
    {
        this.curLevel = curLevel;
        this.takeLevels = takeLevels;
    }
}
