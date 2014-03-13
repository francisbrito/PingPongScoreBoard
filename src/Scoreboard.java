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
            for (Rally rally : set.getRallies()) {
                if (rally != null 
                    && rally.getForTeam() == team
                    && rally.getOutcome() == RallyOutcome.Point) {
                    score++;
                }
            }
        }

        return score;
    }

    public int getRalliesCount() {
        int count = 0;

        for (Set set : this.sets) {
            if (set.getRallies() != null) {
                count += set.getRallies().length;
            }
        }

        return count;
    }

    public int getAllPoints() {
        int points = 0;

        for (Set set : this.sets) {
            for (Rally rally : set.getRallies()) {
                if (rally != null && rally.getOutcome() == RallyOutcome.Point) {
                    points++;
                }
            }
        }

        return 0;
    }
}
