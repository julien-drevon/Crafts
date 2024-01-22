package PatternExamples;

import java.util.List;


public class ChainConditionalTransformer<T> {
    private List<ConditionnalStringConvertor<T>> filters;

    public ChainConditionalTransformer(List<ConditionnalStringConvertor<T>> filters) {
        this.filters = filters;
    }

    public T chain(T val) {
        var ret = val;
        for (var filter : this.filters) {
            ret = filter.transformIfMatch(ret);
        }
        return ret;
    }
}
