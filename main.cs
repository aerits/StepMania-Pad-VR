// var app = new MyCoolApp();
// Console.ReadLine();
using OVRSharp;

var app = new MyCoolApp();
Console.ReadLine();

public class MyCoolApp : Application {
    Pad a;
    public MyCoolApp() : base(ApplicationType.Overlay){
        Console.WriteLine("hit enter to start program");
        Console.ReadLine();
        a = new Pad();
        while (true)
        {
            a.update();
        }
    }

}
