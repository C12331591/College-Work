import ddf.minim.*;

class Object
{
  int X, Y;
  int wid;
  int hei;
  int[] colour = new int[3];
  AudioPlayer sound;
  
  //constructor
  Object(int rX, int rY, int Wid, int Hei, int[] Colour, String soundFile)
  {
    this(rX, rY, Wid, Hei, Colour);
    sound = audio.loadFile(soundFile, 1024);
  }
  
  Object(int rX, int rY, int Wid, int Hei, int[] Colour)
  {
    X = rX;
    Y = rY;
    wid = Wid;
    hei = Hei;
    colour = Colour;
    sound = audio.loadFile("reset.mp3", 1024);//placeholder sound - will be overwritten if a proper sound has been specified
  }
  
  Object()
  {
    X =0;
    Y = 0;
    wid = 0;
    hei = 0;
    colour[0] = 0;
    colour[1] = 0;
    colour[2] = 0;
    sound = audio.loadFile("reset.mp3", 1024);//placeholder sound
  }
}
 
class Console extends Object
{
  Lid lid;
  Light powerLight;
  Spindle spindle;
  boolean on;
  Button eject;
  Button power;
  Button reset;
  
  Console (int rX, int rY, int Wid, int Hei, int[] Colour, String soundFile)
  {
    super(rX, rY, Wid, Hei, Colour, soundFile);
    lid = new Lid();
    powerLight = new Light();
    on = false;
    
    int[] buttonColour = {180, 180, 180};
    int[] discColour = {174, 0, 193};
    int[] lightColour = {90, 255, 0};
    
    //calculating some measurements
    int quarterHei = hei / 4;
    int frontTop = Y + hei - quarterHei;
    int topMiddle = Y + ((hei - quarterHei) / 2);
    int quarterWid = wid / 4;
    
    eject = new Button(X + wid - (quarterWid / 2), Y + int((hei/1.6)), wid / 8, hei/7, buttonColour, "open.mp3");
    power = new Button(X + (quarterWid / 2), Y + int((hei/1.6)), wid / 8, hei/7, buttonColour, "power.mp3");
    reset = new Button(X + int((quarterWid) / 2.5), Y + int((hei/2.1)), ((quarterWid) / 5), hei/15, buttonColour, "reset.mp3");
    
    lid = new Lid(X + (wid / 2), topMiddle, int(wid/1.8), int(hei/1.5), colour, "close.mp3");
    spindle = new Spindle(X + (wid / 2), topMiddle, (quarterWid) / 5, hei/15, discColour);
    powerLight = new Light(X + (quarterWid / 2), frontTop, (wid / 50), (hei / 15), lightColour);
  }
  
  Console (int rX, int rY, int Wid, int Hei, int[] Colour)
  {
    super(rX, rY, Wid, Hei, Colour);
    lid = new Lid();
    powerLight = new Light();
    on = false;
    
    int[] buttonColour = {180, 180, 180};
    int[] discColour = {174, 0, 193};
    int[] lightColour = {90, 255, 0};
    
    //calculating some measurements
    int quarterHei = hei / 4;
    int frontTop = Y + hei - quarterHei;
    int topMiddle = Y + ((hei - quarterHei) / 2);
    int quarterWid = wid / 4;
    
    eject = new Button(X + wid - (quarterWid / 2), Y + int((hei/1.6)), wid / 8, hei/7, buttonColour, "open.mp3");
    power = new Button(X + (quarterWid / 2), Y + int((hei/1.6)), wid / 8, hei/7, buttonColour, "power.mp3");
    reset = new Button(X + int((quarterWid) / 2.5), Y + int((hei/2.1)), ((quarterWid) / 5), hei/15, buttonColour, "reset.mp3");
    
    lid = new Lid(X + (wid / 2), topMiddle, int(wid/1.8), int(hei/1.5), colour, "close.mp3");
    spindle = new Spindle(X + (wid / 2), topMiddle, (quarterWid) / 5, hei/15, discColour);
    powerLight = new Light(X + (quarterWid / 2), frontTop, (wid / 50), (hei / 15), lightColour);
  }
  
  Console()
  {
    super();
    lid = new Lid();
    powerLight = new Light();
    on = false;
  }
  
