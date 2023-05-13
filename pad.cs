using WindowsInput.Native;
using WindowsInput;

public class Pad
{
    private MyCoolOverlay a;
    private double padSize;
    private double[][] panels;
    private InputSimulator sim;

    public Pad()
    {
        sim = new InputSimulator();
        padSize = 0.3;
        panels = new double[4][];
        panels[0] = new double[2] { 0, -0.33 };
        panels[1] = new double[2] { 0, 0.33 };
        panels[2] = new double[2] { 0.33, 0 };
        panels[3] = new double[2] { -0.33, 0 };
        a = new MyCoolOverlay();
        a.Show();
    }
    public void update()
    {
        a.updateFeetPos();
        checkFeetOnPad();
	System.Threading.Thread.Sleep(10);
    }
    public void checkFeetOnPad()
    {
        if (a.isFootOnGround(0) || a.isFootOnGround(1))
        {
            for (int i = 0; i < 4; i++)
                if (a.isFootInCircle(0, panels[i], padSize))
                {
                    pressKey(i);
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
                sim.Keyboard.KeyPress(VirtualKeyCode.UP);
		break;
            case 1:
                e = "backward";
		sim.Keyboard.KeyPress(VirtualKeyCode.DOWN);
                break;
            case 2:
                e = "right";
		sim.Keyboard.KeyPress(VirtualKeyCode.RIGHT);
                break;
            case 3:
                e = "left";
		sim.Keyboard.KeyPress(VirtualKeyCode.LEFT);
                break;
            default:
                e = "invalid";
                break;
        }
        return e;
    }
}
