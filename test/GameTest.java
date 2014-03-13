import org.junit.Test;
import org.junit.Before;
import static org.junit.Assert.assertEquals;

import java.lang.IllegalStateException;

public class GameTest {
    private Game game;

    @Before
    public void setUp() {
        this.game = new Game();
    }

    @Test
    public void testStateDefaultsToNotSet() {
        assertEquals("Game#state should default to GameState.NotSet"
                     , GameState.NotSet
                     , this.game.getState());
    }

    @Test
    public void testTeamsDefaultToTwo() {
        Team[] teams = this.game.getTeams();

        assertEquals("Game#teams should default to two teams."
                     , 2
                     , teams.length);
    }

    @Test(expected=IllegalStateException.class)
    public void testStartThrowsIfSetsArentSetupFirst() {
        this.game.start();
    }

    @Test
    public void testStartSetsCurrentSetToFirstSet() {
        this.game.setNumberOfSets(3);

        Set firstSet = this.game.getSets()[0];

        assertEquals("Game#start should set current set to first set."
                     , firstSet
                     , this.game.getCurrentSet());
    }

    @Test
    public void testStartSetsStateToStarted() {
        this.game.setNumberOfSets(3);
        this.game.start();
        
        GameState state = this.game.getState();

        assertEquals("Game#start should set state to started."
                     , GameState.Started
                     , state);
    }
}