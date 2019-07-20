using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JVCCamcoder {
	public class JVCCamcoderStatus : MonoBehaviour {

		public Dictionary<string, dynamic> CameraDictionary;
		public Dictionary<string, dynamic> FullAutoDictionary;
		public Dictionary<string, dynamic> IrisDictionary;
		public Dictionary<string, dynamic> GainDictionary;
		public Dictionary<string, dynamic> AeLevelDictionary;
		public Dictionary<string, dynamic> ShutterDictionary;
		public Dictionary<string, dynamic> WhbDictionary;
		public Dictionary<string, dynamic> ZoomDictionary;
		public Dictionary<string, dynamic> FocusDictionary;
		public Dictionary<string, dynamic> MasterBlackDictionary;
		public Dictionary<string, dynamic> DetailDictionary;
		public Dictionary<string, dynamic> StreamingDictionary;
		public Dictionary<string, dynamic> DispTvDictionary;
		public Dictionary<string, dynamic> CharacterMixDictionary;
		public Dictionary<string, dynamic> TallyLampDictionary;
		public Dictionary<string, dynamic> SlotADictionary;
		public Dictionary<string, dynamic> SlotBDictionary;
		public Dictionary<string, dynamic> BatteryDictionary;
		public Dictionary<string, dynamic> EnableDictionary;

		public Dictionary<string, dynamic> EnableFullAutoDictionary;
		public Dictionary<string, dynamic> EnableIrisDictionary;
		public Dictionary<string, dynamic> EnableGainDictionary;
		public Dictionary<string, dynamic> EnableAeLevelDictionary;
		public Dictionary<string, dynamic> EnableShutterDictionary;
		public Dictionary<string, dynamic> EnableWhbDictionary;
		public Dictionary<string, dynamic> EnableZoomDictionary;
		public Dictionary<string, dynamic> EnableFocusDictionary;
		public Dictionary<string, dynamic> EnableMasterBlackDictionary;
		public Dictionary<string, dynamic> EnableDetailDictionary;
		public Dictionary<string, dynamic> EnableUserDictionary;
		public Dictionary<string, dynamic> EnableStreamingDictionary;
		public Dictionary<string, dynamic> EnableDispTvDictionary;
		public Dictionary<string, dynamic> EnableCharacterMixDictionary;
		public Dictionary<string, dynamic> EnableMenuDictionary;

		public Dictionary<string, dynamic> ButtonStringDictionary;
		public Dictionary<string, dynamic> ButtonStringGainDictionary;
		public Dictionary<string, dynamic> ButtonStringUserDictionary;
		public Dictionary<string, dynamic> ButtonStringWhbDictionary;

		//		public JVCCamcoderStatus() {
		void Start() {
			EnableFullAutoDictionary = new Dictionary<string, dynamic>();
			EnableIrisDictionary = new Dictionary<string, dynamic>();
			EnableGainDictionary = new Dictionary<string, dynamic>();
			EnableAeLevelDictionary = new Dictionary<string, dynamic>();
			EnableShutterDictionary = new Dictionary<string, dynamic>();
			EnableWhbDictionary = new Dictionary<string, dynamic>();
			EnableZoomDictionary = new Dictionary<string, dynamic>();
			EnableFocusDictionary = new Dictionary<string, dynamic>();
			EnableMasterBlackDictionary = new Dictionary<string, dynamic>();
			EnableDetailDictionary = new Dictionary<string, dynamic>();
			EnableUserDictionary = new Dictionary<string, dynamic>();
			EnableStreamingDictionary = new Dictionary<string, dynamic>();
			EnableDispTvDictionary = new Dictionary<string, dynamic>();
			EnableCharacterMixDictionary = new Dictionary<string, dynamic>();
			EnableMenuDictionary = new Dictionary<string, dynamic>();
			ButtonStringDictionary = new Dictionary<string, dynamic>();
			ButtonStringGainDictionary = new Dictionary<string, dynamic>();
			ButtonStringUserDictionary = new Dictionary<string, dynamic>();
			ButtonStringWhbDictionary = new Dictionary<string, dynamic>();
			EnableDictionary = new Dictionary<string, dynamic>();
			EnableDictionary.Add("Fullauto", EnableFullAutoDictionary);
			EnableDictionary.Add("Iris", EnableIrisDictionary);
			EnableDictionary.Add("Gain", EnableGainDictionary);
			EnableDictionary.Add("AeLevel", EnableAeLevelDictionary);
			EnableDictionary.Add("Shutter", EnableShutterDictionary);
			EnableDictionary.Add("Whb", EnableWhbDictionary);
			EnableDictionary.Add("Zoom", EnableZoomDictionary);
			EnableDictionary.Add("Focus", EnableFocusDictionary);
			EnableDictionary.Add("MasterBlack", EnableMasterBlackDictionary);
			EnableDictionary.Add("Detail", EnableDetailDictionary);
			EnableDictionary.Add("User", EnableUserDictionary);
			EnableDictionary.Add("Streaming", EnableStreamingDictionary);
			EnableDictionary.Add("Disptv", EnableDispTvDictionary);
			EnableDictionary.Add("CharacterMix", EnableCharacterMixDictionary);
			EnableDictionary.Add("Menu", EnableMenuDictionary);
			ButtonStringDictionary = new Dictionary<string, dynamic>();
			ButtonStringDictionary.Add("Gain", ButtonStringGainDictionary);
			ButtonStringDictionary.Add("User", ButtonStringUserDictionary);
			ButtonStringDictionary.Add("Whb", ButtonStringWhbDictionary);
		}
		// Update is called once per frame
		void Update() {

		}
	}
	/*
	 {
	"Response": {
		"Requested": "GetCamStatus",
		"Result": "Success",
		"Data": {
			"Camera": {
				"Status": "Standby",
				"Mode": "Camera",
				"RecMode": "Normal",
				"TC": "00:00:00.00",
				"AspectRatio": "16:9",
				"WebAccess": "On",
				"MenuStatus": "Off"
			},
			"Fullauto": {
				"Status": "Off"
			},
			"Iris": {
				"Status": "Manual",
				"Value": " F2.0"
			},
			"Gain": {
				"Status": "ManualL",
				"Value": " 0dB"
			},
			"AeLevel": {
				"Status": "AeOff",
				"Adjust": "On",
				"Value": " "
			},
			"Shutter": {
				"Status": "Step",
				"Value": " 1/30 "
			},
			"Whb": {
				"Status": "B",
				"Value": "B< 4900K>",
				"WhPRScale": 64,
				"WhPBScale": 64,
				"WhPRPosition": 32,
				"WhPBPosition": 32,
				"WhPRValue": " 0",
				"WhPBValue": " 0"
			},
			"Zoom": {
				"Dynamic": "Off",
				"DynamicPos": 328,
				"Position": 75,
				"DisplayValue": " Z 22"
			},
			"Focus": {
				"Status": "AF",
				"Value": " "
			},
			"MasterBlack": {
				"Value": " -3"
			},
			"Detail": {
				"Value": " 0"
			},
			"Streaming": {
				"Status": "Stop"
			},
			"Disptv": {
				"Status": "On"
			},
			"CharacterMix": {
				"Sdi": "Off",
				"Hdmi": "Off",
				"Video": "Off"
			},
			"TallyLamp": {
				"Priority": "Camera",
				"Lighting": "Off",
				"StudioTally": "Off"
			},
			"SlotA": {
				"Status": "Select",
				"Protect": "Unlock",
				"Remain": "524",
				"ClipNum": 0,
				"RemainWarning": 0
			},
			"SlotB": {
				"Status": "NoCard",
				"Protect": "Unlock",
				"Remain": "-1",
				"ClipNum": 0,
				"RemainWarning": 0
			},
			"Battery": {
				"Info": "Time",
				"Level": "7",
				"Value": "165"
			},
			"Enable": {
				"Fullauto": {
					"Enable": 1,
					"On": 1,
					"Off": 1,
					"Preset": 1
				},
				"Iris": {
					"Enable": 1,
					"StatusDisp": 1,
					"Manual": 1,
					"Auto": 1,
					"Open1": 1,
					"Open2": 1,
					"Open3": 1,
					"Close1": 1,
					"Close2": 1,
					"Close3": 1,
					"PushAuto": 1
				},
				"Gain": {
					"Enable": 1,
					"StatusDisp": 1,
					"Manual": 1,
					"Agc": 1,
					"Lolux": 1,
					"Variable": 1,
					"L": 1,
					"M": 1,
					"H": 1,
					"Up1": 1,
					"Up2": 1,
					"Down1": 1,
					"Down2": 1
				},
				"AeLevel": {
					"Enable": 0,
					"StatusDisp": 1,
					"AeLevelUp": 0,
					"AeLevelDown": 0,
					"AdjustOn": 0,
					"AdjustOff": 0
				},
				"Shutter": {
					"Enable": 1,
					"StatusDisp": 1,
					"Off": 1,
					"Manual": 1,
					"Step": 1,
					"Variable": 1,
					"Eei": 1,
					"Slower": 1,
					"Faster": 1
				},
				"Whb": {
					"Enable": 1,
					"StatusDisp": 1,
					"Manual": 1,
					"Faw": 1,
					"Preset": 1,
					"A": 1,
					"B": 1,
					"PushAuto": 1,
					"WhPaintRP": 1,
					"WhPaintRM": 1,
					"WhPaintBP": 1,
					"WhPaintBM": 1
				},
				"Zoom": {
					"Enable": 1,
					"StatusDisp": 1,
					"Tele1": 1,
					"Tele2": 1,
					"Tele3": 1,
					"Wide1": 1,
					"Wide2": 1,
					"Wide3": 1,
					"Tele": 1,
					"Wide": 1,
					"Preset": 1,
					"Clear": 1,
					"Preset1": 1,
					"Preset2": 1,
					"Preset3": 1
				},
				"Focus": {
					"Enable": 1,
					"StatusDisp": 0,
					"Manual": 1,
					"Auto": 1,
					"Far1": 0,
					"Far2": 0,
					"Far3": 0,
					"Near1": 0,
					"Near2": 0,
					"Near3": 0,
					"Infinity": 1,
					"PushAuto": 0
				},
				"MasterBlack": {
					"Enable": 1,
					"StatusDisp": 1,
					"Up1": 1,
					"Up2": 1,
					"Up3": 1,
					"Down1": 1,
					"Down2": 1,
					"Down3": 1
				},
				"Detail": {
					"Enable": 1,
					"StatusDisp": 1,
					"Up": 1,
					"Down": 1
				},
				"User": {
					"Sw1": 1,
					"Sw2": 1,
					"Sw3": 1,
					"Sw4": 1,
					"Sw5": 1,
					"Sw6": 1,
					"Sw7": 1,
					"Sw8": 1,
					"Sw9": 1,
					"Sw10": 1,
					"Sw11": 0,
					"LensRet": 0
				},
				"Streaming": {
					"On": 0,
					"Off": 0
				},
				"Disptv": {
					"On": 1,
					"Off": 1
				},
				"CharacterMix": {
					"Sdi": 1,
					"Hdmi": 1,
					"Video": 1
				},
				"Menu": {
					"Display": 1,
					"Status": 1,
					"Menu": 1,
					"Set": 1,
					"Cancel": 1,
					"Up": 1,
					"Down": 1,
					"Left": 1,
					"Right": 1
				}
			},
			"ButtonString": {
				"Gain": {
					"L": " 0dB",
					"M": " 6dB",
					"H": "12dB"
				},
				"User": {
					"Sw1": "Focus Assist",
					"Sw2": "TC Preset",
					"Sw3": "Lolux",
					"Sw4": "Clip Review",
					"Sw5": "Zebra",
					"Sw6": "OIS",
					"Sw7": "Rec",
					"Sw8": "Expanded Focus",
					"Sw9": "AWB",
					"Sw10": "AE/FAW Lock",
					"Sw11": "nouse",
					"LensRet": "nouse"
				},
				"Whb": {
					"Preset": "PRESET",
					"A": "A",
					"B": "B"
				}
			}
		}
	}
}
	 */
}
