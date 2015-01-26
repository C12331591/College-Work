class LifeBoard
{
  boolean[][] current;
  boolean[][] next;
  int cellWidth, cellHeight;
  int boardWidth, boardHeight;
  
  LifeBoard(int CellWidth, int CellHeight)
  {
    cellWidth = CellWidth;
    cellHeight = CellHeight;
    
    boardWidth = width / cellWidth;
    boardHeight = height / cellHeight;
    
    current = new boolean[boardHeight][boardWidth];
    next = new boolean[boardHeight][boardWidth];
  }
  
  void on(int x, int y)
  {
    current[y][x] = true;
  }
  
  void off(int x, int y)
  {
    current[y][x] = false;
  }
  
  boolean isOn(int x, int y)
  {
    return current[y][x];
  }
  
  void clearBoard(boolean[][] board)
  {
    for (int i = 0; i < boardHeight; i++)
    {
      for (int j = 0; j < boardWidth; j++)
      {
        current[i][j] = false;
      }
    }
  }
  
  void randomise(int percentage)
  {
    for (int i = 0; i < boardHeight; i++)
    {
      for (int j = 0; j < boardWidth; j++)
      {
        int ran = (int)random(0, 100);
        
        if (ran < percentage)
        {
          current[i][j] = true;
        }
        else
        {
          current[i][j] = false;
        }
      }
    }
  }
  
  int countLiveCellsSurrounding(int x, int y)
  {
    int count = 0;
    
    for (int i = y - 1; i < y + 2 && i < boardHeight; i++)
    {
      if (i < 0)
      {
        i++;
      }
      
      for (int j = x - 1; j < x + 2 && j < boardWidth; j++)
      { 
        if (j < 0)
        {
          j++;
        }
        
        if (current[i][j] && !(i == y && j == x))
        {
          count++;
          //stroke(0, 0, 255);
        }
        else
        {
          //stroke(0, 0, 255);
        }
      }
    }
    
    return count;
  }
  
  void update()
  {
    clearBoard(next);
    
    for (int i = 0; i < boardHeight; i++)
    {
      for (int j = 0; j < boardWidth; j++)
      {
        int sur = countLiveCellsSurrounding(j, i);
        
        if (sur < 2)
        {
          next[i][j] = false;
        }
        else if (sur > 3)
        {
          next[i][j] = false;
        }
        else if (sur == 2)
        {
          if (current[i][j])
          {
            next[i][j] = true;
          }
        }
        else
        {
          next[i][j] = true;//if it has 3 neighbours, it will be live in next no matter what
        }
      }
    }
    
    current = next;
  }
  
  void draw()
  {
    for (int i = 0; i < boardHeight; i++)
    {
      for (int j = 0; j < boardWidth; j++)
      {
        int x = cellWidth * j;
        int y = cellHeight * i;
        
        if (current[i][j])
        {
          fill(0, 0, 0);
        }
        else
        {
          fill(255, 255, 255);
        }
        
        rect(x, y, cellWidth, cellHeight);
      }
    }
  }
  
}