  void draw()
  {
    fill(colour[0], colour[1], colour[2]);
    
    //calculating some measurements
    int quarterHei = hei / 4;
    int tenthWid = wid / 10;
    int frontTop = Y + hei - quarterHei;
    int backLeft = X + tenthWid;
    int backRight = X + wid - tenthWid;
    int backWid = backRight - backLeft;
    int quarterWid = wid / 4;
    int quarterBackWid = backWid/4;
    
    fill(colour[0], colour[1], colour[2]);
    
    line(backLeft, Y, backRight, Y);
    line(backLeft, Y, X, frontTop);
    line(backRight, Y, (X + wid), frontTop);
    line(X, frontTop, (X + wid), frontTop);
    rect(X, frontTop, wid, quarterHei);
    
    line(backLeft + quarterBackWid, Y, X + quarterWid, frontTop);
    line(backRight - quarterBackWid, Y, (X + wid) - quarterWid, frontTop);
    line(X + quarterWid, frontTop, X + quarterWid, Y + hei);
    line((X + wid) - quarterWid, frontTop, (X + wid) - quarterWid, Y + hei);
    
    rect(X + (wid/3.2), Y + (hei/1.2), wid / 6, hei / 17);//memory card door 1
    rect(X + (wid/1.9), Y + (hei/1.2), wid / 6, hei / 17);//memory card door 2
    
    ellipse(lid.X, lid.Y, lid.wid, lid.hei);//tray
    ellipse(power.X, power.Y, power.wid, power.hei);//space for power button
    ellipse(eject.X, eject.Y, eject.wid, eject.hei);//space for eject button
    ellipse(reset.X, reset.Y, reset.wid, reset.hei);//space for reset button
    
    //a crude representation of the laser assembly
    fill(0, 0, 0);
    rect(spindle.X, spindle.Y, wid / 5, hei / 5);
    spindle.draw();
    
    drawPort(X + (wid/3.2), Y + (hei/1.1), wid / 6, hei / 17);//base of controller port 1
    drawPort(X + (wid/1.9), Y + (hei/1.1), wid / 6, hei / 17);//base of controller port 2
    
    lid.draw();
    
    if (eject.draw())//Button.draw returns a positive boolean value if it was just pressed in the current iteration.
    {
      lid.state = true;
    }
    
    if (power.draw())
    {
      on = !on;
      
      if (on && lid.state == false && spindle.state == true)
      {
        console.sound.rewind();
        console.sound.play();
      }
    }
    
    if (reset.draw())
    {
      //reset the bootup sequence
    }
    
    powerLight.draw(on);
    
    if (on)
    {
      if (lid.state == false)
      {
        spindle.speed = 1.14;//makes the disk spin - odd value so the spinning doesn't look too uniform
      }
    }
    else
    {
      console.sound.rewind();//stops the sound of the system running if it is turned off
    }
  }
  
  void drawPort(float x, float y, float Wid, float Hei)
  {
    fill(0, 0, 0);
    rect(x, y, Wid, Hei);
    
    fill(colour[0], colour[1], colour[2]);
    rect(x + (Wid/20), y + (Hei/10), Wid / 3.5, Hei / 1.3);
    rect(x + (Wid/2.8), y + (Hei/10), Wid / 3.5, Hei / 1.3);
    rect(x + (Wid/1.5), y + (Hei/10), Wid / 3.5, Hei / 1.3);
  }
}

class TV extends Object
{
  void DrawTV(int X, int Y)//draws the shape of the TV
  {
    fill(colour[0], colour[1], colour[2]);
    rect(X, Y, wid, hei);//maybe add a little more
  }
}

class Animated extends Object//this class serves as a base for any piece which can have any kind of animation.
{
  boolean state;//this allows the object to have two different states
  
  Animated(int rX, int rY, int Wid, int Hei, int[] Colour, String soundFile)
  {
    super(rX, rY, Wid, Hei, Colour, soundFile);
    state = false;
  }
  
  Animated(int rX, int rY, int Wid, int Hei, int[] Colour)
  {
    super(rX, rY, Wid, Hei, Colour);
    state = false;
  }
  
  Animated()
  {
    super();
    state = false;
  }
  
  boolean detectPress(int X, int Y)//this determines if the object is being pressed - used for buttons and closing the lid
  {
    if ( mouseX > (X - (wid/2)) && mouseX < (X + (wid/2)) )
    {
      if ( mouseY > (Y - (hei/2)) && mouseY < (Y + (hei/2)) && mousePressed )
      {
        return(true);
      }
      else
      {
        return(false);
      }
    }
    else
    {
      return(false);
    }
  }
}

class Button extends Animated
{
  boolean held;
  
  Button(int rX, int rY, int Wid, int Hei, int[] Colour, String soundFile)
  {
    super(rX, rY, Wid, Hei, Colour, soundFile);
    held = false;
  }
  
