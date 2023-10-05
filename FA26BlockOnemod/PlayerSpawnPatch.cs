using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Harmony;


namespace FA26BLOCKI
{
    [HarmonyPatch(typeof(Actor), "Start")]
    internal class PlayerSpawnPatch
    {
        public static void Postfix(Actor __instance, Main main)
        {
           

            bool flag = VTOLAPI.GetPlayersVehicleEnum() != VTOLVehicles.FA26B || !__instance.isPlayer || __instance.gameObject.GetComponentInChildren<Radar>().radarSymbol == "custom";
            if (!flag)
            {
                Main.isfa26 = true;
                GameObject gameObject = __instance.gameObject;
                foreach (VRInteractable inter in gameObject.GetComponentsInChildren<VRInteractable>(true))
                {
                    inter.poseBounds = null;
                }
                // MFDManager componentInChildren = GetChildWithName(__instance.gameObject, "MFD2").GetComponentInChildren<MFDManager>(true);
                //componentInChildren.gameObject.SetActive(false);
                //GameObject gameObject2 = componentInChildren.mfds[1].gameObject
                //;
                //Right MFD
                GameObject rightmfd = Main.GetChildWithName(__instance.gameObject, "MFD2");
                rightmfd.transform.localPosition = new Vector3(309f, -41, 342);
                //GameObject rightposbeound = Main.GetChildWithName(__instance.gameObject, "RightDashPoseBounds");
                //rightposbeound.GetComponent<PoseBounds>().size = new Vector3(0.26f, 0.37f, 0.4f);
                //rightposbeound.transform.localPosition = new Vector3(0.22f, 1f, 6f);

                //Targeting Page IFF gettin rid of things
                GameObject IFFFriend = Main.GetChildWithName(__instance.gameObject, "IFF-Friend");
                GameObject IFFFoe = Main.GetChildWithName(__instance.gameObject, "IFF-Foe");
                IFFFriend.transform.localScale = new Vector3(0, 0, 0);
                IFFFoe.transform.localScale = new Vector3(0, 0, 0);
                //moving the whole lot of things
                //3 gauges
                GameObject RPM1 = Main.GetChildWithName(__instance.gameObject, "RPMGauge");
                RPM1.transform.localPosition = new Vector3(-237, 342, 34);
                GameObject RPM2 = Main.GetChildWithName(__instance.gameObject, "RPMGauge2");
                RPM2.transform.localPosition = new Vector3(-159, 342, 34);
                GameObject APUgauge = Main.GetChildWithName(__instance.gameObject, "APUGauge");
                APUgauge.transform.localPosition = new Vector3(-79, 351.299988f, 33.5999985f);
                APUgauge.transform.localRotation = new Quaternion((float)-0.0133133307, 0, 0, (float)0.999911368);
                //panel from the back
                GameObject rightDash = Main.GetChildWithName(__instance.gameObject, "RightDash");
                GameObject paneltop = Main.GetChildWithName(rightDash, "panelEnd (4)");
                paneltop.transform.localPosition = new Vector3(-136, 531, -411);
                paneltop.transform.localRotation = new Quaternion(0, (float)-0.965925872, (float)-0.258818984, 0);
                paneltop.transform.localScale = new Vector3(2089, 1355, 2507);
                GameObject panelbottom = Main.GetChildWithName(paneltop, "panelEnd (1)");
                panelbottom.transform.localPosition = new Vector3(0, 0, -0.0342999995f);
                GameObject panelmid = Main.GetChildWithName(paneltop, "panelMidsection");
                panelmid.transform.localScale = new Vector3(0, 0, 0);
                //little engine warnings
                GameObject engineindicatorleft = Main.GetChildWithName(__instance.gameObject, "EWIndicator_Left");
                engineindicatorleft.transform.localPosition = new Vector3(-304, 401, 40);
                GameObject engineindicatorright = Main.GetChildWithName(__instance.gameObject, "EWIndicator_Right");
                engineindicatorright.transform.localPosition = new Vector3(-307.5f, 404, 40);
                //engine labels and all
                GameObject Elabel1 = Main.GetChildWithName(__instance.gameObject, "engine1Label");
                Elabel1.transform.localPosition = new Vector3(-301.700012f, 314.100006f, 47.7000008f);
                GameObject Elabel2 = Main.GetChildWithName(__instance.gameObject, "engine2Label");
                Elabel2.transform.localPosition = new Vector3(-305.600006f, 314.600006f, 47.7000008f);
                GameObject APUlabel = Main.GetChildWithName(__instance.gameObject, "apuLabel");
                APUlabel.transform.localPosition = new Vector3(-311.5f, 316.600006f, 48.2999992f);
                APUlabel.transform.localRotation = new Quaternion(0.0133132897f, 0, 0, -0.999911368f);

                //Jettison console
                GameObject jettisonconsole = Main.GetChildWithName(__instance.gameObject, "CenterConsole");
                jettisonconsole.transform.localPosition = new Vector3(262, -728, -350);
                jettisonconsole.transform.localRotation = new Quaternion((float)0.182235554, 0, 0, (float)0.98325491);
                //GameObject jettisonbounds = Main.GetChildWithName(__instance.gameObject, "CenterDashPoseBounds");
                //jettisonbounds.transform.localPosition = new Vector3(0.19f, 0.91f, 5.81f);
                //jettisonbounds.GetComponent<PoseBounds>().size = new Vector3(0.7f, 0.1f, 0.34f);

                /*  fuckery with VRinteractables' posebounds
                GameObject radarpower = Main.GetChildWithName(__instance.gameObject, "RadarPowerInteractable");
                GameObject rwrmode = Main.GetChildWithName(__instance.gameObject, "RWRModeInteractable");
                GameObject miniMFDright = Main.GetChildWithName(__instance.gameObject, "MiniMFDRight");
                GameObject ALT = Main.GetChildWithName(__instance.gameObject, "APAltKnobInteractable");
                radarpower.GetComponent<VRInteractable>().poseBounds = null;
                rwrmode.GetComponent<VRInteractable>().poseBounds = null;
                ALT.GetComponent<VRInteractable>().poseBounds = null;
               */

                GameObject speedgauge = Main.GetChildWithName(__instance.gameObject, "SpeedGauge");
                speedgauge.transform.localPosition = new Vector3(196, -53, 60);

                GameObject altGauge = Main.GetChildWithName(__instance.gameObject, "AltitudeGauge");
                altGauge.transform.localPosition = new Vector3(196, 64, 55);

                GameObject masterArmswitch = Main.GetChildWithName(__instance.gameObject, "MasterArmSwitch");
                masterArmswitch.transform.localPosition = new Vector3(-86, 86, 31);

                GameObject counter = Main.GetChildWithName(__instance.gameObject, "Countermeasures");
                counter.transform.localPosition = new Vector3(923, 310, -417);
                counter.transform.localRotation = new Quaternion((float)-0.515038073, 0, 0, (float)0.857167363);
                //GameObject masterarmposebounds = Main.GetChildWithName(__instance.gameObject, "MasterArmPoseBounds");
                //  masterarmposebounds.transform.localPosition = new Vector3(0.0434999987f, 1.09350002f, 5.87039995f);

                //GameObject fuelport = GetChildWithName(__instance.gameObject, "FuelPortSwitch");
                //fuelport.transform.localPosition = new Vector3(1202, 323, -380);
                //fuelport.transform.localRotation = new Quaternion((float)-0.515038073, 0, 0, (float)0.857167363);

                GameObject radio = Main.GetChildWithName(__instance.gameObject, "RadioDash");
                radio.transform.localPosition = new Vector3(1187, 237, -248);
                radio.transform.localRotation = new Quaternion((float)-0.515038073, 0, 0, (float)0.857167363);
                GameObject radioaudio = Main.GetChildWithName(radio, "radioAudio");
                radioaudio.transform.localPosition = new Vector3(-324, 161, -111);

            }
            


        }
    }

}
