package PatternExamples;
import org.junit.Assert;
import org.junit.Test;


import java.util.List;

public class PredicatePatternExample {

    @Test
    public void JeVoudraisPouvoirTransformerUneChaineSuivantDesConditions() {

        var jeVeuxFiltrer = new ConditionnalStringConvertor<String>(
                s -> s.contains("24"),
                s -> s.replace("24", "42"));
        Assert.assertEquals(jeVeuxFiltrer.transformIfMatch("24 La reponse"), "42 La reponse");

        var jeNeVeuxPasFilter = new ConditionnalStringConvertor<String>(
                s -> s.contains("24") && s.contains(("reponse")),
                s -> s.replace("24", "42"));
        Assert.assertEquals(jeNeVeuxPasFilter.transformIfMatch("2*12=24"), "2*12=24");
    }

    @Test
    public void JeVoudraisPouvoirEnchainerLesFiltres() {
        var monPremierFiltre = new ConditionnalStringConvertor<String>(s -> s.contains("é"), s -> s.replace("é", "e"));
        var monDeuxiemeFiltre = new ConditionnalStringConvertor<String>(s -> s.contains("à"), s -> s.replace("à", "a"));

        var monEnchineurDeFiltres = new ChainConditionalTransformer<String>(List.of(monPremierFiltre, monDeuxiemeFiltre));
        Assert.assertEquals(monEnchineurDeFiltres.chain("tétà"), "teta");
    }
}
