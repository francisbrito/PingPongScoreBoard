public class Scoreboard {
    private Set[] sets;

    public Scoreboard(Set[] sets) {
        if (sets == null) {
            throw new IllegalArgumentException();
        }

        this.sets = sets;
    }

    public int getPointsBy(Team team) {
        int score = 0;

        for (Set set : this.sets) {
            for (Rally rally : set.rallies) {
                if (rally != null 
                    && rally.forTeam == team 
                    && rally.outcome = RallyOutcome.Point) {
                    score++;
                }
            }
        }

        return score;
    }

    public int getRalliesCount() {
        int count = 0;

        for (Set set : this.sets) {
            if (set.rallies != null) {
                set.rallies.length;
            }
        }

        return count;
    }

    public int getAllPoints() {
        int points = 0;

        for (Set set : this.sets) {
            for (Rally rally : set.rallies) {
                if (rally != null && rally.outcome == RallyOutcome.Point) {
                    points++;
                }
            }
        }

        return 0;
    }
}
