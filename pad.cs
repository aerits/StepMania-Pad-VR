using WindowsInput.Native;
using WindowsInput;

public class Pad
{
    private MyCoolOverlay a;
    private double padSize;
    private double[][] panels;
    private InputSimulator sim;
    private double[] padPos;

    public Pad(double x, double y)
    {
        sim = new InputSimulator();
        padPos = new double[2] { x, y };
        padSize = 0.3;
        panels = new double[4][];
	// TODO add rotation (https://wikiless.org/wiki/Rotation_matrix?lang=en)
        panels[0] = new double[2] { 0+x, -0.33+y };
        panels[1] = new double[2] { 0+x, 0.33+y };
        panels[2] = new double[2] { 0.33+x, 0+y };
        panels[3] = new double[2] { -0.33+x, 0+y };
        a = new MyCoolOverlay();
        a.Show();
    }
    public void update()
    {
        a.updateFeetPos();
        checkFeetOnPad();
	System.Threading.Thread.Sleep(10);
    }
    private void checkFeetOnPad()
    {
        if (a.isFootOnGround(0) || a.isFootOnGround(1))
        {
            for (int i = 0; i < 4; i++)
                if (a.isFootInCircle(0, panels[i], padSize) || a.isFootInCircle(1, panels[i], padSize))
                {
		    Console.WriteLine("keypress incoming");
		    pressKey(i);
		}
	}
    }
    private string pressKey(int c)
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
