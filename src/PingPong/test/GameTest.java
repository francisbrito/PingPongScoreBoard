package test;

import static org.junit.Assert.assertEquals;

import org.junit.Test;

public class GameTest {
    @Test
    public void testGameStateDefaultsToNotSet() {
        Game game = new Game();

        assertEquals("Game.state should default to GameState.NotSet",
                     GameState.NotSet, game.getState());
    }
}