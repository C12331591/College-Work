/*PS1 tribute sketch
Brian Willis - C12331591
Finished 2/2/2014
*/

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
    
    drawPort(X + (wid/3.2), Y + (hei/1.1), wid / 6, hei / 17);//controller port 1
    drawPort(X + (wid/1.9), Y + (hei/1.1), wid / 6, hei / 17);//controller port 2
    
    lid.draw();
    
    if (eject.draw())//Button.draw returns a positive boolean value if it was just pressed in the current iteration.
    {
      lid.state = true;
    }
    
    if (power.draw())
    {
      on = !on;
      
      if (on && !lid.state && spindle.state)
      {
        console.sound.rewind();
        console.sound.play();
      }
    }
    
    if (reset.draw())
    {
      tv.reset();
    }
    
    powerLight.draw(on);
    
    if (on)
    {
      if (lid.state == false)
      {
        spindle.speed = 1.14;//makes the disk spin - odd value so the spinning doesn't look too uniform
      }
      else
      {
        console.sound.rewind();//stops the sound of the system running if the lid has been opened
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

class Animated extends Object//this class serves as a base for any piece which can have any kind of animation.
{
  boolean state;//this allows the object to have two different states
  boolean held;//used to indicate whether the user was clicking on the object in the previous iteration
  
  Animated(int rX, int rY, int Wid, int Hei, int[] Colour, String soundFile)
  {
    super(rX, rY, Wid, Hei, Colour, soundFile);
    state = false;
    held = false;
  }
  
  Animated(int rX, int rY, int Wid, int Hei, int[] Colour)
  {
    super(rX, rY, Wid, Hei, Colour);
    state = false;
    held = false;
  }
  
  Animated()
  {
    super();
    state = false;
    held = false;
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
  Button(int rX, int rY, int Wid, int Hei, int[] Colour, String soundFile)
  {
    super(rX, rY, Wid, Hei, Colour, soundFile);
  }
  
  Button(int rX, int rY, int Wid, int Hei, int[] Colour)
  {
    super(rX, rY, Wid, Hei, Colour);
  }
  
  Button()
  {
    super();
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
        
        cy -= (Y / 75);
        cHei -= (Y / 75) * 2;
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
    speed = 0.0f;
    angle = 0.0f;
  }
  
  Spindle()
  {
    super();
    speed = 0.0f;
    angle = 0.0f;
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
      if (!held && console.lid.state)
      {
        state = !state;
        speed = 0;
      }
      
      held = true;
    }
    else
    {
      held = false;
    }
  }
  
  void Rotation()//This method will draw a moving spot on the disk to simulate the disk spinning. It follows the path of an ellipse.
  {
    float px, py;
    float pi = 3.14f;
    float halfWid = float(wid) * 4;//the ellipse that the spot follows is smaller than the disk.
    float halfHei = float(hei) * 4;
    
    //formula for a point on an ellipse
    px = X + (halfWid / 2)*cos(angle * pi);
    py = Y + (halfHei / 2)*sin(angle * pi);
    
    fill(255, 239, 0);
    
    ellipse(px, py, wid * 1.5, hei * 1.5);
    
    angle += speed;
    
    if (speed > 0.0f)
    {
      speed -= 0.002;//the speed decays with every iteration. It will be reset if there is still power. Otherwise, it slows to a halt
    }
    else if (speed < 0.0f)
    {
      speed = 0.0f;//preventing the speed from becoming negative
    }
  }
}

class TV extends Animated
{
  long sequence;
  int screenX, screenY, screenWid, screenHei;
  AudioPlayer full, first;
  float logoProgress;
  PFont psFont;
  
  TV (int X, int Y, int Wid, int Hei, int[] Colour)
  {
    super(X, Y, Wid, Hei, Colour);
    sequence = 0;
    logoProgress = 0;
    screenX = X + (wid / 20);
    screenY = Y + (hei / 20);
    screenWid = wid - (wid / 10);
    screenHei = hei - (hei / 10);
    full = audio.loadFile("startclosed.mp3", 1024);
    first = audio.loadFile("startopen.mp3", 1024);
    psFont = createFont("Typodermic-ZrnicRg-Regular.otf", 32);
  }
  
  TV()
  {
    super();
    sequence = 0;
    logoProgress = 0;
    screenX = X + (wid / 20);
    screenY = Y + (hei / 20);
    screenWid = wid - (wid / 10);
    screenHei = hei - (hei / 10);
    full = audio.loadFile("startclosed.mp3", 1024);
    first = audio.loadFile("startopen.mp3", 1024);
    psFont = createFont("Typodermic-ZrnicRg-Regular.otf", 32);
  }
  
  void draw()
  {
    //drawing the TV
    stroke(colour[0], colour[1], colour[2]);
    fill(colour[0], colour[1], colour[2]);
    rect(X, Y, wid, hei);
    
    int sce = 200;//point at which the first logo appears
    int ps = 800;//point at which the second logo appears
    
    if (!console.lid.state && console.spindle.state)
    {
      state = true;
    }
    else
    {
      state = false;
    }
    
    //drawing the screen
    if (sequence < sce)
    {
      stroke(77, 77, 77);
      fill(77, 77, 77);
      rect(screenX, screenY, screenWid, screenHei);
      
      //these need to be here to prevent a sound bug when reset is pressed
      full.rewind();
      first.rewind();
    }
    else
    {
      if ((sequence > ps) && state)
      {
        stroke(0, 0, 0);
        fill(0, 0, 0);
        rect(screenX, screenY, screenWid, screenHei);
        
        if (sequence > ps + 30)//adding a small delay before the logo appears
        {
          drawPS(screenX, screenY, screenWid);
        }
      }
      else
      {
        if (sequence == sce)
        {
          if (state)
          {
            full.rewind();
            full.play();
          }
          else
          {
            first.rewind();
            first.play();
          }
          
          logoProgress = 0;
        }
        
        if (sequence > sce + 50)//adding a small delay between the sound starting and the logo appearing
        {
          stroke(255, 255, 255);
          fill(255, 255, 255);
          rect(screenX, screenY, screenWid, screenHei);
          
          stroke(255, 155, 0);
          fill(255, 155, 0);
          
          triangle(X + (wid / 2), Y + (hei/6), X + (wid / 2), Y + hei - (hei/6), X + (wid / 4), Y + (hei / 2));
          triangle(X + (wid / 2), Y + (hei/6), X + (wid / 2), Y + hei - (hei/6), X + wid - (wid / 4), Y + (hei / 2));
          
          stroke(255, 100, 0);
          fill(255, 100, 0);
          
          triangle(X + (wid / 2), Y + (hei / 4), X + (wid / 2), Y + (hei / 2), X + (wid / 2) - logoProgress, Y + (((hei / 2) + (hei / 4)) / 2));
          triangle(X + (wid / 2), Y + (hei / 2), X + (wid / 2), Y + hei - (hei / 4), X + (wid / 2) + logoProgress, Y + hei - (((hei / 2) + (hei / 4)) / 2));
          
          if (logoProgress < wid / 11)
          {
            logoProgress += float(wid) / 500;
          }
        }
        else
        {
          stroke(255, 255, 255);
          fill(255, 255, 255);
          rect(screenX, screenY, screenWid, screenHei);
        }
      }
    }
    
    if (console.on)
    {
      sequence++;
    }
    else
    {
      sequence = 0;
      full.rewind();
      first.rewind();
    }
    
    stroke(0, 0, 0);
  }
  
  void reset()
  {
    sequence = 0;
    logoProgress = 0;
    full.rewind();
    first.rewind();
    console.sound.rewind();
  }
  
  void drawPS(int X, int Y, int Wid)
  {
    pushMatrix();
    
    //translating and scaling
    translate(X, Y);
    float size = float(Wid) / 320.0f;
    scale(size);
    
    stroke(0, 0, 0);
    fill(0, 0, 0);
    rect(0, 0, 320, 240);
    
    //yellow parts
    stroke(255, 204, 0);
    fill(255, 204, 0);
    triangle(160, 165, 160, 140, 180, 155);
    ellipse(115, 140, 70, 20);
    triangle(90, 130, 84, 135, 97, 133);
    
    //blue parts
    stroke(62, 111, 201);
    fill(62, 111, 201);
    triangle(135, 105, 135, 115, 125, 110);
    ellipse(190, 120, 70, 20);
    triangle(220, 130, 225, 120, 200, 130);
    
    //green parts
    stroke(0, 201, 118);
    fill(0, 201, 118);
    triangle(125, 110, 180, 155, 220, 130);
    triangle(125, 110, 180, 155, 90, 130);
    
    // the P
    stroke(255, 0, 0);
    fill(255, 0, 0);
    ellipse(175, 75, 40, 60);
    rect(135, 45, 40, 20);
    rect(135, 45, 25, 110);
    triangle(135, 45, 177, 45, 135, 35);
    triangle(135, 155, 160, 150, 160, 165);
    
    //black parts to create gaps
    stroke(0, 0, 0);
    fill(0, 0, 0);
    rect(161, 60, 8, 50);
    ellipse(165, 60, 8, 8);
    triangle(161, 150, 161, 140, 205, 120);
    triangle(161, 140, 205, 120, 190, 120);
    ellipse(197, 120, 15, 4);
    triangle(134, 130, 134, 120, 115, 140);
    triangle(133, 120, 115, 140, 100, 140);
    ellipse(108, 140, 15, 4);
    
    //text
    fill(255, 255, 255);
    textFont(psFont);
    textAlign(CENTER, CENTER);
    text("PlayStation", 155, 185);
    
    popMatrix();
  }
}

Console console;
TV tv;
Minim audio;

//setup and draw
void setup()
{
  int[] consoleColour = {196, 196, 196};
  int[] tvColour = {0, 0, 0};
  
  size(640, 480);
  background(consoleColour[0], consoleColour[1], consoleColour[2]);//sadly, the background needs to be the same colour as the console.
  frameRate(60);
  
  audio = new Minim(this);
  
  console = new Console(95, 175, 450, 225, consoleColour, "running.mp3");
  tv = new TV(240, 10, 160, 120, tvColour);
}

void draw()
{
  background(console.colour[0], console.colour[1], console.colour[2]);
  tv.draw();
  console.draw();
}
