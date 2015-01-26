class Building
{
  int hei;
  
  Building(int Hei)
  {
    hei = Hei;
  }
  
  Building()
  {
    hei = 0;
  }
  
  void draw(int x, int y)
  {
    fill(196, 196, 196);
    rect(x, y, hei / 10, hei);
  }
}

class Coin
{
  float x, y;
  float vel, accel, timeDelta;
  
  Coin(float X, float Y)
  {
    x = X;
    y = Y;
    vel = 0.0f;
    accel = 9.8f;
    timeDelta = 1.0f / 60.0f;
  }
  
  void draw()
  {
    fill(82, 38, 19);
    ellipse(x, y, 3, 3);
    update();
  }
  
  void update()
  {
    vel += accel * timeDelta;
    y += vel * timeDelta;
    
    if (y >= 525)
    {
      vel -= vel / 5;
      vel = -vel;
    }
  }
}

Building empire;
Coin coin;

void setup()
{
  size(800, 600);
  background(0, 200, 255);
  empire = new Building(381);
  coin = new Coin(400, 525 - empire.hei);
}

void draw()
{
  background(0, 200, 255);
  fill(0, 255, 0);//green
  rect(0, 500, 800, 100);
  empire.draw(300, 525 - empire.hei);
  coin.draw();
}
