class Object
{
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
  
  //there is a unique method to draw each different piece used in the sketch. Multiple pieces can be drawn using one instance of the Object class. These will be used as components of the main draw() method
  void DrawBody(int X, int Y)//this will draw the shell
  {
    //calculating some reusable measurements
    int quarterHei = hei / 4;
    int tenthWid = wid / 10;
    int frontTop = Y + hei - quarterHei;
    
    fill(colour[0], colour[1], colour[2]);
    
    line((X+tenthWid), Y, (X + wid - tenthWid), Y);
    line((X+tenthWid), Y, X, frontTop);
    line((X + wid - tenthWid), Y, (X + wid), frontTop);
    line(X, frontTop, (X + wid), frontTop);
  }
  
  void DrawDoor(int X, int Y)
  {
    
  }
  
  void DrawPort(int X, int Y)
  {
    
  }
  
  void DrawTV(int X, int Y)//draws the shape of the TV
  {
    fill(colour[0], colour[1], colour[2]);
    rect(X, Y, wid, hei);//maybe add a little more
  }
}

class Animated extends Object//this class represents any piece which can have any kind of animation. Unlike the object class, an instance of this usually corresponds to one specific piece.
{
  int state;//this will be used for progressively changing the object, or just to allow it to have two or more different positions
  
  void Update()
  {
    //need to make an update method for each animated element.
  }
  
  void DrawButton(int X, int Y, int Size)
  {
    
  }
  
  void DrawLight(int X, int Y)
  {
    
  }
  
  void DrawLid(int X, int Y)
  {
    
  }
}

//the components used in the sketch
Object thing;

//setup and draw
void setup()
{
  size(640, 480);
  thing = new Object();
  thing.wid = 100;
  thing.hei = 50;
}

void draw()
{
  thing.DrawBody(50, 50);
}
