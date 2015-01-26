LifeBoard board;

void setup()
{
  size(640, 480);
  stroke(255, 255, 255);
  
  board = new LifeBoard(10, 10);
  
  board.randomise(50);
}

void draw()
{
  background(255, 255, 255);
  
  board.draw();
  board.update();
}
