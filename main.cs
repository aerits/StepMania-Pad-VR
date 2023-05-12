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
        Console.WriteLine("gaming");
        a.Show();

        while(true){
            Console.WriteLine(a.getFeetPos(0));
            System.Threading.Thread.Sleep(1000);
        }
    }

}