  Button(int rX, int rY, int Wid, int Hei, int[] Colour)
  {
    super(rX, rY, Wid, Hei, Colour);
    held = false;
  }
  
  Button()
  {
    super();
    held = false;
  }
  
  boolean draw()
  {
    boolean switched = false;
    
    fill(colour[0], colour[1], colour[2]);
    
    if (detectPress(X, Y))
    {
      state = true;
      
      if (!held)
      {
        sound.rewind();
        sound.play();
        switched = true;
      }
      
      held = true;
    }
    else
    {
      state = false;
      held = false;
    }
    
    if (state == true)
    {
      ellipse(X, Y+(hei/8), wid, hei - (hei/4));
    }
    else
    {
      ellipse(X, Y, wid, hei);
    }
    
    return switched;
  }
}

class Light extends Animated
{
  Light(int rX, int rY, int Wid, int Hei, int[] Colour)
  {
    super(rX, rY, Wid, Hei, Colour);
  }
  
  Light()
  {
    super();
  }
  
  void draw(boolean lit)
  {
    state = lit;
    
    if (state == true)
    {
      fill(colour[0], colour[1], colour[2]);
    }
    else
    {
      fill(0, 0, 0);
    }
    
    rect(X - (wid / 2), Y - (hei / 2), wid, hei);
  }
}

class Lid extends Animated
{
  int cy;//the actual y value. It starts off the same as y.
  int cHei;//the current height. The width is constant, so it doesn't need a second value to record the current value.
  
  Lid(int X, int Y, int Wid, int Hei, int[] Colour, String soundFile)
  {
    super(X, Y, Wid, Hei, Colour, soundFile);
    cy = Y;
    cHei = hei;
  }
  
  Lid(int X, int Y, int Wid, int Hei, int[] Colour)
  {
    super(X, Y, Wid, Hei, Colour);
    cy = Y;
    cHei = hei;
  }
  
  Lid()
  {
    super();
    cy = Y;
    cHei = hei;
  }
  
  void draw()
  {
    fill(colour[0], colour[1], colour[2]);
    
    if(state == true)
    {
      if (cHei > -(wid/3.5))
      {
        
        cy--;
        cHei -= 2;
      }
    }
    else
    {
      cy = Y;
      cHei = hei;
    }
    
    ellipse(X, cy, wid, cHei);
    
    if (detectPress(X, cy))
    {
      if (state == true)
      {
        sound.rewind();
        sound.play();//if it is being closed, plays the closing sound
      }
      
      state = false;
    }
  }
}

class Spindle extends Animated
{
  float speed;//the speed it is currently spinning at
  float angle;//used in the placement of the spot on the disk
  
  Spindle(int X, int Y, int Wid, int Hei, int[] Colour)
  {
    super(X, Y, Wid, Hei, Colour);
    speed = 0;
    angle = 0;
  }
  
  Spindle()
  {
    super();
    speed = 0;
    angle = 0;
  }
  
  void draw()
  {
    if (state == true)
    {
      fill(colour[0], colour[1], colour[2]);
      ellipse(X, Y, wid*8, hei*8);
      
      Rotation();
    }
    
    fill(0, 0, 0);
    ellipse(X, Y, wid, hei);
    
    if (detectPress(X, Y))
    {
      state = true;
      speed = 0;
    }
  }
  
  void Rotation()//This method will draw a moving spot on the disk to simulate the disk spinning. It follows the path of an ellipse.
  {
    float px, py;
    float pi = 3.14;
    float halfWid = wid * 4;//the ellipse that the spot follows is smaller than the disk.
    float halfHei = hei * 4;
    
    px = X + (halfWid / 2)*cos(angle * pi);
    py = Y + (halfHei / 2)*sin(angle * pi);
    
    fill(255, 239, 0);
    
    ellipse(px, py, wid * 1.5, hei * 1.5);
    
    angle += speed;
    
    if (speed > 0.0)
    {
      speed -= 0.002;//the speed decays with every iteration. It will be reset if there is still power. Otherwise, it slows to a halt
    }
    else if (speed < 0.0)
    {
      speed = 0;//preventing the speed from becoming negative
    }
    
    if (angle >= 2 * pi)
    {
      angle -= 2 * pi;
    }
  }
}

Console console;
AudioPlayer[] sounds;
Minim audio;

//setup and draw
void setup()
{
  size(640, 480);
  background(196, 196, 196);
  frameRate(60);

  int[] colour = {196, 196, 196};
  
  audio = new Minim(this);
  
  console = new Console(50, 150, 500, 250, colour, "running.mp3");
}

void draw()
{
  background(196, 196, 196);
  console.draw();
}
