package PatternExamples;

import java.util.function.Function;
import java.util.function.Predicate;

public class ConditionnalStringConvertor<Tin> {
    private Predicate<Tin> canTransform;
    private Function<Tin, Tin> transform;


    public ConditionnalStringConvertor(Predicate<Tin> canTransform, Function<Tin, Tin> transform) {
        this.canTransform = canTransform;
        this.transform = transform;
    }

    public Tin transformIfMatch(Tin s) {
        if (this.canTransform.test(s)) return this.transform.apply(s);
        return s;
    }
}
