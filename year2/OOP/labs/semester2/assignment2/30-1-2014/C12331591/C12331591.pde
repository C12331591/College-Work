class Object
{
  int X, Y;
  int wid;
  int hei;
  int[] colour = new int[3];
  
  //constructor
  void Object(int Wid, int Hei, int[] Colour)
  {
    wid = Wid;
    hei = Hei;
    colour = Colour;
  }
  
  void Object()
  {
    wid = 0;
    hei = 0;
    colour[0] = 0;
    colour[1] = 0;
    colour[2] = 0;
  }
}
 
class Console extends Object
{
  Lid lid = new Lid();
  
  void valuesForLid()//temporary - use constructor in final version
  {
    lid.cy = Y;
    lid.wid = int(wid/1.8);
    lid.hei = int(hei/1.5);
    lid.cHei = lid.hei;
    lid.colour = colour;
  }
  
  void draw()
  {
    fill(colour[0], colour[1], colour[2]);
    
    //calculating some measurements
    int quarterHei = hei / 4;
    int tenthWid = wid / 10;
    int frontTop = Y + hei - quarterHei;
    int topMiddle = Y + ((hei - quarterHei) / 2);
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
    
    ellipse(X + (wid/2), topMiddle, wid/1.8, hei/1.5);//tray
    ellipse(X + (quarterWid / 2), Y + (hei/1.6), quarterWid / 2, hei/7);//space for power button
    ellipse(X + wid - (quarterWid / 2), Y + (hei/1.6), quarterWid / 2, hei/7);//space for open button
    ellipse(X + (quarterWid / 2.5), Y + (hei/2.1), quarterWid / 5, hei/15);//space for reset button
    
    //a crude representation of the laser assembly
    fill(0, 0, 0);
    rect(X + (wid / 2), topMiddle, wid / 5, hei / 5);
    ellipse(X + (wid / 2), topMiddle, quarterWid / 5, hei/15);
    
    rect(X + (wid/3.2), Y + (hei/1.1), wid / 6, hei / 17);//base of controller port 1
    rect(X + (wid/1.9), Y + (hei/1.1), wid / 6, hei / 17);//base of controller port 2
    
    //testing animated elements
    Light powerLight = new Light();
    
    lid.draw(X + (wid / 2), topMiddle);
    
    int[] buttonColour = {180, 180, 180};
    //Button eject = new Button(quarterWid / 2, hei/7, buttonColour); - find out what's wrong with constructors!
    Button eject = new Button();
    eject.X = X + wid - (quarterWid / 2);
    eject.Y = Y + int((hei/1.6));
    eject.wid = quarterWid / 2;
    eject.hei = hei/7;
    eject.colour[0] = 185;
    eject.colour[1] = 185;
    eject.colour[2] = 185;
    eject.draw();
    
    if (eject.state == 1)
    {
      lid.state = 1;
    }
    
    Button power = new Button();
    power.X = X + (quarterWid / 2);
    power.Y = Y + int((hei/1.6));
    power.wid = quarterWid / 2;
    power.hei = hei/7;
    power.colour[0] = 185;
    power.colour[1] = 185;
    power.colour[2] = 185;
    power.draw();
    
    if (power.state == 1)
    {
      powerLight.state = 1;
    }
    
    powerLight.draw(500, 400, 1);//temporary placement
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

class Animated extends Object//this class serves as a base any piece which can have any kind of animation. Unlike Object, an instance of this represents just one piece, rather than a collection of pieces
{
  int state;//this will be used for progressively changing the object, or just to allow it to have two or more different positions
  
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
  void draw()
  {
    fill(colour[0], colour[1], colour[2]);
    
    boolean clicked = detectPress(X, Y);
    
    if (clicked)
    {
      state = 1;
    }
    
    if (state == 1)
    {
      ellipse(X, Y+(hei/8), wid, hei - (hei/4));
    }
    else
    {
      ellipse(X, Y, wid, hei);
    }
  }
}

class Light extends Animated
{
  void draw(int X, int Y, int size)
  {
    if (state == 1)
    {
      fill(0, 255, 0);
    }
    else
    {
      fill(0, 0, 0);
    }
    
    rect(X, Y, 10, 10);//testing
  }
}

class Lid extends Animated
{
  int cy;//the actual y value. It starts off the same as y.
  int cHei;//the current height. The width is constant, so it doesn't need a second value to record the current value.
  
  void Lid(int Y, int Wid, int Hei, int[] Colour)
  {
    cy = Y;
    wid = Wid;
    Hei = hei;
    cHei = hei;
    colour[0] = Colour[0];
    colour[1] = Colour[1];
    colour[2] = Colour[2];
    state = 0;
  }
  
  void draw(int X, int Y)
  {
    fill(colour[0], colour[1], colour[2]);
    
    if(state == 1)
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
    
    boolean clicked = detectPress(X, cy);
    
    if (clicked)
    {
      state = 0;
    }
  }
}

//the components used in the sketch
Console thing;

//setup and draw
void setup()
{
  size(640, 480);
  background(196, 196, 196);
  
  thing = new Console();
  thing.X = 50;
  thing.Y = 150;
  thing.wid = 400;
  thing.hei = 200;
  thing.colour[0] = 196;
  thing.colour[1] = 196;
  thing.colour[2] = 196;
  
  thing.valuesForLid();
}

void draw()
{
  background(196, 196, 196);
  thing.draw();
}
