package PatternExamples;

import java.util.List;
import java.util.stream.Collectors;


public class ChainConditionalTransformer<T> {
    private List<ConditionnalStringConvertor<T>> filters;

    public ChainConditionalTransformer(List<ConditionnalStringConvertor<T>> filters) {
        this.filters = filters;
    }

    public T chain(T valToTransform) {
        T ret = valToTransform;
        for (var filter : this.filters) {
            ret = filter.transformIfMatch(ret);
        }
        return ret;
    }
}
