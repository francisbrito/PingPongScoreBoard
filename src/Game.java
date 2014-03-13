/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author Kevin
 */

import java.lang.IllegalArgumentException;
import java.lang.IllegalStateException;
import java.lang.RuntimeException;

public class Game {
    private GameState state;
    private int currentSet;
    
    private Set[] sets;

    private Team[] teams;

    private Scoreboard scoreboard;

    public Game()
    {
        this.state = GameState.NotSet;
        this.teams = new Team[2];
    }
    
    public void start()
    {
        // One should setup sets before starting game.
        if (sets == null) {
            throw new IllegalStateException();
        }

        this.currentSet = 0;
        this.state = GameState.Started;
    }
    
    public GameState getState()
    {
        return state;
    }
    public Set getCurrentSet()
    {
        if (this.state == GameState.NotSet) {
            throw new IllegalStateException();
        }

        return this.sets[this.currentSet];
    }
    
    public Set[] getSets()
    {
        return this.sets;
    }
    public void setNumberOfSets(int sets)
    {
        if (sets <= 0) {
            throw new IllegalArgumentException();
        }

        this.sets = new Set[sets];
    }
    public void goToSet(int number)
    {
        if (this.state == GameState.NotSet) {
            throw new IllegalStateException();
        }

        for (Set set : this.sets) {
            if (set.getNumber() == number) {
                this.currentSet = number;

                return;
            }
        }

        throw new RuntimeException("No such set found.");
    }
    public void goToPastSet()
    {
        if (sets == null) {
            throw new IllegalStateException();
        }

        if (this.currentSet == 0) {
            throw new ArrayIndexOutOfBoundsException("Operation results in out of bounds accessas.");
        }


        this.currentSet --;
    }
    public void goToNextSet()
    {
        if (sets == null) {
            throw new IllegalStateException();
        }

        if (this.currentSet == this.sets.length - 1) {
            throw new ArrayIndexOutOfBoundsException("Operation results in out of bounds access.");
        }
    }
    public void goToFirstSet()
    {
        this.currentSet = 0;
    }
    public void goToLastSet()
    {
        this.currentSet = this.sets.length - 1;
    }
    public Team[] getTeams()
    {
        return this.teams;
    }
    public void finish()
    {
        this.state = GameState.Finished;
    }
}
