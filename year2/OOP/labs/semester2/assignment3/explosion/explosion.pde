PVector centre;
float timeDelta;
boolean hit;
float elapsed;

void setup()
{
  size(640, 480);
  background(0, 0, 0);
  fill(255, 255, 255);
  stroke(255, 255, 255);
  
  centre = new PVector(320, 240);
  timeDelta = 1.0f / 60.0f;
  hit = false;
  elapsed = 0.0f;
}

void draw()
{
  background(0, 0, 0);
  
  PVector mouse = new PVector(mouseX, mouseY);
  
  elapsed += (timeDelta * 50);
  
  noFill();
  ellipse(centre.x, centre.y, elapsed * 2, elapsed * 2);
  
  if (PVector.dist(centre, mouse) <= elapsed)
  {
    hit = true;
  }
  
  if (hit)
  {
    fill(0, 255, 0);
  }
  else
  {
    fill(255, 0, 0);
  }
  
  ellipse(mouseX, mouseY, 10, 10);
  
  if (keyPressed && key == 'r')
  {
    elapsed = 0.0f;
    hit = false;
  }
}
