using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LifeManager{
    private static  int lives;

	static void setLives(int life)
    {
        lives = life;
    }

    static int getLives()
    {
        return lives;
    }
}
