using OVRSharp;
using OVRSharp.Math;
using System.Numerics;
using Valve.VR;



public class MyCoolOverlay : Overlay {

  public uint[] footTrackers = new uint[2];

    public MyCoolOverlay()
    : base("my_cool_overlay", "StepMania Pad", false)
  {
    // overlay transformation
    float radians = (float)((Math.PI / 180) * 90); // 90 degrees to radians
    var rotation = Matrix4x4.CreateRotationX(radians); // Lay the overlay flat by rotating it by 90 degrees
    var translation = Matrix4x4.CreateTranslation(0, 0, 0); // Raise the overlay one meter above the ground
    var transform = Matrix4x4.Multiply(rotation, translation); // Combine the transformations in one matrix
    
    Transform = transform.ToHmdMatrix34_t();
    
    // Attach overlay to floor
    TrackedDevice = TrackedDeviceRole.None;

    int counter = 0;
    for( uint i = 0; i < OpenVR.k_unMaxTrackedDeviceCount; i++ ){
      if(OpenVR.System.IsTrackedDeviceConnected(i)){
        Console.WriteLine(OpenVR.System.GetTrackedDeviceClass(i));
        ETrackedDeviceClass t = ETrackedDeviceClass.GenericTracker;
        if(OpenVR.System.GetTrackedDeviceClass(i) == t){
          footTrackers[counter] = i;
          counter++;
        }
      }
    }

    // Set overlay from png
    SetTextureFromFile("C:/Users/steven/Documents/ddr with fbt/osu.jpg");
    SetThumbnailTextureFromFile("C:/Users/steven/Documents/ddr with fbt/osu.jpg");
  }

  public Matrix4x4 getFeetPos(uint c){
    // set to foot tracker at number
    c = footTrackers[c];

    // tell openvr what the origin point of reference is
    ETrackingUniverseOrigin origin = ETrackingUniverseOrigin.TrackingUniverseStanding;

    // create jagged array of the positions openvr will return in
    // the next couple of lines
    TrackedDevicePose_t[] rValue = new TrackedDevicePose_t[OpenVR.k_unMaxTrackedDeviceCount];
    // rValue[0] = new TrackedDevicePose_t[5]; // init first row
    // rValue[1] = new TrackedDevicePose_t[5]; // init second row
    Console.WriteLine(rValue);

    OpenVR.System.GetDeviceToAbsoluteTrackingPose(origin, 0, rValue);
    OpenVR.System.GetDeviceToAbsoluteTrackingPose(origin, 0, rValue);
    
    // TrackedDevicePose_t[][] rValue = new TrackedDevicePose_t[2][];
    // rValue[0] = foot1;
    // rValue[1] = foot2;

    Matrix4x4 matrix = new Matrix4x4(0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0);

    // create matrix
    matrix[0, 0] = rValue[c].mDeviceToAbsoluteTracking.m0;
    matrix[0, 1] = rValue[c].mDeviceToAbsoluteTracking.m1;
    matrix[0, 2] = rValue[c].mDeviceToAbsoluteTracking.m2;
    matrix[0, 3] = rValue[c].mDeviceToAbsoluteTracking.m3;

    matrix[1, 0] = rValue[c].mDeviceToAbsoluteTracking.m4;
    matrix[1, 1] = rValue[c].mDeviceToAbsoluteTracking.m5;
    matrix[1, 2] = rValue[c].mDeviceToAbsoluteTracking.m6;
    matrix[1, 3] = rValue[c].mDeviceToAbsoluteTracking.m7;

    matrix[2, 0] = rValue[c].mDeviceToAbsoluteTracking.m8;
    matrix[2, 1] = rValue[c].mDeviceToAbsoluteTracking.m9;
    matrix[2, 2] = rValue[c].mDeviceToAbsoluteTracking.m10;
    matrix[2, 3] = rValue[c].mDeviceToAbsoluteTracking.m1;
    return matrix;
  }
}
