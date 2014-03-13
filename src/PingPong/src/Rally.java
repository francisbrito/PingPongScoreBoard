public class Rally {
    private RallyOutcome outcome;

    private Team forTeam;

    public Rally() {
        this.outcome = RallyOutcome.NotSet;
    }

    public RallyOutcome getOutcome() {
        return this.outcome;
    }

    public Team getForTeam() {
        return this.forTeam;
    }

    public void markAsLet() {
        this.outcome = RallyOutcome.Let;
    }

    public void markAsPointFor(Team team) {
        this.outcome = RallyOutcome.Point;

        this.forTeam = team;
    }
}
