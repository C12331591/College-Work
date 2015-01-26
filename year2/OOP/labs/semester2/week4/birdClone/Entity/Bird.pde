int gapSize = 120;
float scrollSpeed = -60.0f;

class Bird extends GameEntity
{
  PVector gravity;
  PVector flap;
  boolean held;
  Tower[] towers;
  int score;
  
  Bird()
  {
    super();
    
    gravity = new PVector(0, 70.0f);
    flap = new PVector(0, -110.0f);
    held = false;
    
    towers = new Tower[3];
    towers[0] = new Tower();
    towers[1] = new Tower();
    towers[2] = new Tower();
    towers[0].position.x = 400;
    towers[1].position = new PVector(towers[0].position.x + 320, 0);
    towers[2].position = new PVector(towers[1].position.x + 320, 0);
    score = 0;
  }
  
  void draw()
  {
    update();
    
    pushMatrix();
    translate(position.x, position.y);
    
    fill(255, 255, 0);
    ellipse(0, 0, 50, 20);
    popMatrix();
  }
  
  void update()
  {
    if (!crashed())
    {
      for (int i = 0; i < towers.length; i++)
      {
        towers[i].draw();
      }
      
      if (mousePressed)
      {
        if (!held)
        {
          held = true;
          velocity.y = flap.y;
        }
      }
      else
      {
        held = false;
      }
      
      velocity.add(PVector.mult(gravity, timeDelta));
      position.add(PVector.mult(velocity, timeDelta));
    }
  }
  
  boolean crashed()
  {
    for (int i = 0; i < towers.length; i++)
    {
      if (position.x >= towers[i].position.x && position.x <= towers[i].position.x + gapSize)
      {
        if (position.y <= towers[i].gap || position.y >= towers[i].gap + gapSize)
        {
          return true;
        }
      }
      
      if (position.y < 0 || position.y > 480)
      {
        return true;
      }
    }
    
    return false;
  }
}

class Tower extends GameEntity
{
  int gap;
  PVector forward;
  boolean past;
  
  Tower()
  {
    super();
    
    gap = (int)random(330);
    forward = new PVector(scrollSpeed, 0);
    past = false;
  }
  
  void draw()
  {
    pushMatrix();
    translate(position.x, position.y);
    
    stroke(0, 255, 0);
    fill(0, 255, 0);
    rect(0, 0, 100, 480);
    
    fill(0, 155, 255);
    stroke(0, 155, 255);
    rect(0, gap, 100, gapSize);
    
    stroke(0, 0, 0);
    
    popMatrix();
    
    update();
  }
  
  void update()
  {
    position.add(PVector.mult(forward, timeDelta));
    
    if (position.x < -100)
    {
      position.x += 960;
      gap = (int)random(330);
      past = false;
    }
    
    if (position.x + 100 < bird.position.x && !past)
    {
      past = true;
      bird.score++;
    }
  }
}

Bird bird;

void setup()
{
  size(640, 480);
  bird = new Bird();
  bird.position = new PVector(100, 240);
}

void draw()
{
  if (bird.crashed())
  {
    background(255, 0, 0);
  }
  else
  {
    background(0, 155, 255);
  }
  
  bird.draw();
  
  fill(255, 255, 255);
  text("Score: ", 10, 10);
  text(bird.score, 50, 10);
}
