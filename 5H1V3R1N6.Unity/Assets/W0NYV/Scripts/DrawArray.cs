using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W0NYV
{
    public class DrawArray
    {
        public Vector2[] drawArray = new Vector2[] {
            new Vector2(1.4726877212524414f, -1.2451171875f), 
            new Vector2(1.3019704818725586f, -1.2451171875f), 
            new Vector2(1.1947441101074219f, -1.3583904504776f), 
            new Vector2(1.123046875f, -1.5219497680664062f), 
            new Vector2(1.1906862258911133f, -1.614990234375f), 
            new Vector2(1.3525772094726562f, -1.6050338745117188f), 
            new Vector2(1.4380455017089844f, -1.4549857378005981f), 
            new Vector2(1.51092529296875f, -1.289825439453125f), 
            new Vector2(1.0893869400024414f, -1.2451171875f), 
            new Vector2(0.9186697006225586f, -1.2451171875f), 
            new Vector2(0.8114433288574219f, -1.3583904504776f), 
            new Vector2(0.73974609375f, -1.5219497680664062f), 
            new Vector2(0.8073854446411133f, -1.614990234375f), 
            new Vector2(0.9692764282226562f, -1.6050338745117188f), 
            new Vector2(1.0547447204589844f, -1.4549857378005981f), 
            new Vector2(1.12762451171875f, -1.289825439453125f), 
            new Vector2(0.15380859375f, 0.1614668220281601f), 
            new Vector2(0.15380859375f, -0.0036813411861658096f), 
            new Vector2(0.15380859375f, -0.18590112566016614f), 
            new Vector2(0.15380859375f, -0.3531996870879084f), 
            new Vector2(0.15380859375f, -0.5341083637904376f), 
            new Vector2(0.15380859375f, -0.7010636478662491f), 
            new Vector2(0.15380859375f, -0.8828342985361814f), 
            new Vector2(0.15380859375f, -1.051902174949646f), 
            new Vector2(0.15380859375f, -1.2252406030893326f), 
            new Vector2(0.15380859375f, -1.4018696546554565f), 
            new Vector2(0.2646219730377197f, -1.47705078125f), 
            new Vector2(0.4469585418701172f, -1.47705078125f), 
            new Vector2(0.51025390625f, -1.336439847946167f), 
            new Vector2(0.51025390625f, -1.1743450164794922f), 
            new Vector2(0.5650380253791809f, -1.036362424492836f), 
            new Vector2(0.7384106516838074f, -0.9590544551610947f), 
            new Vector2(0.8886465430259705f, -0.8920633047819138f), 
            new Vector2(1.0437747836112976f, -0.8228906244039536f), 
            new Vector2(1.214752197265625f, -0.7466506958007812f), 
            new Vector2(1.361541748046875f, -0.67779541015625f), 
            new Vector2(1.396484375f, -0.5191230773925781f), 
            new Vector2(1.396484375f, -0.33722639083862305f), 
            new Vector2(1.2796968594193459f, -0.3111015260219574f), 
            new Vector2(1.1170580983161926f, -0.38338541984558105f), 
            new Vector2(0.9668222069740295f, -0.45015692710876465f), 
            new Vector2(0.8022827235981822f, -0.523285586386919f), 
            new Vector2(0.640716552734375f, -0.5950927734375f), 
            new Vector2(0.51025390625f, -0.6178808212280273f), 
            new Vector2(0.51025390625f, -0.44638472609221935f), 
            new Vector2(0.51025390625f, -0.28187520802021027f), 
            new Vector2(0.51025390625f, -0.09315013885498047f), 
            new Vector2(0.51025390625f, 0.065578892827034f), 
            new Vector2(0.469818115234375f, 0.2185821533203125f), 
            new Vector2(0.28586387634277344f, 0.2197265625f), 
            new Vector2(3.18925179541111f, 0.2197265625f), 
            new Vector2(3.0177821964025497f, 0.2197265625f), 
            new Vector2(2.846740015083924f, 0.2197265625f), 
            new Vector2(2.676416113972664f, 0.2197265625f), 
            new Vector2(2.494195526232943f, 0.2197265625f), 
            new Vector2(2.327393383020535f, 0.2197265625f), 
            new Vector2(2.15274341404438f, 0.2197265625f), 
            new Vector2(1.9852066040039062f, 0.2197265625f), 
            new Vector2(1.7968697100877762f, 0.2197265625f), 
            new Vector2(1.7041015625f, 0.11711744591593742f), 
            new Vector2(1.7041015625f, -0.05503045627847314f), 
            new Vector2(1.7041015625f, -0.22853878559544683f), 
            new Vector2(1.7041015625f, -0.4108489491045475f), 
            new Vector2(1.7041015625f, -0.5859375f), 
            new Vector2(1.7041015625f, -0.7437628484331071f), 
            new Vector2(1.7041015625f, -0.9274952113628387f), 
            new Vector2(1.7041015625f, -1.1037445068359375f), 
            new Vector2(1.7041015625f, -1.2743854522705078f), 
            new Vector2(1.7775553464889526f, -1.3916015625f), 
            new Vector2(1.960572050884366f, -1.3916015625f), 
            new Vector2(2.1227995958179235f, -1.3916015625f), 
            new Vector2(2.3109835479408503f, -1.3916015625f), 
            new Vector2(2.4774169921875f, -1.3916015625f), 
            new Vector2(2.6438504364341497f, -1.3916015625f), 
            new Vector2(2.8320343885570765f, -1.3916015625f), 
            new Vector2(2.994261933490634f, -1.3916015625f), 
            new Vector2(3.1772786378860474f, -1.3916015625f), 
            new Vector2(3.250732421875f, -1.2743854522705078f), 
            new Vector2(3.250732421875f, -1.1037445068359375f), 
            new Vector2(3.250732421875f, -0.9274952113628387f), 
            new Vector2(3.250732421875f, -0.7437628484331071f), 
            new Vector2(3.250732421875f, -0.5682864249683917f), 
            new Vector2(3.250732421875f, -0.4108489491045475f), 
            new Vector2(3.250732421875f, -0.22853878559544683f), 
            new Vector2(3.250732421875f, -0.05503045627847314f), 
            new Vector2(3.250732421875f, 0.13000056147575378f), 
            new Vector2(2.1092885732650757f, -0.13671875f), 
            new Vector2(2.275516390800476f, -0.13671875f), 
            new Vector2(2.4421579390764236f, -0.13671875f), 
            new Vector2(2.615694999694824f, -0.13671875f), 
            new Vector2(2.8045860677957535f, -0.13671875f), 
            new Vector2(2.85400390625f, -0.24688482284545898f), 
            new Vector2(2.85400390625f, -0.420989990234375f), 
            new Vector2(2.85400390625f, -0.6069877743721008f), 
            new Vector2(2.85400390625f, -0.7704547047615051f), 
            new Vector2(2.85400390625f, -0.9522438049316406f), 
            new Vector2(2.761650010943413f, -1.03515625f), 
            new Vector2(2.5990136060863733f, -1.03515625f), 
            new Vector2(2.424614606425166f, -1.03515625f), 
            new Vector2(2.2460495680570602f, -1.03515625f), 
            new Vector2(2.100830078125f, -0.996551513671875f), 
            new Vector2(2.100830078125f, -0.8267784118652344f), 
            new Vector2(2.100830078125f, -0.6489238142967224f), 
            new Vector2(2.100830078125f, -0.48150867223739624f), 
            new Vector2(2.100830078125f, -0.30994653701782227f), 
            new Vector2(3.616395741701126f, -0.797119140625f), 
            new Vector2(3.7854178971610963f, -0.797119140625f), 
            new Vector2(3.9625656604766846f, -0.797119140625f), 
            new Vector2(4.140615628566593f, -0.797119140625f), 
            new Vector2(4.314585498068482f, -0.797119140625f), 
            new Vector2(4.473622869700193f, -0.797119140625f), 
            new Vector2(4.661660504061729f, -0.797119140625f), 
            new Vector2(4.831910580396652f, -0.797119140625f), 
            new Vector2(5.004707295447588f, -0.797119140625f), 
            new Vector2(5.175628662109375f, -0.766448974609375f), 
            new Vector2(5.1806640625f, -0.5954444408416748f), 
            new Vector2(5.141143798828125f, -0.444183349609375f), 
            new Vector2(4.961562883108854f, -0.440673828125f), 
            new Vector2(4.80279790237546f, -0.440673828125f), 
            new Vector2(4.628457638900727f, -0.440673828125f), 
            new Vector2(4.456044288817793f, -0.440673828125f), 
            new Vector2(4.279307273682207f, -0.440673828125f), 
            new Vector2(4.106893923599273f, -0.440673828125f), 
            new Vector2(3.9325536601245403f, -0.440673828125f), 
            new Vector2(3.7515246868133545f, -0.440673828125f), 
            new Vector2(3.5857391357421875f, -0.4482269287109375f), 
            new Vector2(3.558349609375f, -0.618896484375f), 
            new Vector2(3.5857391357421875f, -0.7895660400390625f)
        };
    }
}
