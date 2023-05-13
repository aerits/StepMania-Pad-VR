// var app = new MyCoolApp();
// Console.ReadLine();
using OVRSharp;

var app = new MyCoolApp();
Console.ReadLine();

public class MyCoolApp : Application {
    Pad a;
    public MyCoolApp() : base(ApplicationType.Overlay){
        Console.WriteLine("hit enter when you go to desired place to put stepmania pad...");
        Console.ReadLine();
        a = new Pad();
        while (true)
        {
            a.update();
        }
    }

}
