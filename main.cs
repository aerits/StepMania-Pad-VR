// var app = new MyCoolApp();
// Console.ReadLine();
using OVRSharp;
using Valve.VR;

var app = new MyCoolApp();
Console.ReadLine();

public class MyCoolApp : Application {
    public MyCoolOverlay a;

    public MyCoolApp() : base(ApplicationType.Overlay){
        a = new MyCoolOverlay();
        a.Show();

        string createText = "";

        while(true){
            createText = createText + a.getPos(3).ToString() + Environment.NewLine;
            Console.Write(createText);
            File.WriteAllText("C:/Users/steven/Documents/ddr with fbt/output.txt", createText);
            System.Threading.Thread.Sleep(1000);
	    }
    }

}
