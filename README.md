# StepMania Pad VR
This is a project to recreate a DDR pad in vr.

It's designed to be played with the game [stepmania](https://www.stepmania.com/) or its derivatives: [NotITG](https://www.noti.tg/), [etterna](https://etternaonline.com), and many others. It does this by simulating arrow key presses and sending that to the game.

# How to run
1. Clone the repository / download the source code
2. Go into `bin\Debug\net7.0` inside of `StepMania-Pad-VR`
3. Run the binary named `ddr pad vr.exe`
4. Create a shortcut if you want to

# why

i don't want to buy a ddr pad

- this project is to make a vr "pad" to press the arrow keys
- in theory it should be able to not only work with full body trackers but also with your controllers

# amount complete
- functionality of pressing keys when you step on them in theory works
- places a pad in the center of your playspace
- after connecting 2 feet trackers, you can hit the keys in theory

# todo list
- [ ] add gui
- [ ] implement stepping on the pad with controllers
- [ ] allow repositioning of pad
- [ ] animate pad
- [ ] allow hiding the pad
- [ ] maybe add multiple pad functionality
- [ ] follow an irl pad? based on vive tracker

# data for future reference

![image](https://github.com/aerits/StepMania-Pad-VR/blob/master/up%20and%20down.png?raw=true)

*image of a position matrix graphed with viewData.py, numbers are valves m variables from [mDeviceToAbsoluteTracking](https://valvesoftware.github.io/steamvr_unity_plugin/api/Valve.VR.TrackedDevicePose_t.html#Valve_VR_TrackedDevicePose_t_mDeviceToAbsoluteTracking) with 1 added to them*

also it places a picture of osu in the middle of your playspace lol

|       | column 1 | column 2 | column 3 | column 4 (position)                |
|:------|:---------|:---------|:---------|:-----------------------------------|
| row 1 | ??? m0   | ??? m1   | ??? m2   | either x or z, negative is left m3 |
| row 2 | ??? m4   | ??? m5   | ??? m6   | y m7                               |
| row 3 | ??? m8   | ??? m9   | ??? m10  | x or z, negative is forwards m11   |

*table showing what the values in mDeviceToAbsoluteTracking actually are as far as i know*

as you can see i have no idea what most of the numbers are. i assume one of the columns is rotation but after that i have no guesses to what the others are. i really don't understand where i am supposed to find out what these are lol. maybe i was supposed to find that out from some math class in college (i am a highschool student)

(pad image is taken from [here](https://the
trashman.deviantart.com/art/Custom-DDR-Pad-design-251557032))

