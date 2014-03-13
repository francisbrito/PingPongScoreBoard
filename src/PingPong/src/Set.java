import java.util.ArrayList;

public class Set {
    private int number;

    private ArrayList<Rally> rallies;

    public Set(int number) {
        this.number = number;

        this.rallies = new ArrayList<Rally>();
    }

    public int getNumber() {
        return this.number;
    }

    public Rally[] getRallies() {
        // NOTE: Is this really required to convert a list to array,
        // or am I just quite dumb?
        return this.rallies.toArray(new Rally[this.rallies.size()]);
    }
}
