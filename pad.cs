public class Pad
{
    private MyCoolOverlay a;
    private double padSize;
    private double[][] panels;

    public Pad()
    {
        padSize = 0.17;
        panels = new double[4][];
        panels[0] = new double[2] { 0, -0.33 };
        panels[1] = new double[2] { 0, 0.33 };
        panels[1] = new double[2] { 0.33, 0 };
        panels[1] = new double[2] { -0.33, 0 };
        a = new MyCoolOverlay();
        a.Show();
    }
    public void update()
    {
        a.updateFeetPos();
    }
    public void checkFeetOnPad()
    {
        if (a.isFootOnGround(0) || a.isFootOnGround(1))
        {
            for (int i = 0; i < 4; i++)
                if (a.isFootInCircle(0, panels[i], padSize))
                {
                    if (i == 0)
                    {
                        pressKey(i);
                    }
                }
        }
    }
    public string pressKey(int c)
    {
        string e;
        switch (c)
        {
            case 0:
                e = "forward";
                break;
            case 1:
                e = "backward";
                break;
            case 2:
                e = "right";
                break;
            case 3:
                e = "left";
                break;
            default:
                e = "invalid";
                break;
        }
        return e;
    }
}
