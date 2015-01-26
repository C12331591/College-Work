PVector centre;

void setup()
{
  size(640, 480);
  background(0, 0, 0);
  fill(255, 255, 255);
  stroke(255, 255, 255);
  
  centre = new PVector(320, 240);
}

void draw()
{
  background(0, 0, 0);
  
  PVector mouse = new PVector(mouseX, mouseY);
  
  float angle = angle(centre, mouse);
  
  text(angle, 320, 400);
  
  if (range(angle, 0.0f))
  {
    line(320, 240, 640, 240);
  }
  else if(range(angle, HALF_PI))
  {
    line(320, 240, 320, 480);
  }
  else if(range(angle, PI) || range(angle, -PI))
  {
    line(320, 240, 0, 240);
  }
  else if(range(angle, -HALF_PI))
  {
    line(320, 240, 320, 0);
  }
}

float angle(PVector start, PVector end)
{
  return atan2(end.y - start.y, end.x - start.x);
}

boolean range(float angle, float middle)
{
  return ((angle >= (middle - (PI / 4))) && (angle <= (middle + (PI / 4))));
}
