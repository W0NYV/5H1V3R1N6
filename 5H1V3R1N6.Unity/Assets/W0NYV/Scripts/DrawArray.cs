using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W0NYV
{
    public class DrawArray
    {
        public Vector2[] drawArray = new Vector2[] {
            // new Vector2(4.731569290161133f, -3.984375f), 
            // new Vector2(4.1798388957977295f, -3.984375f), 
            // new Vector2(3.81552791595459f, -4.364308387041092f), 
            // new Vector2(3.59375f, -4.8702392578125f), 
            // new Vector2(3.8101959228515625f, -5.16796875f), 
            // new Vector2(4.353218078613281f, -5.118186950683594f), 
            // new Vector2(4.619163513183594f, -4.616219758987427f), 
            // new Vector2(4.83984375f, -4.103515625f), 
            // new Vector2(3.505006790161133f, -3.984375f), 
            // new Vector2(2.9532763957977295f, -3.984375f), 
            // new Vector2(2.58896541595459f, -4.364308387041092f), 
            // new Vector2(2.3671875f, -4.8702392578125f), 
            // new Vector2(2.5836334228515625f, -5.16796875f), 
            // new Vector2(3.1266555786132812f, -5.118186950683594f), 
            // new Vector2(3.3926010131835938f, -4.616219758987427f), 
            // new Vector2(3.61328125f, -4.103515625f), 
            // new Vector2(0.4921875f, 0.5275722444057465f), 
            // new Vector2(0.4921875f, -0.031167749781161547f), 
            // new Vector2(0.4921875f, -0.5948836021125317f), 
            // new Vector2(0.4921875f, -1.1583913709037006f), 
            // new Vector2(0.4921875f, -1.7091467641294003f), 
            // new Vector2(0.4921875f, -2.273004161659628f), 
            // new Vector2(0.4921875f, -2.839211496815551f), 
            // new Vector2(0.4921875f, -3.391549973282963f), 
            // new Vector2(0.4921875f, -3.9608913399279118f), 
            // new Vector2(0.4921875f, -4.528412580490112f), 
            // new Vector2(0.9325867295265198f, -4.7265625f), 
            // new Vector2(1.483856201171875f, -4.725555419921875f), 
            // new Vector2(1.6328125f, -4.229153156280518f), 
            // new Vector2(1.6328125f, -3.6608924865722656f), 
            // new Vector2(1.8987702876329422f, -3.2759389616549015f), 
            // new Vector2(2.4056294541805983f, -3.049927198793739f), 
            // new Vector2(2.921792047098279f, -2.8197669782675803f), 
            // new Vector2(3.4298156946897507f, -2.5932359658181667f), 
            // new Vector2(3.9553865045309067f, -2.3588805608451366f), 
            // new Vector2(4.431358337402344f, -2.088104248046875f), 
            // new Vector2(4.46875f, -1.5265512466430664f), 
            // new Vector2(4.4677734375f, -0.969696044921875f), 
            // new Vector2(3.987696075811982f, -1.0432288274168968f), 
            // new Vector2(3.473935702815652f, -1.2715667709708214f), 
            // new Vector2(2.96875f, -1.49609375f), 
            // new Vector2(2.448981210589409f, -1.7271021008491516f), 
            // new Vector2(1.939310535788536f, -1.9536224007606506f), 
            // new Vector2(1.6328125f, -1.8479557037353516f), 
            // new Vector2(1.6328125f, -1.289187017828226f), 
            // new Vector2(1.6328125f, -0.7332313978113234f), 
            // new Vector2(1.6328125f, -0.17115502385422587f), 
            // new Vector2(1.6328125f, 0.39032861590385437f), 
            // new Vector2(1.3096919059753418f, 0.703125f), 
            // new Vector2(0.758826732635498f, 0.703125f), 
            // new Vector2(10.215428978204727f, 0.703125f), 
            // new Vector2(9.65690302848816f, 0.703125f), 
            // new Vector2(9.086112785618752f, 0.703125f), 
            // new Vector2(8.538588813040406f, 0.703125f), 
            // new Vector2(7.981425683945417f, 0.703125f), 
            // new Vector2(7.408251665707212f, 0.703125f), 
            // new Vector2(6.84059352055192f, 0.703125f), 
            // new Vector2(6.293212111573666f, 0.703125f), 
            // new Vector2(5.716248482465744f, 0.703125f), 
            // new Vector2(5.453125f, 0.328033447265625f), 
            // new Vector2(5.453125f, -0.218017578125f), 
            // new Vector2(5.453125f, -0.782015323638916f), 
            // new Vector2(5.453125f, -1.342305007390678f), 
            // new Vector2(5.453125f, -1.903243443928659f), 
            // new Vector2(5.453125f, -2.4765355499694124f), 
            // new Vector2(5.453125f, -3.0438060062006116f), 
            // new Vector2(5.453125f, -3.594522994942963f), 
            // new Vector2(5.453125f, -4.166001796722412f), 
            // new Vector2(5.789171129465103f, -4.453125f), 
            // new Vector2(6.3526611328125f, -4.453125f), 
            // new Vector2(6.913069905247539f, -4.453125f), 
            // new Vector2(7.47400468820706f, -4.453125f), 
            // new Vector2(8.048499877739232f, -4.453125f), 
            // new Vector2(8.616177823394537f, -4.453125f), 
            // new Vector2(9.17901618545875f, -4.453125f), 
            // new Vector2(9.728392392396927f, -4.453125f), 
            // new Vector2(10.290924072265625f, -4.435577392578125f), 
            // new Vector2(10.40234375f, -3.9228493673726916f), 
            // new Vector2(10.40234375f, -3.3557515144348145f), 
            // new Vector2(10.40234375f, -2.799571340554394f), 
            // new Vector2(10.40234375f, -2.24090978782624f), 
            // new Vector2(10.40234375f, -1.677488966844976f), 
            // new Vector2(10.40234375f, -1.123721863143146f), 
            // new Vector2(10.40234375f, -0.5586472684517503f), 
            // new Vector2(10.40234375f, 0.0008810358121991158f), 
            // new Vector2(10.3983154296875f, 0.5721435546875f), 
            // new Vector2(6.729570150375366f, -0.4375f), 
            // new Vector2(7.281652450561523f, -0.4375f), 
            // new Vector2(7.84306437894702f, -0.4375f), 
            // new Vector2(8.409686154220253f, -0.4375f), 
            // new Vector2(8.974675416946411f, -0.4375f), 
            // new Vector2(9.1328125f, -0.8372564315795898f), 
            // new Vector2(9.1328125f, -1.3948333710432053f), 
            // new Vector2(9.1328125f, -1.9591856747865677f), 
            // new Vector2(9.1328125f, -2.5268936157226562f), 
            // new Vector2(9.1328125f, -3.0869035720825195f), 
            // new Vector2(8.797690600156784f, -3.3125f), 
            // new Vector2(8.235359270125628f, -3.3125f), 
            // new Vector2(7.675213817507029f, -3.3125f), 
            // new Vector2(7.12064453586936f, -3.3125f), 
            // new Vector2(6.72265625f, -3.1412655115127563f), 
            // new Vector2(6.72265625f, -2.5870161056518555f), 
            // new Vector2(6.72265625f, -2.0095901489257812f), 
            // new Vector2(6.72265625f, -1.459212526679039f), 
            // new Vector2(6.72265625f, -0.88671875f), 
            // new Vector2(11.562098801136017f, -2.55078125f), 
            // new Vector2(12.113337270915508f, -2.55078125f), 
            // new Vector2(12.68021011352539f, -2.55078125f), 
            // new Vector2(13.249970011413097f, -2.55078125f), 
            // new Vector2(13.806673593819141f, -2.55078125f), 
            // new Vector2(14.371678613126278f, -2.55078125f), 
            // new Vector2(14.930466994759627f, -2.55078125f), 
            // new Vector2(15.48492839653045f, -2.55078125f), 
            // new Vector2(16.04674255102873f, -2.55078125f), 
            // new Vector2(16.569061279296875f, -2.4367370605468746f), 
            // new Vector2(16.578125f, -1.868635654449463f), 
            // new Vector2(16.408355712890625f, -1.410858154296875f), 
            // new Vector2(15.839787729084492f, -1.41015625f), 
            // new Vector2(15.27291488647461f, -1.41015625f), 
            // new Vector2(14.716726901126094f, -1.41015625f), 
            // new Vector2(14.160585395176895f, -1.41015625f), 
            // new Vector2(13.595450665918179f, -1.41015625f), 
            // new Vector2(13.035811387002468f, -1.41015625f), 
            // new Vector2(12.46819660346955f, -1.41015625f), 
            // new Vector2(11.906382448971272f, -1.41015625f), 
            // new Vector2(11.39495849609375f, -1.5220947265625f), 
            // new Vector2(11.38671875f, -2.092301845550537f), 
            // new Vector2(11.54486083984375f, -2.55010986328125f)
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
